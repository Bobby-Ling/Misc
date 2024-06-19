-- 15) 查询资产表中客户编号，客户基金投资总收益,基金投资总收益的排名(从高到低排名)。
--     总收益相同时名次亦相同(即并列名次)。总收益命名为total_revenue, 名次命名为rank。
--     第一条SQL语句实现全局名次不连续的排名，
--     第二条SQL语句实现全局名次连续的排名。

-- (1) 基金总收益排名(名次不连续)

/* 使用窗口函数
连续排名: row_number(), 排名即行号
同分同名, 不跳级: dense_rank(), 致密排名, 类似1、2、2、3……这种, 因为不跳级, 所以比较"致密"
同分同名, 跳级: rank(), 普通排名, 类似1、2、2、4……这种 

order by: 与常规SQL语句中order by一致, 表示按照某一字段进行排序, 也区分ASC还是DESC
partion by: 用作分类依据, 缺省时表示不分类, 对所有记录排序; 若指定某一字段, 则表示在该字段间进行独立排序, 跨字段重新开始
*/

-- 'rank'要加引号
SELECT 
    pro_c_id,
    SUM(pro_income) AS total_revenue,
    RANK() OVER(ORDER BY SUM(pro_income) desc) AS 'rank'
FROM property
WHERE pro_type = 3
GROUP BY pro_c_id
ORDER BY total_revenue desc, pro_c_id;

-- (2) 基金总收益排名(名次连续)

SELECT 
    pro_c_id,
    SUM(pro_income) AS total_revenue,
    DENSE_RANK() OVER(ORDER BY SUM(pro_income) desc) AS 'rank'
FROM property
WHERE pro_type = 3
GROUP BY pro_c_id
ORDER BY total_revenue desc, pro_c_id;

/*  end  of  your code  */