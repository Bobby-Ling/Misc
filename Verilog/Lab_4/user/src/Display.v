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
        case(sel)
            3'b000:
                begin
                    sel=3'b001;
                    num=NUM[7:4];
                end
            3'b001:
                begin
                    sel=3'b000;
                    num=NUM[3:0];
                end
        endcase
    end
endmodule
