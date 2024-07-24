#define _GNU_SOURCE // for O_DIRECT
#include <fcntl.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <unistd.h>

#define KiB (1024)
#define MiB ((1024) * KiB)
#define GiB ((1024) * MiB)

// #define SIZE (2 * 4 * KiB + 1)
#define SIZE (4 * KiB)

int main(void)
{
    // printf("pid: %d  ppid: %d\n",getpid(),getppid());
    char str[100] = { 0 };
    sprintf(str, "pid: %d get_pid_in_crt: %ld\n", getpid(), syscall(454));
    printf("%s", str);
    fflush(stdout);
    /*
    读管道:
    1.管道中有数据, read返回实际读到的字节数.
    2.管道中无数据: 管道写端被全部关闭, read返回0(好像读到文件结尾); 写端没有全部被关闭, read阻塞等待(不久的将来可能有数据递达, 此时会让出cpu).
    写管道:
    1.管道读端全部被关闭, 进程异常终止(也可使用捕捉SIGPIPE信号, 使进程不终止).
    2. 管道读端没有全部关闭: 管道已满, write阻塞; 管道未满, write将数据写入, 并返回实际写入的字节数.

    因此read -r output < "$fifo"时, 要手动fflush保证printf写入管道!!!

    */
    usleep(1000 * 100); // 100ms might be not enough
    /*
    大坑!!! 这里11353是current->pid
    pid: 10983 get_pid_in_crt: 11353
    output in ./write_test.ftrace.txt
    write_test-11353   [000] ...1.  1087.353609: x64_sys_call <-do_syscall_64
    write_test-11353   [000] ...1.  1087.353609: __do_sys_get_pid_in_crt <-x64_sys_call
    此处在4.19 5.15 6.6中测试过

    但是QEMU内, 如下:
    current_pid is 883
    pid_in_crt is: 883
    诡异的是, 此时trace内PID为: 859


    in kernel/trace/ftrace.c
    static void ftrace_pid_func(unsigned long ip, unsigned long parent_ip,
                            struct ftrace_ops *op, struct ftrace_regs *fregs)
    {
        struct trace_array *tr = op->private;
        int pid;

        if (tr) {
            pid = this_cpu_read(tr->array_buffer.data->ftrace_ignore_pid);
            if (pid == FTRACE_PID_IGNORE)
                return;
            if (pid != FTRACE_PID_TRACE &&
                pid != current->pid)
                return;
        }

        op->saved_func(ip, parent_ip, op, fregs);
    }
    */

    /*
    get_pid_in_crt|ksys_write|sys_open|sys_close
    */

    char* mem = (char*)calloc(SIZE, 1);
    syscall(454); // 1
    int fd = open("example.txt", O_WRONLY | O_CREAT | O_TRUNC, 0644);
    syscall(454); // 2
    memset(mem, '#', SIZE);
    write(fd, mem, SIZE);
    fsync(fd);
    close(fd);
    syscall(454); // 3

    // O_SYNC write时立即写盘
    fd = open("example.txt", O_WRONLY | O_SYNC, 0644);
    memset(mem, '1', SIZE);
    write(fd, mem, SIZE);
    close(fd);
    syscall(454); // 4

    // O_DIRECT Direct IO Access; need #define _GNU_SOURCE
    fd = open("example.txt", O_WRONLY | O_SYNC | O_DIRECT, 0644);
    memset(mem, '1', SIZE);
    write(fd, mem, SIZE);
    close(fd);
    syscall(454); // 5

    // memset(mem, '2', SIZE);
    // write(fd, mem, SIZE);
    // write(fd, str, strlen(str));
    // close(fd);
    // syscall(454); // 6

    return 0;
}

/*
    printf("File Name: %ld\n", file_info.st_size);
    if (fd == -1) {
        perror("open");
        return 1;
    }
    if (bytes_written == -1) {
        perror("write");
        close(fd);
        return 1;
    }
    struct stat file_info;
    if (fstat(fd, &file_info) == -1) {
        perror("fstat");
        exit(EXIT_FAILURE);
    }
*/