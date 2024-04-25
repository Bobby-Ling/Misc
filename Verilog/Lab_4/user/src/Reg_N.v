module Reg_N(clk,rst,load,D,Q);
    parameter DEBUG=0;

    parameter BITWIDTH=8;
    input clk;
    input rst;
    input load;
    input [BITWIDTH-1:0] D;
    output reg [BITWIDTH-1:0] Q=0;

    always@(posedge clk)begin
        if(rst==1)begin
            Q<=0;
        end
        else if(load==1) begin
            Q<=D;
        end

        if(DEBUG==1)
            $write("load:%b,D:%x,Q:%x\n",load,D,Q);
    end
endmodule //reg_N 
