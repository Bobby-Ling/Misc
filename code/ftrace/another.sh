#!/bin/bash
# shellcheck shell=bash

current_user=$(whoami)
echo "The current user is: $current_user"

current_prog=./write_test
trace_path=/sys/kernel/debug/tracing
trace_output=$current_prog.ftrace.txt


echo 1 > $trace_path/tracing_on
# echo nop > $trace_path/current_tracer

echo  > $trace_path/set_graph_function

echo ''  > $trace_path/set_ftrace_filter
echo function_graph  > $trace_path/current_tracer

$current_prog &
current_pid=$!
echo "[$(pgrep -f ${current_prog#./})] $current_pid"
echo  > $trace_path/set_ftrace_pid
echo 1 > $trace_path/tracing_on

sleep 2.1s

echo 0 > $trace_path/tracing_on

cat $trace_path/trace > $trace_output

echo "output in $trace_output"
