#!/bin/bash
# shellcheck shell=bash
KCONFIG_CONFIG='config-wsl-modified-6.6.36.3'
# ARCH=x86_64
ARCH=x86
image_path=./arch/x86/boot/bzImage
target_path=$wingit/Linux/bzImage