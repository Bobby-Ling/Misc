-- 19) 以日历表格式列出2022年2月每周每日基金购买总金额，输出格式如下：
-- week_of_trading Monday Tuesday Wednesday Thursday Friday
--               1
--               2    
--               3
--               4
--   请用一条SQL语句实现该查询：
/*  end  of  your code  */
-- week(d1) - 日期d1在当年的周次。week('2022-2-7') = 6;
-- dayofweek(d1) - 返回d1在本周的次序(1 = Sunday, 2 = Monday, …, 7 = Saturday)
-- weekday(d1) - 同上,但次序含义不同(0 = Monday, 1 = Tuesday, … 6 = Sunday)
-- IF(expr1,expr2,expr3) - 若expr1为TRUE，返回expr2，否则返回expr3.

/* SELECT 
    ROW_NUMBER() OVER(ORDER BY c_id),
    c_id
FROM client; */

SELECT
    week_of_trading,
    SUM(Monday) AS Monday,
    SUM(Tuesday) AS Tuesday,
    SUM(Wednesday) AS Wednesday,
    SUM(Thursday) AS Thursday,
    SUM(Friday) AS Friday
FROM (
    SELECT 
        pro_purchase_time,
        WEEK(pro_purchase_time) - WEEK('2022-02-07') + 1 AS week_of_trading,
        IF(WEEKDAY(pro_purchase_time)=0,SUM(f_amount * pro_quantity),NULL) AS Monday,
        IF(WEEKDAY(pro_purchase_time)=1,SUM(f_amount * pro_quantity),NULL) AS Tuesday,
        IF(WEEKDAY(pro_purchase_time)=2,SUM(f_amount * pro_quantity),NULL) AS Wednesday,
        IF(WEEKDAY(pro_purchase_time)=3,SUM(f_amount * pro_quantity),NULL) AS Thursday,
        IF(WEEKDAY(pro_purchase_time)=4,SUM(f_amount * pro_quantity),NULL) AS Friday
    FROM property,fund
    WHERE 
        pro_pif_id = f_id
        AND 
        pro_type = 3
        AND 
        pro_purchase_time LIKE '2022-02-%'
    GROUP BY pro_purchase_time
) AS tmp
GROUP BY week_of_trading;
