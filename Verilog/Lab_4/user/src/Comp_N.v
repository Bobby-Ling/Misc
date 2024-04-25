module Comp_N(op1,op2,ABOVE,EQ,BELOW);
    parameter DEBUG=0;

    parameter BITWIDTH=8;
    input [BITWIDTH-1:0] op1;
    input [BITWIDTH-1:0] op2;
    output ABOVE;
    output EQ;
    output BELOW;

    assign ABOVE=op1>op2?1:0;
    assign EQ=op1==op2?1:0;
    assign BELOW=op1<op2?1:0;

    always@(*)begin
        if(DEBUG==1)
            $write("op1:%x,op2:%x,ABOVE:%b,EQ:%b,BELOW;:%b\n",
                op1,op2,ABOVE,EQ,BELOW);
    end
endmodule //Comp_N unsigned
