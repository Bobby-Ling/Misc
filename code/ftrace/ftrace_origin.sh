#!/bin/bash
# shellcheck shell=bash

# 脚本开始执行的时间戳
start_time=$(date +%s.%3N)

current_user=$(whoami)
echo "The current user is: $current_user"

current_prog=./write_test
trace_path=/sys/kernel/debug/tracing
trace_output=$current_prog.ftrace.txt

# 创建命名管道
fifo=/tmp/myfifo
mkfifo "$fifo"

echo 0 > $trace_path/tracing_on
# echo nop > $trace_path/current_tracer
echo 102400 > $trace_path/buffer_size_kb

echo  > $trace_path/set_graph_function
# echo 'vfs_write vfs_open' > $trace_path/set_graph_function
# echo 'funcgraph-proc' > $trace_path/trace_options
# sed -i 's/nofunction-fork/nofunction-fork/g' $trace_path/trace_options
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

echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" '\$current_prog &'
$current_prog &
echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'current_pid=$!' ":$!"

# 同$(pgrep -f $current_prog)
# $$本身pid $!最后运行的后台pid
current_pid=$!
# echo "current_pid pid : [$(pgrep -f ${current_pid#./})]"
# cat /proc/$current_pid/status

# 删除命名管道
echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'rm "$fifo"'
rm "$fifo"
echo "current_pid is $current_pid"
echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'echo 1 > $trace_path/tracing_on'
echo  > $trace_path/set_ftrace_pid
echo 1 > $trace_path/tracing_on

wait $current_pid
# sleep 0.4s

echo 0 > $trace_path/tracing_on

echo "[$(echo "$(date +"%s.%3N") - $start_time" | bc)]" 'cat $trace_path/trace > $trace_output'

cat $trace_path/trace > $trace_output

echo "output in $trace_output"

chown bobby_ubuntu $trace_output
chgrp bobby_ubuntu $trace_output
chmod 666 $trace_output

# 一次可行的输出
# root@Bobby:/home/bobby_ubuntu/Git/code/ftrace# ./ftrace.sh 
# The current user is: root
# pid: 10247 get_pid_in_crt: 10615
# current_prog pid : []
# current_pid pid : []
# ps aux | grep 10247 :
# root       10252  0.0  0.0   4028  2176 pts/23   S+   18:45   0:00 grep 10247
# output in ./write_test.ftrace.txt
# root@Bobby:/home/bobby_ubuntu/Git/code/ftrace# ./ftrace.sh 
# The current user is: root
# current_prog pid : [10983]
# current_pid pid : []
# ps aux | grep 10983 :
# root       10983  0.0  0.0   2644  1024 pts/23   S+   18:47   0:00 ./write_test
# root       10987  0.0  0.0   4028  2176 pts/23   S+   18:47   0:00 grep 10983
# pid: 10983 get_pid_in_crt: 11353
# output in ./write_test.ftrace.txt