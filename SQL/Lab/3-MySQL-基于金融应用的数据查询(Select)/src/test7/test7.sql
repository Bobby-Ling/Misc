-- 7) 查询身份证隶属武汉市没有买过任何理财产品的客户的名称、电话号、邮箱。
--    请用一条SQL语句实现该查询：
-- 已知身份证前6位表示居民地区，其中4201开头表示湖北省武汉市。查询身份证隶属武汉市没有买过任何理财产品的客户的名称、电话号、邮箱。依客户编号排序
SELECT 
    c_name,
    c_phone,
    c_mail
FROM client
WHERE 
    c_id_card REGEXP '4201.*'
    AND
    NOT EXISTS (
        SELECT
            pro_type
        FROM property
        WHERE 
            pro_c_id = c_id
            AND
            pro_type = 1
    ) 
ORDER BY c_id;

-- WHERE c_id_card LIKE "4201%"

/*  end  of  your code  */