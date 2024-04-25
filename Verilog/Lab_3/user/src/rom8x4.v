module rom8x4(addr, data);
    input [2:0] addr; // 地址
    output reg [3:0] data; // 地址 addr 处存储的数据

    reg [3: 0] mem [7: 0]; // 8 个 4 位的存储器

    initial begin // 初始化存储器
    // 存放待显示数字 0、 2、 4、 6、 8、 A、 C、 E 的 4 位二进制编码
        mem[0]=4'h0;
        mem[1]=4'h2;
        mem[2]=4'h4;
        mem[3]=4'h6;
        mem[4]=4'h8;
        mem[5]=4'ha;
        mem[6]=4'hc;
        mem[7]=4'he;
    end
    // 读取 addr 单元的值输出
    always@(*) begin
        data=mem[addr];
    end

endmodule
