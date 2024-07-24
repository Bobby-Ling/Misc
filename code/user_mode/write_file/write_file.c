#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <sys/syscall.h>
#define KiB (1024)
#define MiB ((1024)*KiB)
#define GiB ((1024)*MiB)


#define SIZE (2*4*KiB+1)
// 8192
// 1
// 4096
// 4096
// 1

// #define SIZE (2*4*KiB+1)
// 8192         8*KiB
// 1

// #define SIZE (1*MiB-1)
// 1044480      1*MiB-1*KiB
// 4095         1*KiB-1

// #define SIZE (1*GiB)
// 1073741824   1*Gib

// #define SIZE (1*GiB+2*MiB+(1*MiB-1))
// 1076883456   1*GiB+(3*MiB-1*KiB)
// 4095         1*KiB-1

// #define SIZE (1*GiB+2*MiB+3*KiB+4)
// 1075838976   1*GiB+2*MiB
// 3076         3*KiB-4

// #define SIZE __UINT32_MAX__
// __UINT32_MAX__==4294967295 4*GiB-1
// 提交                         实际
// 4294963200   4*GiB-4*KiB     2147479552(7FFFF000)   
// 2147483648   2*GiB           2147479552(7FFFF000)
// 4096         4*KiB           4096
// 4095         4*KiB-1         4096

// #define SIZE (2*GiB+1*MiB)
// #define SIZE 2148532224
// 提交                 实际
// 2148532224(80100000) 2147479552(7FFFF000)   
// 1052672(101000)      1052672(101000)

// #define SIZE 4095
// #define SIZE (4*KiB)
int main()
{
    FILE *fp = fopen("write_file.txt", "w");
    char *mem = (char *)calloc(SIZE, 1);
    memset(mem, '#', SIZE);
    fwrite(mem, 1, SIZE, fp);
    memset(mem, '1', SIZE);
    fwrite(mem, 1, SIZE, fp);
    memset(mem, '2', SIZE);
    fwrite(mem, 1, 1*MiB, fp);
    //ff000 
    //1000 000
    fflush(fp);
    // syscall(449);
    fclose(fp);
    return 0;
}