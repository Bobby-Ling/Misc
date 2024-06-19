-- 第3关: 既买了保险又买了基金的客户

-- 3) 查询既买了保险又买了基金的客户的名称、邮箱和电话。结果依c_id排序
-- 请用一条SQL语句实现该查询：

SELECT c_name,c_mail,c_phone
    FROM client
    WHERE EXISTS(
            SELECT * 
                FROM property
                WHERE pro_c_id = c_id
                    AND pro_type = 2
        )
        AND EXISTS(
            SELECT * 
                FROM property
                WHERE pro_c_id = c_id
                    AND pro_type = 3
        )
    ORDER BY c_id;


/*  end  of  your code  */