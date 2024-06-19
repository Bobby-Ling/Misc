/*
# 函数定义和应用

函数其实有多种，比如标量函数(仅返回一个值)和表函数(返回结果是表),语法也各不相同。这里，我们仅给出一个简化的创建标量函数的语法:

create function语句的语法：
```
create function function_name([para data_type[,...]])
returns data_type
begin
    function_body;
    return expression;
end
```
- function_name:    函数名；
- para:             参数名；
- data_type:        参数的数据类型；
    一个函数可以没有参数，也可以有多个。多参数间用逗号分隔。
- function_body:    函数体。即由合法的SQL语句组成的程序段。
- expression:       函数返回值，可以是常量、表达式，甚至是一条select语句查询的值（必须保证结果唯一);该值类型应与returns短语定义的类型相同。
函数一旦定义，就可以像内部函数一样使用，比如出现在select列表、表达式、以及where子句的条件中。

MySQL的函数定义与存储过程的定义一样，在定义函数之前要用“delimiter 界符”语句指定函数定义的结束界符，并在函数定义后，再次使用“delimiter 界符”语句恢复MySQL语句的界符(分号)。

# 编程要求
主在右侧文件编辑器补充代码，完成以下编程任务：
1) 用create function语句创建符合以下要求的函数：
依据客户编号计算其所有储蓄卡余额的总和。
函数名为：get_deposit
2) 利用创建的函数，仅用一条SQL语句查询存款总额在100万(含)以上的客户身份证号，姓名和存款总额(total_deposit)，结果依存储总额从高到低排序。
 */

USE finance1;
SET GLOBAL log_bin_trust_function_creators = 1;
DROP FUNCTION IF EXISTS get_deposit;
/*
   用create function语句创建符合以下要求的函数：
   依据客户编号计算该客户所有储蓄卡的存款总额。
   函数名为：get_Records。函数的参数名可以自己命名:*/

DELIMITER $$
CREATE FUNCTION get_deposit(client_id INT)
    RETURNS NUMERIC(10, 2)
BEGIN
    RETURN (
        SELECT SUM(b_balance)
        FROM bank_card
        WHERE b_type = '储蓄卡' AND b_c_id = client_id
        GROUP BY b_c_id
        );
END$$
DELIMITER ;

/*  应用该函数查询存款总额在100万以上的客户身份证号，姓名和存储总额(total_deposit)，
    结果依存款总额从高到代排序  */
SELECT
    c_id_card,
    c_name,
    get_deposit(c_id) AS total_deposit
FROM client
WHERE get_deposit(c_id) >= 1000000
ORDER BY get_deposit(c_id) DESC;

/*  代码文件结束     */