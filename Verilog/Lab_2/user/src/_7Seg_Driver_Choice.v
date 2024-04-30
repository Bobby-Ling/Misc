`timescale 1ns / 1ps

module _7Seg_Driver_Choice(SW, SEG, AN, LED);
    input [15:0] SW; // 16 位拨动开关
    output [7:0] SEG; // 7 段数码管驱动，低电平有效
    output [7:0] AN; // 7 段数码管片选信号，低电平有效
    output [15:0] LED; // 16 位 LED 显示
    //    用 SW[3:0]输入待显示的单个数字。
    //    用 SW[15:13]选择被驱动的 7 段数码管。
    //    用 LED[15:0]显示 SW 的状态。
    
    assign LED=SW;
    
    _7Seg_Driver_Decoder_Selector Decoder_Selector(
            .DIGIT(SW[3:0]), 
            .SELECT(SW[15:13]), 
            .DIGIT_BIT(SEG[7:0]),
            .SELECT_BIT(AN[7:0])
            );
endmodule






