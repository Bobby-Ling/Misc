/*
# 可串行化
多个事务并发执行是正确的，当且仅当其结果与按某一次序串行地执行这些事务时的结果相同。两个事务t1,t2并发执行，如果结果与t1→t2串行执行的结果相同，或者与t2→t1串行执行的结果相同，都是正确的(可串行化的)。

如果将事务的隔离级别设置为serializable，则这些事务并发执行，无论怎么调度都会是可串行化的。但这种隔离级别会大大降低并发度，在实践中极小使用。MySQL默认的隔离级别为repeatable read，有的DBMS默认为read committed。
 */

-- 事务1:
USE testdb1;
START TRANSACTION;
DO SLEEP(0.1);
SELECT tickets FROM ticket WHERE flight_no = 'MU2455';
SET @n = SLEEP(2);
SELECT tickets FROM ticket WHERE flight_no = 'MU2455';
COMMIT;
