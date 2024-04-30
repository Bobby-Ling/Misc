`timescale 1ns / 1ps

module _7Seg_Driver_Direct(SW, SEG, AN, LED);
    input [15:0] SW; // 16 λ��������    
    output [7:0] SEG; // 7 ��������������͵�ƽ��Ч
    output [7:0] AN; // 7 �������Ƭѡ�źţ��͵�ƽ��Ч
    output [15:0] LED; // 16 λ LED ��ʾ���ߵ�ƽ��Ч
    //    �� SW[7:0]ֱ������ 7 ������ܵ� CA-CG�� DP ��ʾ��Ԫ��
    //    �� SW[15:8]ѡ�������� 7 ������ܡ�
    //    �� LED[15:0]��ʾ SW ��״̬��
    
    assign LED=SW;
    assign SEG[7:0]=~SW[7:0];
    assign AN=~SW[15:8];
endmodule

/*
module _7Seg_Driver_Direct(SW, CA, CB, CC, CD, CE, CF, CG, DP, AN, LED);
    input [15:0] SW; // 16 λ��������    
    output CA, CB, CC, CD, CE, CF, CG, DP; // 7 ��������������͵�ƽ��Ч
    output [7:0] AN; // 7 �������Ƭѡ�źţ��͵�ƽ��Ч
    output [15:0] LED; // 16 λ LED ��ʾ���ߵ�ƽ��Ч
    //    �� SW[7:0]ֱ������ 7 ������ܵ� CA-CG�� DP ��ʾ��Ԫ��
    //    �� SW[15:8]ѡ�������� 7 ������ܡ�
    //    �� LED[15:0]��ʾ SW ��״̬��
    
    assign LED=SW;
    assign {DP, CG, CF, CE, CD, CC, CB, CA}=~SW[7:0];
    assign AN=~SW[15:8];
endmodule
*/
