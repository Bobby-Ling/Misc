#! /bin/bash

#---------- 数据准备 ----------
export MYSQL_PWD=123123
mysql -h127.0.0.1 -uroot < src/step1/fibonacci.sql 2>/dev/null


#---------- 运行学生代码 ---------- 
mysql -h127.0.0.1 -uroot < src/step1/test1.sql 2>/dev/null

# 选择测试用例 
read -p '' choice

#---------- 开始评测 ---------- 
mysql -h127.0.0.1 -uroot << EDF
use fib;
set @para = $choice;
call sp_fibonacci(@para);
select * from fibonacci;

EDF

#---------- 测试代码  ----------------
# mysql -h127.0.0.1 -uroot < src/step1/check.sql
