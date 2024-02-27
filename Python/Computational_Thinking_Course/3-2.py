#coding=utf-8

from math import pi as PI

n = int(input())

# 请在此添加函数circle_area的代码，返回以n为半径的圆面积计算结果
#********** Begin *********#
def circle_area(r):
    return '{:.2f}'.format(PI*r*r)



#********** End **********#
print(circle_area(n))
