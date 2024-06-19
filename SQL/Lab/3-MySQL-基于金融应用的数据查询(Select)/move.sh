#!/bin/bash
# shellcheck shell=bash

for ((i=1;i<=19;i++)); do
	cat $i.sql > ./src/test$i/test$i.sql
done
