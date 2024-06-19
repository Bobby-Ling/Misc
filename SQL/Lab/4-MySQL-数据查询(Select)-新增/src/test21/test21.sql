  -- 2) 投资积极且偏好理财类产品的客户
--   请用一条SQL语句实现该查询：
/* 
 购买了3种（同一编号的理财产品记为一种）以上理财产品的客户被认为投资积极的客户，若该客户持有基金产品种类数（同一基金编号记为相同的基金产品种类）小于其持有的理财产品种类数，则认为该客户为投资积极且偏好理财产品的客户。查询所有此类客户的编号(pro_c_id)。
 注意结果输出要求：按照客户编号的升序排列，且去除重复结果。 */

WITH pro1 AS (
    SELECT
        pro_c_id,
        COUNT(DISTINCT pro_pif_id) as count
    FROM property
    WHERE 
        pro_type = 1
        -- 理财
    GROUP BY pro_c_id
    HAVING count >= 3
),   pro2 AS (
    SELECT
        pro_c_id,
        COUNT(DISTINCT pro_pif_id) as count
    FROM property
    WHERE 
        pro_type = 3
        -- 基金
    GROUP BY pro_c_id
)
SELECT 
    DISTINCT pro1.pro_c_id
FROM pro1,pro2
WHERE 
    pro1.pro_c_id = pro2.pro_c_id
    AND
    pro1.count > pro2.count;
/*  end  of  your code  */

/* SELECT
    pro_c_id,
    COUNT(DISTINCT pro_pif_id) as count
FROM property
WHERE 
    pro_type = 1
GROUP BY pro_c_id
HAVING count >= 3;

SELECT
    pro_c_id,
    COUNT(DISTINCT pro_pif_id) as count
FROM property
WHERE 
    pro_type = 3
GROUP BY pro_c_id */