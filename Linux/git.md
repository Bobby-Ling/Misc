# Git

## 预配置

```bash
git config --global user.name "Bobby-Ling"
git config --global user.email bobby-ling@outlook.com

git config --global core.editor emacs # vim,etc
git config --global merge.tool vimdiff 

#签出时将换行符转换成CRLF,签入时转换回 LF(win)
git config --global core.autocrlf true   
#签出时不转换换行符,签入时转换回 LF(MacOS/Linux)      
git config --global core.autocrlf input   
#签出签入均不转换                               
git config --global core.autocrlf false

#拒绝提交包含混合换行符的文件     
git config --global core.safecrlf true   
#允许提交包含混合换行符的文件     
git config --global core.safecrlf false   
#提交包含混合换行符的文件时候给出警示 
git config --global core.safecrlf warn


# 差异分析工具 kdiff3,tkdiff,meld,xxdiff,emerge,vimdiff,gvimdiff,ecmerge, opendiff

git config --list #查看配置信息
git config user.name #直接查阅某个环境变量的设定

配置SSH公钥
ssh-keygen -t ed25519 -C "keyname"
# ...
ssh -T git@gitee.com
```

## 初始化仓库

- 在现存的目录下
  ```bash
  git init
  # 随后可进行add和commit
  git add file
  git status [-s]
  git commit -m 'msg'
  git push git@gitee.com:bobby-ling/Learning.git
  git log
  # ...
  # 关联远程仓库
  git remote add origin git@gitee.com:bobby-ling/Learning.git
  git remote -v # 查看当前仓库对应的远程仓库地址
  git remote set-url origin git@gitee.com:bobby-ling/anotherLearning.git # 修改地址
  ```
- 从已有的 Git 仓库克隆
  ```bash
  考虑过子模块:
  git clone [--recursive] git@gitee.com:bobby-ling/Learning.git [newname] [--depth <depth>] [branchname]
  对于已经克隆下来的:
  git submodule init
  git submodule update
  # 待考证[newname]
  # 不加[newname]则会在当前目录下创建一个名为learning的目录
  ```

## 基本操作

- git add
  - `git add ` `* ` `-A ` `--all `
  - 新建文件`git status `提示 `use "git add <file>``..." to include in what will be committed `
  - 修改文件 `use "git add <file>``..." to update what will be committed `
- 回退
  - 未git add
    修改文件 `git restore <file> ` ,早期版本(prev ver 2.23)`git checkout --<file> `
  - 已git add 
    - 先`git restore --staged <file> `(从暂存区撤出,不会撤销更改)
    - 再`git restore <file> `
  - 版本回退
    - `git reset --soft commit-id `
    仅仅修改分支中的HEAD指针的位置,不会改变工作区与暂存区中的文件的版本
    - `git reset --hard HEAD^ `
    - `git reset --hard HEAD~n `
- git commit
  - `git commit -m 'msg' `
  - `git commit -a/-all <file> ` add+commit all changed files 之前add过的可以,新建的未add的不可以
  - `create mode 100644 readme.txt ` 100(普通文件)644(文件权限)
- git log HEAD指针之前的提交历史
  - `--pretty=oneline ` 单行形式
    - `--pretty=oneline --abbrev-commit `或者`--oneline ` 单行+简写commit ID
  - `-n[No.x]` (-n2 -n3 ...)指定查看最近n次提交的内容
  - `--all ` 查看所有分支历史版本
    - `-all --graph `
  - `[branch-name] ` 查看指定分支版本历史
  - 时间范围,格式,etc... 见`git help log `
- git blame
  - `git blame <file> `列表形式显示修改记录
- git reflog 所有提交历史
- git stash
- git checkout
- git diff 
  - `git diff [--stat] [...] <file> ` 简明查看 
  - 默认查看工作区与暂存区(上一次add)文件区别
  - `git diff --cached <file> ` 查看暂存区与本地库中文件内容的区别
  - `git diff HEAD ` 比较工作区与最新本地版本库(如果HEAD指向的是master分支,那么HEAD还可以换成master)
  - `git diff commit-id ` 比较工作区与指定commit提交的差异
  - `git diff --cached commit-id ` 比较暂存区与指定commit提交的差异
  - `git diff [<commit-id>] [<commit-id>] ` 比较两个commit提交之间的差异
  - 解读方式
  略
