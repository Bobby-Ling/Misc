DROP DATABASE IF EXISTS sparsedb;
CREATE DATABASE sparsedb;
USE sparsedb;
CREATE TABLE entrance_exam (
    sno INT PRIMARY KEY COMMENT '学号，主码',
    chinese INT COMMENT '语文',
    math INT COMMENT '数学',
    english INT COMMENT '英语',
    physics INT COMMENT '物理',
    chemistry INT COMMENT '化学',
    biology INT COMMENT '生物',
    history INT COMMENT '历史',
    geography INT COMMENT '地理',
    politics INT COMMENT '政治'
);
INSERT INTO
    entrance_exam (sno, chinese, math, english, physics, chemistry, biology, history, geography, politics)
VALUES
    (1, 115, 130, 130, 90,   88,   87,   NULL, NULL, NULL),
    (2, 120, 135, 125, NULL, NULL, NULL, 82,   95,   85  );

CREATE TABLE sc (
    sno INT COMMENT '学号',
    col_name VARCHAR(50) COMMENT '列名',
    col_value VARCHAR(50) COMMENT '列值'
);
