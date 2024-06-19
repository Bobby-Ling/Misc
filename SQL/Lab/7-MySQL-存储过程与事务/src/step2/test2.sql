/*
# 游标(CURSOR)

## 游标的特点

SQL操作都是面向集合的，即操作的对象以及运算的结果均为集合，但有时候，我们需要一行一行地处理数据，这就需要用到游标(CURSOR)，它相当于一个存储于内存的带有指针的表，每次可以存取指针指向的一行数据，并将指针向前推进一行。游标的数据通常是一条查询语句的结果。对游标的操作一般要用循环语句，遍历游标的每一行数据，并将该行数据读至变量，再根据变量的值进行所需要的其它操作。

游标:
- 不可滚动。即只能从前往后遍历游标数据(即从第1行到最后一行)，不能反向遍历，不能跳跃遍历，不能直接访问中间的某一行。
- 只读。游标里的数据只能读取，不能修改。

## 游标的定义与使用

1. DECLARE语句
用DECLARE语句定义游标、变量以及特情处理程序。
在一个BEGIN...END语句块内，DECLARE定义的顺序要求如下：
    1. 定义变量：
        ```
        DECLARE var_name [, var_name] ... type [DEFAULT value]
        ```
    2. 定义游标：
        ```
        DECLARE cursor_name CURSOR FOR select_statement
        任何合法的select语句(不能带INTO短语)，都可以定义成游标。此后可用FETCH语句读取这个select语句查询到的数据集中的一行数据。
        一个存储过程可义定义多个游标，但不能同名。
        ```
    3. 定义特情处理例程：
        ```
        DECLARE handler_action HANDLER
        FOR condition_value [, condition_value] ...
        statement
        handler_action: {
            CONTINUE
            | EXIT
        }
        condition_value: {
            mysql_error_code
            | SQLSTATE [VALUE] sqlstate_value
            | condition_name
            | SQLWARNING
            | NOT FOUND
            | SQLEXCEPTION
        }
        ```
        - 游标应用中至少需要定义一个NOT FOUND的HANDLER(处理例程)：
            DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = 1;
            其含义是当抛出NOT FOUND异常时，置变量finished的值为1,程序继续运行。当然，在此之前，应当先定义变量finished，并初始化为0(也可在循环语句之前初始化为0），finished作为循环的控制变量，仅当finished变成1时，循环结束。
        - 如果特情处理例程由多条语句组成，可以用BEGIN...END组成复合语句。
        - 当一个存储过程中存在多个游标时，对任何一个游标的读取(FETCH)都可能会触发特情处理。比如一个游标的数据被遍历完毕，再试图FETCH下一行时，会触发NOT FOUND HANDLER, 并进而改变某个变量的值，但另一个游标中可能还有未处理完的数据。编程者应当自己想办法区分是哪个游标的数据处理完毕。

2. OPEN语句
OPEN cursor_name
该语句打开之前定义的游标，并初始化指向数据行的指针(接下来的第一条FETCH语句将试图读取游标的第1行数据)。

3.FETCH语句
FETCH [[NEXT] FROM] cursor_name INTO var_name [, var_name] ...
FETCH语句读取游标的一行数据到变量列表,并推进游标的指针.关键词NEXT, FROM都可省略(或仅省略NEXT)。注意INTO后的变量列表应当与游标定义中的SELECT列表一一对应(变量个数与SELECT列表个数完全相同，数据类型完全一致，每个变量的取值按SELECT列表顺序一一对应)。

FETCH一个未打开的游标会出错。

4. CLOSE语句
CLOSE cursor_name
Close语句关闭先前打开的游标，试图关闭一个未曾打开(OPEN)的游标会出错。

没有CLOSE的游标，在其定义的BEGIN...END语句块结束时，将自动CLOSE。

## 游标应用举例

设有表epl(英超足球比赛记录)结构如下：
```
列名	        类型	    说明
id	        int	    序号,主码
date	    date	比赛日期
home_team	char(30)主队
away_team	char(30)客队
fthg	    int	    全场主队进球
fgag	    int	    全场客户进球
fgr	        char(1)	全场结果：H-主队赢,A-客队赢,D-平
hthg	    int	    上半场主队进球
htag	    int	    上半场客队进球
htr	        int	    上半场结果: H-主队赢,A-客队赢,D-平
season	char(20)	赛季
```
使用游标编写存储过程sp_cursor_demo计算Liverpool足球队在主场获胜的比赛中，上半场的平均进球数，结果通过参数传递。示例程序如下：
```
DELIMITER $$
CREATE PROCEDURE sp_cursor_demo(INOUT average_goals FLOAT)
BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE matches int DEFAULT(0);
    DECLARE goals int DEFAULT(0);
    DECLARE half_time_goals INT;

    DECLARE team_cursor CURSOR FOR SELECT HTHG FROM epl WHERE (home_team = 'Liverpool') and (ftr = 'H');
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    OPEN team_cursor;
    FETCH team_cursor INTO half_time_goals;
    WHILE NOT DONE DO
      SET  goals = goals + half_time_goals;
      SET  matches = matches + 1;
         FETCH team_cursor INTO half_time_goals;
    END while;

    SET  average_goals = goals / matches;
    CLOSE team_cursor;
END $$
DELIMITER;
```
存储过程定义后，可通过以下语句定义参数，调用过程，再从返回参数中获取结果:

SET @average_goals = 0.0;
CALL sp_cursor_demo(@average_goals);
SELECT @average_goals;
上述带前缀@的变量属于MySQL的用户自定义变量，只在该用户的会话期内有效，对别的用户(客户端)不可见。@前缀变量不用申明变量类型，初始化时，由其值决定其类型。

上述存储过程仅用来演示游标的用法，事实上，下面的这条查询语句，即可获得相同的结果，且效率更高：
select avg(hthg) from epl where home_team = 'Liverpool' and ftr = 'H';

一般来説，仅当你需要遍历一个数据集，且一次只能处理其中的一行数据时(比如对每一行，要作不同的业务处理)，你才需要使用游标。当游标的数据集较大时，会造成较大的网络时延。使用游标时，应尽可能缩小数据规模(去掉不必要的行和列)。

 */

