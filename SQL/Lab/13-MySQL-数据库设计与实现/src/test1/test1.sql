/*
1.用户(user)
用户分两类，普通用户可以订票，管理用户有权限维护和管理整个系统的运营。为简单起见，两类用户合并，用admin_tag标记区分。用户的属性(包括业务约束)有：
用户编号: user_id int 主码,自动增加
名字: firstname varchar(50) 不可为空
姓氏: lastname varchar(50) 不可为空
生日: dob date 不可为空
性别: sex char(1) 不可为空
邮箱: email varchar(50)
联系电话: phone varchar(30)
用户名: username varchar(20) 不可空,不可有重
密码: password char(32) 不可空
管理员标志: admin_tag tinyint 缺省值0(非管理员),不能空

2. 旅客(passenger)
用户登录系统不一定是替自己买票，所以用户和旅客信息是分开存储的。属性有：
旅客编号: passenger_id int 自增，主码
证件号码: id char(18) 不可空 不可重
名字：firstname varchar(50) 不可空
姓氏: lastname varchar(50) 不可空
邮箱：mail varchar(50)
电话: phone varchar(20) 不可空
性别: sex char(1) 不可空
生日: dob date

3.机场(airport)
有以下属性：
编号: airport_id int 自增，主码
国际民航组织编码：iata char(3) 不可空，全球唯一
国际航运协会编码: icao char(4) 不可空，全球唯一
机场名称: name varchar(50) 不可空，普通索引
所在城市: city varchar(50)
所在国家: country varchar(50)
纬度: latitude decimal(11,8)
经度: longitude decimal(11,8)
全球每个机场都有唯一IATA编码和ICAO编码，IATA为3个字符，ICAO为4个字符。例如首都机场的(IATA,ICAO)分别为(PEK,ZBAA)，大兴机场为(PKX,ZBAD),天河机机场为(WUH,ZHHH)。在飞机登记牌上出发地和到达地均用IATA表示。为能在地图上显示机场位置，需要记录经纬度信息。

4.航空公司(airline)
有以下属性:
编号：airline_id int 自增，主码
名称：name varchar(30) 不可空
国际民航组织编码: iata char(2) 不可空，具全球唯一性
航空公司的IATA编码为2位，如东航为MU，国航为CA,南航为CZ等，航班号一般以所属航空公司的IATA码为前缀。

5.民航飞机(airplane)
有属性：
编号：airplane_id int 自增，主码
机型：type varchar(50) 不可空，如B737-300,A320-500等
座位: capacity smallint 不可空
标识: identifier varchar(50) 不可空

6.航班常规调度表(flightschedule)
舤班一般以周次安排，例如：每周两个班次，周一和周五。
有属性：
航班号: flight_no char(8) 主码
起飞时间: departure time 非空
到达时间: arrival time 非空
飞行时长: duration smallint 非空
周一：monday tinyint 缺省0
周二：tuesday tinyint 缺省0
周三：wednesday tinyint 缺省0
周四：thursday tinyint 缺省0
周五：friday tinyint 缺省0
周六：saturday tinyint 缺省0
周日：sunday tinyint 缺省0
飞行时长一般以分种计。

7.航班表(flight)
航班依航班常规调度表为基准安排。但调度表不是一成不变，也不是每个既定的航都实际起飞，也不总是按既定的时间起飞，所以实飞航班必须单独安排并记录。
要记录的信息有：
飞行编号：flight_id int 自增，主码
起飞时间: departure datetime 非空
到达时间: arrival datetime 非空
飞行时长：duration smallint 非空
有的系统还会实时显示航班经纬度和高度位置，这里我们作了简化，去掉了实时飞行信息。

8.机票(ticket)
用户可替自己或其亲友购买某个航班的机票。机票的属性有：
票号：ticket_id int 自增，主码
坐位号：seat char(4)
价格：price decimal(10,2) 不能空

9.实体间的联系
实体间的联系都清楚地标注在ER图中：

每个航空公司都有一个母港(机场)，又叫基地。大的机场可能会是多家公司的基地，小型机场可能不是任何航空公司的基地。
每个航班属于一家航空公司，航空公司可以很多航班。
任何一驾民航飞机属于一家航空公司，航空公司可以有多驾飞机。
每驾飞机可以执飞多个航班，一个飞行航班由一架飞机执飞。
一个航班根据执飞机型可以售出若干机票。一张机票是某个特定航班的机票。
用户可以多次订票，旅客可以多次乘坐飞机。一张机票肯定是某个用户为某个特定的旅客购买的特定航班的机票。即机票信息不仅跟乘坐人有关，同时记录购买人信息(虽然两者有时是同一人)。为简单起见，订购时间没有考虑。
无论常规计划的航班，还是实际飞行航班，都是从某个机场出发，到达另一个机场。但一个机场可以是很多个航班的出发地，也是很多航班的到达地。
请根据上述信息和所给ER图，给出在MySQL实现flight_booking的语句，包括建库，建表，创建主码，外码，索引，指定缺省，不能为空等约束。所有索引采用BTREE。所有约束的名字不作要求。所有的外码与主码同名。但有两处例外: 计划航班和飞行航班都涉及出发机场和到达机场，外码与主码同名会导致同一表有两个同名列。故这两处外码例外处理：出发机场命名为from，到达机场命名为to。
注意：所有的表名字和列名，都没有大写字母。列名存在与关键字同名的情形，请妥善处理。你有可能不能一次通过评测，请考虑你的代码要反复修改再运行的情形。

如果觉得上图不够清晰，可以前往：
https://gitee.com/kylin8575543/db2022-spring
点击下载实训所需要的资料包，也可直接查看本文件：
https://gitee.com/kylin8575543/db2022-spring/blob/master/flightbooking.png

请将语句填写在右侧代码文件，然后提交评测。
*/

