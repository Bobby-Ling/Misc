-- 事务2
USE testdb1;
## 请设置适当的事务隔离级别
SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
START TRANSACTION;
-- 时刻1 - 事务2修改航班余票
UPDATE ticket SET tickets = tickets - 1 WHERE flight_no = 'CA8213';

-- 时刻3 - 事务2 取消本次修改
## 请添加代码，使事务1在事务2撤销前读脏;
DO SLEEP(0.2);

ROLLBACK;
