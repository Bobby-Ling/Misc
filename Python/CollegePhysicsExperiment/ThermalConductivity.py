#导热系数
from math import pi,sqrt,pow,tan,sin,cos,radians,degrees
Rc=4.924e-2#m
hc=0.988e-2#m
Rb=4.977e-2#m
hb=0.795e-2#m 
T1=57.9#C_deg
T2=45.8#C_deg
m=0.680#kg
C=394#J/(kg*C_deg)
pho=8.9e-3#kg/m^3
k=1.4e-2#Delta_T/Delta_t
Delta_t=30*5#s
lambda_=m*C*k*(Rc+2*hc)*hb/(2*Rc+2*hc)/(T1-T2)/(pi*Rb**2)
print(lambda_)


Delta_T=[2.3,2.2,2.1,2.1,2.0 ]
n=len(Delta_T)
x=Delta_T#对物理量X做n次等精度测量, 得到包含n个测量值x1, x2,…, xn的一个测量列

#不确定度计算ver2.0

# tp与测量次数n的关系
# p\tp\n 3    4    5    6    7    8    9    10   ∞
# 0.68   1.32 1.20 1.14 1.11 1.09 1.08 1.07 1.06 1
# 0.90   2.92 2.35 2.13 2.02 1.94 1.86 1.83 1.76 1.65
# 0.95   4.30 3.18 2.78 2.57 2.46 2.37 2.31 2.26 1.96
# 0.99   9.93 5.84 4.60 4.03 3.71 3.50 3.36 3.25 2.58

# 三种分布下置信概率与置信因子kp的关系
# 分布\kp\p 0.500 0.577 0.650 0.683 0.900 0.950 0.955 0.990 0.997
# 正态分布  0.675 1.000 1.650 1.960 2.000 2.580 3.000
# 均匀分布  0.877 1.000 1.183 1.559 1.645 1.654 1.715 1.727
# 三角分布  0.717 0.862 1.000 1.064 1.675 1.901 1.929 2.204 2.315

#   正态分布 均匀分布 三角分布
# C 3       sqrt(3)  sqrt(6)
# 几种常见仪器的误差分布与置信系数
# 仪器       米尺 游标卡尺 千分尺 物理天平 秒表
# 误差分布   正态 均匀     正态   正态    正态
# 置信系数C  3   sqrt(3)  3      3       3

# 查表得:
p=0.683#置信概率
tp=1.14#修正因子,n=5时
kp=1.559

delta_instr=45.7*(0.01*sqrt(3))+0#读数xC%+稳定显示后一位的几个单位,C=sqrt(3)

def UA(x,tp):#A类不确定度
    n=len(x)
    x_aver=sum(x)/n#测量列的平均值
    sumtmp=0.0
    for i in x:
        sumtmp+=pow(abs(i-x_aver),2)
    sigma=sqrt(sumtmp/(n-1))#测量列的标准差
    print("测量列的标准差sigma为{}".format(sigma))
    sigma_x_aver=sigma/sqrt(n)#算数平均值的标准差
    print("算数平均值的标准差(未修正的A类不确定度)sigma_x_aver为{}".format(sigma_x_aver))
    uA=sigma_x_aver#未修正的A类不确定度
    UA=tp*uA#使用tp因子修正后的A类不确定度
    print("UA为{}".format(UA))
    return UA

def UB(delta_instr,#仪器最大允许误差
       kp=1.0,
       C=sqrt(3)):
    u_instr=kp*delta_instr/C
    print("u_instr为{}".format(u_instr))
    uB=u_instr#UB=sqrt(uB**2+u_estimate**2),一般忽略u估即u_estimate

    """
    常见仪器最大允许误差
    •钢卷尺: 1m/1mm±0.8mm; 2m/1mm±1.2mm
    •游标卡尺:  125mm/0.02mm±0.02mm 300mm/0.02mm±0.05mm
    •螺旋测微器:  25mm/0.01mm±0.004mm
    •指针电表级别: 5.0、2.0、1.5、1.0、0.5、0.2、0.1等
    •指针电表: 量程x级别 %
        e.g.量程为100 V的1.0级电压表, 测量一个电池的电动势为1.5 V. 
            则仪表的最大允差为1.0 V. 若量程为10V, 则降低到0.1 V. 
    •数字电表: 读数xC%+稳定显示后一位的几个单位
        e.g.某精度为1.0级的三位半电表, 用20.00 V量程测量电池电动势, 读数为1.50 V. 
            按其说明书, C为1, 假设末位数字跳动5个单位, 则测量结果的最大允差为: (0.015+0.05) =0.065 V. 
            若改用2.000 V量程, 则为( 0.015+0.005) = 0.020 V. 
    """
    return uB

def uc(x,tp,kp,delta_instr,C,u_instr=-1.0):#直接测量结果的合成标准不确定度
    if(u_instr==-1.0):
        uc=sqrt(UA(x,tp)**2+UB(kp,delta_instr,C)**2)#本实验不需要算uB
    else:
        uc=sqrt(UA(x,tp)**2+u_instr**2)
    return uc



uc_lambda=uc(x,tp,kp,delta_instr,C=sqrt(3),u_instr=0.1/sqrt(3))
ur=m*C*(Rc+2*hc)*hb/(2*Rc+2*hc)/(T1-T2)/(pi*Rb**2)*uc_lambda/Delta_t
print("uc_lambda为{}".format(uc_lambda))
print("不确定度Ur()为{}".format(ur))