module Slector_N(route_1,route_0,sel,out);
    parameter BITWIDTH=8;
    parameter DEBUG=0;

    input [BITWIDTH-1:0] route_1;
    input [BITWIDTH-1:0] route_0;
    input sel;
    output [BITWIDTH-1:0] out;
    
    assign out=sel?route_1:route_0;

    always@(*)begin
        if(DEBUG==1)
            $display("route_1:%b,route_0:%b,sel:%b,out:%b\n", route_1,route_0,sel,out);
    end
endmodule //Slector_N
