 #! /bin/bash

#---------- 数据准备 ----------
export MYSQL_PWD=123123

#---------- 运行学生代码 ---------- 
touch err.txt 
mysql -h127.0.0.1 -uroot < src/step2/test2.sql > err.txt 2>&1 >/dev/null
if [ $? == 0 ]; then
#---------- 检查结果 ---------- 
mysql -h127.0.0.1 -uroot < src/step2/check2.sql
else 
echo "代码存在错误，以下是提示信息："
cat err.txt 
fi
