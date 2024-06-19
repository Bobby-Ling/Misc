/*
# MySQL对共享锁与锁的支持
通过设置不同的隔离级别，以实现不同的一致性与并发度的需求是较通常的作法。但MySQL也提供了主动加锁的机制，使得在较低的隔离级别下，通过加锁，以实现更高级别的一致性。

MySQL的select语句支持for share和for update短语，分别表示对表加共享(Share)锁和写(write)锁，共享锁也叫读锁，写锁又叫排它锁。
下面这条语句，会对表t1加共享锁:
select * from t1 for share;
如果select语句涉及多张表，还可分别对不同的表加不同的锁，比如：
select * from t1,t2 for share of t1 for update of t2;

加锁短语总是select语句的最后一个短语(复杂的select语句可能有where,group by, having, order by等短语)；
不管share还是update锁，都是在事务结束时才释放。
当然，锁行为会降低并发度。
 */

-- 事务1:
USE testdb1;
SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
START TRANSACTION;
# 第1次查询航班'MU2455'的余票
SELECT tickets FROM ticket WHERE flight_no = 'MU2455' FOR SHARE;
SET @n = SLEEP(2);
# 第2次查询航班'MU2455'的余票
SELECT tickets FROM ticket WHERE flight_no = 'MU2455' FOR SHARE;

COMMIT;
-- 第3次查询所有航班的余票，发生在事务2提交后
SET @n = SLEEP(1);
SELECT * FROM ticket;
