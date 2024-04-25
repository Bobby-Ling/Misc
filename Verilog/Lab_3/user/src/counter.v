module counter(clk, out);
    input clk; // 计数时钟
    output reg[2:0] out=0; // 计数值
    always @(posedge clk) begin // 在时钟上升沿计数器加 1
        out=out+1;
    end
endmodule