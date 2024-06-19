/*根据提示，在右侧代码编辑窗口填写1条SQL语句，完成以下任务：
创建包含所有保险资产记录的详细信息的视图v_insurance_detail，包括购买客户的名称、客户的身份证号、保险名称、保障项目、商品状态、商品数量、保险金额、保险年限、商品收益和购买时间。*/
/*c_name	c_id_card	i_name	i_project	pro_status	pro_quantity	i_amount	i_year	pro_income	pro_purchase_time*/

USE finance1;

DROP VIEW IF EXISTS v_insurance_detail;

CREATE VIEW v_insurance_detail AS
SELECT
    c_name,
    c_id_card,
    i_name,
    i_project,
    pro_status,
    pro_quantity,
    i_amount,
    i_year,
    pro_income,
    pro_purchase_time
FROM
    client,
    insurance,
    property
WHERE
    client.c_id = property.pro_c_id AND
    property.pro_type = 2 AND
    property.pro_pif_id = insurance.i_id;
/*
SELECT
    c_name,
    c_id_card,
    i_name,
    i_project,
    pro_status,
    pro_quantity,
    i_amount,
    i_year,
    pro_income,
    pro_purchase_time
FROM
    client
    JOIN property ON client.c_id = property.pro_c_id
    JOIN insurance ON property.pro_pif_id = insurance.i_id;
*/

SELECT * FROM v_insurance_detail;