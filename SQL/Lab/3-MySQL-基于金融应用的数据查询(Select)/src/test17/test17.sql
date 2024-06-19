-- 17 查询2022年2月购买基金的高峰期。至少连续三个交易日，所有投资者购买基金的总金额超过100万(含)，则称这段连续交易日为投资者购买基金的高峰期。只有交易日才能购买基金,但不能保证每个交易日都有投资者购买基金。2022年春节假期之后的第1个交易日为2月7日,周六和周日是非交易日，其余均为交易日。请列出高峰时段的日期和当日基金的总购买金额，按日期顺序排序。总购买金额命名为total_amount。
--    请用一条SQL语句实现该查询：

-- property:pro_purchase_time,pro_type
-- fund:f_amount

-- row_number()这种窗口函数只能在 SELECT ORDER BY中使用


WITH
    fund_amount_202202 AS (
        SELECT
            pro_purchase_time,
            SUM(f_amount * property.pro_quantity) AS total_amount
        FROM property, fund
        WHERE
            pro_type = 3 AND
            pro_pif_id = f_id AND
            pro_purchase_time LIKE '2022-02%'
        GROUP BY pro_purchase_time )
    , fund_amount_202202_100W AS (
        SELECT
#             WEEKDAY(pro_purchase_time) AS week_date,
            *
        FROM fund_amount_202202
        WHERE total_amount >= 1000000 )
    # 两表join
    , tmp AS (
        SELECT
            f1.pro_purchase_time AS f1_pro_purchase_time,
            f2.pro_purchase_time AS f2_pro_purchase_time
        FROM
            fund_amount_202202_100W f1
            JOIN fund_amount_202202_100W f2 ON IF(
                    DAYNAME(f1.pro_purchase_time) = 'Friday',
                    f1.pro_purchase_time + INTERVAL 3 DAY = f2.pro_purchase_time,
                    f1.pro_purchase_time + INTERVAL 1 DAY = f2.pro_purchase_time
                                               ) )
    , raw_dates AS (
        # 三表join后的
        SELECT
            tmp.f1_pro_purchase_time AS t1,
            tmp.f2_pro_purchase_time AS t2,
            pro_purchase_time        AS t3
        FROM
            tmp
            JOIN fund_amount_202202_100W f3 ON IF(
                    DAYNAME(tmp.f2_pro_purchase_time) = 'Friday',
                    tmp.f2_pro_purchase_time + INTERVAL 3 DAY = f3.pro_purchase_time,
                    tmp.f2_pro_purchase_time + INTERVAL 1 DAY = f3.pro_purchase_time
                                               ) )
    , dates AS (
        # 可行的连续的一段日期
        SELECT DISTINCT *
        FROM (
            SELECT t1
            FROM raw_dates
            UNION ALL
            SELECT t2
            FROM raw_dates
            UNION ALL
            SELECT t3
            FROM raw_dates ) AS tmp2 )
SELECT *
FROM fund_amount_202202_100W
WHERE pro_purchase_time IN (
    SELECT *
    FROM dates )
;

/*  end  of  your code  */