#!/bin/bash
# shellcheck shell=bash

current_user=$(whoami)
echo "The current user is: $current_user"

current_prog=./write_test
trace_output=$current_prog.trace
trace_path=/sys/kernel/debug/tracing

# 列出可用的追踪器
# trace-cmd list -t
# -p指定 plugin

# 查看可被追踪的函数
# trace-cmd list -f

# 对ftrace的设置和ring buffer复位。
trace-cmd reset


$current_prog &
# 同$(pgrep -f $current_prog)
# $$本身pid $!最后运行的后台pid
current_pid=$!
echo "[$(pgrep -f ${current_prog#./})] $current_pid"
cat /proc/$current_pid/status
# 追踪和不追踪特定函数
# trace-cmd set -p function_graph
# trace-cmd set -l vfs_read -l vfs_write -l vfs_open -l vfs_fsync
# trace-cmd set -n rcu_idle_exit
# cat $trace_path/current_tracer
# cat $trace_path/set_ftrace_filter
# cat $trace_path/set_ftrace_pid
trace-cmd record -o $trace_output.dat \
    -p function_graph \
    -l vfs_write \
    & 
    # -l vfs_read \
    # -l vfs_open \
    # -l vfs_fsync \

trace_cmd_pid=$!

sleep 10s

kill -SIGINT $trace_cmd_pid
wait $trace_cmd_pid     

trace-cmd report -i $trace_output.dat > $trace_output.txt

echo "output in $trace_output"
