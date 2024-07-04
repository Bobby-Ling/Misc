/*
# 第5关：DEFAULT约束

## DEFAULT约束的语法

default约束只能定义为列一级约束, 即在需要指定默认值的列之后用关键字DEFAULT申明默认值, 其语法为:
```
col_name data_type [DEFAULT {literal | (expr)} ]
```
> 该列可能还有NOT NULL, UNIQUE, AUTO_INCREMENT, CHECK, FOREIGN KEY等其它约束
默认值可以是
    - 常量
    - 表达式
    表达式要写在一对括弧里 

## 例子

```
create table student(
    name varchar(32) NOT NULL,
    sex char(2) default '男',
);
create table `order`(
   orderNo int auto_increment primary key, 
   orderDate date default (curdate()), 
);
-- 表名称order前后的`号是必须的, 因为order是MySQL的关键字, 当表名或列名与关键字冲突时, 名称前后必须加`号
```

*/

CREATE DATABASE IF NOT EXISTS MyDb;
USE MyDb;

CREATE TABLE hr (
    id CHAR(10) PRIMARY KEY COMMENT '工号,主码',
    name VARCHAR(32) NOT NULL COMMENT '姓名,不允许为空值',
    mz CHAR(16) DEFAULT '汉族' COMMENT '民族, 缺省值为“汉族”'
);