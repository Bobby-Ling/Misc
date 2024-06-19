USE finance1;
SET @payer_id = 1600;
SET @payer_card = '4270302211625243';
SET @payee_id = 100;
SET @payee_card = '4270304201142362';
SET @v = 1095;
SET @retcode = -1;
CALL sp_transfer(@payer_id, @payer_card, @payee_id, @payee_card, @v, @retcode);
SELECT @retcode;
SELECT *
FROM bank_card;
-- where b_c_id in (100,700,1600,1900);
SELECT @retcode;
