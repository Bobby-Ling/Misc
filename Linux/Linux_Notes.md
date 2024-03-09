# Linux B

## 安装

依据[微软官方文档](https://learn.microsoft.com/zh-cn/windows/wsl)安装配置WSL2

## WSL2

### 常用命令

```
# 查看wsl版本
wsl -l -v
# 查看正在wsl中运行的linux发行版
wsl --list --running
# 关闭所有正在wsl中运行的linux发行版
wsl --shutdown
```

### 占用内存过大解决

  - 修改%UserProfile%\.wslconfig

  ```powershell
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

  ```powershell
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

  ```bash
  echo 3 > /proc/sys/vm/drop_caches
  ```
### 强制重启
```powershell
# powershell管理员模式
taskkill -IM "wslservice.exe" /F 
wsl --shutdown
# 然后重新打开即可
```

### Windows10启用systemd
```bash
sudo vi /etc/wsl.conf
# 加入:
# [boot]
# systemd=true
```

>
https://learn.microsoft.com/en-us/windows/wsl/troubleshooting#error-0x80370102-the-virtual-machine-could-not-be-started-because-a-required-feature-is-not-installed
## 权限管理

### 文件类型和权限
`drwxr-xr-x. 3 root root 17 May 6 00:14 .config `
- 文件类型
  - 当为`d `则是目录, 例如上表文件名为“.config”的那一行
  - 当为`- `则是文件, 例如上表文件名为“initial-setup-ks.cfg”那一行
  - 若是`l `则表示为链接文件(link file)
  - `b ` 区块(block) 设备文件,如硬盘,可以随机的在硬盘的不同区块读写(可随机存取设备)
  - `c ` 字符(character) 设备文件,如键盘/鼠标(一次性读取设备)
  - `s ` 数据接口文件(sockets) 例如,可以启动一个程序来监听用户端的要求, 而用户端可以通过这个socket来进行数据的沟通
  - `p ` 数据输送档(FIFO,first-in-first-out, pipe) 一种特殊的文件类型,旨在解决多个程序同时存取一个文件所造成的错误问题
- 文件权限
  - `r ` 读取文件内容或读取目录结构清单(可以用ls读取文件名但不能cd进入和ll查看文件详细信息)
  - `w ` 修改文件内容或修改目录结构清单(创建/删除(不论文件权限如何)/移动/重命名文件或目录)
  - `x ` 执行文件或访问目录(仅有x不能列出文件清单但是可以凭借文件名访问(查看/编辑文件))
  ```bash
  $ ll
  drwxr-xr-x 2 bobby_ubuntu bobby_ubuntu 4096 Jan 25 18:51 xxx/
  $ chmod 100 xxx
  # (x)可以cd进入,但是无法列出文件
  $ cd xxx
  $ ls
  ls: cannot open directory '.': Permission denied
  # 直接访问并修改文件
  $ cat 1.txt
  111
  $ echo 'can modify file'>>1.txt
  $ cat 1.txt
  111can modify file
  # 修改目录权限为400(r),可以ls,但是不能访问
  $ chmod 400 .
  $ cd ..
  $ cd xxx
  -bash: cd: xxx: Permission denied
  $ ls xxx
  ls: cannot access 'xxx/2': Permission denied
  ls: cannot access 'xxx/1.txt': Permission denied
  1.txt  2
  $ ll xxx
  ls: cannot access 'xxx/.': Permission denied
  ls: cannot access 'xxx/2': Permission denied
  ls: cannot access 'xxx/1.txt': Permission denied
  ls: cannot access 'xxx/..': Permission denied
  total 0
  d????????? ? ? ? ?            ? ./
  d????????? ? ? ? ?            ? ../
  -????????? ? ? ? ?            ? 1.txt
  d????????? ? ? ? ?            ? 2/

  # xxx权限rw-,yyy权限777
  $ cat xxx/yyy/y
  cat: xxx/yyy/y: Permission denied

  id -gn bobby_ubuntu #查看主用户组名称
  ```
> 使用`su - `这个指令来切换身份,离开`su - `则使用 `exit `回到 dmtsai 的身份

- 文件默认权限umask
  - 介绍
  文件的默认权限为666, 目录的为777,umask指的是默认值需要减掉的权限;例如umask为003,去除的权限为--------wx, 因此文件为-rw-rw-r--,目录为drwxrwxr--
  - 应用
  团队共享文件夹的umask应该设置为002而非默认值022以保证group内所有人的写入权限
  - 命令
    - 查看umask: `umask `
    - 以符号类型的方式查看umask: `umask -S `
    - 修改umask: `umask UMASK `
    - 见man umask
    - 默认umask: /etc/bashrc

- 文件隐藏权限 (chattr和lsattr)

- 文件特殊权限 SUID, SGID, SBIT

- 




### 命令
- chmod
  - `chmod [-Rcfv] [ugoa...][[-+=][rwxXst]...] file `
  - 处理符号链接: 不会更改符号链接,会更改其指向文件的权限
  - 对于目录,x为可进入权限,w为增删权限(可以重命名目录本身和修改其中已有的文件)
  - -R 递归
  - -c 显示更改了的文件
  ```bash
  chmod u=rwx,go=rx .bashrc
  chmod 777 test.sh
  chmod a+x test.sh
  ```
- chown
  - `chown [-Rcfv]  [owner][:[group]] file `
  - `--dereference `
  - `-h, --no-dereference `
  ```bash
  chown owner file #
  chown owner: file # the group of  the  files is changed to that user's login group
  chown owner:group file #
  chown :group file # =chgrp
  chown : file # 无效
  chown file # 无效

  ```

- chgrp

- file

## 文件目录等操作

###文件目录管理

- ls
  - 参数
    - `-a `  all,包括隐藏文件和所有目录
    - `-A `  all,包括隐藏文件,不包括`. `和`.. `目录
    - `-l `  详细信息显示(属性权限时间等)
    - `-F `  在文件名末显示出该文件名代表的类型
    - `-d `  仅列出目录本身,而不是列出目录内的文件数据???
    - `-f `  直接列出结果(默认会以文件名排序)
    - `-t `  时间,新到旧
    - `-rt `  时间,新到旧
    - `-S `  大小,从大到小
    - `-r `  --reverse
    - `-R `  --recursive  (列出该目录下的所有文件)
    - `-h `  --human-readable  (KB,MB...)
    - `-n `  列出UID和GID而非其名称
    - `-i `  --inode
    - `--time=TIME `  查看ctime,mtime,atime
    - `-l `  --full-time
    > 如果这个文件被修改的时间距离现在太久了, 那么时间部分会仅显示年份而已, 所以显示出完整的时间格式要在`-l `中用`--full-time `
  - 常用:
    - 由旧到新:-rtl
    - 仅显示目录:ls -d */
    - 全部文件:-lR
    - 不显示owner和group:-gG
  - 例子
    ```bash
    ls -ltgG
    ls -p | grep -E "[a-zA-Z0-9._-]+" #ls -只列出文件
    ```
- cp
  - 参数
    - `-a `  --archive, 同`-dR --preserve=all `,它保留链接、文件属性,并复制目录下的所有内容;其作用等于dpR参数组合
      > 无法复制ctime这个属性???
    - `-R `  -r, --recursive
    - `-p `  same as --preserve=mode,ownership,timestamps除复制文件的内容外,还把修改时间和访问权限也复制到新文件中。
    - `-d `  --no-dereference --preserve=links复制时保留链接(cp默认复制源文件)
    - `-s `  --symbolic-link复制成为符号链接文件(快捷方式,文件名右侧会有个指向`-> `的符号)
    - `-l `  --link复制为硬链接
    - `-u `  --update
    - `-i `  --interactive
    - `-f `  --force
    - `-v `  --verbose
  - 常用
    - cp –r srcdir/ destdir(使用-r复制目录,srcdir下所有文件复制至destdir下)
    - cp ~/src.txt a/aa/aaa
    - cp ~/src.txt a/aa/aaa/aaaa.txt
    - rm -- -aaa--避开文件名中`- `的影响
- mv
  - 参数
    - -u, --update
    - -f, --force
    - -n, --no-clobber,不覆盖
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
  ```bash
  mkdir -p 11/22/33 -m 777
  # 仅目录33权限设置为777
  ```
- rmdir
  - -v, --verbose
  - -p, --parents,当子目录被删除后使它也成为空目录的话,则顺便一并删除
- rm
  - -r, -R, --recursive
  - -f, --force
  - --interactive[=WHEN]
    prompt according to WHEN: never, once (-I),  or  always (-i); without WHEN, prompt always
  - -d, --dir,删除空目录
  - -v, --verbose
  - 例子
  ```bash
  ls | grep -v keep | xargs rm #删除keep文件之外的所有文件, -v参数决定了结果为匹配之外的结果
  find ./ -name '*.txt' -exec echo "Found file: {}" \; -exec cp {} /path/to/destination/ \; #-exec执行多个命令

  find ./ -type f -name "*.sh" -exec chmod +x {} \; # 递归添加执行权限
  ```
- pwd
  - -P, --physical真实路径
  - -L, --logical
- basename dir
- dirname dir
- cd
  - `. ` 此目录
  - `.. ` 上一级目录
  - `/ ` 根目录
  - `- ` 上一次访问的目录
  - `~ `
  - `~account `

### 文件查阅

- cat [-AETvbn] (Concatenate)
  - `-A `  相当于 -vET 的整合选项, 可列出一些特殊字符而不是空白
  - `-E `  将结尾的断行字符 $ 显示出来
  - `-T `  将 [tab] 按键以 ^I 显示出来
  - `-v `  列出一些看不出来的特殊字符
  - `-b `  列出行号, 仅针对非空白行做行号显示, 空白行不标行号
  - `-n `  打印出行号, 连同空白行也会有行号, 与 -b 的选项不同

- tac (反向)
见man tac
- nl(行号)
见man nl

- more
当文件内容行数大于屏幕输出的行数时,最后一行会显示出目前显示的百分比,并等待指令
  - Enter : 代表向下翻一行
  - 空白键 (Space) : 代表向下翻一页
  - /string : 代表在这个显示的内容当中, 向下搜寻“string”这个关键字
  - n : 搜索时向下继续搜索
  - :f : 立刻显示出文件名以及目前显示的行数
  - q : 退出
  - b 或 [ctrl]-b : 代表往回翻页, 只对文件有用, 对管道无用

- less
  - Enter : 代表向下翻一行
  - 空白键 (Space) : 代表向下翻一页
  - [pagedown] : 向下翻动一行
  - [pageup] : 向上翻动一行
  - /string : 代表在这个显示的内容当中, 向下搜寻“string”这个关键字
  - ?string : 向上搜索
  - n : 搜索时继续搜索
  - N : 搜索时反向继续搜索(向上搜索时为向下,反之亦然)
  - g : 前进文件的第一行去
  - G : 前进文件的最后一行去
  - :f : 立刻显示出文件名以及目前显示的行数
  - q : 退出
  - b 或 [ctrl]-b : 代表往回翻页, 只对文件有用, 对管道无用

- head [-n number] file
显示前number行内容
> 注意:number为`-number `时显示除了后面number行的内容

- tail [-nf number] [--pid=PID] file
> 注意:number为`+number `时显示除了前面number行的内容
  - `-f `  持续侦测
  - `--pid=PID `  当pid为PID的进程终止时停止侦测,按下[crtl]-c停止侦测
  ```bash
  # 取第11至20行且带行号
  cat -n /etc/man_db.conf | head -n 20 | tail -n 10
  ``` 

- od [-t TYPE] file二进制文件查看
  - TYPE选项:
    - a : 利用默认的字符来输出
    - c : 使用 ASCII 字符来输出
    - d[size] : 利用十进制(decimal) 来输出数据, 每个整数占用 size Bytes 
    - f[size] : 利用浮点数值(floating) 来输出数据, 每个数占用 size Bytes 
    - o[size] : 利用八进位(octal) 来输出数据, 每个整数占用 size Bytes 
    - x[size] : 利用十六进制(hexadecimal) 来输出数据, 每个整数占用 size Bytes 
  ```bash
  $ od -t cd1 abc
  0000000    a    b    c    d    e    f    g    h    i    j    k    l    m    n    o    p
            97   98   99  100  101  102  103  104  105  106  107  108  109  110  111  112
  0000020    q    r    s    t    u    v    w    x    y    z   \n
           113  114  115  116  117  118  119  120  121  122   10
  0000033
  # 左侧8进制表示Bytes数

- touch [-acdmt] file 修改(更新)文件时间戳
  - 时间戳类型
    - modification time (mtime) 内容修改时间
    - status time (ctime) 属性与权限修改时间
    - access time (atime) 最新读取时间
  - 参数
    - `-a `  仅修改atime
    - `-m `  仅修改mtime
    - `-d `  --date=STRING, 使用STRING(格式见man和info)而非当前日期
    - `-t [[CC]YY]MMDDhhmm[.ss]`  使用给定的时间戳而非当前时间
    - `-c `  仅修改文件的时间, 若该文件不存在则不创建新文件
    - `-r`   --reference=FILE, 使用FILE的时间

### 文件查找

## bash脚本

### bash语法

- 注意:

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
  ```
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
    - 乘号 `(*)`前边必须加反斜杠 `(\)`才能实现乘法运算
- 输入输出

  - read
  - echo
  - printf
  - 重定向
    - 命令

      - command > file 输出(>> 追加)
      - command < file 输入
      - n > file (n为0,1,2)(>> 追加)
      - Here Document
    - 注意与示例

      - ``command < in > out ``
      - 合并stdout和stderr ``command > file 2>&1 ``
      - 

      ```bash
      #!/bin/bash
      cat << delimeter
        qwer
        asdf
      delimeter
      ```

      - 屏蔽所有输出 ``command > /dev/null 2>&1 ``
      - ``command > /dev/null ``
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
  # shellcheck shell=bash
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

### 常用bash命令和规范
## SSH

- 远程登录
  略
- scp

  - 参数
    - -p same as --preserve=mode,ownership,timestamps
    - -r
    - -v --verbose
    - -P 指定端口`scp -P 8876 ...
  - 复制文件和目录 `scp local remote `

  ```bash
  scp local_file remote_username@remote_ip:remote_folder 
  scp local_file remote_username@remote_ip:remote_file 
  scp local_file remote_ip:remote_folder 
  scp local_file remote_ip:remote_file 
  # 远程->本地反之
  # 如果路径中有空格,则必须使用双反斜杠 \\ 并将整个路径用引号引起来转义字符:
  ```

## 管道

- 举例
  - grep "/sbin/nologin" /etc/passwd | wc -l
  - cat readme.txt | wc -l

## tmux

- C/S模型构建
  输入tmux命令就相当于开启了一个服务器,此时默认将新建一个会话,然后会话中默认新建一个窗口,窗口中默认新建一个面板。一个tmux session(会话)可以包含多个window(窗口),窗口默认充满会话界面,因此这些窗口中可以运行相关性不大的任务。一个window又可以包含多个pane(面板),窗口下的面板,都处于同一界面下,这些面板适合运行相关性高的任务,以便同时观察到它们的运行情况。
- 会话session

  - 新建会话

  ```bash
  tmux # 新建一个无名称的会话(名称为(编号)0,1,2,...)
  tmux new -s demo # 新建一个名称为demo的会话
  ```

  - 断开当前会话([Ctrl]+b+ d)

  ```bash
  tmux detach # de-attach断开当前会话,会话在后台运行
  ```

  - 进入之前的会话

  ```bash
  tmux attach-session -t session-name 
  #简写为:
  tmux a -t session-name

  tmux a # 默认进入第一个会话
  tmux a -t demo # 进入到名称为demo的会话
  ```

  - 切换会话

  ```bash
  tmux switch -t <session-name>
  # 名称或编号
  ```

  - 查看所有的会话

    ```bash
    tmux list-session # 查看所有会话
    tmux ls # 简写形式
    ```

    - 处于会话中: [Ctrl]+b+ s
      此时tmux将打开一个会话列表,按上下键(⬆︎⬇︎)或者鼠标滚轮,可选中目标会话,按左右键(⬅︎➜)可收起或展开会话的窗口,选中目标会话或窗口后,按回车键即可完成切换。
  - 关闭会话

    - kill-pane
    - kill-server
    - kill-session
    - kill-window

    ```bash
    tmux kill-session -t demo # 关闭demo会话
    tmux kill-server # 关闭服务器,所有的会话都将关闭
    ```
- 窗口window

  - 新建窗口

  ```bash
  tmux new-window
  # 新建一个指定名称的窗口
  tmux new-window -n <window-name>
  ```

  - 切换窗口

  ```bash
  # 切换到指定编号的窗口
  tmux select-window -t <window-number>
  # 切换到指定名称的窗口
  tmux select-window -t <window-name>
  ```
- 窗格pane

  - 划分窗格

  ```bash
  # 在window中操作,因此是拆分窗口window为pane
  tmux split-window # 划分上下两个窗格
  tmux split-window -h # 划分左右两个窗格
  ```

  - 切换pane

  ```bash
  # 光标切换到上方窗格
  tmux select-pane -U
  # 光标切换到下方窗格
  tmux select-pane -D
  # 光标切换到左边窗格
  tmux select-pane -L
  # 光标切换到右边窗格
  tmux select-pane -R
  ```

  - 移动pane

  ```bash
  # 当前窗格上移
  tmux swap-pane -U
  # 当前窗格下移
  tmux swap-pane -D
  ```
- 其他命令

  - tmux info
  - 略
- 进阶
  略
- Tmux快捷指令(复制)

  - 表一:系统指令。
    前缀	指令	描述
    Ctrl+b	?	    显示快捷键帮助文档
    Ctrl+b	d	    断开当前会话
    Ctrl+b	D	    选择要断开的会话
    Ctrl+b	Ctrl+z	挂起当前会话
    Ctrl+b	r	    强制重载当前会话
    Ctrl+b	s	    显示会话列表用于选择并切换
    Ctrl+b	:	    进入命令行模式,此时可直接输入ls等命令
    Ctrl+b	[	    进入复制模式,按q退出
    Ctrl+b	]	    粘贴复制模式中复制的文本
    Ctrl+b	~	    列出提示信息缓存
  - 表二:窗口(window)指令。
    前缀	指令	描述
    Ctrl+b	c	新建窗口
    Ctrl+b	&	关闭当前窗口(关闭前需输入y or n确认)
    Ctrl+b	0~9	切换到指定窗口
    Ctrl+b	p	切换到上一窗口
    Ctrl+b	n	切换到下一窗口
    Ctrl+b	w	打开窗口列表,用于且切换窗口
    Ctrl+b	,	重命名当前窗口
    Ctrl+b	.	修改当前窗口编号(适用于窗口重新排序)
    Ctrl+b	f	快速定位到窗口(输入关键字匹配窗口名称)
  - 表三:面板(pane)指令。
    前缀	指令	描述
    Ctrl+b	"	    当前面板上下一分为二,下侧新建面板
    Ctrl+b	%	    当前面板左右一分为二,右侧新建面板
    Ctrl+b	x	    关闭当前面板(关闭前需输入y or n确认)
    Ctrl+b	z	    最大化当前面板,再重复一次按键后恢复正常(v1.8版本新增)
    Ctrl+b	!	    将当前面板移动到新的窗口打开(原窗口中存在两个及以上面板有效)
    Ctrl+b	;	    切换到最后一次使用的面板
    Ctrl+b	q	    显示面板编号,在编号消失前输入对应的数字可切换到相应的面板
    Ctrl+b	{	    向前置换当前面板
    Ctrl+b	}	    向后置换当前面板
    Ctrl+b	Ctrl+o	顺时针旋转当前窗口中的所有面板
    Ctrl+b	方向键	 移动光标切换面板
    Ctrl+b	o	     选择下一面板
    Ctrl+b	空格键	 在自带的面板布局中循环切换
    Ctrl+b	Alt+方向键	以5个单元格为单位调整当前面板边缘
    Ctrl+b	Ctrl+方向键	以1个单元格为单位调整当前面板边缘(Mac下被系统快捷键覆盖)
    Ctrl+b	t	显示时钟
- 简单实操

```bash
tmux new -s session0
->tmux new-window -n window0
->...
->tmux new-window -n window1
->...
->tmux select-window -t window0
->tmux kill-window -t window0
```

## vim

- command mode
  - 移动光标
    - 方向键和hjkl(20↓或nj)
    - \- 上一行
    - \+ 下一行
    - [Ctrl] + [u] 屏幕“向上”移动半页
    - [Ctrl] + [d] 屏幕“向下”移动半页???
    - 0 或功能键[Home] 行首
    - $ 或功能键[End] 行尾
    - H M L 屏幕首中尾
    - G 文件尾
    - nG 第n行 (1G=gg)
    - n+[Enter] 向下n行
    - n+[space] 向后n个字符
  - 区块选择 (Visual Block)
    - v 字符选择, 会将光标经过的地方反白选择
    - V 列选择, 会将光标经过的列反白选择
    - [Ctrl]+v 区块选择, 可以用长方形的方式选择数据???
    - y 将反白的地方复制起来
    - d 将反白的地方删除掉
    - p 将刚刚复制的区块, 在光标所在处贴上
  - 搜索与替换
    - /word 向下查找
    - ?word 向上查找
    - n 继续向下查找
    - N 继续向上查找
    - 指定范围搜索 见CL mode
  - 复制粘贴与删除
    - 复制
      - nyy 复制本行起向下n行(1yy=yy)
      - y1G 复制本行到第一行
      - yG 复制本行到最后一行
      - y0 复制本字符到行首
      - y$ 复制本字符到行尾
    - 粘贴
      - p 从下一行开始粘贴
      - P 在本行前粘贴
    - 删除
      - x [del]
      - X [backspace]
      - nx 连续向后删除 n 个字符
      - ndd 删除本行起向下n行
      - d1G 删除本行到第一行
      - dG 删除本行到最后一行
      - d0 删除本字符到行首
      - d$ 删除本字符到行尾
  - 其他
    - . 重复上一次命令
    - u 撤销
    - [Ctrl]+r 复原
    - c是change,执行c动作后会进入编辑模式,d是delete,执行d动作后不会进入编辑模式
- insert mode
  - i 光标处
  - I 行首
  - a 光标后
  - A 行尾
  - o 下一行
  - O 上一行
  - r R replace
  - esc退出
- command-line mode
  - :w :w!
  - :q :q!
  - :wq :wq! ZZ ????
  - :[n1,n2]w [filename] 另存为
  - :r [filename] 读取添加至光标后
  - :! command 暂时离开并执行command
  - :set nu 行号
  - :set nonu 取消行号
  - 常用命令
    - :n1,n2s/word1/word2/g n1到n2
    - :1,$s/word1/word2/g 全文
    - :1,$s/word1/word2/gc 带替换确认
- 多文本编辑
  - vim file0 file1 fileN 
  - :n 编辑下一个文件
  - :N 编辑上一个文件
  - :files 列出打开的所有文件
- 多窗口编辑
  - :sp [filename] 
  打开一个新窗口, 如果有加 filename, 表示在新窗口打开一个新文件, 否则表示两个窗口为同一个文件内容(同步显示） 
  - [ctrl]+w+j / [ctrl]+w+↓
  按键的按法是： 先按下 [ctrl] 不放, 再按下 w 后放开所有的按键, 然后再按下 j (或向下方向键） , 则光标可移动到下方的窗口
  - [ctrl]+w+k / [ctrl]+w+↑ 
  同上, 不过光标移动到上面的窗口
  - [ctrl]+w+q
  其实就是 :q 结束离开啦, 举例来说, 如果想要结束下方的窗口, 那么利用 [ctrl]+w+↓ 移动到下方窗口后, 按下 :q 即可离开, 也可以按下[ctrl]+w+q 
- 挑字补全功能

## 正则表达式
```bash
[a-zA-Z0-9._-]+ #Linux文件名
ls | grep "[a-zA-Z0-9._-]+" #所有文件
ls -p| grep "[a-zA-Z0-9._-]+" #所有文件, 不含目录
```
### `grep` 
```
egrep = grep -E
可以使用基本的正则表达外, 还可以用扩展表达式。
扩展表达式：
+ 匹配一个或者多个先前的字符, 至少一个先前字符。
? 匹配0个或者多个先前字符。
a|b|c 匹配a或b或c。
() 字符组, 如: love(able|ers) 匹配loveable或lovers。
(..)(..)\1\2 模板匹配. \1代表前面第一个模板, \2代第二个括弧里面的模板。
x{m,n} =x\{m,n\} x的字符数量在m到n个之间。
```

## linux内核
```bash
vim ./include/generated/uapi/linux/version.h # 查看版本号
```

## 常用软件及其命令

### `sceenfetch`
显示系统/主题信息的命令行脚本

### `ssh`
  ```bash
  sudo apt install openssh-server
  sudo vim /etc/ssh/sshd_config  # sshd_config is a readonly file
  ...
  Port 2222                   # 监听的端口，可以是其它的
  ListenAddress 0.0.0.0       # 0.0.0.0 表示所有的地址
  PasswordAuthentication yes  # 把原来的no改成yes，意思是可以用密码登录
  PermitRootLogin yes         # 把原来的prohibit-password改成yes
  ...
  sudo service ssh restart
  sudo service ssh status
  sudo systemctl enable ssh #开机启动
  ```
### `cmake`
`cmake -DCMAKE_EXPORT_COMPILE_COMMANDS=1`
### `samba`
  ```bash
  sudo apt install samba samba-common
  useadd smb ##添加smb用户
  passwd smb  ##设置密码为smb
  sudo vim /etc/samba/smb.conf


  ```
### 散装命令
#### `uname -a`
  ```bash
  bobby_ubuntu@Bobby:~$ uname -a
  Linux Bobby 5.15.133.1-microsoft-standard-WSL2 #1 SMP Thu Oct 5 21:02:42 UTC 2023 x86_64 x86_64 x86_64 GNU/Linux
  ```
#### `环境变量`
  ```bash
  cat ~/.bashrc
  ...
  alias proxy="source ~/shells/proxy.sh"
  export winData="/mnt/c/Users/bobby/DATA/"
  ...
  source ~/.bashrc

  vim /etc/apt/sources.list
  # 注意:sudo执行脚本不会默认载入用户定义的环境变量
  sudo -E build.sh # 载入当前.bashrc的环境变量来执行shell脚本
  ```
### linux调试
####  `printk` 
  ```bash
  cat /proc/sys/kernel/printk
  10 1 1 2
  ```
  内核通过 printk() 输出的信息具有日志级别, 日志级别是通过在 printk() 输出的字符串前加一个带尖括号的整数来控制的, 如 printk("<6>Hello, world!/n");. 内核中共提供了八种不同的日志级别, 在 linux/kernel.h 中有相应的宏对应. 
  ```
  #define KERN_EMERG    "<0>"    /* system is unusable */
  #define KERN_ALERT    "<1>"    /* action must be taken immediately */
  #define KERN_CRIT     "<2>"    /* critical conditions */
  #define KERN_ERR      "<3>"    /* error conditions */
  #define KERN_WARNING  "<4>"    /* warning conditions */
  #define KERN_NOTICE   "<5>"    /* normal but significant */
  #define KERN_INFO     "<6>"    /* informational */
  #define KERN_DEBUG    "<7>"    /* debug-level messages */
  <0>级, 紧急事件, 系统崩溃之前提示的消息; 
  <1>级, 必须立即采取行动; 
  <2>级, 临界状态, 通常涉及严重的硬件或软件操作失败; 
  <3>级, 报告错误状态, 设备驱动程序会经常使用KERN_ERR 报告来自硬件的问题; 
  <4>级, 对可能出现问题的情况进行警告; 
  <5>级, 有必要进行提示的正常情况, 许多与安全相关的状况用这个级别进行提示; 
  <6>级, 内核提示性信息, 很多驱动程序在启动的时候用这个级别打印出它们找到的硬件信息; 
  <7>级, 用于调试信息. 
  ```
  所以 printk() 可以这样用: printk(KERN_INFO "Hello, world!/n");. 

  未指定日志级别的 printk() 采用的默认级别是 DEFAULT_MESSAGE_LOGLEVEL, 这个宏在 kernel/printk.c 中被定义为整数 4, 即对应KERN_WARNING. 

  在 /proc/sys/kernel/printk 会显示4个数值( 可由 echo 修改) , 分别表示当前控制台日志级别、未明确指定日志级别的默认消息日志级别、最小( 最高) 允许设置的控制台日志级别、引导时默认的日志级别. 当 printk() 中的消息日志级别小于当前控制台日志级别时, printk 的信息( 要有\n符) 就会在控制台上显示. 但无论当前控制台日志级别是何值, 通过 /proc/kmsg ( 或使用dmesg) 总能查看. 另外如果配置好并运行了 syslogd 或 klogd, 没有在控制台上显示的 printk 的信息也会追加到 /var/log/messages.log 中. 

#### `whereis`
  ```bash
  whereis gcc
  gcc: /usr/bin/gcc /usr/lib/gcc /usr/share/gcc /usr/share/man/man1/gcc.1.gz
  ```

#### `dmesg`
  ```bash
  dmesg -l debug -T | tail -10
  ```