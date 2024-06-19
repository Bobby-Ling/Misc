#!/bin/bash
# shellcheck shell=bash
<<'COMMENT'
# MySQL的恢复机制

MySQL的备份与恢复工具:
逻辑备份工具：mysqldump
物理备份工具：mysqlbackup(仅限商用版)
日志工具：mysqlbinlog
还原工具：mysql
管理工具：mysqladmin

## mysqldump
逻辑备份工具，它产生一系的SQL语句，执行这些语句可以重建原数据库的所有对象和数据。缺省输出是控制台，可以通过重定向符号，将其产生的SQL语句集合存入到某个文件。
mysqldump可以备份服务器上的全部数据库，也可以指定某些数据库，或者一个数据库中的某些表。
mysqldump -h127.0.0.1 -uroot -p123123 [options] --databases db_name

--databases 参数用指定数据库名，后面可跟一个或多个数据库的名字，多个数据库名间用空格隔开。
mysqldump命令行工具还可以带若干参数，可选的参数多达几十个，详见官方参考手册。这里只介绍一个：
--flush-logs 刷MySQL日志，即重新开始一个日志文件。
重新开始一个新的日志文件，对未来确定哪些日志更有用很有帮助。通常海量备份前的日志文件，其重要性会降低许多，因为有备份在手，除非备份文件出故障，你可能不再需要使用之前的日志文件。

## mysqlbackup
mysqlbackup是MySQL的物理备份工具，只有付费的商用企业版才有。

## mysql
mysql是MySQL最重要的客户端管理工具，通常用户都是通过mysql登录到MySQL服务器，进行各种操作。此外，还可以直接通过它执行SQL脚本，还原或创建新库。
mysql -h127.0.0.1 -uroot -p12313 < mydb.sql
这样会直接执行mydb.sql的脚本。通过mysqldump备份出来的脚 本文件，可以用该方法直接用来恢复原数据库。

## mysqladmin
mysqladmin是MySQL服务器的管理工具，一般用于配置服务器，也可以用来创建或删除数据库：
mysqladmin [options] command [command-arg] [command [command-arg]]
常用的command(执行命令)有：
create db_name 创建数据库
drop db_name 删除数据库
flush-logs 刷日志
flush-tables 刷表，所有表数据写入磁盘盘
kill id,id,...  杀死某些进程
password new_password 修改(登录者的)登录密码
ping 检查服务器是否可用
status 显示服务器状态
variables 显示各配置参数的值
......

## mysqlbinlog
mysqlbinlog是MySQL的日志管理工具。在需要手工介入的故障恢复中，该工具必不可少。当然，平常也可以用它查看日志。
mysqlbinlog  mysql-bin.000983
上面的例子，用来查看日志文件mysql-bin.000983。MySQL的日志文件具有相同的前缀，后面的数字是日志文件的顺序。这个前缀是可配置的。比如，也可能是binlog.*
执行日志文件会导致日志所记录的事件重新做一遍，这样可以恢复一个给定时间段的数据，恢复的方法如下:
mysqlbinlog [option] binlog_files | mysql -u root -p
介质故障的恢复通常需要把最近一次备份后所有的日志文件全部列上。

mysqlbinlog也支持几十个可选的参数，比如：
--disable-log-bin 在通过日志恢复数据库期间不再写日志
--no-defaults 不使用MySQL默认的设置

MySQL还有其它一些工具(如mysqlimport,mysqlshow等)，这里不一一介绍。
COMMENT

#mysqldump -h127.0.0.1 -uroot -p123123 [options] --databases db_name [--flush-logs]
mysqldump -h127.0.0.1 -uroot --databases residents --flush-logs > residents_bak.sql
