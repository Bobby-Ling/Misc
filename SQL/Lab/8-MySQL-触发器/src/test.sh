 #---------- 数据准备 ----------
export MYSQL_PWD=123123
mysql -h127.0.0.1 -uroot < src/finance1.sql 2>/dev/null

#---------- 运行学生代码 ---------- 
mysql -h127.0.0.1 -uroot < src/test.sql 2>/dev/null

#---------- insert test  ---------- 
#mysql -h127.0.0.1 -uroot < src/ins_upd.sql 2>/dev/null

# 选择测试用例 
read -p '' choice


#---------- 检查结果 ---------- 
mysql -h127.0.0.1 -uroot < src/check$choice.sql
