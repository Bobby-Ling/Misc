#!/bin/sh
# shellcheck shell=bash

dir=/sys/kernel/debug/tracing
sysctl kernel.ftrace_enabled=1
echo function_graph > ${dir}/current_tracer
echo 1 > ${dir}/tracing_on
sleep 1
echo 0 > ${dir}/tracing_on
less ${dir}/trace

current_prog=./abcdefg
# current_prog=./write_test
$current_prog &
# 同$(pgrep -f $current_prog)
# $$本身pid $!最后运行的后台pid
current_pid=$!
echo "[$(pgrep -f ${current_prog#./})] $current_pid"