
/*
# 第3关: 创建外码约束(foreign key)

## 外码

外码是表中的一个或一组字段(属性), 它可以不是本表的主码, 但它与某个主码(同一表或其它表的主码)具有对应关系(语义完全相同). 
相当于对从表的某个主码的"引用"

## 外码约束(参照完整性约束)
外码用来在数据之间(即外码与其对应的主码间)建立关联. 参照完整性约束用于约束外码列的取值范围: 
外码列的取值要么为空, 要么等于其对应的主码列的某个取值. 

## 定义外码约束

可在定义表的同时定义各种完整性约束规则(当然包括外码约束, 亦即参照完整性约束). 外码约束既可以定义为列约束, 亦可定义为表约束:

1. 列级外码约束
```
列级外码约束 ::=  列名  数据类型
      [REFERENCES tbl_name (col_name)
      [ON DELETE RESTRICT|CASCADE|SET NULL|NO ACTION|SET DEFAULT]
      [ON UPDATE RESTRICT|CASCADE|SET NULL| NO ACTION|SET DEFAULT]]
-- MySQL尚未实现
```

2. 表级外码约束
```
表级外码约束 ::= [CONSTRAINT [约束名]]
        FOREIGN KEY (col_name,...) 
        REFERENCES tbl_name (col_name,...)
           [ON DELETE RESTRICT|CASCADE|SET NULL|NO ACTION|SET DEFAULT]
           [ON UPDATE RESTRICT|CASCADE|SET NULL| NO ACTION|SET DEFAULT] 
```
表级外码约束的好处
    - 可以给约束命名
    - 支持多属性组合外码(即外码由多个列组成). 
外码约束的名称一般以"FK_"为前缀, 这是约定俗成的规则. 

> 事实上, 外码约束定义在表一级, 是不二的选择, 因为MySQL对列级外码约束的支持仅停留在语法检查阶段, 实际并没有实现(至少8.0.22还没有实现). 

*/

CREATE DATABASE IF NOT EXISTS MyDb;
USE MyDb;

CREATE TABLE dept
(
    deptNo INT PRIMARY KEY COMMENT '部门号，主键',
    deptName VARCHAR(32) COMMENT '部门名称'
)   COMMENT='部门';

CREATE TABLE staff
(
    staffNo INT PRIMARY KEY COMMENT '职工号, 主键',
    staffName VARCHAR(32) COMMENT '职工姓名',
    gender CHAR(1) COMMENT '性别, F-女, M-男',
    dob date COMMENT '出生日期',
    salary numeric(8,2) COMMENT '工资', 
    /* numeric(总的位数, 小数点后的位数) */
    deptNo INT COMMENT '部门号,外键',
    CONSTRAINT FK_staff_deptNo 
        FOREIGN KEY(deptNo)     /* 主表的字段 */
        REFERENCES dept(deptNo) /* 从表的字段 */
)   COMMENT='职工';
