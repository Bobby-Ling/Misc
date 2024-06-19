USE finance1;
-- 请用一条SQL语句删除client表中没有银行卡的客户信息：

# NOT EXISTS
DELETE
FROM
    client
WHERE
    NOT EXISTS(
        SELECT
            1
        FROM
            bank_card
#         如果对于某个client.c_id，能够在bank_card.b_c_id中找到匹配的记录，那么这个子查询将返回1（尽管具体返回什么并不重要，只要返回一些值即可）。
        WHERE client.c_id = bank_card.b_c_id
              );

# NOT IN
/*DELETE
FROM
    client
WHERE c_id NOT IN (
    SELECT
        b_c_id
    FROM
        bank_card
                  );*/

/*
# 单独的合法写法
SELECT
    1
FROM
    client,
    bank_card
WHERE client.c_id = bank_card.b_c_id
*/
/*
EXISTS用于检查子查询是否至少会返回一行数据，该子查询实际上并不返回任何数据，而是返回值True或False
in是把外表和内表作hash连接，而exists是对外表作loop循环，每次loop循环再对内表进行查询，一直以来认为exists比in效率高的说法是不准确的。
如果查询的两个表大小相当，那么用in和exists差别不大；如果两个表中一个较小一个较大，则子查询表大的用exists，子查询表小的用in；

“select 1 from T2 where T1.a=T2.a” 相当于一个关联表查询，相当于
“select 1 from T1,T2 where T1.a=T2.a”
但是，如果你当当执行1)句括号里的语句，是会报语法错误的
*/

/* the end of your code */