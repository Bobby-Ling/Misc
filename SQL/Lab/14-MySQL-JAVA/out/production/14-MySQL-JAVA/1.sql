SELECT
    c_name,
    c_mail,
    c_phone
FROM client
WHERE c_mail IS NOT NULL;