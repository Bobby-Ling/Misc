module divider(clk, clk_N);
    input clk; // 系统时钟, 100MHZ,10ns
    output reg clk_N=0; // 分频后的时钟

    parameter N = 100_000_000; // 1Hz 的时钟,N=fclk/fclk_N
    reg [31:0] counter=0; /* 计数器变量, 通过计数实现分频. 
                        当计数器从 0 计数到(N/2-1)时, 
                        输出时钟翻转, 计数器清零 */

    always @(posedge clk) begin // 时钟上升沿
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