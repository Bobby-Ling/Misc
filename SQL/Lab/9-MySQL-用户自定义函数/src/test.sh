#---------- 数据准备 ----------
export MYSQL_PWD=123123
mysql -h127.0.0.1 -uroot < src/finance1.sql 2>/dev/null

#---------- 运行学生代码 ---------- 
mysql -h127.0.0.1 -uroot < src/test.sql


# 选择测试用例 
read -p '' choice

#---------- 开始评测 ---------- 
mysql -h127.0.0.1 -uroot << EDF
use finance1;
set @para = $choice;
select get_deposit(@para);

EDF