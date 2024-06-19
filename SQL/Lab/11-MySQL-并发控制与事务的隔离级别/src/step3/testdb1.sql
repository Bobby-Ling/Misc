drop database if exists testdb1;
create database testdb1;
use testdb1;

drop table if exists ticket;
create table ticket(flight_no char(6) primary key, tickets int);
insert into ticket values('MU2455',167),('CZ5525',159),('CA8213',301);
