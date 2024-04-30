`timescale 1ns / 1ps

// module _7Seg_Driver_Display(SW, CA, CB, CC, CD, CE, CF, CG, DP, AN, LED, CLK100MHZ);


// module _7Seg_Driver_Display(SW, CA, CB, CC, CD, CE, CF, CG, DP, AN, LED, CLK100MHZ);
module _7Seg_Driver_Display(SW, SEG, AN, LED);
    input [15:0] SW; // 16 位拨动开关    
    output [7:0] SEG; // 7 段数码管驱动，低电平有效
    output [7:0] AN; // 7 段数码管片选信号，低电平有效
    output [15:0] LED; // 16 位 LED 显示，高电平有效
    //    用 SW[7:0]直接驱动 7 段数码管的 CA-CG、 DP 显示单元。
    //    用 SW[15:8]选择被驱动的 7 段数码管。
    //    用 LED[15:0]显示 SW 的状态。
    // input CLK100MHZ;
    
    wire [7:0] SEG_BIT;
    wire [7:0] AN_BIT;
    _7Seg_Driver_Decoder_Selector Decoder_Selector(
        .DIGIT(SW[3:0]), //in
        .SELECT(SW[15:13]), //in
        .DIGIT_BIT(SEG_BIT[7:0]),   //out
        .SELECT_BIT(AN_BIT[7:0])    //out
        );
    
    assign LED=SW;
    assign SEG[7:0]=SEG_BIT[7:0];
    assign AN=AN_BIT;
endmodule
/*
module _7Seg_Driver_Display(SW, CA, CB, CC, CD, CE, CF, CG, DP, AN, LED);
    input [15:0] SW; // 16 位拨动开关    
    output CA, CB, CC, CD, CE, CF, CG, DP; // 7 段数码管驱动，低电平有效
    output [7:0] AN; // 7 段数码管片选信号，低电平有效
    output [15:0] LED; // 16 位 LED 显示，高电平有效
    //    用 SW[7:0]直接驱动 7 段数码管的 CA-CG、 DP 显示单元。
    //    用 SW[15:8]选择被驱动的 7 段数码管。
    //    用 LED[15:0]显示 SW 的状态。
    // input CLK100MHZ;
    
    wire [7:0] SEG_BIT;
    wire [7:0] AN_BIT;
    _7Seg_Driver_Decoder_Selector Decoder_Selector(
        .DIGIT(SW[3:0]), //in
        .SELECT(SW[15:13]), //in
        .DIGIT_BIT(SEG_BIT[7:0]),   //out
        .SELECT_BIT(AN_BIT[7:0])    //out
        );
    
    assign LED=SW;
    assign {DP, CG, CF, CE, CD, CC, CB, CA}=SEG_BIT[7:0];
    // assign {CA, CB, CC, CD, CE, CF, CG}=SEG_BIT[7:1];
    // assign DP=SEG_BIT[0]&CLK100MHZ;
    assign AN=AN_BIT;
endmodule
*/