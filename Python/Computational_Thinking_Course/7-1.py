import math

# TSP问题贪心算法版本

result_path = list()    # 节点列表
matrix = list()
left_node = list()# 保存所有节点
node_list = list()# 节点坐标列表
start_node = 0# 开始节点

#也可自己写代码实现算法，但请不要修改输入和输出，避免影响评测。
def tsp_greedy_agr(matrix: list, start_node: int)-> int:
    """
    tsp贪心算法，可能结果会有误差
    :param matrix:  满秩矩阵
    :param start_node:  出发节点
    :return:    最短距离
    """
    # 0   3   6   7
    # 5   0   2   3
    # 6   4   0   2
    # 3   7   5   0

    result_path = list()
    result_path.append(start_node)# 将开始节点加入列表
    now_node = start_node   # 当前节点
    min_path = 0
    while len(result_path) < len(matrix):# 如果没有走过所有节点
        min_node_index = now_node   # 最小距离节点索引
        matrix[now_node][now_node] = 0xFFFFFF
        for col_index in range(len(matrix[now_node])):
            # 请在此添加代码
            #-----------Begin----------
            # print('col_index={}'.format(col_index))
            if matrix[now_node][min_node_index]>matrix[now_node][col_index] and (not col_index in result_path):
            #------------End-----------
                min_node_index = col_index
            # print('min_index={} '.format(min_node_index))
        print()    
        matrix[now_node][now_node] = 0
        min_path += matrix[now_node][min_node_index]     
        result_path.append(min_node_index)
        now_node = min_node_index

    result_path.append(start_node)
    for index in range(len(result_path)):
        result_path[index] = str(result_path[index])
    print('-'.join(result_path))
    # 添加最后节点返回开始节点距离
    return min_path+matrix[now_node][start_node]


if __name__ == "__main__":
    matrix = [
        [0.0, 94.54099639838793, 268435455, 268435455, 97.05795884337854, 268435455],
        [94.54099639838793, 0.0, 33.13608305156178, 61.032778078668514, 71.00704190430693, 99.92497185388645],
        [268435455, 33.13608305156178, 0.0, 72.94518489934754, 38.2099463490856, 268435455],
        [268435455, 61.032778078668514, 72.94518489934754, 0.0, 94.49338601193207, 48.27007354458868],
        [97.05795884337854, 71.00704190430693, 38.2099463490856, 94.49338601193207, 0.0, 98.76203977248295],
        [268435455, 99.92497185388645, 268435455, 48.27007354458868, 98.76203977248295, 0.0]
    ]
    # matrix = [
    #     [00, 94, 99, 99, 97, 99],
    #     [94, 00, 33, 61, 71, 99],
    #     [99, 33, 00, 72, 38, 99],
    #     [99, 61, 72, 00, 94, 48],
    #     [97, 71, 38, 94, 00, 98],
    #     [99, 99, 99, 48, 98, 00]
    # ]
    # matrix=[
    #     [0,   3,   6,   7],
    #     [5,   0,   2,   3],
    #     [6,   4,   0,   2],
    #     [3,   7,   5,   0],
    # ]
    tsp_greedy_agr(matrix, 0)

