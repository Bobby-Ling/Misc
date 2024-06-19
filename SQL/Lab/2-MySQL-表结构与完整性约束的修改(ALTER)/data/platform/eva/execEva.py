# jupyter评测执行脚本

#!/usr/bin/python3
# -*- coding:utf-8 -*-

from pickle import TRUE
from re import I
import re
from tkinter.messagebox import RETRY
from click import command
from pathlib import Path
import sys
import base64
import os
import json
import subprocess


class Evalute:

    def __init__(self,input,jupyter_file,timeout):
        try:
            f = open(jupyter_file)
            f.close()
        except FileNotFoundError:
            print("Error: 没有找到文件 %s,%s",jupyter_file)
        else:
            #存在
            self.encode_input = input
            self.jupyter_file = jupyter_file
            self.decode_input = self.decode_case(input)
            self.timeout = timeout



    #解析测试集
    def decode_case(self,input):
        input_list = []
        if input == "IA==":
            input_list.append(input)
        else:
            #判断整个base64是否包含逗号，若包含则切割，不包含则解析返回
            if input.find(",") != -1:
                input_list = []
                input_list = input.split(",")
            else:
                input_list.append(input)
        return input_list


    #检查测试集是否为空
    def check_input_is_null(self):
        #假设无测试集的情况是空格
        if self.decode_input[0] == "IA==":
           return True
        return False


    #初始化,生成执行命令列表
    def init(self):
        self.cmd_list = []
        if self.check_input_is_null() == False:
            for param in self.decode_input:
                str = "echo \"" + param + "\" | base64 -d |" + "/usr/bin/python3.6 " + self.jupyter_file + " 2>&1 | base64"
                self.cmd_list.append(str)
        if self.check_input_is_null() == True:
            str = "/usr/bin/python3 " + self.jupyter_file + " 2>&1 |base64"
            self.cmd_list.append(str)
        return

    #执行评测并保存结果返回列表
    def run(self):
        #评测结果
        self.eva_result = ""
        r = []
        eva_result_direct = {}
        eva_result_direct["compileResult"] = "Y29tcGlsZSBzdWNjZXNzZnVsbHk"
        for num in self.cmd_list:
            ret = os.popen(num,'r').read()
            r.append(ret)
        eva_result_direct["out"] = r
        self.eva_result = json.dumps(eva_result_direct, ensure_ascii=False)


    # 脚本只做结果输出
    def print_console(self):
        print(self.eva_result)
        return


    #开始评测
    def start(self):
        #评测初始化
        self.init()
        #执行存结果
        self.run()
        #输出结果到console
        self.print_console()



if __name__ == '__main__':
    # 参数：测试集每组以逗号分隔base64编码；jupyter源代码路径；timeout；
    a = Evalute(sys.argv[1],sys.argv[2],sys.argv[3])
    a.start()