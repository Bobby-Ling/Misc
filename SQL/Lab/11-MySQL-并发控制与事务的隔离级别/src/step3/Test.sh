#! /bin/bash

#执行sql文件

mysql -uroot -p123123 -t << EDF
USE mydb;

select * from account;

EDF