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
patchelf --set-interpreter /opt/glibc-2.35/lib/ld-2.32.so  --set-rpath /opt/glibc-2.35/lib [executable]
```

- 链接上:

```
~/Git/code$ ldd out
        linux-vdso.so.1 (0x00007ffd6d9a6000)
        libc.so.6 => /opt/glibc-2.35/lib/libc.so.6 (0x00007f38e16fb000)
        /lib64/ld-linux-x86-64.so.2 (0x00007f38e18f2000)
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
