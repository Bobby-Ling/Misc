#include <unistd.h>
#include <fcntl.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <thread>
#include <string>
#include <string_view>
#include <iostream>
#include <array>
#include <memory>
#include <vector>

using namespace std;

std::string exec(const char *cmd) {
    std::array<char, 512> buffer;
    std::string result;
    result += cmd + "\n"s;
    // Open the pipe
    std::unique_ptr<FILE, decltype(&pclose)> pipe(popen(cmd, "r"), pclose);
    if (!pipe) {
        throw std::runtime_error("popen() failed!");
    }
    // Read the output a line at a time
    while (fgets(buffer.data(), buffer.size(), pipe.get()) != nullptr) {
        result += buffer.data();
    }
    return result;
}



int main() {
    exec("rm to_be_write*");
    sleep(0.2);
    getpid();
    printf("pid: %d  ppid: %d\n", getpid(), getppid());

    int n = 20;
    int fds[20] = {0};

    vector<thread> thds;
    for (size_t i = 0; i < n; i++) {
        thds.emplace_back([&]() {
            string file_name = "to_be_write"s + to_string(i) + "-pid-"s + to_string(getpid()) + ".txt"s;
            fds[i] = open(file_name.c_str(), O_WRONLY | O_CREAT | O_TRUNC, 0644);
            string cmd = "mv "s + file_name + " "s + string(file_name).replace(file_name.find(".txt"), 4, "-fd-"s + to_string(fds[i]) + ".txt"s);
            cout << " " << cmd << " " << endl;
            system(cmd.c_str());
            if (fds[i] == -1) {
                perror("open");
            }
            auto str = "pid: "s + to_string(getpid());
            ssize_t bytes_written;
            while (-1 == (bytes_written = write(fds[i], str.c_str(), str.length()))) {
            }
            cout << to_string(i) + ": content: "s + str + " bytes_written: "s + to_string(bytes_written) << " " << endl;
            sleep(0.3);
            close(fds[i]);
        });
    }
    for (size_t i = 0; i < n; i++) {
        thds[i].join();
    }
    cout << endl;
    for (size_t i = 0; i < n; i++) {
        cout << fds[i] << " ";
    }
    cout << endl;
    cout << exec(("ls /proc/"s + to_string(getpid()) + "/fd"s).c_str());
    // if (bytes_written == -1) {
    //     perror("write");
    //     close(fds[i]);
    //     return 1;
    // }
    // struct stat file_info;
    // if (fstat(fd, &file_info) == -1) {
    //     perror("fstat");
    //     exit(EXIT_FAILURE);
    // }
    // printf("写入文件大小:%ld bytes\n", file_info.st_size);
    // close(fd);
    return 0;
}
