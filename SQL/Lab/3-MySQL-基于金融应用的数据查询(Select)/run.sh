#!/bin/bash
# shellcheck shell=bash
cat finance.sql   common.sql  $1.sql | mysql -h127.0.0.1 -uroot -p123123