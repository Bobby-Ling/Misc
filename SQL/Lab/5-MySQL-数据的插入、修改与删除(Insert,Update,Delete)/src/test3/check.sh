#---------- 数据准备 ----------
export MYSQL_PWD=123123
mysql -h127.0.0.1 -uroot < src/test1/finance1.sql 2>/dev/null

#---------- 运行学生代码 ---------- 
mysql -h127.0.0.1 -uroot < src/test3/test3.sql 

#---------- 检查结果 ---------- 
mysql -h127.0.0.1 -uroot < src/test3/check.sql
 