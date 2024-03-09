.386
data segment use16
	;sum dw 0
data ends
stack segment use16 stack
	;db 200 dup(0)
stack ends
code segment use16
	assume ds:data,ss:stack,cs:code
_main:
	;mov ax,data
	;mov ds,ax
	;mov eax,1h
	;mov ah,4ch
	;int 21h
	ret
code ends
	end _main