`timescale 1ns / 1ps
`include "../src/Cal.v"
module Lab4_1_tb;
    parameter clk_period = 10;//T=10ns  

    reg clk;  
    initial  begin
        clk = 0;  
        forever
            #(clk_period/2) clk = ~clk;  
    end
    wire CLK100MHZ;
    assign CLK100MHZ=clk;


    parameter BITWIDTH=8;
    wire [15:0] SW;
    wire [15:0] LED;
    wire [7:0] SEG;
    wire [7:0] AN;
    wire [BITWIDTH-1:0] sum_value;

    assign SW=16'h0001;//start

    Cal  #(.BITWIDTH(8),.N_COMPUTE(2),.N_DISPLAY(10)) Cal_Inst(
        .clk(CLK100MHZ),
        .SW(SW),
        .LED(LED),
        .SEG(SEG),
        .AN(AN),
        .sum_value(sum_value)
    );


    integer i;
    initial begin
        $display($time);
        
        for (i=1; i < 2000; i=i+1)
        begin
            #5
            $display("i:%d, clk:%b, SEG:%b AN:%b sum_value:%d DONE:%b", 
                i,clk,SEG,AN,sum_value,LED[0]);
        end
        $display($time);
    end
endmodule