- 文件重命名
  - 手动直接修改
  删除+新建,但可识别为rename
  - `git mv <prevfile> <newfile> `
- 分支和HEAD
  - 分支本质上仅仅是指向提交对象的指针
  - `.git/refs/heads/branchname ` 文件存储的是commit ID
  - `.git/HEAD `存储的是当前HEAD指针 `refs/heads/branchname `
  - HEAD->branch->commit object
  - 创建分支 `git branch branchname `
  - 查看状态 
    - `git log `
    - `git branch ` 查看分支列表和当前分支
    - `git branch -v ` 查看所有分支的最后一次提交
  - 切换分支 
    - `git checkout branchname `
    - `git checkout -b branchname ` 新建+创建
  - 删除分支
    - 当前工作的分支,不能是该分支
    - `git branch -d branchname ` 
    - `git branch -D branchname ` 未合并时强制删除
- 设置忽略文件(.gitignore忽略规则)
  - 格式规范
    - 所有空行或者以 # 开头的行都会被 Git 忽略
    - 可以使用标准的glob模式(shell所使用的简化了的正则表达式)匹配,它会递归地应用在整个工作区中
      - 以`＃ `开头的行用作注释。
      - 星号`* `匹配零个或多个任意字符。
      - `[abc] `匹配任何一个列在方括号中的字符 (这个例子要么匹配一个a,要么匹配一个b,要么匹配一个 c);
      - 如果在方括号中使用短划线分隔两个字符,表示所有在这两个字符范围内的都可以匹配(比如`[0-9] `表示匹配所有 0 到 9 的数字)。
      - 问号(?)只匹配一个任意字符。
      - 使用两个星号`** `表示匹配任意中间目录,比如` a/**/z `可以匹配 `a/z `、` a/b/z `或` a/b/c/z `等。
    - 匹配模式可以以`/ `开头,防止递归
    - 匹配模式最后跟`/ `说明要忽略的是目录
    - 要忽略指定模式以外的文件或目录,可以在模式前加上叹号`! `取反
  - 例子
  ```bash
  # 1.忽略public下的所有目录及文件
  /public/*

  # 2.不忽略/public/assets,就是特例的意思,assets文件不忽略
  !/public/assets

  # 3.忽略具体的文件
  index.html

  # 4.忽略所有的java文件
  *.java

  # 5.忽略 a.java b.java
  [ab].java

  # 6.忽略 doc/ 目录及其所有子目录下的 .pdf 文件
  doc/**/*.pdf

  # 7.忽略 doc/notes.txt,但不忽略 doc/server/arch.txt
  doc/*.txt

  # 8.忽略任何目录下名为 build 的文件夹
  build/

  # 9.只忽略当前目录下的 TODO 文件,而不忽略 subdir/TODO文件
  /TODO
  ```
  - 具体方法
    - 忽略单个仓库中的文件(本地使用)
      - 编辑`.git/info/exclude ` 文件
      - 只在本机当前仓库起效,不会对其他的克隆仓库起效
    - 忽略单个仓库中的文件(远程共用)
    根目录下新建`.gitignore `文件
    - 全局忽略
    `git config --global core.excludesfile <filewithpath> `
  - 其他
    - 规则失误
      ```bash
      $ git add 1.test
      The following paths are ignored by one of your .gitignore files:
      1.test
      Use -f if you really want to add them.
      ```
      - 可使用`git add -f `强制添加被忽略的文件
      - 使用`git check-ignore `检查生效的规则
        ```bash
        $ git check-ignore -v 1.test
        .gitignore:3:*.class	1.test
        ```
    - 优先级
      1. 从命令行中读取可用的忽略规则
      2. 当前目录定义的规则(.gitingore文件)
      3. 父级目录定义的规则,依次递推,目录结构较高的.gitignore文件将被较近的.gitignore文件中相同的配置所覆盖(.gitingore文件)
      4. .git/info/exclude文件中定义的规则
      5. core.excludesfile中定义的全局规则
    - 忽略已跟踪文件的改动(本机使用)(待验证)
      > .gitignore只能忽略那些原来没有被track的文件,如果某些文件已经被纳入了版本管理中,则修改.gitignore是无效的。
      1. 第一种办法
      clone后
      ```bash
      # 忽略跟踪(提交代码时,忽略某一个文件不提交,即某个文件不被版本控制)
      # file-path是目标文件路径 
      git update-index --assume-unchanged file-path

      # 恢复跟踪
      git update-index --no-assume-unchanged file-path
      ```
      注意
      > 执行 git checkout（切换分支）和git reset（回退版本）命令的时候仍然会影响到这些文件,并把内容恢复到被跟踪的内容（再次执行上面命令,修改仍然不会被跟踪）
      2. 第二种办法
      `.git/info/exclude `的文件不会提交到版本库中去



