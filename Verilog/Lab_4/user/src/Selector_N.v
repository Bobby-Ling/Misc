module Slector_N(route_1,route_0,sel,out);
    parameter BITWIDTH=8;
    input [BITWIDTH-1:0] route_1;
    input [BITWIDTH-1:0] route_0;
    input sel;
    output [BITWIDTH-1:0] out;
    
    assign out=(route_1&sel)|(route_0&(~sel));
endmodule //Slector_N