-- 编写一存储过程，自动安排某个连续期间的大夜班的值班表:

/*
医院的某科室有科室主任1名(亦为医生)，医生若干(至少2名，不含主任)，护士若干(至少4人)，现在需要编写一存储过程，自动安排某个连续期间的大夜班(即每天00:00-8:00时间段)的值班表，排班规则为：
1.每个夜班安排1名医生，2名护士；
2.值班顺序依工号顺序循环轮流安排(即排至最后1名后再从第1名接着排)；
3.科室主任参与轮值夜班，但不安排周末(星期六和星期天)的夜班，当周末轮至科主任时，主任的夜班调至周一，由排在主任后面的医生依次递补值周末的夜班。

存储过程的名字为sp_night_shift_arrange,它带两个输入参数：start_date, end_date，分别指排班的起始时间和结束时间。排班结果直接写入表night_shift_schedule，其结构如下：

表   night_shift_schedule(夜班值班安排表)
列	            类型	        说明
n_date	        date	    日期, primary key
n_doctor_name	char(30)	医生姓名
n_nurse1_name	char(30)	护士1姓名
n_nurse2_name	char(30)	护士2姓名
假定该科室没有同名的医生和同名的护士。
科室参与值班的医护人员存储在表employee中，其结构为：

表   employee(医护人员表)
列	    类型	        说明
e_id	int	        编号, primary key
e_name	char(30)	姓名
e_type	int	        类别：1-主任,医生;2-医生;3-护士
不用考虑其它信息(比如科室之类的)，在生产环境中，只需在where短语中施加条件限制即可明确选出所需科室的医护人员。这里，且把表中全部人员视为该科室人员。
 */
DROP TABLE IF EXISTS DEBUG;
CREATE TABLE DEBUG (
    id INT AUTO_INCREMENT PRIMARY KEY,
    time_stamp DATE,
    msg VARCHAR(255),
    doctor_index INT,
    nurse_index INT
);

