-- 13) 综合客户表(client)、资产表(property)、理财产品表(finances_product)、
--     保险表(insurance)、基金表(fund)和投资资产表(property)，
--     列出所有客户的编号、名称和总资产，总资产命名为total_property。
--     总资产为储蓄卡余额，投资总额，投资总收益的和，再扣除信用卡透支的金额
--     (信用卡余额即为透支金额)。客户总资产包括被冻结的资产。
--    请用一条SQL语句实现该查询：


SELECT
    c_id,
    c_name,
    -- amount
    IFNULL(SUM(amount),0) AS total_property
FROM client
LEFT JOIN (
    SELECT 
        pro_c_id,
        pro_quantity * p_amount as amount
    FROM property, finances_product
    WHERE 
        pro_type = 1
        AND 
        pro_pif_id = p_id
    -- 理财产品
    -- 直接叠起来
    UNION ALL

    SELECT 
        pro_c_id,
        pro_quantity * i_amount as amount
    FROM property, insurance
    WHERE 
        pro_type = 2
        AND 
        pro_pif_id = i_id
    -- 保险
    UNION ALL

    SELECT 
        pro_c_id,
        pro_quantity * f_amount as amount
    FROM property, fund
    WHERE 
        pro_type = 3
        AND 
        pro_pif_id = f_id
    -- 基金
    UNION ALL

    SELECT 
        pro_c_id,
        pro_income as amount
    FROM property
    -- 收益
    UNION ALL

    SELECT
        b_c_id as pro_c_id,
        if(b_type = "储蓄卡", b_balance, -b_balance) as amount
    FROM bank_card
    -- 储蓄
) as all_property on c_id = all_property.pro_c_id
GROUP BY c_id;

/*
这样不能保留左侧所有行
SELECT
    c_id,
    c_name,
    -- amount
    IFNULL(SUM(amount),0) AS total_property
FROM client, (
    SELECT 
        pro_c_id,
        pro_quantity * p_amount as amount
    FROM property, finances_product
    WHERE 
        pro_type = 1
        AND 
        pro_pif_id = p_id
    -- 理财产品
    -- 直接叠起来
    UNION ALL

    SELECT 
        pro_c_id,
        pro_quantity * i_amount as amount
    FROM property, insurance
    WHERE 
        pro_type = 2
        AND 
        pro_pif_id = i_id
    -- 保险
    UNION ALL

    SELECT 
        pro_c_id,
        pro_quantity * f_amount as amount
    FROM property, fund
    WHERE 
        pro_type = 3
        AND 
        pro_pif_id = f_id
    -- 基金
    UNION ALL

    SELECT 
        pro_c_id,
        pro_income as amount
    FROM property
    -- 收益
    UNION ALL

    SELECT
        b_c_id as pro_c_id,
        if(b_type = "储蓄卡", b_balance, -b_balance) as amount
    FROM bank_card
    -- 储蓄
) as all_property 
WHERE all_property.pro_c_id = c_id
GROUP BY c_id
ORDER BY c_id;
*/

/* 
-- 这样会多出重复的列 与目的不同
SELECT
    c_id,
    c_name, 
    IFNULL(SUM(finances_sel.amount),0)+
    IFNULL(SUM(insurance_sel.amount),0)+
    IFNULL(SUM(fund_sel.amount),0)+
    IFNULL(SUM(bank_card_sel.amount),0)+
    IFNULL(SUM(property_sel.amount),0)
        AS total_property
FROM client
LEFT JOIN (
    SELECT 
        pro_c_id,
        pro_quantity * p_amount as amount
    FROM property, finances_product
    WHERE 
        pro_type = 1
        AND 
        pro_pif_id = p_id
    -- 理财产品
) as finances_sel on c_id = finances_sel.pro_c_id
LEFT JOIN (
    SELECT 
        pro_c_id,
        pro_quantity * i_amount as amount
    FROM property, insurance
    WHERE 
        pro_type = 2
        AND 
        pro_pif_id = i_id
    -- 保险
) as insurance_sel on c_id = insurance_sel.pro_c_id
LEFT JOIN (
    SELECT 
        pro_c_id,
        pro_quantity * f_amount as amount
    FROM property, fund
    WHERE 
        pro_type = 3
        AND 
        pro_pif_id = f_id
    -- 基金
) as fund_sel on c_id = fund_sel.pro_c_id
LEFT JOIN (
    SELECT 
        pro_c_id,
        pro_income as amount
    FROM property
    -- 收益
) as property_sel on c_id = property_sel.pro_c_id
LEFT JOIN (
    SELECT
        b_c_id,
        if(b_type = "储蓄卡", b_balance, -b_balance) as amount
    FROM bank_card
    -- 储蓄
) as bank_card_sel on c_id = bank_card_sel.b_c_id
GROUP BY c_id;
 */

/* 
pro_quantity * p_amount as amount
pro_quantity 和p_amount在不同的表中
 */

/*  end  of  your code  */ 