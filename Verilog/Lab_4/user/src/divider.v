module divider(clk, clk_N);
    input clk; // ϵͳʱ��, 100MHZ,10ns
    output reg clk_N=0; // ��Ƶ���ʱ��

    parameter N = 100_000_000; // 1Hz ��ʱ��,N=fclk/fclk_N
    reg [31:0] counter=0; /* ����������, ͨ������ʵ�ַ�Ƶ. 
                        ���������� 0 ������(N/2-1)ʱ, 
                        ���ʱ�ӷ�ת, ���������� */

    always @(posedge clk) begin // ʱ��������
        counter=1+counter;
        if(counter==(N/2+1)) begin
            clk_N=~clk_N;
            counter=0;
        end

        // _-_-_-_-_-_-_-_-_-_-_-_-_-_- clk
        // _--__--__--__-               clk_2 2
        // _----____----_               clk_4 3
        // _--------________            clk_8 5
        // _----------------________... clk_16 9
    end
endmodule