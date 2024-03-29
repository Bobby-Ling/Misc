# `GDB+vscode`调试Glibc
- 编译具备调试信息的glibc:

```bash
../configure \
    --prefix=/opt/glibc-2.35 \
    --disable-werror \
    --without-selinux \
    --enable-add-ons \
    --enable-kernel=5.15.1 \
    --without-gd \
    --enable-debug=yes \
    --with-headers=/usr/include/kernelheader/include \
    --enable-kernel=5.15.1 \
    CFLAGS="-Og -g3" \
    CXXFLAGS="-Og -g3"
```
- gcc 编译加上"-Wl,-rpath=/opt/glibc-2.35/lib"
- 或者
```bash 
patchelf --set-interpreter /opt/glibc-2.35/lib/ld-2.35.so  --set-rpath /opt/glibc-2.35/lib [executable]
```
- 链接上:
```bash
bobby_ubuntu@Bobby:~/Git/code$ ldd out_no_debug 
        linux-vdso.so.1 (0x00007ffdd1dec000)
        libc.so.6 => /lib/x86_64-linux-gnu/libc.so.6 (0x00007fd722486000)
        /lib64/ld-linux-x86-64.so.2 (0x00007fd7226c1000)
bobby_ubuntu@Bobby:~/Git/code$ ldd out
        linux-vdso.so.1 (0x00007ffe7d4c6000)
        libc.so.6 => /opt/glibc-2.35/lib/libc.so.6 (0x00007f69c6cfd000)
        /lib64/ld-linux-x86-64.so.2 (0x00007f69c6ef4000)
```

# `GDB+vscode+QEMU`调试Kernel
```.vscode/launch.json
{  
    "version": "0.2.0",  
    "configurations": [  
        {
            "name": "(gdb) 调试vmlinux",
            "type": "cppdbg",
            "request": "launch",
            "miDebuggerServerAddress": "127.0.0.1:1234",
            "program": "${workspaceFolder}/vmlinux",
            "args": [],
            "stopAtConnect": true,
            "cwd": "${workspaceFolder}",
            "externalConsole": false,
            "MIMode": "gdb",
            "setupCommands": [
                {
                    "text": "cd ${workspaceFolder}", 
                    "ignoreFailures": false
                },
                {
                    "description": "为 gdb 启用当前目录的.gdbinit",
                    "text": "source ./.gdbinit",
                    "ignoreFailures": false
                }
            ],
            "preLaunchTask": "startvm.sh"
        },
    ]  
}
```

```.vscode/tasks.json
    "tasks": [
      {
        "type": "shell",
        "label": "startvm.sh",
        "command": "nohup sh -c '${workspaceFolder}/startvm.sh &';echo OK",
        "args": [
        ],
        "group": {
          "kind": "build",
          "isDefault": true
        },
        "detail": "startvm.sh"
      },
    ]
```

# glibc 
```bash
~/Git/glibc-2.35$ find -name  "syscall-names.list"
./sysdeps/unix/sysv/linux/syscall-names.list
make update-syscall-lists
```

# 模块
```bash
sudo make drivers/usb/serial/usbserial.ko KCONFIG_CONFIG=config-wsl-modified-5.15.1 -j $(nproc)
```
