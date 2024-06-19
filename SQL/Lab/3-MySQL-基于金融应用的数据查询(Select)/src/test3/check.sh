#检查模板
#---------- 数据准备 ----------
export MYSQL_PWD=123123
mysql -h127.0.0.1 -uroot < src/common/finance1.sql 2>/dev/null
mysql -h127.0.0.1 -uroot < src/common/finance2.sql 2>/dev/null


# 选择数据库实例 
read -p '' choice

#---------- 运行学生代码 ---------- 
mysql -h127.0.0.1 -uroot << EDF
use $choice;
source src/test3/test3.sql

EDF
