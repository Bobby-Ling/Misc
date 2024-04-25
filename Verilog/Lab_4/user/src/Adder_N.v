module Adder_N(op1,op2,out);
    parameter BITWIDTH=8;
    input [BITWIDTH-1:0] op1;
    input [BITWIDTH-1:0] op2;
    output [BITWIDTH-1:0] out;

    assign out=op1+op2;
endmodule //Adder_N
