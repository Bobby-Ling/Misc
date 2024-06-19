-- 6) 查找相似的理财客户
--   请用一条SQL语句实现该查询：
/* 在某些推荐方法中，需要查找某位客户在理财行为上相似的其他客户，不妨设其定义为：对于A客户，其购买的理财产品集合为{P}，另所有买过{P}中至少一款产品的其他客户集合为{B}，则{B}中每位用户购买的{P}中产品的数量为他与A客户的相似度值。将{B}中客户按照相似度值降序排列，得到A客户的相同相似度值则按照客户编号升序排列，这样取前两位客户即为A客户的相似理财客户列表。
  查询每位客户(列名：pac)的相似度排名值小于3的相似客户(列名：pbc)列表，以及该每位客户和他的每位相似客户的共同持有的理财产品数(列名：common)、相似度排名值(列名：crank)。
  注意结果输出要求：要求结果先按照左边客户编号(pac)升序排列，同一个客户的相似客户则按照客户相似度排名值（crank）顺序排列。*/

WITH
    intersection      AS (
        # 求的是任意两用户间的交集大小
        SELECT
            pro1.pro_c_id AS pro_c_id1,
            pro2.pro_c_id AS pro_c_id2,
            COUNT(*) AS common
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
        ORDER BY pro_c_id1, common, pro_c_id2
                         )
  , intersection_top2 AS (
    # top2的交集
        SELECT
            pro_c_id1 AS pac,
            pro_c_id2 AS pbc,
            common,
#     RANK() OVER (PARTITION BY pro_c_id1 ORDER BY common DESC ) AS crank
            ROW_NUMBER() OVER (PARTITION BY pro_c_id1 ORDER BY common DESC, pro_c_id2) AS crank
        FROM
            intersection
                         )
SELECT *
FROM
    intersection_top2
WHERE crank <= 2;
/*  end  of  your code  */