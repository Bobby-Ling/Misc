   -- 3) 查询购买了所有畅销理财产品的客户
--   请用一条SQL语句实现该查询：

/* 
  若定义持有人数超过2的理财产品称为畅销理财产品。查询购买了所有畅销理财产品的客户编号(pro_c_id)。
 注意结果输出要求：按照客户编号的升序排列，且去除重复结果。 */

WITH pro_c_pif AS (
    SELECT
        pro_c_id,
        pro_pif_id
    FROM property
    WHERE pro_type = 1
    ORDER BY pro_c_id
),  pro_pif AS (
    SELECT
        pro_pif_id
    FROM property
    WHERE pro_type = 1
    GROUP BY pro_pif_id
    HAVING COUNT(DISTINCT pro_c_id) > 2
)
SELECT
    pro_c_pif.pro_c_id AS pro_c_id
#     COUNT(pro_pif.pro_pif_id),
#     (SELECT COUNT(*) FROM pro_pif)
#     pro_c_pif.pro_pif_id
FROM
    pro_c_pif,
    pro_pif
WHERE
    pro_c_pif.pro_pif_id = pro_pif.pro_pif_id
GROUP BY pro_c_id
HAVING
    COUNT(pro_pif.pro_pif_id) = (SELECT COUNT(*) FROM pro_pif)
ORDER BY pro_c_pif.pro_c_id







/*  end  of  your code  */