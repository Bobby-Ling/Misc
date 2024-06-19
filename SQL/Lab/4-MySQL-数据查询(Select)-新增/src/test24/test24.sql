-- 5) 查询任意两个客户的相同理财产品数
--   请用一条SQL语句实现该查询：
/*
查询任意两个客户之间持有的相同理财产品种数，并且结果仅保留相同理财产品数至少2种的用户对。
  注意结果输出要求：第一列和第二列输出客户编号(pro_c_id,pro_c_id)，第三列输出他们持有的相同理财产品数(total_count)，按照第一列的客户编号的升序排列。
*/
SELECT
    pro_c_id1 AS pro_c_id,
    pro_c_id2 AS pro_c_id,
    total_count
FROM
    (
        # 求的是任意两用户间的交集
        SELECT
            pro1.pro_c_id AS pro_c_id1,
            pro2.pro_c_id AS pro_c_id2,
            COUNT(*) AS total_count
        FROM
            property pro1,
            property pro2
        WHERE
            pro1.pro_type = 1 AND
            pro2.pro_type = 1 AND
            pro1.pro_pif_id = pro2.pro_pif_id AND
            # 不需要确保不重复
            pro1.pro_c_id != pro2.pro_c_id
        GROUP BY pro1.pro_c_id, pro2.pro_c_id
        ORDER BY pro_c_id1
    ) AS raw
WHERE total_count >= 2;
/*  end  of  your code  */