#!/bin/bash
# shellcheck shell=bash source=./kconfig.sh
if [ ! -f "./kconfig.sh" ]; then 
	echo "$(pwd)目录没有kconfig.sh"
	return	
fi
source ./kconfig.sh

# echo "注意这是一个硬链接文件:"
# ls -l $0

build() {
	echo "make KCONFIG_CONFIG=$KCONFIG_CONFIG -j $(nproc)"
	echo "output in build.log"
	make ARCH=$ARCH KCONFIG_CONFIG=$KCONFIG_CONFIG -j $(nproc) 2>&1 | tee build.log
}

modules_install() {
	# ${parameter:-default_value}
	local install_path=${1:-/}
	echo "sudo make ARCH=$ARCH -j $(nproc) modules_install INSTALL_MOD_PATH=$install_path"
	sudo make ARCH=$ARCH -j $(nproc) modules_install INSTALL_MOD_PATH=$install_path
}

headers_install() {
	local install_path=${1:-/usr/include/kernelheader}
	echo "sudo make ARCH=$ARCH -j $(nproc) headers_install INSTALL_HDR_PATH=$install_path"
	sudo make ARCH=$ARCH -j $(nproc) headers_install INSTALL_HDR_PATH=$install_path
}

menuconfig() {
	# 配置选项CONFIG_KCONTIG_PROC把完整的压缩过的内核配置文件存放在/proc/config
	# zcat /proc/config.gz > .config
	echo "make menuconfig KCONFIG_CONFIG=$KCONFIG_CONFIG"
	make menuconfig KCONFIG_CONFIG=$KCONFIG_CONFIG 
}

qemu_install() {
	# 前面的返回值为0时表示true, 即非0才执行return 1
	pwd
	cp -f $image_path ./qemu/
	sudo qemu-nbd --connect=/dev/nbd0 ./qemu/disk.qcow2 || echo "已经连接"
	sudo mount /dev/nbd0p2 ./qemu/qcow2 || echo "已经挂载"
	modules_install ./qemu/qcow2/
	headers_install ./qemu/qcow2/usr/include/kernelheader
	sudo umount ./qemu/qcow2
	sudo qemu-nbd -d /dev/nbd0
}

wsl_install() {
	# if [ $(md5sum $target_path | awk '{$1}') != $(md5sum $image_path | awk '{$1}') ]; then echo 1; fi 一行
	if [ -e $target_path ] && [ $(md5sum $target_path | awk '{$1}') != $(md5sum $image_path | awk '{$1}') ]; then
		echo "sudo mv -- $wingit/Linux/bzImage $wingit/Linux/bzImage_$(date +"%Y-%m-%d_%H-%M-%S")"
		sudo mv -- $wingit/Linux/bzImage $wingit/Linux/bzImage_$(date +"%Y-%m-%d_%H-%M-%S") || return 1
	fi
	echo "sudo cp -f $image_path $wingit/Linux/"
	sudo cp -f $image_path $wingit/Linux/
}

all() {
	start_time=$(date +"%Y-%m-%d %H:%M:%S")
	startTime_s=$(date +%s)
	echo "开始于: $start_time"
	build
	if [ $? -eq 0 ]; then
		echo "编译成功"

		end_time=$(date +"%Y-%m-%d %H:%M:%S")
		endTime_s=$(date +%s)
		echo "结束于: $end_time"
		end_seconds=$(date -d "$end_time" +%s)
		duration=$(( $endTime_s - $startTime_s ))

		modules_install
		if [ $? -eq 0 ]; then
			echo "模块安装成功"
			headers_install
			if [ $? -eq 0 ]; then
				echo "头文件安装成功"

				echo "编译时间: $duration s"
				if [ -e $image_path ] && [ $? -eq 0 ]; then
					wsl_install || echo "WSL安装失败"
					qemu_install || echo "QEMU安装失败"
					echo "安装成功"
				else 
					echo "安装失败"
				fi
			else 
				echo "头文件安装失败"
			fi
		else
			echo "模块安装失败"
		fi
		
	else
		echo "编译失败"
	fi	
}

gen_compile_commands() {
	echo "./scripts/clang-tools/gen_compile_commands.py "
	./scripts/clang-tools/gen_compile_commands.py 
	echo "bear --output ./compile_commands.json --append  -- make -j $(nproc) tools/all"
	bear --output ./compile_commands.json --append  -- make -j $(nproc) tools/all
}

help() {
    echo "Usage: ./build.sh {build|modules_install|headers_install|wsl_install|qemu_install|all|menuconfig|gen_compile_commands|help}"
}

_script_completions() {
	# COMP_WORDS 	类型为数组，存放当前命令行中输入的所有单词
	# COMP_CWORD 	类型为整数，当前输入的单词在COMP_WORDS中的索引
	# COMPREPLY 	类型为数组，候选的补全结果
	# COMP_WORDBREAKS 	类型为字符串，表示单词之间的分隔符
	# COMP_LINE 	类型为字符串，表示当前的命令行输入字符
	# COMP_POINT 	类型为整数，表示光标在当前命令行的哪个位置
    local cur prev opts
    COMPREPLY=()
    cur="${COMP_WORDS[COMP_CWORD]}"
    prev="${COMP_WORDS[COMP_CWORD-1]}"
    opts="build modules_install headers_install wsl_install qemu_install all menuconfig gen_compile_commands help"

	COMPREPLY=( $(compgen -W "${opts}" -- ${cur}) )
	return 0
}

complete -F _script_completions ./build.sh

# $#参数个数
if [ $# -eq 0 ]; then
    # echo "build_all"
	# build_all
	# exit 0会退出当前shell
	# return $?
	return 0
fi

case "$1" in
    build) # 取值后面必须为单词in, 每一模式必须以右括号结束, 每个分支以;;结束
        build
        ;;
    modules_install)
        modules_install
        ;;
    headers_install)
        headers_install
        ;;
    wsl_install)
        wsl_install
        ;;
    qemu_install)
        qemu_install
        ;;
	all)
        all
        ;;
    menuconfig)
        menuconfig
        ;;
	gen_compile_commands)
		gen_compile_commands
		;;
    help)
        help
        ;;
    *)
        echo "目标错误"
        help
        exit 1
        ;;
esac