`timescale 1ns / 1ps
// `include "../src/_7Seg_Driver_Decoder_Selector.v"
`include "../src/BCD_Decode.v"
module Lab2_1_tb(

    );
    reg [3:0] digit;
    reg [2:0] select;
    wire [7:0] digit_bit;
    wire [7:0] select_bit;
    
    reg place;
    wire [3:0] bcd;
    
    _7Seg_Driver_Decoder_Selector tb_Decoder_Selector(
       .DIGIT(digit), 
       .SELECT(select), 
       .DIGIT_BIT(digit_bit), 
       .SELECT_BIT(select_bit)
    );

    BCD_Decode BCD_Decode_Inst(
        .DIGIT(digit), 
        .SELECT(select), 
        .PLACE(place), 
        .BCD(bcd)
        // .BCD_BIT(), 
        // .SELECT_BIT()
        );
    
    integer i;
    
    initial
    begin
        for (i=0; i < 17; i=i+1)
        begin
            #50 digit=i;
            $display("i:%d, digit_bit: %b", i,digit_bit);
        end
        
        for (i=0; i < 9; i=i+1)
        begin
            #50 select=i;
            $display("i:%d, select_bit: %b", i,select_bit);
        end

        for (i=0; i <= 9; i=i+1)
        begin
            #25 digit=i; 
            #25 place=1'b1;
            $write("i:%d, bcd[1]: %x   ", i,bcd);
            #25 place=1'b0;
            $write("bcd[0]: %x\n",bcd);
        end

        for (i=10; i < 16; i=i+1)
        begin
            #25 digit=i; 
            #25 place=1'b1;
            $write("i:%d, bcd[1]: %x   ", i,bcd);
            #25 place=1'b0;
            $write("bcd[0]: %x\n",bcd);
        end
    end
    
    
        /*
    reg [15:0] switches;
    wire [7:0] seg;
    wire [7:0] led;
    
    integer i;
    
    _7Seg_Driver_Choice 7Seg_Instance(
        SW(), 
        SEG, 
        AN, 
        LED
        );
 
    function [7:0] expected_led;
       input [7:0] swt;
    begin      
       expected_led[0] = ~swt[0];
       expected_led[1] = swt[1] & ~swt[2];
       expected_led[3] = swt[2] & swt[3];
       expected_led[2] = expected_led[1] | expected_led[3];
       expected_led[7:4] = swt[7:4];
    end   
    endfunction   
    
    initial
    begin
        for (i=0; i < 255; i=i+2)
        begin
            #50 switches=i;
            #10 e_led = expected_led(switches);
            if(leds == e_led)
                $display("LED output matched at", $time);
            else
                $display("LED output mis-matched at ",$time,": expected: %b, actual: %b", e_led, leds);
        end
    end
      
    */
endmodule
