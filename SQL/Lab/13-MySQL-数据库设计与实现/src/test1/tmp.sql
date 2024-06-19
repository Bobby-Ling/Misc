CREATE TABLE user (
    user_id INT PRIMARY KEY AUTO_INCREMENT COMMENT '用户编号',
    firstname VARCHAR(50) NOT NULL COMMENT '名字',
    lastname VARCHAR(50) NOT NULL COMMENT '姓氏',
    dob DATE NOT NULL COMMENT '生日',
    sex CHAR(1) NOT NULL COMMENT '性别',
    email VARCHAR(50) COMMENT '邮箱',
    phone VARCHAR(30) COMMENT '联系电话',
    username VARCHAR(20) NOT NULL UNIQUE COMMENT '用户名',
    password CHAR(32) NOT NULL COMMENT '密码',
    admin_tag TINYINT DEFAULT 0 NOT NULL COMMENT '管理员标志'
);

CREATE TABLE passenger (
    passenger_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '旅客编号',
    id CHAR(18) NOT NULL UNIQUE COMMENT '证件号码',
    firstname VARCHAR(50) NOT NULL COMMENT '名字',
    lastname VARCHAR(50) NOT NULL COMMENT '姓氏',
    mail VARCHAR(50) COMMENT '邮箱',
    phone VARCHAR(20) NOT NULL COMMENT '电话',
    sex CHAR(1) NOT NULL COMMENT '性别',
    dob DATE COMMENT '生日'
);

CREATE TABLE airport (
    airport_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '编号',
    iata CHAR(3) NOT NULL UNIQUE COMMENT '国际民航组织编码',
    icao CHAR(4) NOT NULL UNIQUE COMMENT '国际航运协会编码',
    name VARCHAR(50) NOT NULL KEY COMMENT '机场名称',
    city VARCHAR(50) COMMENT '所在城市',
    country VARCHAR(50) COMMENT '所在国家',
    latitude DECIMAL(11, 8) COMMENT '纬度',
    longitude DECIMAL(11, 8) COMMENT '经度'
);

CREATE TABLE airline (
    airline_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '编号',
    name VARCHAR(30) NOT NULL COMMENT '名称',
    iata CHAR(2) NOT NULL UNIQUE COMMENT '国际民航组织编码'
);

CREATE TABLE airplane (
    airplane_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '编号',
    type VARCHAR(50) NOT NULL COMMENT '机型',
    capacity SMALLINT NOT NULL COMMENT '座位',
    identifier VARCHAR(50) NOT NULL COMMENT '标识'
);

CREATE TABLE flightschedule (
    flight_no CHAR(8) PRIMARY KEY COMMENT '航班号',
    departure TIME NOT NULL COMMENT '起飞时间',
    arrival TIME NOT NULL COMMENT '到达时间',
    duration SMALLINT NOT NULL COMMENT '飞行时长',
    monday TINYINT DEFAULT 0 COMMENT '周一',
    tuesday TINYINT DEFAULT 0 COMMENT '周二',
    wednesday TINYINT DEFAULT 0 COMMENT '周三',
    thursday TINYINT DEFAULT 0 COMMENT '周四',
    friday TINYINT DEFAULT 0 COMMENT '周五',
    saturday TINYINT DEFAULT 0 COMMENT '周六',
    sunday TINYINT DEFAULT 0 COMMENT '周日'
);

CREATE TABLE flight (
    flight_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '飞行编号',
    departure DATETIME NOT NULL COMMENT '起飞时间',
    arrival DATETIME NOT NULL COMMENT '到达时间',
    duration SMALLINT NOT NULL COMMENT '飞行时长'
);

CREATE TABLE ticket (
    ticket_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '票号',
    seat CHAR(4) COMMENT '坐位号',
    price DECIMAL(10, 2) NOT NULL COMMENT '价格'
);

