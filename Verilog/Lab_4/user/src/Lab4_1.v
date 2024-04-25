module Lab4_1(
    input CLK100MHZ,
    input [15:0] SW,
    output [15:0] LED,
    output [7:0] SEG,
    output [7:0] AN
);

    Cal  #(.BITWIDTH(8)) Cal_Inst(
        .CLK100MHZ(CLK100MHZ),
        .SW(SW),
        .LED(LED),
        .SEG(SEG),
        .AN(AN)
    );
    
endmodule //Lab4_1
