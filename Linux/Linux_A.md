# Linux A

## 安装

依据[微软官方文档](https://learn.microsoft.com/zh-cn/windows/wsl)安装配置WSL2

## WSL2

- 常用命令

```
# 查看wsl版本
wsl -l -v
# 查看正在wsl中运行的linux发行版
wsl --list --running
# 关闭所有正在wsl中运行的linux发行版
wsl --shutdown
```

- 占用内存过大解决

  - 修改%UserProfile%\.wslconfig

  ```
  # Settings apply across all Linux distros running on WSL 2
  [wsl2]

  # Limits VM memory to use no more than 2 GB, this can be set as whole numbers using GB or MB
  memory=2GB 

  # Sets the VM to use two virtual processors
  processors=6

  # Sets amount of swap storage space to 2GB, default is 25% of available RAM
  swap=2GB

  # Sets swapfile path location, default is %USERPROFILE%\AppData\Local\Temp\swap.vhdx
  # swapfile=C:\\temp\\wsl-swap.vhdx
  ```

  - 然后

  ```
  wsl --shutdown
  ```

  - 查看是否生效

  ```bash
  # 查看内存、swap大小
  free -m
  # 查看处理器个数
  cat /proc/cpuinfo| grep "processor"| wc -l
  ```
  - linux释放cache
  ```
  echo 3 > /proc/sys/vm/drop_caches
  ```

## 打开terminal

使用Windows terminal连接至Ubuntu的终端

## 文件目录等操作

重点注意ls cp mv rm

- ls
  - 参数
    - ls:目录和文件
    - -a:all,包括.开头
    - -A:不包括.开头
    - -l:属性权限
    - -t:时间
    - -h, --human-readable
    - -i, --inode
    - -r, --reverse
    - -R, --recursive
    - -S     sort by file size, largest first
  - 常用:
    - 由旧到新:-rtl
    - 仅显示目录:ls -d */
    - 全部文件:-lR
- cp
  - 参数
    - -a, --archive,=-dpR,它保留链接、文件属性，并复制目录下的所有内容。其作用等于dpR参数组合
    - -R, -r, --recursive
    - -p  same as --preserve=mode,ownership,timestamps除复制文件的内容外，还把修改时间和访问权限也复制到新文件中。
    - -s, --symbolic-link
    - -l, --link,hard link files instead of copying
    - -d  ame as --no-dereference --preserve=links复制时保留链接
    - -u, --update
    - -i, --interactive
    - -f, --force
    - -v, --verbose
  - 常用
    - cp –r srcdir/ destdir(使用-r复制目录,srcdir下所有文件复制至destdir下)
    - cp ~/src.txt a/aa/aaa
    - cp ~/src.txt a/aa/aaa/aaaa.txt
- mv
  - 参数
    - -u, --update
    - -f, --force
    - -n, --no-clobber，不覆盖
    - -b, 覆盖前备份
    - -i, --interactive
    - -v, --verbose
  - 常用
    - mv src/aa/ dest/(移动的是目录aa/)
    - mv src/aa/- dest/(移动的是文件)
    - mv src/aa/a.txt dest/b.txt(覆盖文件)
- mkdir

  - -p:递归(-p, --parents)
  - -m:权限(-m, --mode=MODE)
- rmdir

  - -v, --verbose
  - -p, --parents,当子目录被删除后使它也成为空目录的话，则顺便一并删除
- rm
  - -r, -R, --recursive
  - -f, --force
  - --interactive[=WHEN]
    prompt according to WHEN: never, once (-I),  or  always (-i); without WHEN, prompt always
  - -d, --dir,删除空目录
  - -v, --verbose
- pwd
  - -P, --physical真实路径
  - -L, --logical
- chmod
  - -v, --verbose
  - -c, --changes(仅在更改时才显示)
  - -R, --recursive
- 其他
  - ./    本目录下
  - ../   同级目录
  - /dev/ 根目录
## bash脚本
- 注意：
  - echo会自动换行
  - #!/bin/sh与#!/bin/bash的不同
    - 对'\n'(单引号内容)的处理 
    - 对{#name[0]}的处理 
    - etc
- 变量
- 数组
  - 关联数组
  - 检索
  - 长度
  ```bash
  declare -A arrname=(["aaa"]=)
- 传递参数
  - $0 文件名
  - $n 第n个参数
  - $# 个数
  - $- (字符串)合并输出所有参数
  - $@ 分别输出所有参数
- 运算:
  - awk和expr
  - 算数运算符
  - 关系运算符
    - -eq
    - -ne
    - ==
    - !=
    - -gt (greater)
    - -lt (less)
    - -ge
    - -le
  - 布尔运算符
    - !  not
    - -o or
    - -a and
  - 逻辑运算符
    - && ``[ $a -lt 20 && $b -gt 100 ] ``
    - ||
  - 字符串运算符
    - ``[ $a = $b ] ``
    - ``[ $a != $b ] ``
    - -z
    - -n
    - $
  - 文件测试运算符
  略
  - 注意
    - 注意空格:``[ $a == $b ],[ $a -lt 20 -o $b -gt 100 ] ,val=`expr 2 + 2` ``
    - 乘号`(*)`前边必须加反斜杠`(\)`才能实现乘法运算
- 输入输出
  - read
  - echo
  - printf
  - 重定向
- 流程控制
  - if...fi
  - for...done
  - while...done
  - case...esac
  - break和continue
- 函数
- Exp:
  ```bash
  #!/bin/bash
  #name='aaa''\n''bbb'
  #name2='ccc'
  #echo ${name}
  #echo ${#name2}
  array1=(1 "2" 3)
  echo ${array1}
  # ${array1[@/*]}数组全部
  echo ${array1[@]}
  echo ${array1[*]}
  echo ${array1[2]}
  echo '---------------------'
  echo "examples: \$*"
  for i in "$*";do
          echo $i
  done
  echo 'examples: $@'
  for i in "$@";do
          echo $i
  done
  #批量创建文件
  val=1
  while [ ${val} -le 40 ]
  do
          touch ${val}.test
          let "val++"
  done
  echo 'done!'

  ```