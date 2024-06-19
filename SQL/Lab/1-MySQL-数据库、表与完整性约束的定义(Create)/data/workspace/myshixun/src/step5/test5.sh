#! /bin/bash

#---------- 数据准备 --------------
export MYSQL_PWD=123123

#---------- 运行学生代码 ---------- 
touch err.txt 
mysql -h127.0.0.1 -uroot < src/step5/step5.sql > err.txt 2>&1 >/dev/null
if [ $? == 0 ]; then


#----------- 数据测试 --------------
mysql -h127.0.0.1 -uroot --force < src/step5/data1.sql 2>/dev/null


#---------- 检查结果 ---------- 
mysql -h127.0.0.1 -uroot < src/step5/check.sql

else 
echo "代码存在错误，以下是提示信息："
cat err.txt 
fi


#---------- 数据准备 ----------
# export MYSQL_PWD=123123
# mysql -h127.0.0.1 -uroot --force < src/step4/insert_test.sql 2>/dev/null

#---------- 运行学生代码 ---------- 
#mysql -h127.0.0.1 -uroot < src/step4/test4.sql 2>/dev/null

#----------- 数据测试
# mysql -h127.0.0.1 -uroot --force < src/step4/insert_test.sql 2>/dev/null

#---------- 检查结果 ---------- 
#mysql -h127.0.0.1 -uroot < src/step4/check4.sql