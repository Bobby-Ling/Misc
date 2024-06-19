#include "storage/disk_manager.h"

#include <assert.h>    // for assert
#include <string.h>    // for memset
#include <sys/stat.h>  // for stat
#include <unistd.h>    // for lseek

#include "defs.h"

DiskManager::DiskManager() { 
    memset(fd2pageno_, 0, MAX_FD * (sizeof(std::atomic<page_id_t>) / sizeof(char))); 
}

/**
 * @brief Write the contents of the specified page into disk file
 *
 * @description: 将数据写入文件的指定磁盘页面中
 * @param {int} fd 磁盘文件的文件句柄
 * @param {page_id_t} page_no 写入目标页面的page_id
 * @param {char} *offset 要写入磁盘的数据
 * @param {int} num_bytes 要写入磁盘的数据大小
 */

void DiskManager::write_page(int fd, page_id_t page_no, const char *offset, int num_bytes) {
    // Todo:
    // 1.lseek()定位到文件头，通过(fd,page_no)可以定位指定页面及其在磁盘文件中的偏移量
    // 2.调用write()函数
    // 注意处理异常
    //lseek

    /*
    SEEK_SET 参数offset 即为新的读写位置.
    SEEK_CUR 以目前的读写位置往后增加offset 个位移量.
    SEEK_END 将读写位置指向文件尾后再增加offset 个位移量.
    当whence 值为SEEK_CUR 或SEEK_END 时, 参数offet 允许负值的出现.
    */
    lseek(fd, page_no * PAGE_SIZE, SEEK_SET);
    if (write(fd, offset, num_bytes) == -1) {
        throw UnixError();
    }
}

/**
 * @brief Read the contents of the specified page into the given memory area
 *
 * @description: 读取文件中指定编号的页面中的部分数据到内存中
 * @param {int} fd 磁盘文件的文件句柄
 * @param {page_id_t} page_no 指定的页面编号
 * @param {char} *offset 读取的内容写入到offset中
 * @param {int} num_bytes 读取的数据量大小
 */
void DiskManager::read_page(int fd, page_id_t page_no, char *offset, int num_bytes) {
    // Todo:
    // 1.lseek()定位到文件头，通过(fd,page_no)可以定位指定页面及其在磁盘文件中的偏移量
    // 2.调用read()函数
    // 注意处理异常
    lseek(fd, page_no * PAGE_SIZE, SEEK_SET);
    if (read(fd, offset, num_bytes) == -1) {
        throw UnixError();
    }
}

/**
 * @brief Allocate new page (operations like create index/table)
 * For now just keep an increasing counter
 * 
 * @description: 分配一个新的页号
 * @return {page_id_t} 分配的新页号
 * @param {int} fd 指定文件的文件句柄
 */
page_id_t DiskManager::AllocatePage(int fd) {
    // Todo:
    // 简单的自增分配策略，指定文件的页面编号加1

    assert(fd >= 0 && fd < MAX_FD);
    return fd2pageno_[fd] ++; 
}
  

/**
 * @brief Deallocate page (operations like drop index/table)
 * Need bitmap in header page for tracking pages
 * This does not actually need to do anything for now.
 */
void DiskManager::DeallocatePage(__attribute__((unused)) page_id_t page_id) {

}

bool DiskManager::is_dir(const std::string &path) {
    struct stat st;
    return stat(path.c_str(), &st) == 0 && S_ISDIR(st.st_mode);
}

void DiskManager::create_dir(const std::string &path) {
    // Create a subdirectory
    std::string cmd = "mkdir " + path;
    if (system(cmd.c_str()) < 0) {  // 创建一个名为path的目录
        throw UnixError();
    }
}

void DiskManager::destroy_dir(const std::string &path) {
    std::string cmd = "rm -r " + path;
    if (system(cmd.c_str()) < 0) {
        throw UnixError();
    }
}

/**
 * @brief 用于判断指定路径文件是否存在 
 */
bool DiskManager::is_file(const std::string &path) {
    // Todo:
    // 用struct stat获取文件信息
    struct stat st;
    return stat(path.c_str(), &st) == 0 && S_ISREG(st.st_mode);
    /*
    常规文件(regular file)包含文本文件、二进制可执行文件等;
    不包括特殊文件类型, 如目录、符号链接、设备文件等.

    执行成功则返回0，失败返回-1，错误代码存于errno。
    错误代码：
    1、ENOENT 参数file_name 指定的文件不存在
    2、ENOTDIR 路径中的目录存在但却非真正的目录
    3、ELOOP 欲打开的文件有过多符号连接问题, 上限为16 符号连接
    4、EFAULT 参数buf 为无效指针, 指向无法存在的内存空间
    5、EACCESS 存取文件时被拒绝
    6、ENOMEM 核心内存不足
    7、ENAMETOOLONG 参数file_name 的路径名称太长
    */
}

/**
 * @brief 用于创建指定路径文件
 */
