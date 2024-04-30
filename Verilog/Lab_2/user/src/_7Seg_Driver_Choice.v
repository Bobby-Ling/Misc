`timescale 1ns / 1ps

module _7Seg_Driver_Choice(SW, SEG, AN, LED);
    input [15:0] SW; // 16 λ��������
    output [7:0] SEG; // 7 ��������������͵�ƽ��Ч
    output [7:0] AN; // 7 �������Ƭѡ�źţ��͵�ƽ��Ч
    output [15:0] LED; // 16 λ LED ��ʾ
    //    �� SW[3:0]�������ʾ�ĵ������֡�
    //    �� SW[15:13]ѡ�������� 7 ������ܡ�
    //    �� LED[15:0]��ʾ SW ��״̬��
    
    assign LED=SW;
    
    _7Seg_Driver_Decoder_Selector Decoder_Selector(
            .DIGIT(SW[3:0]), 
            .SELECT(SW[15:13]), 
            .DIGIT_BIT(SEG[7:0]),
            .SELECT_BIT(AN[7:0])
            );
endmodule






