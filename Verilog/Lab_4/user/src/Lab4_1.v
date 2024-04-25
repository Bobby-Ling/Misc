module Lab4_1(
    input CLK100MHZ,
    input [15:0] SW,
    output [15:0] LED,
    output [7:0] SEG,
    output [7:0] AN
);

    Cal  #(
        .BITWIDTH(8),
        .N_COMPUTE(100_000_000),
        .N_DISPLAY(1000_000)) Cal_Inst(
        .clk(CLK100MHZ),
        .SW(SW),
        .LED(LED),
        .SEG(SEG),
        .AN(AN)
    );
    
endmodule //Lab4_1
