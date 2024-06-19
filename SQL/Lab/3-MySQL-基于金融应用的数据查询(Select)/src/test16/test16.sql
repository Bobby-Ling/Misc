-- 16) 查询持有相同基金组合的客户对，如编号为A的客户持有的基金，编号为B的客户也持有，反过来，编号为B的客户持有的基金，编号为A的客户也持有，则(A,B)即为持有相同基金组合的二元组，请列出这样的客户对。为避免过多的重复，如果(1,2)为满足条件的元组，则不必显示(2,1)，即只显示编号小者在前的那一对，这一组客户编号分别命名为c_id1,c_id2。

-- 请用一条SQL语句实现该查询：

-- CTE（Common Table Expression）
WITH property_grouped AS (
    SELECT 
        pro_c_id,
        -- 只选择组合, 因此
        GROUP_CONCAT(DISTINCT pro_pif_id ORDER BY pro_pif_id) AS fund_set
    FROM property
    WHERE pro_type = 3
    GROUP BY pro_c_id
)
SELECT 
    p1.pro_c_id AS c_id1,
    p2.pro_c_id AS c_id2
FROM property_grouped p1, property_grouped p2
WHERE 
    p1.fund_set = p2.fund_set 
    AND 
    p1.pro_c_id < p2.pro_c_id;


/* 
-- 这样需要重复写两遍子查询
SELECT 
    p1.pro_c_id AS c_id1,
    p2.pro_c_id AS c_id2
FROM (
    SELECT 
        pro_c_id,
        -- 只选择组合, 因此
        GROUP_CONCAT(DISTINCT pro_pif_id ORDER BY pro_pif_id) AS fund_set
    FROM property
    WHERE pro_type = 3
    GROUP BY pro_c_id
) p1, (
    SELECT 
        pro_c_id,
        GROUP_CONCAT(DISTINCT pro_pif_id ORDER BY pro_pif_id) AS fund_set
    FROM property
    WHERE pro_type = 3
    GROUP BY pro_c_id
) p2
WHERE 
    p1.fund_set = p2.fund_set 
    AND 
    p1.pro_c_id < p2.pro_c_id; */


/* SELECT 
    p1.pro_c_id AS c_id1,
    p2.pro_c_id AS c_id2
FROM (
    SELECT 
        pro_c_id,
        -- 只选择组合, 因此
        group_concat(DISTINCT pro_pif_id ORDER BY pro_pif_id) AS fund_set
    FROM property
    WHERE pro_type = 3
    GROUP BY pro_c_id
) AS property_grouped p1, property_grouped p2
-- 表的别名在子查询中不能被引用
WHERE 
    p1.pro_c_id < p2.pro_c_id
    AND 
    p1.fund_set = p2.fund_set; */


/* select 
    pro_c_id,
    group_concat(pro_id), 
    group_concat(pro_pif_id),
    group_concat(pro_type)
from property 
group by pro_c_id; */




/*  end  of  your code  */