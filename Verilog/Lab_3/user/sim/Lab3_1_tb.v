`timescale 1ns / 1ps
`include "../src/dynamic_scan.v"
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
    reg isOn;

    dynamic_scan #(2) dynamic_scan_inst(
        .clk(clk),
        .isReverse(isReverse),
        .isOn(isOn),
        .SEG(SEG),
        .AN(AN)
    );

    integer i;

    initial begin
        isOn=1'b1;
        $display($time);
        for (i=1; i < 200; i=i+1)
        begin
            #5
            $display("i:%d, clk:%b, clk_N_out:%b, SEG:%b AN:%b", i,clk,clk_N_out,SEG,AN);
        end
        $display($time);

        for (i=1; i < 200; i=i+1)
        begin
            #5
            $display("i:%d, clk:%b, clk_N_out:%b, SEG:%b AN:%b", i,clk,clk_N_out,SEG,AN);
        end
        $display($time);

        isOn=1'b0;
        $display($time);
        for (i=1; i < 200; i=i+1)
        begin
            #5
            $display("i:%d, clk:%b, clk_N_out:%b, SEG:%b AN:%b", i,clk,clk_N_out,SEG,AN);
        end
        $display($time);

        for (i=1; i < 200; i=i+1)
        begin
            #5
            $display("i:%d, clk:%b, clk_N_out:%b, SEG:%b AN:%b", i,clk,clk_N_out,SEG,AN);
        end
        $display($time);
        $finish;
    end
endmodule
