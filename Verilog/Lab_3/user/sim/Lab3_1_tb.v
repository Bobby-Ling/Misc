`timescale 1ns / 1ps

module Lab3_1_tb;
    parameter clk_period = 10;//T=10ns  

    reg clk;  
    initial  begin
        clk = 0;  
        forever
            #(clk_period/2) clk = ~clk;  
    end


    wire CLK100MHZ;
    
    assign CLK100MHZ=clk;
    wire clk_N_out;
    divider #(2) divider_inst(
        .clk(clk),
        .clk_N(clk_N_out)
    );

    wire [7:0] SEG;
    wire [7:0] AN;
    dynamic_scan #(2) dynamic_scan_inst(
        .clk(clk),
        .SEG(SEG),
        .AN(AN)
    );

    integer i;

    initial begin
        $display($time);
        for (i=1; i < 200; i=i+1)
        begin
            #5
            $display("i:%d, clk:%b, clk_N_out:%b, SEG:%b AN:%b", i,clk,clk_N_out,SEG,AN);
            // $display("i:%d, clk:%b", i,clk);
            // $display("clk_N_out:%b",clk_N_out);
            // $display("SEG:%b AN:%b",SEG,AN);
        end
        $display($time);
    end
endmodule
