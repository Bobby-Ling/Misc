module Mem_N(addr,Data);
    parameter   ADDR_WIDTH=4,
                DATA_WIDTH=8;
    // input [ADDR_WIDTH-1:0] addr;
    input [DATA_WIDTH-1:0] addr;
    output reg [DATA_WIDTH-1:0] Data=0;

    reg [DATA_WIDTH-1:0] mem [0:(1<<ADDR_WIDTH)-1];
    always@(*)begin
       Data<=mem[addr]; 
    end 

    integer i;
    initial begin
        $readmemh("C:/Users/bobby/DATA/Git/Verilog/Lab_4/user/data/mem.txt",mem);
        for (i = 0; i<(1<<ADDR_WIDTH); i=i+1) begin
            // $display("%x",mem[i]);
        end
    end 
endmodule //Mem_N
