# 请在以下适当的空白处填写SQL语句，完成任务书的要求。空白行可通过回车换行添加。 

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



/* *********** 结束 ************* */