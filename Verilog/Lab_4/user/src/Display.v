`include "./_7Seg_Driver_Decoder_Selector.v"
module Display(clk,NUM,SEG,AN);
    parameter BITWIDTH=8;
    input clk;
    input [BITWIDTH-1:0] NUM;
    output [7:0] SEG;
    output [7:0] AN;

    reg [3:0] num=0;
    reg [2:0] sel=0;

    _7Seg_Driver_Decoder_Selector _7Seg_Driver_Decoder_Selector_Inst(
        .DIGIT(num),
        .SELECT(sel),
        .DIGIT_BIT(SEG), 
        .SELECT_BIT(AN)
    );

    always@(posedge clk)begin
        num=NUM[3:0];
        sel=0;
    end
    always@(negedge clk)begin
        num=NUM[7:4];
        sel=1;
    end
endmodule
