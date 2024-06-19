#!/bin/bash
# shellcheck shell=bash

mv data/workspace/myshixun/src/test$1/test$1.sql data/workspace/myshixun/src/test$1/test$1.origin.sql
cp $1.sql data/workspace/myshixun/src/test$1/test$1.sql
cd data/workspace/myshixun || exit
./src/test$1/test.sh

