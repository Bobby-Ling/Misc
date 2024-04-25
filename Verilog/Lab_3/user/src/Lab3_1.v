`timescale 1ns / 1ns
module Lab3_1(
    input CLK100MHZ,
    output [7:0] SEG, // 7 段数码管驱动，低电平有效
    output [7:0] AN // 7 段数码管片选信号，低电平有效
);
    // divider #(100_000_000) divider_inst(
    //     .clk(CLK100MHZ),
    //     .clk_N(LED[0])
    // );

    dynamic_scan #(100_000_000) (
        .clk(CLK100MHZ), 
        .SEG(SEG), 
        .AN(AN)
        );
endmodule