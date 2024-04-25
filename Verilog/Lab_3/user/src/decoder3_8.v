module decoder3_8(num, sel);
    input [2: 0] num; // 数码管编号： 0~7
    output reg [7:0] sel=0; // 7 段数码管片选信号，低电平有效

    always @(*) begin
        sel=~(1<<num);        
    end
endmodule
