 # 请用函数实现arctg泰勒级数计算，包含隐含参数N
def arctg(x, N=5):   # 迭代项数N的缺省值是5，即如果调用时不给值就用5
    #   请在此添加实现代码   #
    # ********** Begin *********#
    sum=0
    for i in range(1,N+1):
        term=(1 if i%2==1 else -1)*pow(x,2*i-1)/(2*i-1)
        sum+=term
    return sum
print('%.20f' % arctg(float(input())))
    
    # ********** End **********#