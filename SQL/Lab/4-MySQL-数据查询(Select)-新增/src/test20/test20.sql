 -- 1) 查询销售总额前三的理财产品
--   请用一条SQL语句实现该查询：
/* 查询2010年和2011年这两年每年销售总额前3名（如果有并列排名，则后续排名号跳过之前的并列排名个数，例如1、1、3）的统计年份（pyear）、销售总额排名值(rk)、理财产品编号(p_id)、销售总额(sumamount)。
  注意结果输出要求：(1)按照年份升序排列，同一年份按照销售总额的排名值升序排列，如遇到并列排名则按照理财产品编号升序排列;(2)属性显示：统计年份（pyear）、销售总额排名值(rk)、理财产品编号(p_id)、销售总额(sumamount)（3）结果显示顺序：先按照统计年份（pyear）升序排,同一年份按照销售总额排名值（rk）升序排,同一排名值的按照理财产品编号（p_id ）升序排。 */

SELECT
    *
FROM (
    SELECT
        YEAR(pro_purchase_time) AS pyear,
        RANK() OVER (PARTITION BY YEAR(pro_purchase_time) ORDER BY p_amount * pro_quantity DESC) AS rk,
        p_id,
        p_amount * pro_quantity AS sumamount
    FROM property, finances_product
    WHERE 
        pro_pif_id = p_id
        AND 
        pro_type = 1
        AND
        pro_purchase_time REGEXP '201[0|1].*'
    -- HAVING rk <= 3 不行
    ORDER BY pyear,rk,p_id
) sub
-- 必须有alias
WHERE rk <= 3;



/* SELECT
    pro_income,
    pro_type,
    RANK() OVER(PARTITION BY pro_type ORDER BY pro_income) as rk
FROM property; */

/* 
SELECT
    pro_pif_id,
    -- p_amount, 
    -- pro_quantity,
    p_amount * pro_quantity AS amount,
    -- pro_purchase_time,
    YEAR(pro_purchase_time) AS pyear
FROM property, finances_product
WHERE pro_pif_id = p_id */




/*  end  of  your code  */