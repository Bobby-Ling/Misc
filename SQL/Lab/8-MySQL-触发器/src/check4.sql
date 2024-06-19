use finance1;

-- normal insert 
insert into property values(2004,2000,1,2,'可用',1,800,CURDATE());
select pro_id,pro_c_id,pro_pif_id,pro_type,pro_status,pro_quantity,pro_income  
from property where pro_id = 2004;