## cheatsheet

[cheatsheet](image/git/1673754766427.png "cheatsheet")

## 进阶

- git config
  - 查看
    - `git config --list --local ` 仓库级别
    - `git config --list --global ` 全局(用户)
    - `git config --list --system ` 系统
    - `git config --list ` 全部
  - 签名
    ```bash
    git config --global user.name "Bobby-Ling"
    git config --global user.email bobby-ling@outlook.com

    git config --global --unset 
    user.name
    ```
  - 设置别名
    - `git config [--global/--local/--system] alias.[frdlyname] [command] `
    - `git config [--global/--local/--system] --unset alias.[frdlyname] ` 删除别名
    - `git config [--global/--local/--system] --remove-section alias ` 删除所有别名
    ```bash
    #示例,注意引号
    $ git config --global alias.lg "log --color --graph --pretty=format:'%Cred%h%Creset -%C(yellow)%d%Creset %C(cyan)%s %C(magenta)(%cr) %C(bold blue)<%an>%Creset'"
    ```
  - 设置颜色
  `git config --global color.ui true `
- git核心概念
  - 暂存区(index)
    - 存储方式 
      - 存储于.git/index文件
      - 包含的是文件的目录树,记录了文件名、文件的时间戳、文件长度、文件类型以及其SHA-1值,没有存储文件内容
      - 存放的是文件内容(blob)的索引(快照)或tree对象的索引,指向.git/objects/目录下的文件
    - 暂存区内容写到版本库中后,暂存区索引内容不清空
    - 可以看作是一个临时的tree对象,每次git add时更新,commit时以此为基准正式写入数据库的tree对象
    > 暂存区(index)其实就是一个临时tree对象。每次commit的时候可以直接把当前工作空间的文件夹直接转换为一个tree对象,并使commit对象指向它。但是,有时候我们的一些临时改动不想存入库中,因此,便加入一个暂存区

    > 所以,这里有三个文件夹,暂存区和仓库中是tree对象的形式存在。刚开始,三个文件夹内容一致,我们可以直接修改工作空间的文件夹。然后通过命令(git add/rm)可以将想要提交的修改合并到暂存区中的tree对象上。最后通过命令(git commit)才会将暂存区中的tree保存到库中,并生成一个commit对象指向这个tree对象
    - Git通过暂存区的文件索引信息来创建tree对象
    - 底层命令 `git ls-files ` 查看暂存区的文件信息
        - --cached(-c) 查看暂存区中文件,默认
        - --midified(-m) 查看修改的文件
        - --delete(-d) 查看删除过的文件
        - --other(-o) 查看没有被Git跟踪的文件
        - --stage(-s) 显示mode以及文件对应的Blob对象,进而可以获取暂存区中对应文件里面的内容(全部文件,不论修改与否,相当于快照)
  - blob 数据对象
    - 存储方式
      - 存储于.git/objects目录(即对象数据库)中
      - 存储一个文本文件的内容(存储快照,非增量,进行zlib压缩)
      - 只存内容,不存文件名,文件名在tree对象中保存
      - 文件内容40位SHA-1的前两位作为.git/objects/子目录的名字,后38位作为文件名字
    - 意义
      - 文件一次次的版本
    - 底层命令
      - `git hash-object -w 文件路径 ` 把工作区的一个文件提交到本地版本库中
      - `find .git/objects -type f ` 查看Git数据库中的对象(Linux命令)
      - `git cat-file -p 40位键 ` 查看该Git对象的内容
      - `git cat-file -t 40位键 ` 查看该Git对象的类型
    ```bash
    # 操作
    $ echo 'git manually create blob object'>>2
    $ echo 'git manually create blob object' | git hash-object -w --stdin
    2baae9daaf8d17b52b1a909f10944be6b5b332ea

    # 查看效果
    $ find .git/objects -type f
    .git/objects/2b/aae9daaf8d17b52b1a909f10944be6b5b332ea
    $ git cat-file -p
    git manually create blob object
    $ git cat-file -t
    blob
    ```
  - tree 树对象
    - 存储方式
      - 存储于.git/index索引文件中(暂存区stage)
      - 基于暂存区创建
      - >一个树对象可以包含一条或多条记录(tree对象和blob 对象),每条记录含有一个指向blob 对象或者子tree对象的SHA-1指针,以及相应的模式、类型、文件名信息
    - 意义
      - 项目一次次的版本
      - 为一个项目commit时全部文件的快照(不含文件信息)
    - 底层命令
      - `git ls-files ` 查看暂存区的文件信息
        - --cached(-c) 查看暂存区中文件,默认
        - --midified(-m) 查看修改的文件
        - --delete(-d) 查看删除过的文件
        - --other(-o) 查看没有被Git跟踪的文件
        - --stage(-s) 显示mode以及文件对应的Blob对象,进而可以获取暂存区中对应文件里面的内容(全部文件,不论修改与否,相当于快照)
      - `git update-index ` 将一个单独文件存入暂存区中
        - --add 文件首次添加到暂存区时使用
        - --cacheinfo 要添加的文件位于Git数据库中(接续上一步手动添加blob的操作),而不是位于当前工作目录;不加为加入暂存区+存入版本库
        - 100644 普通文件(blob对象的文件模式一般都为100644)
          100755 可执行文件 
          120000 符号链接
      - `git write-tree ` 向数据库中写入tree对象
      - `git read-tree ` 把树对象读入暂存区
        - --prefix=bak 将一个已有的树对象作为子树读入暂存区
      ```bash
      # 添加索引,初次添加使用--add
      $ git update-index --add --cacheinfo 100644 2baae9daaf8d17b52b1a909f10944be6b5b332ea 2
      # 查看数据库,尚未变动
      $ find .git/objects -type f
      .git/objects/2b/aae9daaf8d17b52b1a909f10944be6b5b332ea
      # 把暂存区中的内容提交到本地版本库
      # 通过write-tree命令生成tree对象
      $ git write-tree 2baae9daaf8d17b52b1a909f10944be6b5b332ea
      # 查看数据库,多出tree对象ad...
      $ find .git/objects -type f
      .git/objects/ad/509e710a408a60f770cc228816d37e13ae07d2
      .git/objects/2b/aae9daaf8d17b52b1a909f10944be6b5b332ea
      $ git cat-file -t ad509e710a408a60f770cc228816d37e13ae07d2
      tree
      $ git cat-file -p ad509e710a408a60f770cc228816d37e13ae07d2
      100644 blob 2baae9daaf8d17b52b1a909f10944be6b5b332ea    2
      # 暂存区内容写到版本库,暂存区不清空
      $ git ls-files -s
      100644 2baae9daaf8d17b52b1a909f10944be6b5b332ea 0       2
      
      # 修改文件2并加入数据库(多出96...)
      $ echo 'ver.2'>>2
      $ git hash-object -w ./2
      962ac3f9c16c4f5d74fb0d666d86f152fd92def4
      # 更新索引
      $ git update-index --cacheinfo 100644 962ac3f9c16c4f5d74fb0d666d86f152fd92def4 2
      # 查看索引,原条目被覆盖
      $ git ls-files -s
      100644 962ac3f9c16c4f5d74fb0d666d86f152fd92def4 0       2

      # 新建文件new.txt并更新
      # 直接从工作区添加,不用带----cacheinfo <文件权限> <SHA-1> <文件名>
      $ echo 'new file' >> new.txt
      $ git update-index --add new.txt
      # 查看暂存区,多出new.txt条目
      $ git ls-files -s
      100644 962ac3f9c16c4f5d74fb0d666d86f152fd92def4 0       2
      100644 fa49b077972391ad58037050f2a75f74e3671e92 0       new.txt
      # 查看数据库,多出fa...
      $ find .git/objects/ -type f
      .git/objects/fa/49b077972391ad58037050f2a75f74e3671e92
      .git/objects/ad/509e710a408a60f770cc228816d37e13ae07d2
      .git/objects/2b/aae9daaf8d17b52b1a909f10944be6b5b332ea
      .git/objects/96/2ac3f9c16c4f5d74fb0d666d86f152fd92def4
      $ git cat-file -p fa49b077972391ad58037050f2a75f74e3671e92
      new file
      # 提交暂存区至版本库,生成tree对象,数据库新增9c...
      $ git write-tree
      9cee2c18aedce1524947b3d76c8daa911a178435
      $ git cat-file -p 9cee2c18aedce1524947b3d76c8daa911a178435
      100644 blob 962ac3f9c16c4f5d74fb0d666d86f152fd92def4    2
      100644 blob fa49b077972391ad58037050f2a75f74e3671e92    new.txt
      
      # 
      $ git read-tree --prefix=bak ad509e710a408a60f770cc228816d37e13ae07d2
      $ git ls-files -s
      100644 962ac3f9c16c4f5d74fb0d666d86f152fd92def4 0       2
      100644 2baae9daaf8d17b52b1a909f10944be6b5b332ea 0       bak/2
      100644 fa49b077972391ad58037050f2a75f74e3671e92 0       new.txt
      $ find .git/objects -type f
      .git/objects/fa/49b077972391ad58037050f2a75f74e3671e92
      .git/objects/ad/509e710a408a60f770cc228816d37e13ae07d2
      .git/objects/2b/aae9daaf8d17b52b1a909f10944be6b5b332ea
      .git/objects/96/2ac3f9c16c4f5d74fb0d666d86f152fd92def4
      .git/objects/9c/ee2c18aedce1524947b3d76c8daa911a178435

      # 写入tree对象
      $ git write-tree
      b8612e2d2dd439c9d93f6afb2a079c96b1820e59
      # 然后数据库新增一个tree对象
      $ git cat-file -p b8612e2d2dd439c9d93f6afb2a079c96b1820e59
      100644 blob 962ac3f9c16c4f5d74fb0d666d86f152fd92def4    2
      040000 tree ad509e710a408a60f770cc228816d37e13ae07d2    bak
      100644 blob fa49b077972391ad58037050f2a75f74e3671e92    new.txt

      ```
  - commit
    - 存储于.git/objects数据库中
    - 指向基于当前暂存区中索引文件生成的tree对象,包含父提交的ID,提交时间,提交者信息,作者信息,以及提交备注等内容
    - 进行代码提交时,需要根据暂存区的内容,先生成tree对象,再生成commit对象
    - 底层命令
      - ` git commit-tree [(-p <parent>)...] [-S[<keyid>]] [(-m <message>)...] [(-F <file>)...] <tree> ` 以树对象的SHA-1值,以及该提交的父提交对象创建一个commit对象(首次无须指定父提交对象)
    ```bash
    $ find .git/objects/ -type f |xargs ls -ta # 时间排序
    .git/objects/b8/612e2d2dd439c9d93f6afb2a079c96b1820e59 # tree
    .git/objects/9c/ee2c18aedce1524947b3d76c8daa911a178435 # tree
    .git/objects/fa/49b077972391ad58037050f2a75f74e3671e92 # blob
    .git/objects/96/2ac3f9c16c4f5d74fb0d666d86f152fd92def4 # blob
    .git/objects/ad/509e710a408a60f770cc228816d37e13ae07d2 # tree
    .git/objects/2b/aae9daaf8d17b52b1a909f10944be6b5b332ea # blob 
    # 新建首次提交(数据库新增be...)
    $ echo 'first commit' | git commit-tree ad509e710a408a60f770cc228816d37e13ae07d2
    be077c64512c572b18dbcb32d12a560180f24cfb
    # 查看信息
    $ git cat-file -p be077c64512c5
    72b18dbcb32d12a560180f24cfb
    tree ad509e710a408a60f770cc228816d37e13ae07d2
    author Bobby-Ling <bobby-ling@outlook.com> 1673861238 +0800
    committer Bobby-Ling <bobby-ling@outlook.com> 1673861238 +0800

    first commit
    # 创建第二个commit对象
    $ echo 'second commit' | git commit-tree 9cee2c18aedce1524947b3d76c8daa911a178435 -p be077c64512c572b18dbcb32d12a560180f24cfb
    4d7bc8a11c372997298186d243b76b404dd36ae4
    # 查看
    $ git cat-file -p 4d7bc8a11c372997298186d243b76b404dd36ae4
    tree 9cee2c18aedce1524947b3d76c8daa911a178435
    parent be077c64512c572b18dbcb32d12a560180f24cfb
    author Bobby-Ling <bobby-ling@outlook.com> 1673861661 +0800
    committer Bobby-Ling <bobby-ling@outlook.com> 1673861661 +0800

    second commit # 注释(-m)
    # 第三个略

    ```
  - 总结
    - `git add ./ ` 相当于
      - `git hash-object -w <file> ` 
      每个修改的文件
      - `git update-index `
      将工作区的文件快照(索引,全部),存入暂存区(index),之后`git ls-files -s `里的文件为最新版本(最新的blob)
    - `git commit -m 'msg' ` 相当于
      - `git write-tree `
      依据暂存区的"临时tree"生成tree对象存储至数据库
      - `git commit-tree `
      然后封装这个tree对象生成commit对象存入数据库
    - 对于文件记录完整副本,对于工作区记录变更
    - 文件状态????
    - 本地版本库
    即每一次的commit(其中包含tree和相应的blob数据)
    - 常用命令
    ```bash
    git ls-files [-cmdos]
    find .git/objects/ -type f |xargs ls -tal
    git cat-file [-p] [-t]
    ```
  - tag
