`include "../src/counter.v"
`include "../src/divider.v"
`include "../src/rom8x4.v"
`include "../src/pattern.v"
`include "../src/decoder3_8.v"

module dynamic_scan(clk, isReverse, isOn, SEG, AN);
    input clk; // ϵͳʱ��
    input isReverse;
    input isOn;
    output reg [7:0] SEG; // �ֱ��Ӧ CA�� CB�� CC�� CD�� CE�� CF�� CG �� DP
    output reg [7:0] AN; // 8 λ�����Ƭѡ�ź�
    parameter N = 100_000_000;

    wire clk_N;
    divider #(N) divider_inst(
        .clk(clk),
        .clk_N(clk_N)
    );

    wire [2:0] count;
    counter counter_inst(
        .clk(clk_N),
        .isReverse(isReverse),
        .isOn(isOn),
        .out(count)
    );

    wire [3:0] read_out;
    rom8x4 rom8x4_inst(
        .addr(count),
        .data(read_out)
    );

    wire [7:0] select;
    decoder3_8 decoder3_8_inst(
        .num(count),
        .sel(select)
    );

    wire [7:0] display;
    pattern pattern_inst(
        .code(read_out),
        .patt(display)
    );

    always @(*) begin
        AN<=select;
        SEG<=display;
    end
endmodule