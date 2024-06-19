# 请在以下空白处填写完成任务的语句，空白行可通过回车换行添加。
# 你也可以在命令行窗口完成任务，不过，在命令行键入的语句不会被保存。


CREATE DATABASE IF NOT EXISTS MyDb;
USE MyDb;

CREATE TABLE dept
(
    deptNo INT PRIMARY KEY COMMENT '部门号，主键',
    deptName VARCHAR(32) COMMENT '部门名称'
)   COMMENT='部门';

CREATE TABLE staff
(
    staffNo INT PRIMARY KEY COMMENT '职工号, 主键',
    staffName VARCHAR(32) COMMENT '职工姓名',
    gender CHAR(1) COMMENT '性别, F-女, M-男',
    dob date COMMENT '出生日期',
    salary numeric(8,2) COMMENT '工资', 
    /* numeric(总的位数, 小数点后的位数) */
    deptNo INT COMMENT '部门号,外键',
    CONSTRAINT FK_staff_deptNo 
        FOREIGN KEY(deptNo)     /* 主表的字段 */
        REFERENCES dept(deptNo) /* 从表的字段 */
)   COMMENT='职工';


# 结束 