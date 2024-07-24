#!/bin/bash
# shellcheck shell=bash

# 创建命名管道
fifo=/tmp/myfifo
mkfifo "$fifo"

# prog=./write_test
prog=./out.sh
# 启动程序并将其输出重定向到命名管道
$prog > "$fifo" &
# $!最后一个运行的后台任务pid
pid=$! 

# 从命名管道中读取
output=""
read -r output < "$fifo"

pid_in_crt=0
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
echo $pid_in_crt
echo $pid
# 删除命名管道
rm "$fifo"

# 等待程序在后台运行完毕
wait $pid