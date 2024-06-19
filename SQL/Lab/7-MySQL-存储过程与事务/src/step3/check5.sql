use finance1;
set @payer_id = 1900; set @payer_card = '6228365310342443';
set @payee_id = 1900; set @payee_card = '4270304201500306';
set @v = 9042; set @retcode = -1;
call sp_transfer(@payer_id, @payer_card, @payee_id, @payee_card, @v, @retcode);
select @retcode;
select * from bank_card;
-- where b_c_id in (100,700,1600,1900);
