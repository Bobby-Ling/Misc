- 安装
conda --version
conda update conda
conda info
conda info --envs
conda config --show-sources
conda config --add channels https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/free/
conda config --add channels https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/main/

- 环境配置
创建环境
conda create -n my_env python=3.7.0
激活环境
activate my_env
切换到另一个环境
activate my_env
注销当前环境
deactivate
复制环境
conda create -n my_env --clone my_env_2
删除环境
conda remove -n my_env2 --all

在所有powershell中启用conda
conda init powershell

- 包管理
conda list  
conda list  <package name>
搜索已经安装的包
conda install <package name>