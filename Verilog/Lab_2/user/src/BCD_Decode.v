`include "./_7Seg_Driver_Decoder_Selector.v"
module BCD_Decode(DIGIT, SELECT, PLACE, BCD, BCD_BIT, SELECT_BIT);
    input [3:0] DIGIT; // 待显示的数[F-0]
    input [2:0] SELECT; // 选择的数码管[7-0]
    input PLACE;    // 1为十位
    output [3:0] BCD;   //十进制的数
    output [7:0] BCD_BIT;   //数码管比特
    output [7:0] SELECT_BIT; //数码管选择比特

    assign BCD=PLACE?(DIGIT/4'd10):(DIGIT%4'd10);

    _7Seg_Driver_Decoder_Selector _7Seg_Driver_Decoder_Selector_Inst(
        .DIGIT(BCD), 
        .SELECT(SELECT),
        .DIGIT_BIT(BCD_BIT), 
        .SELECT_BIT(SELECT_BIT)
        );

endmodule