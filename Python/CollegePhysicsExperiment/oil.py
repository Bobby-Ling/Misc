# coding=utf-8
#密里根油滴计算
from math import pi,sqrt,pow,floor
def q(t_aver,u):
    rho=981#kg/m^3
    g=9.795#m/s^2
    eta=1.83e-5#kg/(m*s)
    l=1.5e-3#m
    b=6.16e-6#m*cmHg
    p=76#cmHg
    d=5e-3#m
    vg=l/t_aver
    a=sqrt(9*eta*vg/(2*rho*g))
    q=18*pi/sqrt(2*rho*g)*pow((eta*l)/(t_aver*(1+b/(p*a))),1.5)*d/u
    return q

e=1.6e-19
# U=[]
# tg=[]
U=[240,212,232,148,114,125,265,164,204,217]
tg=[9.78,9.66,9.34,9.24,15.66,15.88,15.62,20.46,9.08,9.74]
q_out=[]
n=10
# print("输入数据个数n")
# n=int(input())
# print("输入U")
# for i in range(0,n):
#     U.append(float(input()))
# print("输入tg")
# for i in range(0,n):
#     tg.append(float(input()))
for i in range(0,n):
    # print(U[i])
    # print(q(tg[i],U[i]))
    q_out=q(tg[i],U[i])
    n=floor(q_out/e)
    print("%.2f %d"%(q_out*1.0e+18,n))
print("Succes!!(单位x10^-18C,n)")
# 192 135 107 158
# 19.5 10.6 10.3 12.8

