-- 第2关: 添加与删除字段

/*
# ALTER TABLE语句

## 给表添加字段

```
ALTER TABLE 表名
[修改事项 [, 修改事项] ...]

修改事项 ::=
    ADD [COLUMN] 列名 数据类型 [列约束]
        [FIRST | AFTER col_name]
    ...
[FIRST | AFTER col_name]指示添加的位置, 默认为表的最后一列
```

对于表:
create table student(
  sno char(10) primary key,
  sname varchar(32) not null,
  sex char(2),
  age int
);
添加mobile字段:
alter table student 
    add mobile char(11) constraint CK_student_mobile check(mobile rlike '1[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
rlike还可以用regexp替代

## 删除表中的字段

要将表student中age int改为DOB date:
    - `alter table student change age DOB date`
    表student可能已经存储了数据, 直接将一个int型的列改成date型的列, 将出现类型不匹配错误;
    并且原来存储的年龄信息都将丢失
    - `alter table sudent add DOB date`添加列DOB, 再用`alter table student drop age删除列age`:
        - `alter table sudent add DOB date after sex`
        - `update student set DOB = date_add('2020-9-1', interval -1*age year)`
        - `alter table student drop age`

*/


use MyDb;

-- 请在以下空白处添加适当的SQL代码, 实现编程要求
-- 语句1: 删除表orderDetail中的列orderDate
ALTER TABLE orderDetail DROP orderDate;
-- 语句2: 添加列unitPrice
ALTER TABLE orderDetail ADD unitPrice numeric(10,2) COMMENT '产品的成交单价'