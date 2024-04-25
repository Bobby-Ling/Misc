module _7Seg_Driver_Decoder_Selector(DIGIT, SELECT, DIGIT_BIT, SELECT_BIT);
    input [3:0] DIGIT; // 待显示的数[F-0]
    input [2:0] SELECT; // 选择的数码管[7-0]
    output reg [7:0] DIGIT_BIT; // 数码管显示bit流, 低电平有效
    output reg [7:0] SELECT_BIT; // 直接控制选择的数码管, 低电平有效
    
    always@(*) begin        
        case(DIGIT[3:0])
            4'b0000:		DIGIT_BIT[7:0]=8'b11000000;
            4'b0001:		DIGIT_BIT[7:0]=8'b11111001;
            4'b0010:		DIGIT_BIT[7:0]=8'b10100100;
            4'b0011:		DIGIT_BIT[7:0]=8'b10110000;
            4'b0100:		DIGIT_BIT[7:0]=8'b10011001;
            4'b0101:		DIGIT_BIT[7:0]=8'b10010010;
            4'b0110:		DIGIT_BIT[7:0]=8'b10000010;
            4'b0111:		DIGIT_BIT[7:0]=8'b11111000;
            4'b1000:		DIGIT_BIT[7:0]=8'b10000000;
            4'b1001:		DIGIT_BIT[7:0]=8'b10011000;
            4'b1010:		DIGIT_BIT[7:0]=8'b10001000;
            4'b1011:		DIGIT_BIT[7:0]=8'b10000011;
            4'b1100:		DIGIT_BIT[7:0]=8'b11000110;
            4'b1101:		DIGIT_BIT[7:0]=8'b10100001;
            4'b1110:		DIGIT_BIT[7:0]=8'b10000110;
            4'b1111:		DIGIT_BIT[7:0]=8'b10001110;
            default:        DIGIT_BIT[7:0]=8'b00000000;
        endcase
        
        SELECT_BIT=~(1<<SELECT);
    end    
endmodule