# 请将你实现flight_booking数据库的语句写在下方：
# ^\s*([\u4e00-\u9fa5]+)[:：](.*)$  ->  $2 COMMENT '$1',
# ,\n\s+ -> \n);\n\n
# 主码,* -> PRIMARY KEY
# 自增|自动增加 -> AUTO_INCREMENT
# 不可空|不可为空|不能空|非空 -> NOT NULL
# 不可有重|不可重|全球唯一|具全球唯一性 -> UNIQUE
# 缺省值0|缺省0 -> DEFAULT 0
# 普通索引 -> KEY
# ，|,+ ->
# [0-9].\s*[\u4e00-\u9fa5]+\(([a-z]+)\) ->
# [0-9].\s*[\u4e00-\u9fa5]+\(([a-z]+)\)\n(([^\n]+\n)+?\n) ->  CREATE TABLE $1 (\n$2);\n\n
# ,\n\n -> \n

DROP DATABASE IF EXISTS flight_booking;
CREATE DATABASE flight_booking;
USE flight_booking;
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
) COMMENT '用户分两类，普通用户可以订票，管理用户有权限维护和管理整个系统的运营。为简单起见，两类用户合并，用admin_tag标记区分';

CREATE TABLE passenger (
    passenger_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '旅客编号',
    id CHAR(18) NOT NULL UNIQUE COMMENT '证件号码',
    firstname VARCHAR(50) NOT NULL COMMENT '名字',
    lastname VARCHAR(50) NOT NULL COMMENT '姓氏',
    mail VARCHAR(50) COMMENT '邮箱',
    phone VARCHAR(20) NOT NULL COMMENT '电话',
    sex CHAR(1) NOT NULL COMMENT '性别',
    dob DATE COMMENT '生日'
) COMMENT '用户登录系统不一定是替自己买票，所以用户和旅客信息是分开存储的。';

CREATE TABLE airport (
    airport_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '编号',
    iata CHAR(3) NOT NULL UNIQUE COMMENT '国际民航组织编码',
    icao CHAR(4) NOT NULL UNIQUE COMMENT '国际航运协会编码',
    name VARCHAR(50) NOT NULL COMMENT '机场名称',
    city VARCHAR(50) COMMENT '所在城市',
    country VARCHAR(50) COMMENT '所在国家',
    latitude DECIMAL(11, 8) COMMENT '纬度',
    longitude DECIMAL(11, 8) COMMENT '经度',

    INDEX (name)
) COMMENT '全球每个机场都有唯一IATA编码和ICAO编码，IATA为3个字符，ICAO为4个字符。例如首都机场的(IATA,ICAO)分别为(PEK,ZBAA)，大兴机场为(PKX,ZBAD),天河机机场为(WUH,ZHHH)。在飞机登记牌上出发地和到达地均用IATA表示。为能在地图上显示机场位置，需要记录经纬度信息。';