DELIMITER $$
DROP PROCEDURE IF EXISTS sp_night_shift_arrange;
CREATE PROCEDURE sp_night_shift_arrange(IN start_date DATE, IN end_date DATE)
BEGIN
    /*
    1.declare语句必须用在begin...end语句块中,并且必须出现在begin...end语句块的最前面
    2.declare定义的变量的作用范围仅限于declare语句所在的begin...end块内及嵌套在该块内的其他begin...end块；
     */
    DECLARE move_director BOOLEAN DEFAULT FALSE;
    DECLARE now_date DATE DEFAULT (start_date);
    DECLARE done BOOLEAN DEFAULT FALSE;
    DECLARE current_doctor CHAR(30);
    DECLARE current_type INT DEFAULT 0;
    DECLARE doctor_count INT DEFAULT 0;
    DECLARE doctor_index INT DEFAULT 0;
    DECLARE nurse_count INT DEFAULT 0;
    DECLARE nurse_index INT DEFAULT 0;
    DECLARE current_nurse1 CHAR(30);
    DECLARE current_nurse2 CHAR(30);

    DECLARE doctor_cursor CURSOR FOR (
        SELECT e_name, e_type
        FROM employee
        WHERE e_type = 2 OR e_type = 1
        ORDER BY e_id
        );
    DECLARE nurse_cursor CURSOR FOR (
        SELECT e_name
        FROM employee
        WHERE e_type = 3
        ORDER BY e_id
        );
    DECLARE CONTINUE HANDLER FOR NOT FOUND BEGIN
        # 判断哪个cursor走到头了
        # 由于在本次异常处理后返回的仍然是旧值，导致会出现重复的fetch值，
        INSERT INTO DEBUG VALUES (NULL, NULL, CONCAT('before'), doctor_index, nurse_index);

        IF NOT doctor_index <= doctor_count THEN
            CLOSE doctor_cursor;
            OPEN doctor_cursor;
            SET doctor_index = 0;
        END IF;
        IF NOT nurse_index <= nurse_count THEN
            CLOSE nurse_cursor;
            OPEN nurse_cursor;
            SET nurse_index = 0;
        END IF;
        INSERT INTO DEBUG VALUES (NULL, NULL, CONCAT('after'), doctor_index, nurse_index);
        SET done = TRUE;
    END;

    OPEN doctor_cursor;
    OPEN nurse_cursor;

    # 两种赋值方法
    SELECT COUNT(*)
    INTO doctor_count
    FROM employee
    WHERE e_type = 2 OR e_type = 1;

    SET nurse_count = (
        SELECT COUNT(*)
        FROM employee
        WHERE e_type = 3
        );

    WHILE NOT done
        DO
            # 如果有重排主任的需求，即上一次已经再抓过医生了, 这次就不再抓取医生
            IF move_director = TRUE THEN
                # 而是直接设置当前为主任
                SET current_doctor = (
                    SELECT e_name
                    FROM employee
                    WHERE e_type = 1
                    );
                INSERT INTO DEBUG
                VALUES
                    (NULL, now_date, CONCAT('move_director now doctor: ', current_doctor), doctor_index,
                     nurse_index);
                SET current_type = 1;
                SET move_director = FALSE;
            ELSE
                SET doctor_index = doctor_index + 1;
                FETCH doctor_cursor INTO current_doctor, current_type;
                IF done THEN
                    # 当走完时会读取重复值，因此再读取一遍
                    SET doctor_index = doctor_index + 1;
                    FETCH doctor_cursor INTO current_doctor, current_type;
                    SET done = FALSE;
                END IF;
                INSERT INTO DEBUG
                VALUES (NULL, now_date, CONCAT('fetching ', current_doctor), doctor_index, nurse_index);
            END IF;

            # 护士正常取
            SET nurse_index = nurse_index + 1;
            FETCH nurse_cursor INTO current_nurse1;
            IF done THEN
                SET nurse_index = nurse_index + 1;
                FETCH nurse_cursor INTO current_nurse1;
                SET done = FALSE;
            END IF;
            INSERT INTO DEBUG
            VALUES (NULL, now_date, CONCAT('fetching ', current_nurse1), doctor_index, nurse_index);

            SET nurse_index = nurse_index + 1;
            FETCH nurse_cursor INTO current_nurse2;
            IF done THEN
                SET nurse_index = nurse_index + 1;
                FETCH nurse_cursor INTO current_nurse2;
                SET done = FALSE;
            END IF;
            INSERT INTO DEBUG
            VALUES (NULL, now_date, CONCAT('fetching ', current_nurse2), doctor_index, nurse_index);

            # 当主任值班，就判断是否周末
            IF current_type = 1 AND (WEEKDAY(now_date) = 5 OR WEEKDAY(now_date) = 6) THEN
                SET move_director = TRUE;
                # 再抓一个医生
                SET doctor_index = doctor_index + 1;
                FETCH doctor_cursor INTO current_doctor, current_type;
                IF done THEN
                    SET doctor_index = doctor_index + 1;
                    FETCH doctor_cursor INTO current_doctor, current_type;
                    SET done = FALSE;
                END IF;
                INSERT INTO DEBUG
                VALUES (NULL, now_date, CONCAT('#fetching ', current_doctor), doctor_index, nurse_index);
            END IF;

            # DAYNAME(now_date) 转换为字符串
            INSERT INTO night_shift_schedule VALUES (now_date, current_doctor, current_nurse1, current_nurse2);
            INSERT INTO DEBUG
            VALUES (NULL, now_date, CONCAT(current_doctor, current_nurse1, current_nurse2), doctor_index, nurse_index);

            # 根据日期决定是否完毕
            SET now_date = now_date + INTERVAL 1 DAY;
            IF now_date > end_date THEN
                SET done = TRUE;
            END IF;
        END WHILE;

END$$

DELIMITER ;

DELETE
FROM night_shift_schedule
WHERE
    LENGTH(DAYNAME(n_date)) < 100;
CALL sp_night_shift_arrange('2022-5-1', '2022-5-31');

SELECT n_date `date`, DAYNAME(n_date) dayofweek, n_doctor_name doctor, n_nurse1_name nurse1, n_nurse2_name nurse2
FROM night_shift_schedule;
/*  end  of  your code  */

SELECT *
FROM DEBUG;