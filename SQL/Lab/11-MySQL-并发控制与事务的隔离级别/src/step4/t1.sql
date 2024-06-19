/*
# 幻读(phantom read)
幻读定义其实是有些争议的，在某些文献中，幻读被归为不可重复读(unrepeatable read)中的一类，而另一些则把它与不可重复读区分开来：
- 幻读是指一个事务(t1)读取到某数据后，另一个事务(t2)作了insert或delete操作，事务t1再次读取该数据时，魔幻般地发现数据变多了或者变少了(记录数量不一致)；
- 而不可重复读限指事务t2作了update操作，致使t1的两次读操作读到的结果(数据的值)不一致。

## 产生幻读的原因
显然，幻读产生的原因，是事务t1的两次读取之间，有另一个事务insert或delete了t1读取的数据集。
根据第一关介绍的基本知识，除了最高级别serializable(可串行化)以外的任何隔离级别，都有可能发生幻读。

## 编程要求
在低隔离级别，复现幻读是很容易的。本关要求大家在较高隔离级别，即仅次于serializable的repeatable read隔离级别下重现“幻读”现象，这样，可更好地体验不可重复读与幻读的区别。

设有表ticket记录了航班余票数，其结构如下表所示：
列	        类型	        说明
flight_no	char(6)	    primary key
aircraft	char(10)	执飞机型
tickets	    int	        余票数
现有两个涉及该表的并发事务t1和t2，分别定义在t1.sql和t2.sql代码文件中。

两次查询余票超过300张的航班信息(第2次查询已替你写好)；
在第1次查询之后，事务t2插入了一条航班信息并提交(t2.sql已替你写好)；
第2次查询的记录数增多,发生“幻读”。
不得修改t1的事务隔离级别(保持默认的repeatable read)
 */
-- 事务1（采用默认的事务隔离级别- repeatable read）:
USE testdb1;
SELECT @@transaction_isolation;
START TRANSACTION;
## 第1次查询余票超过300张的航班信息
SELECT * FROM ticket WHERE tickets > 300;
DO SLEEP(2);
-- 修改航班MU5111的执飞机型为A330-300：
UPDATE ticket SET aircraft = 'A330-300' WHERE flight_no = 'MU5111';
-- 第2次查询余票超过300张的航班信息
SELECT * FROM ticket WHERE tickets > 300;
COMMIT;