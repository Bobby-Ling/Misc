#include <linux/fdtable.h>
#include <linux/file.h>
#include <linux/init.h>
#include <linux/kernel.h>
#include <linux/kprobes.h>
#include <linux/module.h>
#include <linux/pid.h>
#include <linux/sched.h>
#include <linux/sched/signal.h>
#include <linux/uaccess.h>
#include <linux/uidgid.h>

static struct kprobe kp;

int get_process_name_init(int target_pid)
{
    struct task_struct* task;
    rcu_read_lock();
    task = pid_task(find_vpid(target_pid), PIDTYPE_PID);
    rcu_read_unlock();

    if (!task) {
        printk(KERN_INFO "No task found for PID %d\n", target_pid);
        return -ESRCH;
    }

    printk(KERN_INFO "Process name for PID %d: %s\n", target_pid, task->comm);
    return 0;
}

struct task_struct* get_proc(pid_t pid)
{
    struct pid* pid_struct = NULL;
    struct task_struct* mytask = NULL;
    pid_struct = find_get_pid(pid);
    if (!pid_struct)
        return NULL;
    mytask = pid_task(pid_struct, PIDTYPE_PID);
    return mytask;
}

int get_path(struct task_struct* mytask, int fd)
{
    struct file* myfile = NULL;
    struct files_struct* files = NULL;
    char path[100] = { '\0' };
    char* ppath = path;
    files = mytask->files;
    if (!files) {
        printk("files is null..\n");
        return -1;
    }
    myfile = files->fdt->fd[fd];
    if (!myfile) {
        printk("myfile is null..\n");
        return -1;
    }
    ppath = d_path(&(myfile->f_path), ppath, 100);
    printk(KERN_INFO "path = %s\n", ppath);
    return 0;
}

// kprobe pre-handler: called just before the probed instruction is executed
static int handler_pre(struct kprobe* p, struct pt_regs* regs)
{
    unsigned int fd;
    const char __user* buf;
    size_t count;

    // #include <bpf_helpers.h>
    // #define PT_REGS_PARM1(x) ((x)->di)
    // #define PT_REGS_PARM2(x) ((x)->si)
    // #define PT_REGS_PARM3(x) ((x)->dx)
    // #define PT_REGS_PARM4(x) ((x)->cx)
    // #define PT_REGS_PARM5(x) ((x)->r8)
    // #define PT_REGS_RET(x) ((x)->sp)
    // #define PT_REGS_FP(x) ((x)->bp)
    // #define PT_REGS_RC(x) ((x)->ax)
    // #define PT_REGS_SP(x) ((x)->sp)
    // #define PT_REGS_IP(x) ((x)->ip)
    fd = regs->di;
    buf = (const char __user*)regs->si;
    count = regs->dx;

    struct task_struct* current_task = current;
    pid_t user_pid = task_tgid_vnr(current);
    uid_t user_uid = current->cred->uid.val;

    // 通过线程唯一的task_struct获取pid和uid; 每个进程的fd表是线程共享的
    if (user_uid == 1001) {
        printk(KERN_INFO "ksys_write called by %d: fd = %u, buf = %p, count = %zu, "
                         "tgid = %d, sys_getpid = %d in kprobe",
            user_uid, fd, buf, count, current->tgid, user_pid);
        get_process_name_init(user_pid);
    }
    // XXX 坑点!
    // getpid()==sys_getpid()==task_tgid_vnr(current)!=current->tgid,
    // 当然不会==current->pid

    /*
    说明此时struct task_struct的上下文是一样的
    [  +0.000444] ksys_write called by 1001: fd = 2, buf = 00000000d62270fb, count
    = 1, tgid = 41139, pid = 41139 in kprobe [  +0.000003] ksys_write called by
    1001: fd = 2, buf = 00000000d62270fb, count = 1, tgid = 41139, pid = 41139
    */
    /*
    sudo readlink /proc/28006/fd/9
    /home/bobby_ubuntu/Git/code/user_mode/pid/to_be_write8-pid-28006-fd-18.txt
    */
    // printk(KERN_INFO "pid = %d, fd = %d, path = %s\n", current_task->pid, fd,
    // get_path(get_proc(current_task->pid),fd)); get_path(get_proc(current->pid),
    // fd);

    return 0;
}

static int __init kprobe_init(void)
{
    int ret;

    kp.pre_handler = handler_pre;
    kp.symbol_name = "ksys_write";

    ret = register_kprobe(&kp);
    if (ret < 0) {
        printk(KERN_ERR "register_kprobe failed, returned %d\n", ret);
        return ret;
    }

    printk(KERN_INFO "kprobe registered at %p\n", kp.addr);
    return 0;
}

static void __exit kprobe_exit(void)
{
    unregister_kprobe(&kp);
    printk(KERN_INFO "kprobe unregistered\n");
}

module_init(kprobe_init);
module_exit(kprobe_exit);

MODULE_LICENSE("GPL");
MODULE_AUTHOR("Bobby");
MODULE_DESCRIPTION("A kprobe module to log ksys_write parameters");