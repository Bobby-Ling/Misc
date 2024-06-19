#!/bin/bash
# shellcheck shell=bash

echo "finance1" | ./src/test$1/check.sh
echo ""
echo "finance2" | ./src/test$1/check.sh
