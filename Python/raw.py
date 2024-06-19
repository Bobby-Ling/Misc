import win32api
import win32con
import win32gui
import ctypes
import time

# 引入必要的Windows API函数
user32 = ctypes.windll.user32

# 定义输入法相关常量
VK_HANJA = 0x19  # 切换输入法
WM_IME_CHAR = 0x286  # 用于向窗口发送IME字符的消息
VK_RETURN = 0x0D  # 回车键

def send_ime_char(hwnd, char):
    """向窗口发送IME字符"""
    user32.PostMessageW(hwnd, WM_IME_CHAR, char, 0)

def main(input_text:str):
    # 获取当前前台窗口的句柄
    hwnd = user32.GetForegroundWindow()
    

    # 切换到中文输入法（假设已安装拼音输入法）
    win32api.keybd_event(VK_HANJA, 0, 0, 0)
    time.sleep(0.1)  # 等待输入法切换生效
    
    for char in input_text:
        if char == '\n':
            # 模拟按下回车键
            print("")
            win32api.keybd_event(VK_RETURN, 0, 0, 0)
            win32api.keybd_event(VK_RETURN, 0, win32con.KEYEVENTF_KEYUP, 0)
        print(char,end="")
        # 向窗口发送IME字符
        send_ime_char(hwnd, ord(char))
        time.sleep(0.01)  # 每个字符之间稍作等待
        # win32api.keybd_event(VK_RETURN, 0, 0, 0)
    # 切换回英文输入法
    win32api.keybd_event(VK_HANJA, 0, 0, 0)
    time.sleep(0.1)

import tkinter as tk
import pyautogui

def start_typing():
    try:
        delay = float(delay_entry.get())
    except ValueError:
        delay = 0  # Default to no delay if input is invalid
    input_text = input_text_box.get("1.0", tk.END).strip()
    
    pyautogui.sleep(delay)
    # pyautogui.write(input_text, interval=0.05)  # interval controls the typing speed
    main(input_text)

def set_window_on_top():
    hwnd = win32gui.FindWindow(None, "PyAutoGUI Typing")
    if hwnd:
        win32gui.SetWindowPos(hwnd, win32con.HWND_TOPMOST, 0, 0, 0, 0, win32con.SWP_NOMOVE | win32con.SWP_NOSIZE)
        print("窗口已置顶")


# 创建主窗口
root = tk.Tk()
root.title("PyAutoGUI Typing")

# 延时输入框
tk.Label(root, text="延时 (秒):").pack()
delay_entry = tk.Entry(root)
delay_entry.pack()

# 输入文本框
tk.Label(root, text="输入文本:").pack()
input_text_box = tk.Text(root, height=10, width=40)
input_text_box.pack()

# 开始按钮
start_button = tk.Button(root, text="开始", command=start_typing)
start_button.pack()

clear_button = tk.Button(root, text="清空文本框", command=lambda: input_text_box.delete(1.0, tk.END))
clear_button.pack(pady=5)

set_top_button = tk.Button(root, text="设置窗口置顶", command=set_window_on_top)
set_top_button.pack(pady=5)

# 运行主循环
root.mainloop()
