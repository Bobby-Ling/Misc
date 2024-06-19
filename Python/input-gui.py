import tkinter as tk
import pyautogui

def start_typing():
    try:
        delay = float(delay_entry.get())
    except ValueError:
        delay = 0  # Default to no delay if input is invalid
    input_text = input_text_box.get("1.0", tk.END).strip()
    
    pyautogui.sleep(delay)
    pyautogui.write(input_text, interval=0.05)  # interval controls the typing speed

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

# 运行主循环
root.mainloop()
