/*
# 读脏
读脏(dirty read)，或者又叫脏读，是指一个事务(t1)读取到另一个事务(t2)修改后的数据，后来事务t2又撤销了本次修改(即事务t2以roll back结束)，数据恢复原值。这样，事务t1读到的数据就与数据库里的实际数据不一致，这样的数据被称为“脏”数据，意即不正确的数据。
## 读脏产生的原因
显然，产生读脏的原因，是事务t1读取数据时，修改该数据的事务t2还没有结束(commit或roll back，统称uncommitted),且t1读取的时间点又恰在t2修改该数据之后。
 */

-- 事务1:
USE testdb1;
## 请设置适当的事务隔离级别
SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

START TRANSACTION;

-- 时刻2 - 事务1读航班余票,发生在事务2修改之后
## 添加等待代码，确保读脏
DO SLEEP(0.1);
SELECT tickets FROM ticket WHERE flight_no = 'CA8213';
COMMIT;
