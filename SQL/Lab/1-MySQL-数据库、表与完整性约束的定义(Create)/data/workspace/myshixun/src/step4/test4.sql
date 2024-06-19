# 请在以下空白处填写完成任务的语句，空白行可通过回车换行添加。
# 你也可以在命令行窗口完成任务，不过，在命令行键入的语句不会被保存。


CREATE DATABASE IF NOT EXISTS MyDb;
USE MyDb;

CREATE TABLE products
(
    pid CHAR(10) PRIMARY KEY COMMENT '产品户ID,主码',
    name VARCHAR(32) COMMENT '产品名称',
    brand CHAR(10) COMMENT '品牌，只能是A B中的某一个',
    price INT COMMENT '价格，必须>0',
    CONSTRAINT CK_products_brand CHECK(brand in ('A','B')),
    CONSTRAINT CK_products_price CHECK(price > 0)
);


# 结束 