void DiskManager::create_file(const std::string &path) {
    // Todo:
    // 调用open()函数，使用O_CREAT模式
    // 注意不能重复创建相同文件

    // mode = 0664 S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP | S_IROTH
    int fd = open(path.c_str(), O_RDWR | O_EXCL | O_CREAT, 0664);
    if (fd == -1) {
        // 包含重复创建相同文件
        throw FileExistsError(path);
    }


    /*
    O_RDONLY: 只读模式
    O_WRONLY: 只写模式
    O_RDWR: 可读可写
    以下的常量是选用的, 这些选项是用来和上面的必选项进行按位或起来作为flags参数.
    O_APPEND 表示追加, 如果原来文件里面有内容, 则这次写入会写在文件的最末尾.
    O_CREAT 表示如果指定文件不存在, 则创建这个文件
    O_EXCL 表示如果要创建的文件已存在, 则出错, 同时返回 -1, 并且修改 errno 的值.
    O_TRUNC 表示截断, 如果文件存在, 并且以只写、读写方式打开, 则将其长度截断为0.
    O_NOCTTY 如果路径名指向终端设备, 不要把这个设备用作控制终端.
    O_NONBLOCK 如果路径名指向 FIFO/块文件/字符文件, 则把文件的打开和后继 I/O设置为非阻塞模式(nonblocking mode)

    文件权限由open的mode参数和当前进程的umask掩码共同决定。
    第三个参数mode在第二个参数中有O_CREAT时才作用，如果没有，则第三个参数可以忽略
    S_IRUSR,S_IWUSR,S_IXUSR,S_IRWXU;
    S_IRGRP,S_IWGRP,S_IXGRP,S_IRWXG;
    S_IROTH,S_IWOTH,S_IXOTH,S_IRWXO;
    */

}

/**
 * @brief 用于删除指定路径文件 
 */
void DiskManager::destroy_file(const std::string &path) {
    // Todo:
    // 调用unlink()函数
    // 注意不能删除未关闭的文件

    if (unlink(path.c_str()) == -1) {
        if (errno == ENOENT) {
            // No such file or directory
            throw FileNotFoundError(path.c_str());
        }
        throw UnixError();
    }
}

/**
 * @brief 用于打开指定路径文件
 * @return fd
 */
int DiskManager::open_file(const std::string &path) {
    // Todo:
    // 调用open()函数，使用O_RDWR模式
    // 注意不能重复打开相同文件，并且需要更新文件打开列表
    int fd = -1;
    if ( is_file(path) == 0 ) {
        throw FileNotFoundError(path);
    } 
    
    auto search = path2fd_.find(path);

    if ( search == path2fd_.end() ) {
        fd = open( path.c_str(), O_RDWR);
        //path2fd_.insert(std::make_pair(path, fd));
        //fd2path_.insert(std::make_pair(fd, path));
        path2fd_[path] = fd;
        fd2path_[fd] = path;
    } 

    return fd;  
}

/**
 * @brief 用于关闭指定路径文件
 */
void DiskManager::close_file(int fd) {
    // Todo:
    // 调用close()函数
    // 注意不能关闭未打开的文件，并且需要更新文件打开列表

    auto it = fd2path_.find(fd);
    if( it != fd2path_.end() ) {
        close(fd);
        const std::string path = fd2path_[fd];
        path2fd_.erase(path);
        //path2fd_.erase( path2fd_.find((*it).second) );
        fd2path_.erase(fd);
    } else {
        throw FileNotOpenError(fd);
    }
}

int DiskManager::GetFileSize(const std::string &file_name) {
    struct stat stat_buf;
    int rc = stat(file_name.c_str(), &stat_buf);
    return rc == 0 ? stat_buf.st_size : -1;
}

std::string DiskManager::GetFileName(int fd) {
    if (!fd2path_.count(fd)) {
        throw FileNotOpenError(fd);
    }
    return fd2path_[fd];
}

int DiskManager::GetFileFd(const std::string &file_name) {
    if (!path2fd_.count(file_name)) {
        return open_file(file_name);
    }
    return path2fd_[file_name];
}

bool DiskManager::ReadLog(char *log_data, int size, int offset, int prev_log_end) {
    // read log file from the previous end
    if (log_fd_ == -1) {
        log_fd_ = open_file(LOG_FILE_NAME);
    }
    offset += prev_log_end;
    int file_size = GetFileSize(LOG_FILE_NAME);
    if (offset >= file_size) {
        return false;
    }

    size = std::min(size, file_size - offset);
    lseek(log_fd_, offset, SEEK_SET);
    ssize_t bytes_read = read(log_fd_, log_data, size);
    if (bytes_read != size) {
        throw UnixError();
    }
    return true;
}

void DiskManager::WriteLog(char *log_data, int size) {
    if (log_fd_ == -1) {
        log_fd_ = open_file(LOG_FILE_NAME);
    }

    // write from the file_end
    lseek(log_fd_, 0, SEEK_END);
    ssize_t bytes_write = write(log_fd_, log_data, size);
    if (bytes_write != size) {
        throw UnixError();
    }
}
