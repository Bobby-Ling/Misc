/*
# 不可重复读
不可重复读(unrepeatable read)，是指一个事务(t1)读取到某数据后，另一个事务(t2)修改了该数据，事务t1并未修改该数据，但当t1再次读取该数据时，发现两次读取的结果不一样。
## 产生不可重复读的原因
显然，不可重复读产生的原因，是事务t1的两次读取之间，有另一个事务修改了t1读取的数据。


    事务1        事务2
1   READ        *
2   *           READ
3   WRITE, READ *
4   *           READ, WRITE
    COMMIT
5   *           READ
                COMMIT
6   READ        *

?????

 */

-- 事务1:
## 请设置适当的事务隔离级别
SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITTED;
# set session transaction isolation level READ UNCOMMITTED ;

-- 开启事务
START TRANSACTION;
-- 时刻1 - 事务1读航班余票:
INSERT INTO result
SELECT NOW(), 1 t, tickets
FROM ticket
WHERE flight_no = 'CZ5525';

## 添加等待代码，确保事务2的第一次读取在事务1修改前发生
DO SLEEP(2);

-- 时刻3 - 事务1修改余票，并立即读取:
UPDATE ticket SET tickets = tickets - 1 WHERE flight_no = 'CZ5525';
INSERT INTO result
SELECT NOW(), 1 t, tickets
FROM ticket
WHERE flight_no = 'CZ5525';

## 添加代码，使事务2 的第2次读取在事务1修改之后，提交之前发生
# DO SLEEP(2);
# ????

COMMIT;

-- 时刻6 - 事务1在t2也提交后读取余票
## 添加代码，确保事务1在事务2提交后读取
DO SLEEP(3);

INSERT INTO result
SELECT NOW(), 1 t, tickets
FROM ticket
WHERE flight_no = 'CZ5525';

