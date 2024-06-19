/*
# 流程控制

## 变量的定义与赋值

- 用declare语句定义变量，并赋予默认值或初始值，未赋默认值 则初始值为null:
    DECLARE var_name [, var_name] ... type [DEFAULT value]
- 用set语句给变量赋值：
    SET variable = expr [, variable = expr]
    set语句还可以设置许多MySQL的配置参数。
- 通过select语句给变量赋值：
    select col into var_name from table; #将table表中的col列值赋给变量
    select语句可以带复杂的where，group by，having等短语。

## 复合语句与流程控制语句

1. 复合语句BEGIN...END
```
BEGIN
[statement_list]
END;
```
2. if语句
```
IF search_condition THEN  statement_list
[ELSEIF search_condition THEN statement_list] ...
[ELSE statement_list]
END IF;
```
3. while语句
```
WHILE search_condition DO
   statement_list
END WHILE;
```

## 存储过程

存储过程（Stored Procedure）是一种在数据库中存储复杂程序，以便外部程序调用的一种数据库对象。
存储过程是为了完成特定功能的 SQL 语句集，经编译创建并保存在数据库中，用户可通过指定存储过程的名字并给定参数（需要时）来调用执行。

### 存储过程的创建和查询

- 创建存储过程：
```
CREATE PROCEDURE proc1()
BEGIN
SELECT * FROM user;
END;
```
在命令行客户端中，如果有一行命令以分号结束，那么回车后，MySQL 将会执行该命令，但在创建存储过程中我们并不希望 MySQL 这么做。
MySQL 本身将分号识别为语句分隔符，因此必须临时重新定义分隔符以使 MySQL 将整个存储的程序定义传递给服务器。
要重新定义 MySQL 分隔符，请使用 delimiter命令。使用 delimiter 首先将结束符定义为//，完成创建存储过程后，使用//表示结束，然后将分隔符重新设置为分号（;）：
```
DELIMITER //
CREATE PROCEDURE proc1()
BEGIN
SELECT * FROM user;
END //
DELIMITER ;
注意：/也可以换成其他符号，例如$;
```
- 执行存储过程：call 存储过程名

- 创建带有参数的存储过程
    - IN：输入参数，也是默认模式，表示该参数的值必须在调用存储过程时指定，在存储过程中修改该参数的值不能被返回；
    - OUT：输出参数，该值可在存储过程内部被改变，并可返回；
    - INOUT：输入输出参数，调用时指定，并且可被改变和返回。

## 存储过程的查询和删除

- 查询
SHOW PROCEDURE STATUS WHERE db='数据库名';
SHOW CREATE PROCEDURE 数据库.存储过程名;
- 删除
DROP PROCEDURE [IF EXISTS] 数据库名.存储过程名;

 */


USE fib;

-- 创建存储过程`sp_fibonacci(in m int)`，向表fibonacci插入斐波拉契数列的前m项，及其对应的斐波拉契数。fibonacci表初始值为一张空表。请保证你的存储过程可以多次运行而不出错。

DROP PROCEDURE IF EXISTS sp_fibonacci;
DELIMITER $$
CREATE PROCEDURE sp_fibonacci(IN m INT)
#     m: [1,MAX]
BEGIN
    ######## 请补充代码完成存储过程体 ########
    /*不会逐行删除数据，而是直接释放整个表的数据页，
      会重置自增列的计数器，适合快速删除所有数据并且不涉及复杂的条件或外键约束*/
    TRUNCATE fibonacci;
    SET @count = 0;
    SET @fibo_n = 0;
    SET @fibo_n1 = 1;
    SET @temp = 0;
    WHILE @count < m DO
        INSERT INTO fibonacci
        VALUES (@count, @fibo_n);
        SET @count = @count + 1;
        SET @temp = @fibo_n1;
        SET @fibo_n1 = @fibo_n1 + @fibo_n;
        SET @fibo_n = @temp;
    END WHILE;
/*
01
11
12
23
35

*/
END $$

DELIMITER ;

CALL sp_fibonacci(2);

SELECT * FROM fibonacci;
 
