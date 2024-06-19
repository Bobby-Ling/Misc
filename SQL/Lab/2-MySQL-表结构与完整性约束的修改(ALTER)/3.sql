-- 第3关: 修改字段

/*
# ALTER TABLE语句

```
ALTER TABLE 表名
[修改事项 [, 修改事项] ...]

修改事项 ::=
    ...
  | ALTER [COLUMN] 列名 {SET DEFAULT {常量 | (表达式)} | DROP DEFAULT}
    列的DEFAULT约束
  | CHANGE [COLUMN] 列名 新列名 数据类型 [列约束]
        [FIRST | AFTER col_name]
    列名, 数据类型, 约束(相当于删除之前的列, 再在指定位置插入一个全新的列)
    注意: 新列带的CHECK约束只做语法检查!! 因此应该先DROP之前的列, 再ADD新的列
  | MODIFY [COLUMN] 列名 数据类型 [列约束]
        [FIRST | AFTER col_name]
    数据类型, 约束
  | RENAME COLUMN 列名 TO 新列名
    列名
    关键字COLUMN不能省略
  | RENAME {INDEX|KEY} 索引名 TO 新索引名
  | RENAME [TO|AS] 新表名
```

## 修改字段的名称
...

## 修改字段的数据类型和约束
...

## 修改字段在表中的位置
MODIFY
需要把列名、数据类型和约束完整地重述一遍, 并在其后带上位置指示短语: FIRST或AFTER某个列. 
注意: 如果数据类型和约束重述的跟之前的不一样, 则相当于修改了这个列, 如果重述的列名跟之前的不一样, 则会抛出错误信息(列不存在)
*/

use MyDb;

-- 请在以下空白处添加适当的SQL语句, 实现编程要求

/*
create table addressBook(
   serialNo int auto_increment primary key,
   name char(32),
   company char(32),
   position char(10),
   workPhone char(16),
   mobile char(11),
   QQ int,
   weixin char(12)
);
*/
ALTER TABLE addressBook 
    MODIFY QQ char(12),
    RENAME COLUMN weixin TO wechat
