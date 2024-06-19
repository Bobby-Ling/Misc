import win32api
import win32con
import win32gui
import ctypes
import time

# 引入必要的Windows API函数
user32 = ctypes.windll.user32

# 定义输入法相关常量
VK_HANJA = 0x19  # 한자键, 用于切换输入法
WM_IME_CHAR = 0x286  # 用于向窗口发送IME字符的消息
VK_RETURN = 0x0D  # 回车键


win32api.keybd_event(VK_RETURN, 0, 0, 0)
win32api.keybd_event(VK_RETURN, 0, 0, 0)
win32api.keybd_event(VK_RETURN, 0, 0, 0)
win32api.keybd_event(VK_RETURN, 0, 0, 0)