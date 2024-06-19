# MySQL配置

```bash
# 安装配置
sudo apt install mysql-server mysql-client libmysqlclient-dev
sudo mysql_secure_installation
systemctl status mysql.service
# 配置文件
sudo vi /etc/mysql/mysql.conf.d/mysqld.cnf
# MySQL缺省是只允许本地访问的, 这里设置允许任何地址访问
# bind-address 修改值为 0.0.0.0


sudo /etc/init.d/mysql restart
# log
/var/log/mysql/error.log
# 数据目录
/var/lib/mysql/
# 文档
/usr/share/doc/mysql-server-<version>

# 使用ROOT登录MySQL
sudo mysql -uroot -p
# 创建用户
create user bobby_ubuntu identified WITH caching_sha2_password by '1843';
# 赋予权限
GRANT ALL ON *.* TO 'root'@'%';
# 删除用户
drop user bobby
# 修改密码
ALTER USER USER() IDENTIFIED BY '1843';
# or
mysqladmin -uroot -p password 123123

use mysql;
select host, user, authentication_string, plugin from user;
update user set host='%' where user='root';
GRANT ALL ON *.* TO 'root'@'%';
GRANT ALL ON *.* TO 'root'@'%';
flush privileges;

ALTER USER 'bobby'@'%' IDENTIFIED WITH caching_sha2_password BY '1843';

# 远程登录
mysql -h 127.0.0.1  -u bobby -p
# 一定要有-p

# 首先新建一个数据库
CREATE DATABASE LabDB
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_general_ci;
```

## C++

```cpp

#include <mysql/mysql.h>
#include <stdio.h>
#include <stdlib.h>
int main() 
{
    MYSQL *conn;
    MYSQL_RES *res;
    MYSQL_ROW row;
    char server[] = "localhost";
    char user[] = "root";
    char password[] = "mima";
    char database[] = "mysql";
    
    conn = mysql_init(NULL);
    
    if (!mysql_real_connect(conn, server,user, password, database, 0, NULL, 0)) 
    {
        fprintf(stderr, "%s\n", mysql_error(conn));
        exit(1);
    }
    
    if (mysql_query(conn, "show tables")) 
    {
        fprintf(stderr, "%s\n", mysql_error(conn));
        exit(1);
    }
    
    res = mysql_use_result(conn);
    
    printf("MySQL Tables in mysql database:\n");
    
    while ((row = mysql_fetch_row(res)) != NULL)
    {
        printf("%s \n", row[0]);
    }
    
    mysql_free_result(res);
    mysql_close(conn);
    
    printf("finish! \n");
    return 0;
}
//g++ -Wall mysql_test.cpp -o mysql_test -lmsqlclient
```
