/* 
# 第6关：UNIQUE约束

唯一性约束(Unique约束)用于保证表中字段取值的唯一性

## UNIQUE约束的语法

```
-- 列约束
col_name data_type UNIQUE

-- 表约束
[CONSTRAINT [约束名]] UNIQUE(列1, 列2, ...)
```

类似于PRIMARY KEY约束, 但是:
- 不要求字段必须非空(Not Null)
- 一个表可以定义多个Unique约束

 */

CREATE DATABASE IF NOT EXISTS MyDb;
USE MyDb;

CREATE TABLE s
(
    sno CHAR(10) PRIMARY KEY COMMENT '学号,主码',
    name VARCHAR(32) NOT NULL COMMENT '姓名,不允许为空值',
    ID CHAR(18) UNIQUE COMMENT '身份证号, 不允许有两个相同的身份证号'
);