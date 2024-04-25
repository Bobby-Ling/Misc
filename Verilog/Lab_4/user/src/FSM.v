module FSM(
    input clk,
    input rst,
    input start,
    input next_zero,
    output reg LOAD_SUM=0,
    output reg LOAD_NEXT=0,
    output reg SUM_SEL=0,
    output reg NEXT_SEL=0,
    output reg ADDR_SEL=0,
    output reg DONE=0
);
    parameter DEBUG=0;

    parameter   STATE_START=      4'b0001,
                STATE_COMPUTE_SUM=4'b0010,
                STATE_GET_NEXT=   4'b0100,
                STATE_DONE=       4'b1000;

    reg [3:0] state=STATE_START;
    always@(posedge clk) begin
        if(rst==1)begin
            state<=STATE_START;
        end


        if(DEBUG==1) begin
            // $write("clk:%b ",clk);
            $write("next_zero:%b ",next_zero);
            // $write("start:%b ",start);
            case (state)
                STATE_START:        $write("STATE_START      ");
                STATE_COMPUTE_SUM:  $write("STATE_COMPUTE_SUM");
                STATE_GET_NEXT:     $write("STATE_GET_NEXT   ");
                STATE_DONE:         $write("STATE_DONE       ");
                default:            $write("ERROR:%b       ",state);
            endcase
        end

        case (state)
            STATE_START: 
                begin
                    // begin
                    //     LOAD_SUM    <=0;
                    //     LOAD_NEXT   <=0;
                    //     SUM_SEL     <=0;
                    //     NEXT_SEL    <=0;
                    //     ADDR_SEL    <=0;
                    //     DONE        <=0;
                    // end
                    if(start==1)begin
                        state=STATE_COMPUTE_SUM;
                    end
                end
            STATE_COMPUTE_SUM:
                begin
                    // begin
                    //     LOAD_SUM    <=1;
                    //     LOAD_NEXT   <=0;
                    //     SUM_SEL     <=1;
                    //     NEXT_SEL    <=1;
                    //     ADDR_SEL    <=1;
                    //     DONE        <=0;
                    // end
                    state=STATE_GET_NEXT;
                end
            STATE_GET_NEXT:   
                begin
                    // begin
                    //     LOAD_SUM    <=0;
                    //     LOAD_NEXT   <=1;
                    //     SUM_SEL     <=1;
                    //     NEXT_SEL    <=1;
                    //     ADDR_SEL    <=0;
                    //     DONE        <=0;
                    // end
                    if(next_zero==1)begin
                        state=STATE_DONE;
                    end
                    else begin
                        state=STATE_COMPUTE_SUM;
                    end
                end
            STATE_DONE:
                begin
                    // begin
                    //     LOAD_SUM    <=0;
                    //     LOAD_NEXT   <=0;
                    //     SUM_SEL     <=0;
                    //     NEXT_SEL    <=0;
                    //     ADDR_SEL    <=0;
                    //     DONE        <=1;
                    // end
                    if(start==0)begin
                        state=STATE_START;
                    end
                    else begin
                        state=STATE_DONE;
                    end
                end
            default:
                state=STATE_START;
        endcase
        
        case (state)
            STATE_START: 
                begin
                    LOAD_SUM    <=0;
                    LOAD_NEXT   <=0;
                    SUM_SEL     <=0;
                    NEXT_SEL    <=0;
                    ADDR_SEL    <=0;
                    DONE        <=0;
                end
            STATE_COMPUTE_SUM:
                begin
                    LOAD_SUM    <=1;
                    LOAD_NEXT   <=0;
                    SUM_SEL     <=1;
                    NEXT_SEL    <=1;
                    ADDR_SEL    <=1;
                    DONE        <=0;
                end
            STATE_GET_NEXT:   
                begin
                    LOAD_SUM    <=0;
                    LOAD_NEXT   <=1;
                    SUM_SEL     <=1;
                    NEXT_SEL    <=1;
                    ADDR_SEL    <=0;
                    DONE        <=0;
                end
            STATE_DONE:
                begin
                    LOAD_SUM    <=0;
                    LOAD_NEXT   <=0;
                    SUM_SEL     <=0;
                    NEXT_SEL    <=0;
                    ADDR_SEL    <=0;
                    DONE        <=1;
                end
            default:
                state=STATE_START;
        endcase

        if(DEBUG==1)begin
            $write(" -> ");
            case (state)
                STATE_START:        $write("STATE_START      ");
                STATE_COMPUTE_SUM:  $write("STATE_COMPUTE_SUM");
                STATE_GET_NEXT:     $write("STATE_GET_NEXT   ");
                STATE_DONE:         $write("STATE_DONE       ");
                default:            $write("ERROR:%b       ",state);
            endcase
            $write("  ");

            // $display("LOAD_SUM:%b, LOAD_NEXT:%b, SUM_SEL:%b, NEXT_SEL:%b, ADDR_SEL:%b, DONE:%b",
            $write("%b %b %b %b %b %b ",
                LOAD_SUM,LOAD_NEXT,SUM_SEL,NEXT_SEL,ADDR_SEL,DONE);
            $write("END\n");
        end
    end

endmodule //FSM
