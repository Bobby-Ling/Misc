module decoder3_8(num, sel);
    input [2: 0] num; // ����ܱ�ţ� 0~7
    output reg [7:0] sel=0; // 7 �������Ƭѡ�źţ��͵�ƽ��Ч

    always @(*) begin
        sel=~(1<<num);        
    end
endmodule
