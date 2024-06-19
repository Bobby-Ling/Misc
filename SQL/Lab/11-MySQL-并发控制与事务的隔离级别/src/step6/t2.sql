-- 事务2:
USE testdb1;
START TRANSACTION;
# SET @n = SLEEP(1);
UPDATE ticket SET tickets = tickets - 1 WHERE flight_no = 'MU2455';
COMMIT;
