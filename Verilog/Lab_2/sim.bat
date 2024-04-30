iverilog -g2012 -s Lab2_1_tb ^
    -o c:/Users/bobby/DATA/Git/Verilog/Lab_2/simulation/icarus/out.vvp ^
    -I C:/Users/bobby/DATA/Git/Verilog/Lab_2/user/src ^
    c:/Users/bobby/DATA/Git/Verilog/Lab_2/user/sim/Lab2_1_tb.v >sim.txt
vvp -n c:/Users/bobby/DATA/Git/Verilog/Lab_2/simulation/icarus/out.vvp >>sim.txt