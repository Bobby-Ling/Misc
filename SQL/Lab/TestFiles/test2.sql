/*DELIMITER $$
DROP PROCEDURE IF EXISTS func;
CREATE PROCEDURE func()
BEGIN
    IF EXISTS(
        SELECT *
        FROM property
        WHERE pro_type = 1
        ) THEN
        SELECT '111';
    ELSE
        SELECT '222';
    END IF;
END $$
DELIMITER ;

CALL func();*/

/*
# 触发器

触发器是与某个表绑定的命名存储对象，与存储过程一样，它由一组语句组成，当这个表上发生某个操作(insert,delete,update)时，触发器被触发执行。触发器一般用于实现业务完整性规则。当primary key,foreign key, check等约束都无法实现某个复杂的业务规则时，可以考虑用触发器来实现。

## 触发器的创建

创建触发器的语句：
CREATE TRIGGER trigger_name
trigger_time trigger_event
ON tbl_name
FOR EACH ROW
trigger_body

- trigger_name:   每个触发器有一个唯一的命名
- trigger_time:   触发的时机，二选一： BEFORE | AFTER
- trigger_event:  触发事件，三选一： INSERT | UPDATE | DELETE
- tbl_name:       与触发器绑定的表
- trigger_body:   触发器程序体，可由变量定义、赋值，流程控制，SQL语句等组成。
    但触发器体内不能使用create,alter,drop等DDL语句,也不能使用start transaction, commit,rollback等事务相关语句。
与创建存储过程、函数一样，创建触发器时也要用delimiter语句重新指定触发器定义语句的界符(触发器内语句的分隔符仍为分号)，在触发器定义之后，再把界符更改回去。

## before与after触发器的区别:

before触发器在试图激活触发器的那条语句(insert|delete|update)之前执行。
after触发器仅在before触发器(如果有的话)和试图激活触发器的那条语句都成功执行后才执行。
before触发器或after触发器如果未能成功执行，则激活触发器的语句也不会执行。

## 触发器内的特殊表

在触发器内可以使用两类特殊表：
old表和new表.它总是与触发器绑定的表有相同的结构，且只能在触发器内访问。
delete触发器可以访问old表,其内容为被delete掉的数据。
insert触发器可以访问new表,其内容为insert的新数据。
update触发器可以访问old表和new表，old表保存着修改前的数据，new表保存着修改后的内容。

## 编程要求
在右侧代码文件编辑器里补充代码，实现本任务所要求的完整性业务规则。当插入的数据不符合要求时，拒绝数据的插入，并反馈出错信息：
1) pro_type数据不合法时，显示:
type x is illegal!
这里，x系指试图插入的pro_type值。
2) pro_type = 1,但NEW.pro_pif_id不是finances_product表中的某个主码值，显示:
finances product #x not found!
这里,x系指试图插入的pro_pif_di的值。
3) pro_type = 2,但NEW.pro_pif_id不是insurance表中的某个主码值，显示:
insurance #x not found!
这里,x系指试图插入的NEW.pro_pif_id的值。
4) pro_type = 3,但NEW.pro_pif_id不是fund表中的某个主码值，显示:
fund #x not found!
这里,x系指试图插入的NEW.pro_pif_id的值。

提示：
1) 查阅MySQL的字符串函数，构造出错信息；
2) 当数据不合法时，用signal sqlstate 语句抛出异常，并设置出错信息：
SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = msg;
其中，通用SQLSTATE '45000'意指用户定义的待处理异常，msg需替换成你想要显示的提示信息(不超过128个字符)。
 */

USE finance1;
DROP TRIGGER IF EXISTS before_property_inserted;
-- 请在适当的地方补充代码，完成任务要求：
DELIMITER $$
CREATE TRIGGER before_property_inserted
    BEFORE INSERT
    ON property
    FOR EACH ROW
BEGIN
    IF NEW.pro_type = 1
    THEN
        IF NOT EXISTS(
            SELECT *
            FROM finances_product
            WHERE p_id = NEW.pro_pif_id
            )
        THEN
            SET @tmp = 1;
        END IF;
    ELSE
        SET @msg = CONCAT('type x is illegal!');
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = @msg;
    END IF;
END;
$$
DELIMITER ;

