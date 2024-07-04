#!/usr/bin/env python
import numpy as np

""" 
    [1,2,3],
    [3,4,5],
    [5,4,3],
    [0,2,4],
    [1,3,5] 
    
    [4,11,14],
    [8,7,-2]
"""
# 定义给定的矩阵
A = np.array([
    [0,1],
    [1,1],
    [1,0]
])

# 进行SVD分解
U, Sigma, Vt = np.linalg.svd(A)

# 打印结果
print("U矩阵: ")
print(U)
print("\n奇异值: ")
print(Sigma)
print("\nV转置矩阵: ")
print(Vt)



# 定义系数矩阵 A 和常数向量 B
A = np.array([
    [1,1,0], 
    [1,2,1],
    [0,1,1]
])
B = np.array([0,0,0])

# 求解线性方程组 AX = B
X = np.linalg.solve(A, B)

print("解向量 X: ")
print(X)