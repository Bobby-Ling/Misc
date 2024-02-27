#coding=utf-8

#输入数字字符串，并转换为数值列表
a = input()
num1 = eval(a)
numbers = list(num1)

# 请在此添加函数bubbleSort代码，实现编程要求
#********** Begin *********#
def bubbleSort(sortlist):
    l=len(sortlist)
    for i in range(0,l-1):
        for j in range(0,l-i-1):
            if sortlist[j]>sortlist[j+1]:
                sortlist[j],sortlist[j+1]=sortlist[j+1],sortlist[j]
    return sortlist


#********** End **********#
print(bubbleSort(numbers))



