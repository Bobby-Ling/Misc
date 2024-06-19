-- 事务2
## 请设置适当的事务隔离级别以构造不可重复读
SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITTED;
START TRANSACTION;
-- 时刻2 - 事务2在事务1读取余票之后也读取余票
## 添加代码，确保事务2的第1次读发生在事务1读之后，修改之前
DO SLEEP(1);


INSERT INTO result
SELECT NOW(), 2 t, tickets
FROM ticket
WHERE flight_no = 'CZ5525';

-- 时刻4 - 事务2在事务1修改余票但未提交前再次读取余票，事务2的两次读取结果应该不同
## 添加代码，确保事务2的读取时机
DO SLEEP(2);

INSERT INTO result
SELECT NOW(), 2 t, tickets
FROM ticket
WHERE flight_no = 'CZ5525';

-- 事务2立即修改余票
UPDATE ticket SET tickets = tickets - 1 WHERE flight_no = 'CZ5525';

-- 时刻5 - 事务2 读取余票（自己修改但未交的结果）:
-- set @n = sleep(1);
DO SLEEP(1);

INSERT INTO result
SELECT NOW(), 2 t, tickets
FROM ticket
WHERE flight_no = 'CZ5525';

COMMIT;
