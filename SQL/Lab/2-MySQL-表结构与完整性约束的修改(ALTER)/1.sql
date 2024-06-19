-- 第1关: 修改表名

/* 
# ALTER TABLE语句

- 列
	- 添加删除
	- 修改数据类型
	- 修改列名
- 约束
	- 添加删除
- 索引
	- 添加删除(创建销毁)
- 表
	- 修改表名

## 语法

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
  | ALTER [COLUMN] 列名 {SET DEFAULT {常量 | (表达式)} | DROP DEFAULT}
  | CHANGE [COLUMN] 列名 新列名 数据类型 [列约束]
        [FIRST | AFTER col_name]
  | MODIFY [COLUMN] 列名 数据类型 [列约束]
        [FIRST | AFTER col_name]
  | RENAME COLUMN 列名 TO 新列名
  | RENAME {INDEX|KEY} 索引名 TO 新索引名
  | RENAME [TO|AS] 新表名
```

ALTER TABLE 表名
- ADD
	- 列
	- 约束(主码、外码、CHECK、UNIQUE等)
- DROP
	- 列
	- 约束
	- 索引(含Unique)
- ALTER
	- 修改/删除列的DEFAULT约束
- RENAME
```
rename to: change
rename as: alias
```
	- 列
	- 索引
	- 表
- MODIFY
	(列的定义)
	- 列数据类型
	- 列约束(MySQL未实现)
- CHANGE
	(列的定义和名称)
	- 列数据类型
	- 列约束(MySQL)
	- 列名

## 注意

1. MySQL未实现的功能
	- MODIFY列约束
	- CHANGE列约束
	对于以上二者, 可用ADD新增CHECK约束
	- DROP CONSTRAINT 主码约束名
	只能用DROP PRIMARY KEY
	因为MySQL并没有完全实现`constraint 约束名 primary key(...)`, 会忽略命名, 故会提示约束不存在
2. Default约束
	- alter语句
		- 增加Default约束: "alter 列 set default ..."
		- 删除列的default约束: "alter 列 drop default"
	- "Modify 列名 数据类型 ..." 
		- 如果该短语没有default约束, 就相当于删除了原来的default约束
		- 如果该短语带有default约束, 就相当于添加了default约束
			- 如果之前已有default约束, 则新的Default约束将代替原有的Default约束
3. 删除unique约束
	- "drop constraint 约束名"
	- "drop key 索引名"
	Unique索引的名字===Unique约束名, 初始值为列名(在更改列名后, Unique索引名并不会随之更改)
	> 唯一性(unique)约束实际是用Unique索引来实现的, Unique索引的名字总是与Unique约束名完全一样, 它们本就是同一套机制. 如果没有显式命名的话, Unqiue索引名或者说Unique约束名一般与列同名(组合属性作索引, 则与组合属性中的第1列同名). 但要注意是的, 在更改列名后, Unique索引名并不会随之更改. 在创建Unqiue约束时, 用"constriant"短语给约束取一个有意义的名字, 是一个值得推荐的习惯. 
4. 注意RENAME,MODIFY和CHANGE的区别: 
	- 仅改列名, 用RENAME
	- 只改数据类型不改名, 用MODIFY
	- 既改名又改数据类型, 用CHANGE
 */
-- DROP TABLE my_table;
-- DROP TABLE your_table;

CREATE DATABASE IF NOT EXISTS TestDb1;
USE TestDb1;
-- CREATE TABLE IF NOT EXISTS your_table
-- (
-- 	a INT primary key default(999)
-- );
-- -- IF NOT EXISTS使得创建同名表不会覆盖

ALTER TABLE your_table RENAME as my_table;
-- DESCRIBE my_table;