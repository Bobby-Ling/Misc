module Comp_N(op1,op2,ABOVE,EQ,BELOW);
    parameter BITWIDTH=8;
    input [BITWIDTH-1:0] op1;
    input [BITWIDTH-1:0] op2;
    output ABOVE;
    output EQ;
    output BELOW;

    assign ABOVE=op1>op2?1:0;
    assign EQ=op1==op2?1:0;
    assign BELOW=op1<op2?1:0;
endmodule //Comp_N unsigned
