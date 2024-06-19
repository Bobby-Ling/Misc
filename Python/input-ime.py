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

def send_ime_char(hwnd, char):
    """向窗口发送IME字符"""
    user32.PostMessageW(hwnd, WM_IME_CHAR, char, 0)

def set_foreground_window(title):
    """将目标窗口设置为前台窗口"""
    hwnd = win32gui.FindWindow(None, title)
    if hwnd:
        win32gui.SetForegroundWindow(hwnd)
    return hwnd

def main():
    # # 要输入文本的目标窗口标题
    # target_window_title = "记事本"
    
    # # 将目标窗口设置为前台窗口
    # hwnd = set_foreground_window(target_window_title)
    # if not hwnd:
    #     print(f"未找到窗口: {target_window_title}")
    #     return

    # 获取当前前台窗口的句柄
    hwnd = user32.GetForegroundWindow()
    
    # 需要输入的中文字符
    chinese_text = "你好，世界"

    # 切换到中文输入法（假设已安装拼音输入法）
    win32api.keybd_event(VK_HANJA, 0, 0, 0)
    time.sleep(0.1)  # 等待输入法切换生效
    
    for char in chinese_text:
        # 向窗口发送IME字符
        send_ime_char(hwnd, ord(char))
        time.sleep(0.1)  # 每个字符之间稍作等待

    # 切换回英文输入法
    win32api.keybd_event(VK_HANJA, 0, 0, 0)
    time.sleep(0.1)

if __name__ == "__main__":
    main()
