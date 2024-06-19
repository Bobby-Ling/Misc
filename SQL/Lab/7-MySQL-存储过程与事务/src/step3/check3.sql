use finance1;
set @payer_id = 1600; set @payer_card = '4270302211625243';
set @payee_id = 100; set @payee_card = '4270304201142362';
set @v = 200000; set @retcode = -1;
call sp_transfer(@payer_id, @payer_card, @payee_id, @payee_card, @v, @retcode);
select @retcode;
select * from bank_card;
-- where b_c_id in (100,700,1600,1900);
