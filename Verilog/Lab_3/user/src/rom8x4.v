module rom8x4(addr, data);
    input [2:0] addr; // ��ַ
    output reg [3:0] data; // ��ַ addr ���洢������

    reg [3: 0] mem [7: 0]; // 8 �� 4 λ�Ĵ洢��

    initial begin // ��ʼ���洢��
    // ��Ŵ���ʾ���� 0�� 2�� 4�� 6�� 8�� A�� C�� E �� 4 λ�����Ʊ���
        mem[0]=4'h0;
        mem[1]=4'h2;
        mem[2]=4'h4;
        mem[3]=4'h6;
        mem[4]=4'h8;
        mem[5]=4'ha;
        mem[6]=4'hc;
        mem[7]=4'he;
    end
    // ��ȡ addr ��Ԫ��ֵ���
    always@(*) begin
        data=mem[addr];
    end

endmodule
