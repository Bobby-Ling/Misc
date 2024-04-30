`timescale 1ns / 1ps

module _7Seg_Driver_Direct(SW, SEG, AN, LED);
    input [15:0] SW; // 16 位拨动开关    
    output [7:0] SEG; // 7 段数码管驱动，低电平有效
    output [7:0] AN; // 7 段数码管片选信号，低电平有效
    output [15:0] LED; // 16 位 LED 显示，高电平有效
    //    用 SW[7:0]直接驱动 7 段数码管的 CA-CG、 DP 显示单元。
    //    用 SW[15:8]选择被驱动的 7 段数码管。
    //    用 LED[15:0]显示 SW 的状态。
    
    assign LED=SW;
    assign SEG[7:0]=~SW[7:0];
    assign AN=~SW[15:8];
endmodule

/*
module _7Seg_Driver_Direct(SW, CA, CB, CC, CD, CE, CF, CG, DP, AN, LED);
    input [15:0] SW; // 16 位拨动开关    
    output CA, CB, CC, CD, CE, CF, CG, DP; // 7 段数码管驱动，低电平有效
    output [7:0] AN; // 7 段数码管片选信号，低电平有效
    output [15:0] LED; // 16 位 LED 显示，高电平有效
    //    用 SW[7:0]直接驱动 7 段数码管的 CA-CG、 DP 显示单元。
    //    用 SW[15:8]选择被驱动的 7 段数码管。
    //    用 LED[15:0]显示 SW 的状态。
    
    assign LED=SW;
    assign {DP, CG, CF, CE, CD, CC, CB, CA}=~SW[7:0];
    assign AN=~SW[15:8];
endmodule
*/