CREATE TABLE airline (
    airline_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '编号',
    name VARCHAR(30) NOT NULL COMMENT '名称',
    iata CHAR(2) NOT NULL UNIQUE COMMENT '国际民航组织编码',

    airport_id INT NOT NULL,
    CONSTRAINT fk_base_in FOREIGN KEY (airport_id) REFERENCES airport(airport_id)
) COMMENT '航空公司的IATA编码为2位，如东航为MU，国航为CA,南航为CZ等，航班号一般以所属航空公司的IATA码为前缀。';

CREATE TABLE airplane (
    airplane_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '编号',
    type VARCHAR(50) NOT NULL COMMENT '机型,如B737-300,A320-500等',
    capacity SMALLINT NOT NULL COMMENT '座位',
    identifier VARCHAR(50) NOT NULL COMMENT '标识',

    airline_id INT NOT NULL,
    CONSTRAINT fk_own FOREIGN KEY (airline_id) REFERENCES airline(airline_id)
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
    sunday TINYINT DEFAULT 0 COMMENT '周日',

    airline_id INT NOT NULL,
    `from` INT NOT NULL,
    `to` INT NOT NULL,
    CONSTRAINT fk_arrange FOREIGN KEY (airline_id) REFERENCES airline(airline_id),
    CONSTRAINT fk_from FOREIGN KEY (`from`) REFERENCES airport(airport_id),
    CONSTRAINT fk_to FOREIGN KEY (`to`) REFERENCES airport(airport_id)
) COMMENT '舤班一般以周次安排，例如：每周两个班次，周一和周五。飞行时长一般以分种计。';

CREATE TABLE flight (
    flight_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '飞行编号',
    departure DATETIME NOT NULL COMMENT '起飞时间',
    arrival DATETIME NOT NULL COMMENT '到达时间',
    duration SMALLINT NOT NULL COMMENT '飞行时长',

    airplane_id INT NOT NULL,
    airline_id INT NOT NULL,
    flight_no CHAR(8) NOT NULL,
    `from` INT NOT NULL,
    `to` INT NOT NULL,
    CONSTRAINT fk_airline_execute FOREIGN KEY (airplane_id) REFERENCES airplane(airplane_id),
    CONSTRAINT fk_flightschedule_execute FOREIGN KEY (flight_no) REFERENCES flightschedule(flight_no),
    CONSTRAINT fk_serve_for FOREIGN KEY (airline_id) REFERENCES airline(airline_id),
    CONSTRAINT fk_flight_from FOREIGN KEY (`from`) REFERENCES airport(airport_id),
    CONSTRAINT fk_flight_to FOREIGN KEY (`to`) REFERENCES airport(airport_id)

) COMMENT '航班依航班常规调度表为基准安排。但调度表不是一成不变，也不是每个既定的航都实际起飞，也不总是按既定的时间起飞，所以实飞航班必须单独安排并记录。';

CREATE TABLE ticket (
    ticket_id INT AUTO_INCREMENT PRIMARY KEY COMMENT '票号',
    seat CHAR(4) COMMENT '坐位号',
    price DECIMAL(10, 2) NOT NULL COMMENT '价格',

    passenger_id INT NOT NULL,
    user_id INT NOT NULL,
    flight_id INT NOT NULL,
    CONSTRAINT fk_purchase FOREIGN KEY (passenger_id) REFERENCES passenger(passenger_id),
    CONSTRAINT fk_book_for FOREIGN KEY (user_id) REFERENCES user(user_id),
    CONSTRAINT fk_issued_for FOREIGN KEY (flight_id) REFERENCES flight(flight_id)
) COMMENT '用户可替自己或其亲友购买某个航班的机票。';
# CONSTRAINT fk_purchase命名可省略

