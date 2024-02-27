 # 本程序计算1-N整数立方的累加和

N = int(input())
#   请在此添加实现代码   #
# ********** Begin *********#
sum=0
for i in range(1,N+1):
    sum+=i**3
print(sum)



# ********** End **********#