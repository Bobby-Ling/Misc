;PROG0409���ļ���Ϊhello.asm
.386
.model flat, stdcall
option casemap:none
; ˵���������õ��Ŀ⡢����ԭ�ͺͳ���
includelib      msvcrt.lib
printf          PROTO C :ptr sbyte, :VARARG
; ������
.data
szMsg           byte    "Hello World! %d", 0ah, 0
szEnd           byte    "End! %d", 0ah, 0
; ������
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