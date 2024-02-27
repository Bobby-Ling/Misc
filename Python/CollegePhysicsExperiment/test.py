#组合光学不确定度计算
#单位统一为mm
import math
d10=(5.305,5.370,5.310)
d20=(7.370,7.309,7.250)
n=3
tp=1.32
p=0.683
kp=1.00
C=3
delta_instr=0.005
m=10
lam=589.3*(1e-3)

sum=0
for i in d10:
    sum+=i
av1=sum/3

sum=0
for i in d20:
    sum+=i
av2=sum/3

UB=kp*delta_instr/C
print(UB)

sum=0
for i in d10:
    sum+=(i-av1)*(i-av1)
sigma=math.sqrt(sum/(n-1))
sigmabar=sigma/(math.sqrt(n))
UA=sigmabar*tp
Ur=math.sqrt(UA*UA+UB*UB)
print(sigma)
print(sigmabar)
print(UA)
print(Ur)
Urd10=Ur

print()

sum=0
for i in d20:
    sum+=(i-av2)*(i-av2)
sigma=math.sqrt(sum/(n-1))
sigmabar=sigma/(math.sqrt(n))
UA=sigmabar*tp
Ur=math.sqrt(UA*UA+UB*UB)
print(sigma)
print(sigmabar)
print(UA)
print(Ur)
Urd20=Ur

print()

UrR=math.sqrt(((2*av1)/(4*m*lam)*Urd10)**2+((2*av2)/(4*m*lam)*Urd20)**2)
print(UrR)

print()

R=(av2*av2-av1*av1)/(4*m*lam)
print(R)