import win32api
import win32con
import win32gui
import ctypes
import time

# 引入必要的Windows API函数
user32 = ctypes.windll.user32

class input_ime:

    # 定义输入法相关常量
    win32con.VK_HANJA # = 0x19  # 切换输入法
    win32con.WM_IME_CHAR # = 0x286  # 用于向窗口发送IME字符的消息
    win32con.VK_RETURN # = 0x0D  # 回车键

    def send_ime_char(hwnd, char):
        """向窗口发送IME字符"""
        user32.PostMessageW(hwnd, win32con.WM_IME_CHAR, char, 0)

    def input(input_text:str,hwnd):
        print(win32gui.GetWindowText(hwnd),win32gui.GetWindowText(user32.GetForegroundWindow()))

        # 切换到中文输入法（假设已安装拼音输入法）
        win32api.keybd_event(win32con.VK_HANJA, 0, 0, 0)
        time.sleep(0.1)  # 等待输入法切换生效
        
        for char in input_text:
            if char == '\n':
                # 模拟按下回车键
                print("")

                win32api.keybd_event(win32con.VK_RETURN, 0, 0, 0)
                win32api.keybd_event(win32con.VK_RETURN, 0, win32con.KEYEVENTF_KEYUP, 0)
            print(char,end="")
            # 向窗口发送IME字符
            input_ime.send_ime_char(hwnd, ord(char))
            time.sleep(0.01)  # 每个字符之间稍作等待
            # win32api.keybd_event(win32con.VK_RETURN, 0, 0, 0)
        # 切换回英文输入法
        win32api.keybd_event(win32con.VK_HANJA, 0, 0, 0)
        time.sleep(0.1)

import tkinter as tk
import pyautogui

class main_window:
    title = "模拟键盘输入(IME)"
    is_on_top = False
    input_text_box = ''
    delay_entry = ''

    def __init__() -> None:
        # 创建主窗口
        root = tk.Tk()
        root.title(main_window.title)

        # 延时输入框
        tk.Label(root, text="延时 (秒):").pack()
        main_window.delay_entry = tk.Entry(root)
        main_window.delay_entry.pack()

        # 输入文本框
        tk.Label(root, text="输入文本:").pack()
        main_window.input_text_box = tk.Text(root, height=10, width=40)
        main_window.input_text_box.pack()

        # 开始按钮
        start_button = tk.Button(root, text="开始", command=main_window.start_typing)
        start_button.pack()

        clear_button = tk.Button(root, text="清空文本框", command=lambda: main_window.input_text_box.delete(1.0, tk.END))
        clear_button.pack(pady=5)

        set_top_button = tk.Button(root, text="设置窗口置顶", command=main_window.toggle_window_on_top)
        set_top_button.pack(pady=5)

        # 运行主循环
        root.mainloop()
    
    def start_typing():
        try:
            delay = float(main_window.delay_entry.get())
        except ValueError:
            delay = 0  # Default to no delay if input is invalid
        input_text = main_window.input_text_box.get("1.0", tk.END).strip()
        
        time.sleep(delay)

        input_ime.input(input_text,user32.GetForegroundWindow())

    def toggle_window_on_top():
        hwnd = win32gui.FindWindow(None, main_window.title)
        if hwnd:
            main_window.is_on_top = not main_window.is_on_top
            if main_window.is_on_top == True:
                win32gui.SetWindowPos(hwnd, win32con.HWND_TOPMOST, 0, 0, 0, 0, win32con.SWP_NOMOVE | win32con.SWP_NOSIZE)
                print("窗口已置顶")
            else:
                win32gui.SetWindowPos(hwnd, win32con.HWND_NOTOPMOST, 0, 0, 0, 0, win32con.SWP_NOMOVE | win32con.SWP_NOSIZE)
                print("窗口已取消置顶")

main_window.__init__()