- 注意


## 其他问题

- 重新安装系统/Linux下载别人的代码后出现"当前文件夹中的 git 存储库可能不安全,因为该文件夹由当前用户以外的其他人所有"的警告

  > 本次安全升级的名称为CVE-2022-24765,主要想防范在多用户主机上,通过创建上级目录的方式,进行git配置的篡改
  >

  > 原有的git机制是,如果本级目录下没有.git目录,它会向上级目录(父级)查找.git目录,直到查找到为止这种机制下,如果有恶意人员借助共享目录的权限,在最上级目录创建.git文件,可能导致用户误操作在非项目目录中操作git时,将会使用恶意人员部署的git配置
  > 所以这次git增加了限制,在逐层读取git配置时,同时检查文件所有权人,如果非本用户,则停止如果想添加例外,则需要使用上面提到的 safe.directory
  > 该漏洞反馈者是中国科学院大学网络空间安全专业的博士,大牛:俞晨东
  >

  > 参考链接
  > [https://blog.csdn.net/guoyihaoguoyihao/article/details/124868059](https://blog.csdn.net/guoyihaoguoyihao/article/details/124868059)
  > [http://blog.ycdxsb.cn/](http://blog.ycdxsb.cn/)
  > [https://github.com/ycdxsb](https://github.com/ycdxsb)
- Linux和Windows CRLF换行符问题

- 文件系统文件名限制问题
  ```bash
  $ git reset --hard HEAD
  error: invalid path 'drivers/gpu/drm/nouveau/nvkm/subdev/i2c/aux.c'
  ...
  git config core.protectNTFS false
  ```

- 克隆大型项目

  > 有些项目非常庞大，例如android源码，如果只是想获取项目的代码以及之后的更新，而不需要care该项目的历史提交记录，那么可以只克隆某个分支的最后一次提交。
  ```bash
  # 选择克隆单个分支
  git clone --branch <branch_name> <remote-address>
  只克隆最新的提交记录
  # git clone <remote-address> --depth 1
  # -- depth代表克隆的深度，--depth 1代表只克隆最新一次提交记录以及这次提交之后的最新内容，不克隆历史提交，所造成的影响就是不能查看历史提交记录，但是克隆速度大大提升。
  # 组合
  git clone --branch <branch_name> <remote-address> --depth 1
  # 只克隆单个分支的最新一次提交。
  ```