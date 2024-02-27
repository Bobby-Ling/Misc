 #请验证输入的列表N_list中的整数是否为四位数，并返回四位数整数的千位数值

N_list = [int(i) for i in input().split(',')]
List=[]
#   请在此添加实现代码   #
# ********** Begin *********#
for ele in N_list:
    if((ele<=9999)and(ele>=1000)):
        List.append(ele//1000)
print(List)



# ********** End **********#
