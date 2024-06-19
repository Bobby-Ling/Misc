use finance1;

-- type 21 is illegal!
insert into property values(2001,2000,1,21,'可用',1,800,CURDATE()); 
select * from property where pro_id = 2001;
 
