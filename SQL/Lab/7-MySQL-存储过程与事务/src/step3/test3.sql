/*
# 事务的定义和应用

- 开启事务：
    START TRANSACTION 或 BEGIN (前者兼容性更好)
- 事务提交：
    COMMIT
- 事务回滚：
    ROLLBACK
- 开启或关闭当前会话的自动事务模式
    SET autocommit = ON|OFF
    也可用1|0,true|false代替ON|OFF。
    缺省情况下，autocommit模式被设置为ON，即你在命令行提交的每一条语句会自动封装成一个事务，即使下一条语句发生错误，前一条语句产生的结果也不可撤销。
注意，事务内部不允许嵌套另一个事务，尽量不要在事务内部使用DDL语句，因为即使事务回滚,DDL语句对数据库的修改也不会撤销。

## 编程要求

在金融应用场景数据库中，编程实现一个转账操作的存储过程sp_transfer，实现从一个帐户向另一个帐户转账。该过程有5个输入参数：
applicant_id 付款人编号
source_card_id 付款卡号
receiver_card_id 收款人编号
dest_card_id 收款卡号
amount 转账金额
还有1个整型输出参数：
return_code 1：正常转账；0:转账不成功

转账操作涉及对表bank_card的操作(在生产环境中，至少还要记录转账操作本身相关的信息至转账表，在实验环境中没有设计这样的表，从略；另外，生产环境中，当银行卡被冻结，或被卡主挂失后，都不能进行转账，在实验环境中，没有设计相应的字段 ，故也从略)。

注意事项：

仅当转款人是转出卡的持有人时，才可转出；
仅当收款人是收款卡的持有人时，才可转入；
储蓄卡之间可以相互转账；
允许储蓄卡向信用卡转账，称为信用卡还款(允许替它人还款)，还款可以超过信用卡余额，此时，信用卡余额为负数；
信用卡不能向储蓄卡转账；
转账金额不能超过储蓄卡余额；

附上 bank_card(银行卡)表结构
字段名称	    数据类型	        约束	                    说明
b_number	CHAR(30)	    PRIMARY KEY	            银行卡号
b_type	    CHAR(20)	    无	                    银行卡类型(储蓄卡/信用卡)
b_c_id	    INTEGER	        NOT NULL FOREIGN KEY	所属客户编号,引用自client表的c_id字段。
b_balance	NUMERIC(10,2)	NOT NULL	            余额,信用卡余额系指已透支的金额
 */

USE finance1;

-- 在金融应用场景数据库中，编程实现一个转账操作的存储过程sp_transfer_balance，实现从一个帐户向另一个帐户转账。
-- 请补充代码完成该过程：
DELIMITER $$
DROP PROCEDURE IF EXISTS sp_transfer;
CREATE PROCEDURE sp_transfer(
    IN applicant_id INT,
    IN source_card_id CHAR(30),
    IN receiver_id INT,
    IN dest_card_id CHAR(30),
    IN amount NUMERIC(10, 2),
    OUT return_code INT)
BEGIN
    DECLARE src_c_id INT;
    DECLARE src_number CHAR(30);
    DECLARE src_type CHAR(20);
    DECLARE src_balance DECIMAL(10, 2);
    DECLARE dest_c_id INT;
    DECLARE dest_number CHAR(30);
    DECLARE dest_type CHAR(20);
    DECLARE dest_balance DECIMAL(10, 2);

    SET return_code = 1;

    # 找不到则为NULL
    SELECT
        b_c_id,
        b_number,
        b_type,
        b_balance
    INTO
        src_c_id,
        src_number,
        src_type,
        src_balance
    FROM bank_card
    WHERE b_c_id = applicant_id AND b_number = source_card_id;
    SELECT
        b_c_id,
        b_number,
        b_type,
        b_balance
    INTO
        dest_c_id,
        dest_number,
        dest_type,
        dest_balance
    FROM bank_card
    WHERE b_c_id = receiver_id AND b_number = dest_card_id;

    #     仅当转款人是转出卡的持有人时，才可转出；
    #     仅当收款人是收款卡的持有人时，才可转入；
    #     信用卡不能向储蓄卡转账；
    #     转账金额不能超过储蓄卡余额；
    IF src_c_id IS NULL OR
        dest_c_id IS NULL OR
        (src_type = '信用卡' AND dest_type = '储蓄卡') OR
        (src_type = '储蓄卡' AND amount > src_balance)
    THEN
        SET return_code = 0;
    END IF;

    START TRANSACTION ;
    #     储蓄卡之间可以相互转账；
    #     允许储蓄卡向信用卡转账，称为信用卡还款(允许替它人还款)，还款可以超过信用卡余额，此时，信用卡余额为负数；
    IF return_code = 1 THEN
        # SELECT * FROM bank_card WHERE b_number = src_number OR b_number = dest_number;

        UPDATE bank_card
        SET b_balance = b_balance - IF(src_type = '信用卡', -amount, amount)
        WHERE b_number = src_number;
        UPDATE bank_card
        SET b_balance = b_balance + IF(dest_type = '信用卡', -amount, amount)
        WHERE b_number = dest_number;

        # SELECT * FROM bank_card WHERE b_number = src_number OR b_number = dest_number;
    END IF;
    COMMIT;

END$$

DELIMITER ;

/*SET @ret = 0;
CALL sp_transfer(1000, 4270204201286893, NULL, NULL, NULL, @ret);*/
/*  end  of  your code  */

/*
3154.00 8470.00
2059.00 8470.00

*/