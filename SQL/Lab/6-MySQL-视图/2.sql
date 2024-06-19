-- 基于上一关创建的视图v_insurance_detail进行分组统计查询，列出每位客户的姓名，身份证号，保险投资总额(insurance_total_amount)和保险投资总收益(insurance_total_revenue),结果依保险投资总额降序排列。
--  请用一条SQL语句实现该查询：

/*c_name	c_id_card	insurance_total_amount	insurance_total_revenue*/
SELECT *
FROM
    (
        SELECT
            c_name,
            c_id_card,
            SUM(i_amount * pro_quantity) AS insurance_total_amount,
            SUM(pro_income) AS insurance_total_revenue
        FROM
            v_insurance_detail
        GROUP BY c_name, c_id_card

    ) AS raw
ORDER BY insurance_total_amount DESC;


/*  end  of  your code  */