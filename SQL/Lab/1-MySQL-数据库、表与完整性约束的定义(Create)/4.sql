/*
# 第4关: CHECK约束

## 用户定义的完整性约束

关系数据库的完整性约束共有三类: 
    - 实体完整性约束(PRIMARY KEY)
    - 参照完整性约束(FOREIGN KEY)
    - 用户定义的完整性约束(CHECK)

## CHECK约束的定义方法

```
CHECK约束 ::= [CONSTRAINT [约束名]] CHECK (条件表达式)]
```

    - 约束仅涉及单个列, 则既可以定义为列约束, 也可以定义为表约束
    例如: "性别"列的取值仅限从("男","女")中取值; 
    - 约束涉及表的多个列, 则该约束只能定义为表约束
    例如: 如果职称为"教授", 则它的薪资应当不低于6000元. 这个约束涉及到"职称"和"薪资"两个列的内容, 故只能用表约束来实现. 

CHECK约束作列约束时, 紧跟在列定义之后定义(即跟在列名, 列数据类型之后申明); CHECK约束作为表约束时, 单独申明. 

```
-- 列约束
create table student(
  sex char(1) CONSTRAINT CK_student_sex CHECK(sex in ('M','F')),
)

-- 表约束
create table student(
  sex char(1),
  CONSTRAINT CK_student_sex CHECK(sex in ('M','F'))
)
```
*/

CREATE DATABASE IF NOT EXISTS MyDb;
USE MyDb;

CREATE TABLE products
(
    pid CHAR(10) PRIMARY KEY COMMENT '产品户ID,主码',
    name VARCHAR(32) COMMENT '产品名称',
    brand CHAR(10) COMMENT '品牌，只能是A B中的某一个',
    price INT COMMENT '价格，必须>0',
    CONSTRAINT CK_products_brand CHECK(brand in ('A','B')),
    CONSTRAINT CK_products_price CHECK(price > 0)
);
