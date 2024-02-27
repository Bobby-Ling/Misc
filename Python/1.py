from math import pi,sqrt,pow,tan,sin,cos,radians,degrees
# x=[2.183,2.182,2.185,2.184,2.182]
# x=[42.35,42.45,42.37,42.33,42.30,42.40,42.48,42.35,42.49]
# x=[47.7,47.2,46.7,46.3,45.8,45.4,45.0,44.6,44.2,43.8]
x=[2.3,2.2,2.1,2.1,2.0 ]
tp=2.31
def UA(x,tp):
    n=len(x)
    x_aver=sum(x)
    sumtmp=0.0
    for i in x:
        # a=abs(i-x_aver)
        # b=pow(a,2)
        # c=sumtmp+b
        # sumtmp=c
        sumtmp+=pow(abs(i-x_aver),2)
    # sigma=sqrt(sumtmp/(n-1))#标准误差
    # sigma_x_aver=sigma/sqrt(n)
    # uA=sigma_x_aver
    uA=sqrt(sumtmp/((n-1)*n))
    UA=tp*uA#A类不确定度
    return UA
print(UA(x,tp))
def dms2r(d,m,s=0):
	return float(radians(d+m/60+s/3600))

def UA1(x,tp):
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
UA1(x,tp)
# print(sin(dms2r(30,0)))