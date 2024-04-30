`timescale 1ns / 1ns
module Lab3_1(
    input CLK100MHZ,
    input [15:0] SW,
    output [7:0] SEG, // 7 段数码管驱动，低电平有效
    output [7:0] AN // 7 段数码管片选信号，低电平有效
);
    dynamic_scan #(100_000_00) (
        .clk(CLK100MHZ), 
        .isReverse(SW[0]),
        .isOn(SW[1]),
        .SEG(SEG), 
        .AN(AN)
        );
endmodule