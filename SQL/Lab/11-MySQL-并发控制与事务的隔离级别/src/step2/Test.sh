#! /bin/bash
mysql -uroot -p123123 <<EDF
drop database if exists mydb;
CREATE DATABASE mydb;
USE mydb;

create table account(
	name varchar(25) not null,
	money int not null
);

insert into account values ('A',100),('B',100);
EDF
#执行sql文件
mysql -uroot -p123123 -t < src/step2/query2.sql

