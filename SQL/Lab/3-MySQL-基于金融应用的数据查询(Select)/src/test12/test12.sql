 -- 12) 综合客户表(client)、资产表(property)、理财产品表(finances_product)、保险表(insurance)和
 --     基金表(fund)，列出客户的名称、身份证号以及投资总金额（即投资本金，
 --     每笔投资金额=商品数量*该产品每份金额)，注意投资金额按类型需要查询不同的表，
 --     投资总金额是客户购买的各类资产(理财,保险,基金)投资金额的总和，总金额命名为total_amount。
 --     查询结果按总金额降序排序。
 -- 请用一条SQL语句实现该查询：

-- 1表示理财产品;2表示保险;3表示基金

SELECT
    c_name,
    c_id_card,
    SUM(
        CASE
            WHEN pro_type = 1 THEN pro_quantity * fp.p_amount
            WHEN pro_type = 2 THEN pro_quantity * i.i_amount
            WHEN pro_type = 3 THEN pro_quantity * f.f_amount
            ELSE 0
        END
    ) AS total_amount
FROM
    client
-- 依次连接这4张表
LEFT JOIN
    property ON c_id = pro_c_id
LEFT JOIN
    finances_product fp ON pro_type = 1 AND pro_pif_id = fp.p_id
LEFT JOIN
    insurance i ON pro_type = 2 AND pro_pif_id = i.i_id
LEFT JOIN
    fund f ON pro_type = 3 AND pro_pif_id = f.f_id
GROUP BY
    c_id, c_name, c_id_card
ORDER BY
    total_amount DESC;

/* 
不加任何筛选地join
 */




/*  end  of  your code  */ 