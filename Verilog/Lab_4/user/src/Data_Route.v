`include "./Adder_N.v"
`include "./Comp_N.v"
`include "./Mem_N.v"
`include "./Selector_N.v"
`include "./Reg_N.v"

module Data_Route(clk,rst,LOAD_SUM,LOAD_NEXT,SUM_SEL,NEXT_SEL,ADDR_SEL,next_zero,sum_value);
    parameter BITWIDTH=8;
    input clk;
    input rst;
    input LOAD_SUM;
    input LOAD_NEXT;
    input SUM_SEL;
    input NEXT_SEL;
    input ADDR_SEL;
    output next_zero;
    output [BITWIDTH-1:0] sum_value;

    wire [BITWIDTH-1:0] sum_added;
    wire [BITWIDTH-1:0] sum_sel;
    wire [BITWIDTH-1:0] sum;
    wire [BITWIDTH-1:0] data;

    wire [BITWIDTH-1:0] ZERO;
    wire [BITWIDTH-1:0] ONE;
    assign ZERO=0;
    assign ONE=1;
    assign sum_value=sum;
    
    Adder_N #(.BITWIDTH(BITWIDTH)) SUM_ADD_Inst(
        .op1(sum),
        .op2(data),
        .out(sum_added)
    );
    
    Slector_N #(.BITWIDTH(BITWIDTH)) SUM_SEL_Inst(
        .route_1(sum_added),
        .route_0(ZERO),
        .sel(SUM_SEL),
        .out(sum_sel)
    );

    Reg_N #(.BITWIDTH(BITWIDTH)) SUM_STORE_Inst(
        .clk(clk),
        .rst(rst),
        .load(LD_SUM),
        .D(sum_sel),
        .Q(sum)
    );
    
    wire [BITWIDTH-1:0] next_addr;
    wire [BITWIDTH-1:0] next;
    wire [BITWIDTH-1:0] next_added;
    wire [BITWIDTH-1:0] next_sel;
    wire [BITWIDTH-1:0] addr;

    Slector_N #(.BITWIDTH(BITWIDTH)) NEXT_SEL_Inst(
        .route_1(data),
        .route_0(ZERO),
        .sel(NEXT_SEL),
        .out(next_addr)
    );

    Comp_N #(.BITWIDTH(BITWIDTH)) IS_ZERO_Inst(
        .op1(next_addr),
        .op2(ZERO),
        .EQ(next_zero)
    );

    Reg_N #(.BITWIDTH(BITWIDTH)) NEXT_ADDR_STORE_Inst(
        .clk(clk),
        .rst(rst),
        .load(LD_NEXT),
        .D(next_addr),
        .Q(next)
    );

    Adder_N #(.BITWIDTH(BITWIDTH)) ADDR_ADD_Inst(
        .op1(next),
        .op2(ONE),
        .out(next_added)
    );

    Slector_N #(.BITWIDTH(BITWIDTH)) ADDR_SEL_Inst(
        .route_1(next_added),
        .route_0(next),
        .sel(ADDR_SEL),
        .out(addr)
    );

    Mem_N #(.DATA_WIDTH(BITWIDTH)) Mem_Inst(
        .addr(addr),
        .Data(data)
    );

endmodule //Data_Route
