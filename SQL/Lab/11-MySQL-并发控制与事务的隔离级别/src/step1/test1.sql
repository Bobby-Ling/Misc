-- 请不要在本代码文件中添加空行！！！ 
USE testdb1;
# 设置事务的隔离级别为 read uncommitted
SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
-- 开启事务
START TRANSACTION;
insert into dept(name) values("SALES");
insert into dept(name) values("SALES");
INSERT INTO dept(name) VALUES ('运维部');
# 回滚事务：
ROLLBACK;
/* 结束 */