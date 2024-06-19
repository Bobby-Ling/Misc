# 请在以下空白处填写完成任务的语句，空白行可通过回车换行添加。
# 你也可以在命令行窗口完成任务，不过，在命令行键入的语句不会被保存。



CREATE DATABASE IF NOT EXISTS MyDb;
USE MyDb;

DROP table s;

CREATE TABLE IF NOT EXISTS  s
(
    sno CHAR(10) PRIMARY KEY COMMENT '学号,主码',
    name VARCHAR(32) NOT NULL COMMENT '姓名,不允许为空值',
    ID CHAR(18) UNIQUE COMMENT '身份证号, 不允许有两个相同的身份证号'
);
# 结束 