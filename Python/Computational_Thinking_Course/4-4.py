# class Counter(object) :
#     def __init__(self, fun) :
#         self._fun = fun
#         self.counter=0
#     def __call__(self,*args, **kwargs) :
#         self.counter += 1
#         return self._fun(*args, **kwargs)

# @Counter
x=int(input())+1
def Fibonacci(n):
    if n==0:
        return 0
    elif n==1:
        return 1
    else :
        return Fibonacci(n-2)+Fibonacci(n-1)
for i in range(1,x+1):
    print(Fibonacci(i))