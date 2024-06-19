#!/bin/bash

#---------- 数据准备 --------------
export MYSQL_PWD=123123

#---------- 运行学生代码 ---------- 
touch err.txt 
mysql -h127.0.0.1 -uroot < src/test6/test6.sql > err.txt 2>&1 >/dev/null
if [ $? == 0 ]; then

#----------- 数据测试 --------------
# mysql -h127.0.0.1 -uroot --force < src/step5/data1.sql 2>/dev/null


#---------- 检查结果 ---------- 
mysql -h127.0.0.1 -uroot < src/test6/check.sql

else 
echo "代码存在错误，以下是提示信息："
cat err.txt 
fi


#执行sql语句
#export MYSQL_PWD=123123
#mysql -h127.0.0.1 -uroot << EOF
#use MyDb;
#desc s;
#EOF
