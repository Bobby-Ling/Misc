#电路的暂态过程
from math import pi,sqrt,pow,tan,sin,cos,radians,degrees,log

f=500.000000#Hz
E=5.000#V
r=50.0#Ohm
C=0.06e-6#F
L=5e-3#H
#RC
class RC:
    t_d=110e-6#s
    R=2900.0#Ohm
    t_measure=t_d/log(2)
    t_theory=(R+r)*C
    print("%.1fe-6s" %(t_measure*1e6))
    print("%.1fe-6s" %(t_theory*1e6))
    Er_t=abs(t_theory-t_measure)/t_theory
    print("%.1f%%" % (Er_t * 100))

class RLC:
    R=0.0#Ohm
    t_n=332e-6#s
    N=3
    T_measure=t_n/N
    T_theory=2*pi*sqrt(L*C)/sqrt(1-(R+r)**2*C/(4*L))
    print("%fe-6s" %(T_measure*1e6))
    print("%fe-6s" %(T_theory*1e6))
    Er_T=abs(T_theory-T_measure)/T_theory
    print("%.1f%%" % (Er_T * 100))

    R=520.0
    Rc_measure=R+r
    Rc_theory=2*sqrt(L/C)
    print(Rc_measure)
    print(Rc_theory)
    Er_Rc=abs(Rc_theory-Rc_measure)/Rc_theory
    print("%.1f%%" % (Er_Rc * 100))
