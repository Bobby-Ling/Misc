#!/bin/bash
# shellcheck shell=bash
echo "arg: dir port"
cd $1
scp -P$2 -r root@47.96.157.89:/data/workspace/myshixun/src .
