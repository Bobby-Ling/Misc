#---------- 数据准备 ----------
export MYSQL_PWD=123123
mysql -h127.0.0.1 -uroot < src/test1/finance1.sql 2>/dev/null

#---------- 运行学生代码 ----------
if [ $(cat src/test4/test4.sql  | grep -c "bank_card") -lt 1 ]; then 
echo "语句没有通过语义检查!" 
else 

touch err.txt 

mysql -h127.0.0.1 -uroot < src/test4/test4.sql  > err.txt 2>&1 >/dev/null
# 2 > err.txt 
# --- 2>/dev/null

if [ $? == 0 ]; then

#---------- 检查结果 ---------- 
mysql -h127.0.0.1 -uroot < src/test4/check.sql

else 
echo "代码存在错误，以下是提示信息："
cat err.txt 
fi
fi
