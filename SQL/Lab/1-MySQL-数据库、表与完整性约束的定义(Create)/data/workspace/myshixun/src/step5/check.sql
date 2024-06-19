use MyDb;


select  COLUMN_NAME as Field, 
        COLUMN_TYPE as Type, 
        IS_NULLABLE as `Null`,
        COLUMN_KEY as `Key`, 
        COLUMN_DEFAULT as `DEFAULT`
from  information_schema.COLUMNS
where TABLE_SCHEMA='MyDb' and TABLE_NAME in ('hr') 
order by COLUMN_NAME;

-- desc hr;
select id,name,mz from hr where id = 'TEST01';