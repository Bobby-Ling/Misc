#!/bin/bash
# shellcheck shell=bash source=./ftrace_official.sh source-path=SCRIPTDIR
# directives 需要shellsheck -x选项

# 脚本开始执行的时间戳
start_time=$(date +%s.%3N)
echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" "start"

current_user=$(whoami)
echo "The current user is: $current_user"

current_prog=write_test
trace_path=/sys/kernel/debug/tracing
trace_output=$current_prog.ftrace.txt

# 创建命名管道
fifo=/tmp/myfifo
mkfifo "$fifo"

source ./ftrace_official.sh
pushd /sys/kernel/debug/tracing
initialize_ftrace
popd
# echo 0 > $trace_path/tracing_on
# 确保初始为空
cat $trace_path/trace >./initial.txt
# echo nop > $trace_path/current_tracer

# ftrace选项
echo 102400 >$trace_path/buffer_size_kb
# set_graph_function是指定从何处开始, 可用列表在available_filter_functions中
# echo  > $trace_path/set_graph_function
# 没有vfs_close?
# echo '__ia32_sys_get_pid_in_crt' > $trace_path/set_graph_function # for kernel 4.19
echo '__do_sys_get_pid_in_crt' >$trace_path/set_graph_function # for kernel 5.x +
echo '__x64_sys_open ksys_read ksys_write ksys_sync __x64_sys_fsync __x64_sys_close' >>$trace_path/set_graph_function
echo 'vfs_open vfs_read vfs_write vfs_fsync ' >>$trace_path/set_graph_function
echo -e "set_graph_function: \n$(cat $trace_path/set_graph_function)" # -e启用转义字符
# 从输出中过滤掉指定函数, 可用列表在available_filter_functions中
# 支持glob模式匹配: '<match>*'' '*<match>'' '*<match>*'' '<match1>*<match2>''
# static函数无法观测
echo '__rcu_read_lock __rcu_read_unlock' >$trace_path/set_ftrace_notrace # may don't work on kernel 4.19
echo '_raw_spin_lock _raw_spin_unlock' >>$trace_path/set_ftrace_notrace  # 注意是>>
echo '_raw_spin_lock_irq _raw_spin_unlock_irq' >>$trace_path/set_ftrace_notrace
echo 'preempt_count_add preempt_count_sub' >>$trace_path/set_ftrace_notrace
echo -e "set_ftrace_notrace: \n$(cat $trace_path/set_ftrace_notrace)" # -e启用转义字符

# funcgraph-proc用于在使用graph_function时像function一样显示前面的TASK/PID e.g.:
# tracer: function_graph
# CPU  TASK/PID         DURATION                  FUNCTION CALLS
# |     |    |           |   |                     |   |   |   |
#  11)  tokio-r-3604  => write_t-432575
#  ------------------------------------------
#  11) write_t-432575 |               |  vfs_open() {

# 设置trace_options文件等价于直接在options目录(包含所有选项)中设置对应的选项文件为1/0
# e.g.:
# echo funcgraph-proc > $trace_path/trace_options 和下面的等价
echo 1 >$trace_path/options/funcgraph-proc

echo 1 >$trace_path/options/funcgraph-tail
echo 1 >$trace_path/options/function-fork

# event tracing
# echo 1 > $trace_path/events/syscalls/sys_enter_write/enable
# echo sys_enter_write >> $trace_path/set_event
# echo 1 > /sys/kernel/tracing/events/enable
# echo *:* > $trace_path/set_event
# 启用所有syscalls event
# echo 1 > /sys/kernel/tracing/events/syscalls/enable
# 启用所有event
# echo 1 > /sys/kernel/tracing/events/enable

# cat /sys/kernel/debug/tracing/available_tracers
# echo function  > $trace_path/current_tracer
echo function_graph >$trace_path/current_tracer

echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" './$current_prog > "$fifo" &'
# 启动程序并将其输出重定向到命名管道
# 单引号避免expand
./$current_prog >"$fifo" &
echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'current_pid=$!' ":$!"
# $$本身pid $!最后运行的后台pid
current_pid=$!
# 从命名管道中读取
output=""
read -r output <"$fifo"
# 删除命名管道
echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'rm "$fifo"'
rm "$fifo"
pid_in_crt=$(
    echo $output | awk '
    {
        # 匹配形如 "pid: %d get_pid_in_crt: %ld\n"
        if ($0 ~ /pid: [0-9]+ get_pid_in_crt: [0-9]+/) {
            # 将()内匹配的提取至arr
            match($0, /pid: ([0-9]+) get_pid_in_crt: ([0-9]+)/, arr)
            pid_in_crt = arr[2]
            print pid_in_crt
        }
    }'
)
# current_pid=$(
#     echo $output | awk '
#     {
#         # 匹配形如 "pid: %d get_pid_in_crt: %ld\n"
#         if ($0 ~ /pid: [0-9]+ get_pid_in_crt: [0-9]+/) {
#             # 将()内匹配的提取至arr
#             match($0, /pid: ([0-9]+) get_pid_in_crt: ([0-9]+)/, arr)
#             current_pid = arr[1]
#             print current_pid
#         }
#     }'
# )
echo "current_pid is $current_pid"
echo "pid_in_crt is: $pid_in_crt"

# 这里非常奇怪, 在function中无输出, graph_function中正常过滤(current->pid)
# echo $current_pid > $trace_path/set_ftrace_pid
echo $pid_in_crt >$trace_path/set_ftrace_pid
# echo  > $trace_path/set_ftrace_pid
echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'echo 1 > $trace_path/tracing_on'
echo 1 >$trace_path/tracing_on

wait $current_pid
# sleep 1s

echo 0 >$trace_path/tracing_on

echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'output to file'

cat $trace_path/trace | awk '{
    if($0 ~ /(#.*$)|^[^#].+\|.+\|  (.+$)/) {
        match($0, /(#.*$)|^[^#].+\|.+\|  (.+$)/, arr)
        print arr[1]""arr[2]
    }
}' >$trace_output

# head -12 $trace_path/trace >$trace_output
# rg ".*$current_prog-$pid_in_crt.*|^#.*" $trace_path/trace > $trace_output

echo "output in $trace_output"

chown bobby_ubuntu $trace_output
chgrp bobby_ubuntu $trace_output
chmod 666 $trace_output
