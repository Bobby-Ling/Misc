# tracer: function_graph
#
# CPU  TASK/PID         DURATION                  FUNCTION CALLS
# |     |    |           |   |                     |   |   |   |
 6)  ftrace_-859   | ! 744.846 us  |  mutex_unlock();
 6)  ftrace_-859   |               |  vfs_open() {
 6)  ftrace_-859   |               |    do_dentry_open() {
 6)  ftrace_-859   |               |      path_get() {
 6)  ftrace_-859   |   1.428 us    |        mntget();
 6)  ftrace_-859   |   6.403 us    |      } /* path_get */
 6)  ftrace_-859   |               |      __mnt_want_write() {
 6)  ftrace_-859   |   0.912 us    |        preempt_count_add();
 6)  ftrace_-859   |   0.907 us    |        preempt_count_sub();
 6)  ftrace_-859   |   4.825 us    |      } /* __mnt_want_write */
 6)  ftrace_-859   |   1.234 us    |      try_module_get();
 6)  ftrace_-859   |               |      security_file_open() {
 6)  ftrace_-859   |   1.470 us    |        hook_file_open();
 6)  ftrace_-859   |   2.085 us    |        apparmor_file_open();
 6)  ftrace_-859   |   8.180 us    |      } /* security_file_open */
 6)  ftrace_-859   |               |      security_locked_down() {
 6)  ftrace_-859   |   1.192 us    |        lockdown_is_locked_down();
 6)  ftrace_-859   |   3.704 us    |      } /* security_locked_down */
 6)  ftrace_-859   |   1.006 us    |      mutex_lock();
 6)  ftrace_-859   |   0.963 us    |      mutex_unlock();
 6)  ftrace_-859   |               |      file_ra_state_init() {
 6)  ftrace_-859   |   1.481 us    |        inode_to_bdi();
 6)  ftrace_-859   |   3.628 us    |      } /* file_ra_state_init */
 6)  ftrace_-859   | + 44.616 us   |    } /* do_dentry_open */
 6)  ftrace_-859   | + 54.419 us   |  } /* vfs_open */
 6)  ftrace_-859   |               |  ksys_write() {
 6)  ftrace_-859   |               |    __fdget_pos() {
 6)  ftrace_-859   |   0.975 us    |      __fget_light();
 6)  ftrace_-859   |   4.029 us    |    } /* __fdget_pos */
 6)  ftrace_-859   |               |    vfs_write() {
 6)  ftrace_-859   |               |      rw_verify_area() {
 6)  ftrace_-859   |               |        security_file_permission() {
 6)  ftrace_-859   |               |          apparmor_file_permission() {
 6)  ftrace_-859   |   1.615 us    |            aa_file_perm();
 6)  ftrace_-859   |   4.578 us    |          } /* apparmor_file_permission */
 6)  ftrace_-859   |   7.114 us    |        } /* security_file_permission */
 6)  ftrace_-859   |   9.554 us    |      } /* rw_verify_area */
 6)  ftrace_-859   |   0.884 us    |      preempt_count_add();
 6)  ftrace_-859   |   0.850 us    |      preempt_count_sub();
 6)  ftrace_-859   |               |      __check_object_size() {
 6)  ftrace_-859   |   1.070 us    |        check_stack_object();
 6)  ftrace_-859   |   2.924 us    |      } /* __check_object_size */
 6)  ftrace_-859   |   0.874 us    |      mutex_lock();
