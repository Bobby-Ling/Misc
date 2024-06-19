-- 第4关: 添加、删除与修改约束

/*
# Alter table语句与约束

```
ALTER TABLE 表名
[修改事项 [, 修改事项] ...]

修改事项 ::=
    ADD [COLUMN] 列名 数据类型 [列约束]
        [FIRST | AFTER col_name]
  | ADD {INDEX|KEY} [索引名] [类型] (列1,...) 
  | ADD [CONSTRAINT [约束名]] 主码约束
  | ADD [CONSTRAINT [约束名]] UNIQUE约束
  | ADD [CONSTRAINT [约束名]] 外码约束
  | ADD [CONSTRAINT [约束名]] CHECK约束
  | DROP {CHECK|CONSTRAINT} 约束名
  | DROP [COLUMN] 列名
  | DROP {INDEX|KEY} 索引名
  | DROP PRIMARY KEY
  | DROP FOREIGN KEY fk_symbol
```

## 主码的删除与添加

- 删除主码: 
ALTER TABLE 表名 DROP PRIMARY KEY;
- 添加主码: 
ALTER TABLE 表名 ADD [CONSTRAINT [约束名]] PRIMARY KEY(列1,列2,...);

创建主码时, MySQL将创建主码索引; 删除主码, 即意味着删除主码索引. 反过来, 删除主码索引, 也意味着删除了主码约束
因此, 删除主码也可以是`drop index `PRIMARY` on 表名;`

> 迄今为止, MySQL尽管在语法上支持主码约束的命名, 但实际上并没有真正实现主码约束的命名功能. 
即, MySQL并不会创建用户语句中所指定的约束名. 所以, 试图通过约束名删除主码约束是行不通的. 
MySQL中, 所有的主码约束(主码索引)名均为PRIMARY, 无论怎么命名或更命, 这个名字都不会改变. 
由于PRIMARY是MySQL的保留字, 所以, 在引用这个主码约束(索引)名时, 必须用一对``符号将PRIMARY括起来. 

## 外码/Check约束/Unique约束的删除与添加

- 删除
ALTER TABLE 表名 DROP CONSTRAINT 约束名 
- 添加
ALTER TABLE 表名 ADD [CONSTRAINT [约束名]] 外码约束

一些区别:
- 创建外码时, MySQL将同步创建外码索引, 如果外码约束有显式命名, 则外码索引与外码约束同名. 如果外码约束未命名, 则外码索引与外码列的列名同名. 
删除外码约束时, 外码索引不会跟着删除. 如果将来重新创建了外码, 并显式命名, 则外码索引会自动更名(与外码约束名保持相同). 
- 添加Check约束时, 如果现有数据与该约束规则相矛盾, 则创建约束的请求会被拒绝. 
- 删除unique索引, 等同于删除unique约束. 反过来, 删除unique约束, 也等同于删除了unique索引
*/


/*
create table Dept(
    deptNo int primary key,
    deptName varchar(32),
    tel char(11),
    mgrStaffNo int
);
create table Staff(
    staffNo int,
    staffName varchar(32),
    gender char(1),
    dob date,
    salary numeric(8,2),
    dept int
);
*/

use MyDb;
-- 请在以下空白处填写适当的诘句, 实现编程要求. 
-- (1) 为表Staff添加主码
ALTER TABLE Staff 
    ADD CONSTRAINT PK_Staff PRIMARY KEY(staffNo);
-- (2) Dept.mgrStaffNo是外码, 对应的主码是Staff.staffNo,请添加这个外码, 名字为FK_Dept_mgrStaffNo:
ALTER TABLE Dept
    ADD CONSTRAINT FK_Dept_mgrStaffNo FOREIGN KEY(mgrStaffNo) REFERENCES Staff(staffNo);
-- (3) Staff.dept是外码, 对应的主码是Dept.deptNo. 请添加这个外码, 名字为FK_Staff_dept:
ALTER TABLE Staff
    ADD CONSTRAINT FK_Staff_dept FOREIGN KEY(dept) REFERENCES Dept(deptNo);
-- (4) 为表Staff添加check约束, 规则为: gender的值只能为F或M; 约束名为CK_Staff_gender:
ALTER TABLE Staff
    add CONSTRAINT CK_Staff_gender CHECK(gender regexp '[F|M]');
-- (5) 为表Dept添加unique约束: deptName不允许重复. 约束名为UN_Dept_deptName: 
ALTER TABLE Dept
    ADD CONSTRAINT UN_Dept_deptName UNIQUE(deptName);