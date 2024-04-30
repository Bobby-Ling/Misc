iverilog -g2012 -s Lab4_1_tb ^
    -o c:/Users/bobby/DATA/Git/Verilog/Lab_4/simulation/icarus/out.vvp ^
    -I C:/Users/bobby/DATA/Git/Verilog/Lab_4/user/src ^
    c:/Users/bobby/DATA/Git/Verilog/Lab_4/user/sim/Lab4_1_tb.v >sim.txt
vvp -n c:/Users/bobby/DATA/Git/Verilog/Lab_4/simulation/icarus/out.vvp >>sim.txt