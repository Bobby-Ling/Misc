;PROG0409，文件名为hello.asm
.386
.model flat, stdcall
option casemap:none
; 说明程序中用到的库、函数原型和常量
includelib      msvcrt.lib
printf          PROTO C :ptr sbyte, :VARARG
; 数据区
.data
szMsg           byte    "Hello World! %d", 0ah, 0
szEnd           byte    "End! %d", 0ah, 0
; 代码区
.code
start:
                ;mov ah,1
                ;int 21h
                ;mov dl,0ah
                ;mov ah,2
                ;int 21h

                mov eax,9
next:   
                invoke  printf, offset szMsg, eax
                dec eax
                JNE next
                invoke  printf, offset szEnd, eax
                ret            
end             start