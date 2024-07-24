#!/bin/bash
# shellcheck shell=bash

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

echo 0 > $trace_path/tracing_on
# echo nop > $trace_path/current_tracer
echo 102400 > $trace_path/buffer_size_kb

# ftrace选项
# echo  > $trace_path/set_graph_function
# echo 'vfs_write vfs_open' > $trace_path/set_graph_function
# echo 'funcgraph-proc' > $trace_path/trace_options
# sed -i 's/nofunction-fork/function-fork/g' $trace_path/trace_options
echo function-fork > $trace_path/trace_options
# echo 1 > $trace_path/options/funcgraph-proc
# echo 1 > $trace_path/options/funcgraph-tail
echo ''  > $trace_path/set_ftrace_filter

# echo 1 > $trace_path/events/syscalls/sys_enter_write/enable 
# echo sys_enter_write >> $trace_path/set_event
# echo 1 > /sys/kernel/tracing/events/enable
# echo *:* > $trace_path/set_event
# 启用所有syscalls event
# echo 1 > /sys/kernel/tracing/events/syscalls/enable
# 启用所有event
# echo 1 > /sys/kernel/tracing/events/enable

# cat /sys/kernel/debug/tracing/available_tracers        
echo function  > $trace_path/current_tracer
# echo function_graph  > $trace_path/current_tracer

echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" './$current_prog > "$fifo" &'
# 启动程序并将其输出重定向到命名管道
# 单引号避免expand
./$current_prog > "$fifo" &
echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'current_pid=$!' ":$!"
# $$本身pid $!最后运行的后台pid
current_pid=$! 
# 从命名管道中读取
output=""
read -r output < "$fifo"
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

# 这里非常奇怪
# echo $current_pid > $trace_path/set_ftrace_pid
# echo $pid_in_crt > $trace_path/set_ftrace_pid
echo  > $trace_path/set_ftrace_pid
echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'echo 1 > $trace_path/tracing_on'
echo 1 > $trace_path/tracing_on

wait $current_pid
# sleep 1s

echo 0 > $trace_path/tracing_on

echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'output to file'

# cat $trace_path/trace > $trace_output
# head -12 $trace_path/trace >$trace_output
rg ".*$current_prog-$pid_in_crt.*|^#.*" $trace_path/trace > $trace_output

echo "output in $trace_output"

chown bobby_ubuntu $trace_output
chgrp bobby_ubuntu $trace_output
chmod 666 $trace_output
