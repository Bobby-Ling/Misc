module counter(clk, isReverse, isOn, out);
    input clk; // ����ʱ��
    input isReverse;
    input isOn;
    output reg[2:0] out=0; // ����ֵ
    always @(posedge clk) begin // ��ʱ�������ؼ������� 1
        if(isOn==1'b1)begin
            if(isReverse==1)begin
                out=out-1;
            end
            else begin
                out=out+1;
            end
        end
        else begin
            out=out;
        end
    end
endmodule