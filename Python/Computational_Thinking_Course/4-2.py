def fact(n):
    #  ********* Begin *********#
    #  在此处补全代码#
    if n==1:
        return 1 
    else:
        return n*fact(n-1) 
    #  ********* End *********#
print(fact(5))