import math
def ln(x, N=50):
    '''
    :param x: 输入值
    :param N: 迭代项数
    :return: 对数值，误差的绝对值
    '''
    #   请在此添加实现代码   #
    # ********** Begin *********#
    x-=1
    sum=0
    for i in range(1,N+1):
        term=(1 if i%2==1 else -1)*pow(x,i)/i
        sum+=term
    error=math.fabs(sum-math.log(x+1))
    return sum,error
print(ln(2))



    # ********** End **********#