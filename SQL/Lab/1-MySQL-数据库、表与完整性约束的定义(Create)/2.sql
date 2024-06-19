/* 
# 第2关: 创建表及表的主码约束

```
CREATE TABLE [IF NOT EXISTS] tbl_name
(列定义|表约束,...)
```
IF NOT EXISTS为可选短语, 其语义为仅当该表不存在时才创建表; 
如果不带该短语, 创建表时, 如果同名表已存在, 则输出报错信息; 
用"|"隔开的内容为多选一, "a|b"表示要么a, 要么b. 

```
列定义 ::=  列名  数据类型
      [NOT NULL | NULL] 
      [DEFAULT {常量 | (表达式)} ]
      [AUTO_INCREMENT] [UNIQUE [KEY]] [PRIMARY KEY]
      [COMMENT '列备注']
      [REFERENCES tbl_name (col_name)
           [ON DELETE RESTRICT|CASCADE|SET NULL|NO ACTION|SET DEFAULT]
           [ON UPDATE RESTRICT|CASCADE|SET NULL| NO ACTION|SET DEFAULT]]
      [[CONSTRAINT [约束名]] CHECK (表达式)] 
```
- [NOT NULL |NULL]表示空或非空约束, 缺省为NULL, 即该列的内容允许为空值, NOT NULL则约束该列的内容必须为非空; 
- DEFAULT关键字为列指定缺省值, 可以是常量, 也可以是表达式; 
- AUTO_INCREMENT指定该列为自增列(如1, 2, 3, ...), 一般用于自动编号, 显然只有数字类型的列才可以定义这一特性; 
- [UNIQUE]指定该列值具有唯一性(但可以有空值-甚至多个空值的存在, 如果该列没有定义NOT NULL约束); 
- PRIMARY KEY指定该列为主码, 相当于定义表的实体完整性约束; 只有当主码由单属性组成时, 才可以这样定义主码(主码由多属性组成时, 应当用表约束来定义); 
- COMMENT用来给列附加一条注释; 
- "REFERENCES"短语为该列定义参照完整性约束, 指出该列引用哪个表的哪一列的值, 以及违背参照完整性后的具体处理规则(多个规则中选一), 具体内容将在随后的练习里再讲解; 
- CHECK(表达式)为列指定"自定义约束", 只有使(表达式)的值为true的数据才允许写入数据库; 关键词CONSTRAINT用来为约束命名. 

```
表约束 ::= [CONSTRAINT [约束名]]
       | PRIMARY KEY (key_part,...)
       | UNIQUE (key_part,...)
       | FOREIGN KEY (col_name,...) 
            REFERENCES tbl_name (col_name,...)
                [ON DELETE RESTRICT|CASCADE|SET NULL|NO ACTION|SET DEFAULT]
                [ON UPDATE RESTRICT|CASCADE|SET NULL| NO ACTION|SET DEFAULT]
       | CHECK (表达式)
```
表约束以关键词CONSTRAINT打头, 后跟约束名, 约束名可以省略, 甚至连同关键词CONSTRAINT一同省略. 这时, 系统将自动为约束命名, DBMS取的名字一般可读性不强, 不好记, 会给将来可能的修改约束、删除约束等操作带来麻烦, 总是给约束取一个有意义的名字是个好习惯. 
表约束可以是主码约束(PRMARY KEY)、唯一性约束(UNIQUE)、外码约束(FOREIGN KEY)、CHECK约束等中的一种. 
建议遵守约定俗成的约束命名规则: 
- 主码约束以"PK_"打头, 后跟表名, 一个表只会有一个主码约束; 
- 外码约束以"FK_"打头, 后跟表名及列名; 
- CHECK约束以"CK_"打头, 后跟表名及列名. 

主码约束及唯一性约束中"key_part"的语法规则如下: 
`key_part::= {列名| (表达式)} [ASC | DESC]`
主码约束(索引)和唯一性约束(索引)均可由一至多个列(或含列的表达式)组成, 每个列(或含列的表达式)后用关键词ASC或DESC指示排序规则(升序或降序),ASC(升序)为缺省值, 可以省略. 系统会为主码约束和唯一性约束自动建索引. 
外码约束可以由1个或多个列组成, 后跟被引用表的名字和被引用的列, 引用列和被引用列要一一对应. 随后还可以定义违背参照完整性时的处理策略. 

定义主码有两种方法: 

- 单属性主码, 既可在列定义里用PRIMARY KEY约束指定主码, 也可以作为表约束单独定义; 
- 组合属性作主码时, 该主码只能定义为表约束. 
在MySQL中, 主码作列的约束时, 不能自主取名, 作表约束时, 才可以自主命名. 不过, MySQL对主码命名短语的支持只停留在语法上, 实际并没有实现(通过`constraint 约束名 primary key(...)`给主码约束所起的名字会被直接忽略). 

*/

/*
接下来, 建一个表t_user, 定义表的各列, 为表指定主码
字段名称	数据类型	备注
id  INT 用户ID,主码
username	VARCHAR(32)	用户名
password	VARCHAR(32)	密码
phone	CHAR(11)	手机号码
*/

/* CREATE TABLE t_user
(
    id INT PRIMARY KEY,
    username VARCHAR(32),
    password VARCHAR(32),
    phone CHAR(11)
); */

/*
CREATE TABLE t_user
(
    id INT,
    username VARCHAR(32),
    password VARCHAR(32),
    phone CHAR(11),
    CONSTRAINT PK_t_temp PRIMARY KEY (id)
    --在表约束定义主码, 并为主码约束命名为PK_t_temp
);
*/
-- show tables;
-- DESC t_user;
-- 查看表的结构

CREATE DATABASE TestDb;
USE TestDb;
CREATE TABLE t_emp
(
    id INT COMMENT '员工编号，主码',
    name VARCHAR(32) COMMENT '员工名称',
    deptId INT COMMENT '所在部门标号',
    salary FLOAT COMMENT '工资',
    CONSTRAINT PK_t_temp PRIMARY KEY (id)
);
--在表约束定义主码, 并为主码约束命名为PK_t_temp
-- DROP DATABASE TestDb;