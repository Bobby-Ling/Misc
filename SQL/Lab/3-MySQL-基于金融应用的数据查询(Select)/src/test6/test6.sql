-- 第6关: 商品收益的众数

-- 6) 查询资产表中所有资产记录里商品收益的众数和它出现的次数。
--    请用一条SQL语句实现该查询：

SELECT 
    pro_income,
    COUNT(*) AS presence
FROM property
GROUP BY pro_income
HAVING COUNT(*) = (
    SELECT MAX(presence_count) 
    FROM (
        SELECT COUNT(*) AS presence_count
        FROM property
        GROUP BY pro_income
    ) AS subquery
);
/* 
-- Reference 'presence' not supported (reference to group function) 
HAVING子句在GROUP BY子句之后执行, 但presence别名是GROUP BY子句的结果. 因此, 数据库引擎无法识别HAVING子句中的presence别名
    HAVING COUNT(*) = (
    SELECT MAX(presence) 
    FROM property 
) */

/* ORDER BY presence DESC
WHERE presence = (
    SELECT MAX(presence) FROM 
) */

/*  end  of  your code  */