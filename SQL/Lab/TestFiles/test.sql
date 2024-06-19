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
#         SET done = TRUE;
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
            SET doctor_index = doctor_index + 1;
            FETCH doctor_cursor INTO current_doctor, current_type;
            INSERT INTO DEBUG
            VALUES (NULL, now_date, CONCAT('fetching ', current_doctor), doctor_index, nurse_index);

            SET current_nurse2 = '';
            # 护士正常取
            SET nurse_index = nurse_index + 1;
            FETCH nurse_cursor INTO current_nurse1;
            INSERT INTO DEBUG
            VALUES (NULL, now_date, CONCAT('fetching ', current_nurse1), doctor_index, nurse_index);

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