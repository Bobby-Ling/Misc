# 请填写语句，完成以下功能：
# (1) 创建角色client_manager和fund_manager；
CREATE ROLE client_manager,fund_manager;
# (2) 授予client_manager对client表拥有select,insert,update的权限；
GRANT SELECT, INSERT, UPDATE ON client TO client_manager;
# (3) 授予client_manager对bank_card表拥有查询除银行卡余额外的select权限；
/*
    不知道为什么报错
    GRANT SELECT ON bank_card TO client_manager;
    REVOKE SELECT (b_balance) ON bank_card FROM client_manager;
*/
GRANT SELECT (b_c_id, b_number, b_type) ON bank_card TO client_manager;
# (4) 授予fund_manager对fund表的select,insert,update权限；
GRANT SELECT, INSERT, UPDATE ON fund TO fund_manager;
# (5) 将client_manager的权限授予用户tom和jerry；
GRANT client_manager TO tom,jerry;
# (6) 将fund_manager权限授予用户Cindy.
GRANT fund_manager TO Cindy;
