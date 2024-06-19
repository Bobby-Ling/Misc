-- 4) 	查找相似的理财产品

--   请用一条SQL语句实现该查询：
/*    在某些推荐方法中，需要查找某款理财产品相似的其他理财产品，不妨设其定义为：对于某款理财产品A，可找到持有A数量最多的“3”个（包括所有持有相同数量的客户，因此如有3个并列第一、1个第二、一个第三，则排列结果是1,1,1,2,3）客户，然后对于这“3”个客户持有的所有理财产品（不包含产品A自身），每款产品被全体客户持有总人数被认为是和产品A的相似度，若有相似度相同的理财产品，则为了便于后续处理的确定性，则这些相似度相同的理财产品间按照产品编号的升序排列。按照和产品A的相似度，最多的“3”款（同上理，前3名允许并列的情况，例如排列结果是1,2,2,2,3）理财产品，就是产品A的相似的理财产品。
请查找产品14的相似理财产品编号（不包含14自身）（pro_pif_id）、该编号的理财产品的购买客户总人数（cc）以及该理财产品对于14 号理财产品的相似度排名值（prank）。
注意结果输出要求：按照相似度值降序排列，相同相似度的理财产品之间则按照产品编号的升序排列。*/

WITH
    most_owner_of_14_top3 AS (
        # 持有理财产品14的top3客户
        SELECT
            pro_c_id
        FROM
            (
                # 持有理财产品14的客户及持有数量、排名
                SELECT
                    pro_c_id,
                    pro_quantity,
                    DENSE_RANK() OVER (ORDER BY pro_quantity DESC) AS rk
                FROM
                    property
                WHERE
                    pro_pif_id = 14 AND pro_type = 1
                ORDER BY pro_quantity DESC
            ) AS most_owner_of_14
        WHERE
            rk <= 3
                             ),
    all_products_of_top3 AS (
        # 连续嵌套
        # top3用户持有的所有理财产品(除了14)
        SELECT
#             pro_quantity,
#             property.pro_c_id,
            pro_pif_id
        FROM
            most_owner_of_14_top3,
            property
        WHERE
            most_owner_of_14_top3.pro_c_id = property.pro_c_id AND
            property.pro_type = 1 AND
            property.pro_pif_id != 14
                            ),
    hold_count_of_each_products_owned_by_top3 AS (
        # 每款产品被全体持有的总数
        SELECT
            property.pro_pif_id,
            COUNT(pro_c_id) AS cc
        FROM (
            # 连续嵌套
            # top3用户持有的所有理财产品(除了14)
            SELECT
#         property.pro_quantity,
#         property.pro_c_id,
#         property.pro_type,
                pro_pif_id
            FROM
                (
                    # 持有理财产品14的top3客户
                    SELECT
                        pro_c_id
                    FROM
                        (
                            # 持有理财产品14的客户及持有数量、排名
                            SELECT
                                pro_c_id,
                                pro_quantity,
                                DENSE_RANK() OVER (ORDER BY pro_quantity DESC) AS rk
                            FROM
                                property
                            WHERE
                                pro_pif_id = 14 AND pro_type = 1
                            ORDER BY pro_quantity DESC
                        ) AS most_owner_of_14
                    WHERE
                        rk <= 3
                ) AS most_owner_of_14_top3,
                property
            WHERE
                most_owner_of_14_top3.pro_c_id = property.pro_c_id AND
                property.pro_type = 1 AND
                property.pro_pif_id != 14
             ) AS all_products_of_top3,
            property
        WHERE
            all_products_of_top3.pro_pif_id = property.pro_pif_id AND
            property.pro_type = 1 AND
            property.pro_pif_id != 14
        GROUP BY pro_pif_id
                                                 )
SELECT *
FROM
    (
        SELECT
            pro_pif_id,
            cc,
            DENSE_RANK() OVER (ORDER BY cc DESC ) AS prank
        FROM
            hold_count_of_each_products_owned_by_top3
        ORDER BY cc DESC, pro_pif_id
    ) AS raw
WHERE
    prank <= 3;


/*  end  of  your code  */

SELECT *
FROM (
    SELECT
        pro_pif_id,
        cc,
        DENSE_RANK() OVER (ORDER BY cc DESC ) AS prank
    FROM
        (
            # 每款产品被全体持有的总数
            SELECT
                property.pro_pif_id,
                COUNT(pro_c_id) AS cc
            FROM (
                # 连续嵌套
                # top3用户持有的所有理财产品(除了14)
                SELECT
#         property.pro_quantity,
#         property.pro_c_id,
#         property.pro_type,
                    pro_pif_id
                FROM
                    (
                        # 持有理财产品14的top3客户
                        SELECT
                            pro_c_id
                        FROM
                            (
                                # 持有理财产品14的客户及持有数量、排名
                                SELECT
                                    pro_c_id,
                                    pro_quantity,
                                    DENSE_RANK() OVER (ORDER BY pro_quantity DESC) AS rk
                                FROM
                                    property
                                WHERE
                                    pro_pif_id = 14 AND pro_type = 1
                                ORDER BY pro_quantity DESC
                            ) AS most_owner_of_14
                        WHERE
                            rk <= 3
                    ) AS most_owner_of_14_top3,
                    property
                WHERE
                    most_owner_of_14_top3.pro_c_id = property.pro_c_id AND
                    property.pro_type = 1 AND
                    property.pro_pif_id != 14
                 ) AS all_products_of_top3,
                property
            WHERE
                all_products_of_top3.pro_pif_id = property.pro_pif_id AND
                property.pro_type = 1 AND
                property.pro_pif_id != 14
            GROUP BY pro_pif_id
        ) AS hold_count_of_each_products_owned_by_top3
    ORDER BY cc DESC, pro_pif_id
     ) AS raw
WHERE
    prank <= 3;



# SELECT *
# FROM property
# WHERE
#     pro_pif_id = 4 AND
#     pro_type = 1;
#
# DROP TABLE IF EXISTS most_owner_of_14_top3;
# CREATE TABLE most_owner_of_14_top3 (
#     auto_id INT AUTO_INCREMENT PRIMARY KEY,
#     pro_c_id INT NOT NULL COMMENT '客户编号'
# );
# INSERT INTO most_owner_of_14_top3 VALUES (NULL, 200), (NULL, 1000), (NULL, 1200), (NULL, 1400);
# SELECT property.pro_c_id, pro_pif_id, pro_quantity
# FROM property, most_owner_of_14_top3
# WHERE property.pro_c_id = most_owner_of_14_top3.pro_c_id AND pro_type = 1;
