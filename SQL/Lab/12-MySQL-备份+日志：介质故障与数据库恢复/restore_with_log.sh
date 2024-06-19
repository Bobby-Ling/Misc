#!/bin/bash
# shellcheck shell=bash

mysql -h127.0.0.1 -uroot < train_bak.sql

# mysqlbinlog [option] binlog_files | mysql -u root -p
# option ::= [--disable-log-bin|--no-defaults|...]

mysqlbinlog --no-defaults log/binlog.000018 | mysql -uroot