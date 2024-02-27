from math import pi,sqrt,pow,tan,sin,cos,radians,degrees
p=0.683
tp=1.11
f0=37090#Hz
v0=331.45#m/s
t=18.0#C deg
T0=273.16#C deg
UB_water=0.02/1000#m

l_air=[48.24,57.48,62.12,66.90,71.18,80.78,85.40,90.12,94.72,99.38,104.12,108.66]#mm
l_water=[76.20,95.62,108.10,137.36,159.12,178.42,193.02,213.56,234.60,255.48,276.60,298.00]#mm
for i in range(0,12):
    l_air[i]=l_air[i]/1000#m
for i in range(0,12):
    l_water[i]=l_water[i]/1000#m
print(l_air)
print(l_water)
delta_l_air=[]#m
delta_l_water=[]#m

for i in range(0,6):
    delta_l_air.append((l_air[i+6]-l_air[i])/6)
for i in range(0,6):
    delta_l_water.append((l_water[i+6]-l_water[i])/6)

delta_l_air_aver=sum(delta_l_air)/len(delta_l_air)#m
delta_l_water_aver=sum(delta_l_water)/len(delta_l_water)#m
print(delta_l_air)
print(delta_l_water)
print("delta_l_air_aver={}".format(delta_l_air_aver))
print("delta_l_water_aver={}".format(delta_l_water_aver))


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

v_air=f0*2*delta_l_air_aver#m/s
v_air_theory=v0*sqrt(1+t/T0)#m/s
Ur_air=abs(v_air_theory-v_air)/v_air_theory#m/s
print("v_air={}".format(v_air))
print("v_air_theory={}".format(v_air_theory))
print("Ur_air={}".format(Ur_air))
print()
v_water=f0*2*delta_l_water_aver#m/s
UA_water=UA(delta_l_water,tp)#m/s
Ur_water=f0*2*sqrt(UA_water**2+UB_water**2)#m/s
print("v_water={}".format(v_water))
print("UA_water={}".format(UA_water))
print("Ur_water={}".format(Ur_water))

