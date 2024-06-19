use finance1;

-- insurance #40 not found! 
insert into property values(2002,2000,40,2,'可用',1,800,CURDATE()); 
select * from property where pro_id = 2002;
 
 