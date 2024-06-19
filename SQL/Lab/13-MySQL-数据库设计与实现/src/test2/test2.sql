DROP DATABASE IF EXISTS theater;
CREATE DATABASE theater;
USE theater;
# ^[\u4e00-\u9fa5]+\((.+)\)：\s*(([^\n]+\n)+?\n) -> CREATE TABLE $1(\n$2);\n\n
# ^([\u4e00-\u9fa5]+)\((.+)\) -> \t $2 VARCHAR(50) COMMENT '$1'
# ,\n\n -> \n

CREATE TABLE schedule (
    schedule_ID INT COMMENT '标识号' PRIMARY KEY,
    date DATE COMMENT '日期',
    time TIME COMMENT '时间',
    price INT COMMENT '票价',
    number INT COMMENT '票数'
);

CREATE TABLE movie (
    movie_ID INT COMMENT '标识号' PRIMARY KEY,
    title VARCHAR(50) COMMENT '电影名',
    type VARCHAR(50) COMMENT '类型',
    runtime TIME COMMENT '时长',
    release_date DATE COMMENT '首映日期',
    director VARCHAR(50) COMMENT '导演姓名',
    starring VARCHAR(50) COMMENT '主演姓名',

    schedule_ID INT,
    FOREIGN KEY (schedule_ID) REFERENCES schedule(schedule_ID)
);

CREATE TABLE customer (
    c_ID INT COMMENT '标识号' PRIMARY KEY,
    name VARCHAR(50) COMMENT '姓名',
    phone VARCHAR(50) COMMENT '手机号'
);

CREATE TABLE hall (
    hall_ID INT COMMENT '标识号' PRIMARY KEY,
    mode VARCHAR(50) COMMENT '放映模式',
    capacity INT COMMENT '容纳人数',
    location VARCHAR(50) COMMENT '位置',

    schedule_ID INT,
    FOREIGN KEY (schedule_ID) REFERENCES schedule(schedule_ID)
);

CREATE TABLE ticket (
    ticket_ID INT COMMENT '标识号' PRIMARY KEY,
    seat_num INT COMMENT '座位号',

    c_ID INT,
    schedule_ID INT,
    FOREIGN KEY (c_ID) REFERENCES customer(c_ID),
    FOREIGN KEY (schedule_ID) REFERENCES schedule(schedule_ID)
);

  
  