# 请在以下空白处填写完成任务的语句，空白行可通过回车换行添加。
# 你也可以在命令行窗口完成任务，不过，在命令行键入的语句不会被保存。


CREATE DATABASE IF NOT EXISTS MyDb;
USE MyDb;

CREATE TABLE hr
(
    id CHAR(10) PRIMARY KEY COMMENT '工号,主码',
    name VARCHAR(32) NOT NULL COMMENT '姓名,不允许为空值',
    mz CHAR(16) DEFAULT '汉族' COMMENT '民族, 缺省值为“汉族”'
);

# 结束 