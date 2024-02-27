#分光计
from math import pi,sqrt,pow,tan,sin,cos,radians,degrees
# def dms2d(d,m,s=0):
# 	return d+m/60+s/3600
def dms2r(d,m,s=0):#角度（度分秒）转弧度
	return float(radians(d+m/60+s/3600))
p=0.683
tp=1.14
kp=1.00

delta_instr=dms2r(0,2)#rad
uc_A=dms2r(0,2)
A_aver=dms2r(60,0)

# n=int(input("输入数据个数"))
# x=[dms2r(58,15),dms2r(58,20,30),dms2r(58,19),dms2r(58,18),dms2r(58,18,30)]#数据输入
# x=[dms2r(38,29),dms2r(38,28),dms2r(38,30),dms2r(38,30),dms2r(38,32)]#数据输入
x=[dms2r(49,21),dms2r(50,57),dms2r(51,53),dms2r(50,53),dms2r(51,2)]#数据输入

print(x)
n=len(x)
sigma_min=sum(x)/n

#求n
n_=sin((A_aver+sigma_min)/2)/sin(A_aver/2)
print("n为%f"%(n_))


def UA(x,tp):
    n=len(x)
    x_aver=sum(x)/n
    sumtmp=0.0
    for i in x:
        sumtmp+=pow(abs(i-x_aver),2)
    sigma=sqrt(sumtmp/(n-1))#标准误差
    sigma_x_aver=sigma/sqrt(n)
    uA=sigma_x_aver
    # uA=sqrt(sumtmp/((n-1)*n))
    UA=tp*uA#A类不确定度
    print("UA为{}".format(UA))
    return UA
def uB(kp,delta_instr,C=3):
    u_instr=kp*delta_instr/C
    uB=u_instr
    return uB

def uc(x,n,tp,kp,delta_instr,C,u_instr=-1.0):
    if(u_instr==-1.0):
        uc=sqrt(UA(x,tp)**2+uB(kp,delta_instr,C)**2)#本实验不需要算uB
    else:
        uc=sqrt(UA(x,tp)**2+u_instr**2)
    return uc



uc_sigma_min=uc(x,n,tp,kp,delta_instr,3,delta_instr)
ur=sqrt(((1/tan((A_aver+sigma_min)/2)-1/tan(A_aver/2))**2)*(uc_A**2)/4+(1/tan((A_aver+sigma_min)/2)**2)*(uc_sigma_min**2)/4)
print("uc_A={}".format(uc_A))
print("sigma_min为{}".format(sigma_min))
print("uc_sigma_min为{}".format(uc_sigma_min))
print("不确定度ur(n)为{}".format(ur))