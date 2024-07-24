#!/bin/bash

# 实时读取 dmesg 日志
# echo | awk '{ print (abc ~ /^\/dev.+|pipe.+|anon_inode.+|$/ )?1:0 }'
# abc没有定义, 因此为空, 可以被/^$/匹配
dmesg -w | awk '
{
    # 匹配形如 “ksys_write called by %d: fd = %u, buf = %p, count = %zu, tgid = %d, pid = %d” 的行
    if ($0 ~ /ksys_write called by [0-9]+: fd = [0-9]+, buf = [0-9a-fx]+, count = [0-9]+, tgid = [0-9]+, pid = [0-9]+/) {
        # 将()内匹配的提取PID和FD至arr
        match($0, /fd = ([0-9]+), buf = [0-9a-fx]+, count = [0-9]+, tgid = ([0-9]+)/, arr)
        fd = arr[1]
        pid = arr[2]
        
        # 获取进程名称, 注意, awk使用""进行拼接(没有空格)
        comm_file = "/proc/" pid "/comm"
        comm = "N/A"
        if ((getline line < comm_file) > 0) {
            comm = line
        }
        close(comm_file)

        # 获取文件名
        fd_file = "/proc/" pid "/fd/" fd
        cmd = "sudo readlink " fd_file
        cmd | getline filename
        close(cmd)
        
        # sudo readlink /proc/28006/fd/9
        # /home/bobby_ubuntu/Git/code/user_mode/pid/to_be_write8-pid-28006-fd-18.txt
        
        # 使用正则表达式过滤文件名(含空文件名)
        if (filename ~ /^\/dev.+|pipe.+|anon_inode.+|$/) {
            # print "filtered: " filename
            if (filename ~ /^$/ ) {
                # print "空文件名",filename
            }
            next
        }

        # 输出结果
        print "PID: " pid "\t, Process Name: " comm ", FD: " fd "\t, Filename: " filename
    }
}'
