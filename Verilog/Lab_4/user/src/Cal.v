`include "./FSM.v"
`include "./Data_Route.v"
`include "./Display.v"
`include "./divider.v"

module Cal(clk,SW,LED,SEG,AN,sum_value);
    parameter   BITWIDTH=8,
                N_COMPUTE=100_000_000,//慢的时钟用来计算,1HZ
                N_DISPLAY=1000_000;//快的时钟用来显示,100HZ

    input clk;
    input [15:0] SW;
    output [15:0] LED;
    output [7:0] SEG;
    output [7:0] AN;
    output [BITWIDTH-1:0] sum_value;


    wire clk_COMPUTE;
    wire clk_DISPLAY;
    divider #(N_COMPUTE) divider_compute_inst(
        .clk(clk),
        .clk_N(clk_COMPUTE)
    );
    divider #(N_DISPLAY) divider_display_inst(
        .clk(clk),
        .clk_N(clk_DISPLAY)
    );

    
    wire reset;
    wire start;
    assign reset=SW[1];
    assign start=SW[0];

    wire LOAD_SUM;
    wire LOAD_NEXT;
    wire SUM_SEL;
    wire NEXT_SEL;
    wire ADDR_SEL;
    wire DONE;
    wire next_zero;
    // wire sum_value;

    
    Data_Route #(.BITWIDTH(BITWIDTH)) Data_Route_Inst(
        .clk(clk_COMPUTE),
        .rst(reset),
        .LOAD_SUM(LOAD_SUM),
        .LOAD_NEXT(LOAD_NEXT),
        .SUM_SEL(SUM_SEL),
        .NEXT_SEL(NEXT_SEL),
        .ADDR_SEL(ADDR_SEL),
        .next_zero(next_zero),
        .sum_value(sum_value)
        );
    FSM FSM_Inst(
        .clk(clk_COMPUTE),
        .rst(reset),
        .start(start),
        .next_zero(next_zero),
        .LOAD_SUM(LOAD_SUM),
        .LOAD_NEXT(LOAD_NEXT),
        .SUM_SEL(SUM_SEL),
        .NEXT_SEL(NEXT_SEL),
        .ADDR_SEL(ADDR_SEL),
        .DONE(DONE)
    );

    Display #(.BITWIDTH(BITWIDTH)) DIsplay_Inst(
        .clk(clk_DISPLAY),
        .NUM(sum_value),
        .SEG(SEG),
        .AN(AN)
    );

    assign LED={15'b0,DONE};
    assign AN=8'b11111110;
    // assign SEG
endmodule //Cal
