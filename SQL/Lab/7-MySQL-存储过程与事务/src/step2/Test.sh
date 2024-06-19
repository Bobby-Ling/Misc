#! /bin/bash

# 选择测试用例 
read -p '' choice
#---------- 数据准备 ----------
export MYSQL_PWD=123123

mysql -h127.0.0.1 -uroot < src/step2/hms$choice.sql 2>/dev/null
#mysql -h127.0.0.1 -uroot < src/step2/hms2.sql 2>/dev/null


#---------- 运行学生代码 ---------- 
#mysql -h127.0.0.1 -uroot < src/step2/test2.sql 
# 2>/dev/null

#---------- 运行学生代码 ---------- 
mysql -h127.0.0.1 -uroot << EDF
use hms$choice;
source src/step2/test2.sql

EDF

# 选择测试用例 
#read -p '' choice

#---------- 开始评测 ---------- 
mysql -h127.0.0.1 -uroot < src/step2/check$choice.sql

