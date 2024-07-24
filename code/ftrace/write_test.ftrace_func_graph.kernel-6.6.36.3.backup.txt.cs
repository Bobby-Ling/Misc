# tracer: function_graph
#
# CPU  TASK/PID         DURATION                  FUNCTION CALLS
# |     |    |           |   |                     |   |   |   |
finish_task_switch.isra.0() {
  _raw_spin_unlock() {
    preempt_count_sub();
  } /* _raw_spin_unlock */
} /* finish_task_switch.isra.0 */
__do_sys_get_pid_in_crt();
vfs_open() {
  do_dentry_open() {
    path_get() {
      mntget();
    } /* path_get */
    __mnt_want_write() {
      preempt_count_add();
      preempt_count_sub();
    } /* __mnt_want_write */
    try_module_get();
    security_file_open() {
      hook_file_open();
      selinux_file_open() {
        inode_security();
        avc_policy_seqno();
        inode_has_perm() {
          avc_has_perm() {
            avc_lookup();
          } /* avc_has_perm */
        } /* inode_has_perm */
      } /* selinux_file_open */
      __fsnotify_parent() {
        dget_parent();
        fsnotify();
        dput();
      } /* __fsnotify_parent */
    } /* security_file_open */
    ext4_file_open() {
      ext4_inode_attach_jinode() {
        kmem_cache_alloc() {
          should_failslab();
        } /* kmem_cache_alloc */
        _raw_spin_lock() {
          preempt_count_add();
        } /* _raw_spin_lock */
        jbd2_journal_init_jbd_inode();
        _raw_spin_unlock() {
          preempt_count_sub();
        } /* _raw_spin_unlock */
      } /* ext4_inode_attach_jinode */
      dquot_file_open() {
        generic_file_open();
        __dquot_initialize();
      } /* dquot_file_open */
    } /* ext4_file_open */
    file_ra_state_init() {
      inode_to_bdi();
    } /* file_ra_state_init */
    __fsnotify_parent() {
      dget_parent();
      fsnotify();
      dput();
    } /* __fsnotify_parent */
  } /* do_dentry_open */
} /* vfs_open */
__do_sys_get_pid_in_crt();
ksys_write() {
  __fdget_pos() {
    __fget_light();
  } /* __fdget_pos */
  vfs_write() {
    rw_verify_area() {
      security_file_permission() {
        selinux_file_permission() {
          inode_security();
          avc_policy_seqno();
        } /* selinux_file_permission */
      } /* security_file_permission */
    } /* rw_verify_area */
    preempt_count_add();
    preempt_count_sub();
    __get_task_ioprio();
    ext4_file_write_iter() {
      ext4_buffered_write_iter() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        ext4_generic_write_checks() {
          generic_write_checks() {
            generic_write_check_limits();
          } /* generic_write_checks */
        } /* ext4_generic_write_checks */
        file_modified() {
          __file_remove_privs() {
            setattr_should_drop_suidgid();
            security_inode_need_killpriv() {
              cap_inode_need_killpriv() {
                __vfs_getxattr() {
                  xattr_resolve_name();
                  ext4_xattr_security_get() {
                    ext4_xattr_get() {
                      down_read() {
                        preempt_count_add();
                        preempt_count_sub();
                      } /* down_read */
                      ext4_xattr_ibody_get();
                      up_read() {
                        preempt_count_add();
                        preempt_count_sub();
                      } /* up_read */
                    } /* ext4_xattr_get */
                  } /* ext4_xattr_security_get */
                } /* __vfs_getxattr */
              } /* cap_inode_need_killpriv */
            } /* security_inode_need_killpriv */
          } /* __file_remove_privs */
          inode_needs_update_time() {
            ktime_get_coarse_real_ts64();
            timestamp_truncate();
          } /* inode_needs_update_time */
        } /* file_modified */
        generic_perform_write() {
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              inode_to_bdi();
              filemap_alloc_folio() {
                folio_alloc() {
                  alloc_pages() {
                    policy_nodemask();
                    policy_node();
                    __alloc_pages() {
                      should_fail_alloc_page();
                      get_page_from_freelist() {
                        node_dirty_ok() {
                          node_page_state();
                          node_page_state();
                          node_page_state();
                          node_page_state();
                        } /* node_dirty_ok */
                        preempt_count_add();
                        _raw_spin_trylock() {
                          preempt_count_add();
                        } /* _raw_spin_trylock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        preempt_count_sub();
                      } /* get_page_from_freelist */
                    } /* __alloc_pages */
                  } /* alloc_pages */
                } /* folio_alloc */
              } /* filemap_alloc_folio */
              filemap_add_folio() {
                __filemap_add_folio() {
                  __mem_cgroup_charge() {
                    get_mem_cgroup_from_mm();
                    charge_memcg() {
                      try_charge_memcg();
                      mem_cgroup_charge_statistics() {
                        __count_memcg_events() {
                          cgroup_rstat_updated();
                        } /* __count_memcg_events */
                      } /* mem_cgroup_charge_statistics */
                      memcg_check_events();
                    } /* charge_memcg */
                  } /* __mem_cgroup_charge */
                  _raw_spin_lock_irq() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irq */
                  __mod_lruvec_page_state() {
                    __mod_lruvec_state() {
                      __mod_node_page_state();
                      __mod_memcg_lruvec_state() {
                        cgroup_rstat_updated();
                      } /* __mod_memcg_lruvec_state */
                    } /* __mod_lruvec_state */
                  } /* __mod_lruvec_page_state */
                  _raw_spin_unlock_irq() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irq */
                } /* __filemap_add_folio */
                folio_add_lru() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* folio_add_lru */
              } /* filemap_add_folio */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int() {
                folio_create_empty_buffers() {
                  folio_alloc_buffers() {
                    alloc_buffer_head() {
                      kmem_cache_alloc() {
                        should_failslab();
                        __get_obj_cgroup_from_memcg();
                        obj_cgroup_charge();
                        mod_objcg_state();
                      } /* kmem_cache_alloc */
                      preempt_count_add();
                      preempt_count_sub();
                    } /* alloc_buffer_head */
                  } /* folio_alloc_buffers */
                  _raw_spin_lock() {
                    preempt_count_add();
                  } /* _raw_spin_lock */
                  _raw_spin_unlock() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock */
                } /* folio_create_empty_buffers */
                ext4_da_get_block_prep() {
                  ext4_es_lookup_extent() {
                    _raw_read_lock() {
                      preempt_count_add();
                    } /* _raw_read_lock */
                    _raw_read_unlock() {
                      preempt_count_sub();
                    } /* _raw_read_unlock */
                  } /* ext4_es_lookup_extent */
                  down_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* down_read */
                  ext4_ext_map_blocks() {
                    ext4_find_extent() {
                      __kmalloc() {
                        kmalloc_slab();
                        __kmem_cache_alloc_node() {
                          should_failslab();
                        } /* __kmem_cache_alloc_node */
                      } /* __kmalloc */
                      ext4_cache_extents();
                    } /* ext4_find_extent */
                    ext4_es_find_extent_range() {
                      _raw_read_lock() {
                        preempt_count_add();
                      } /* _raw_read_lock */
                      __es_find_extent_range() {
                        __es_tree_search.isra.0();
                      } /* __es_find_extent_range */
                      _raw_read_unlock() {
                        preempt_count_sub();
                      } /* _raw_read_unlock */
                    } /* ext4_es_find_extent_range */
                    ext4_es_insert_extent() {
                      _raw_write_lock() {
                        preempt_count_add();
                      } /* _raw_write_lock */
                      __es_remove_extent() {
                        __es_tree_search.isra.0();
                      } /* __es_remove_extent */
                      __es_insert_extent() {
                        kmem_cache_alloc() {
                          should_failslab();
                        } /* kmem_cache_alloc */
                        _raw_spin_lock() {
                          preempt_count_add();
                        } /* _raw_spin_lock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                      } /* __es_insert_extent */
                      _raw_write_unlock() {
                        preempt_count_sub();
                      } /* _raw_write_unlock */
                    } /* ext4_es_insert_extent */
                    kfree() {
                      __kmem_cache_free();
                    } /* kfree */
                  } /* ext4_ext_map_blocks */
                  ext4_da_reserve_space() {
                    __dquot_alloc_space() {
                      _raw_spin_lock() {
                        preempt_count_add();
                      } /* _raw_spin_lock */
                      ext4_get_reserved_space();
                      _raw_spin_unlock() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock */
                    } /* __dquot_alloc_space */
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    ext4_claim_free_clusters() {
                      ext4_has_free_clusters();
                    } /* ext4_claim_free_clusters */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                  } /* ext4_da_reserve_space */
                  ext4_es_insert_delayed_block() {
                    _raw_write_lock() {
                      preempt_count_add();
                    } /* _raw_write_lock */
                    __es_remove_extent() {
                      __es_tree_search.isra.0();
                    } /* __es_remove_extent */
                    __es_insert_extent() {
                      ext4_es_can_be_merged.isra.0();
                      kmem_cache_alloc() {
                        should_failslab();
                      } /* kmem_cache_alloc */
                    } /* __es_insert_extent */
                    _raw_write_unlock() {
                      preempt_count_sub();
                    } /* _raw_write_unlock */
                  } /* ext4_es_insert_delayed_block */
                  up_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* up_read */
                } /* ext4_da_get_block_prep */
                clean_bdev_aliases() {
                  filemap_get_folios();
                } /* clean_bdev_aliases */
              } /* __block_write_begin_int */
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty() {
                  folio_memcg_lock();
                  __folio_mark_dirty() {
                    _raw_spin_lock_irqsave() {
                      preempt_count_add();
                    } /* _raw_spin_lock_irqsave */
                    inode_to_bdi();
                    __mod_lruvec_page_state() {
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                    } /* __mod_lruvec_page_state */
                    __mod_zone_page_state();
                    __mod_node_page_state();
                    mem_cgroup_track_foreign_dirty_slowpath() {
                      __msecs_to_jiffies();
                    } /* mem_cgroup_track_foreign_dirty_slowpath */
                    _raw_spin_unlock_irqrestore() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock_irqrestore */
                  } /* __folio_mark_dirty */
                  folio_memcg_unlock();
                  __mark_inode_dirty();
                } /* mark_buffer_dirty */
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              inode_to_bdi();
              filemap_alloc_folio() {
                folio_alloc() {
                  alloc_pages() {
                    policy_nodemask();
                    policy_node();
                    __alloc_pages() {
                      should_fail_alloc_page();
                      get_page_from_freelist() {
                        node_dirty_ok() {
                          node_page_state();
                          node_page_state();
                          node_page_state();
                          node_page_state();
                        } /* node_dirty_ok */
                        preempt_count_add();
                        _raw_spin_trylock() {
                          preempt_count_add();
                        } /* _raw_spin_trylock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        preempt_count_sub();
                      } /* get_page_from_freelist */
                    } /* __alloc_pages */
                  } /* alloc_pages */
                } /* folio_alloc */
              } /* filemap_alloc_folio */
              filemap_add_folio() {
                __filemap_add_folio() {
                  __mem_cgroup_charge() {
                    get_mem_cgroup_from_mm();
                    charge_memcg() {
                      try_charge_memcg();
                      mem_cgroup_charge_statistics() {
                        __count_memcg_events() {
                          cgroup_rstat_updated();
                        } /* __count_memcg_events */
                      } /* mem_cgroup_charge_statistics */
                      memcg_check_events();
                    } /* charge_memcg */
                  } /* __mem_cgroup_charge */
                  _raw_spin_lock_irq() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irq */
                  kmem_cache_alloc_lru() {
                    should_failslab();
                    __get_obj_cgroup_from_memcg();
                    memcg_list_lru_alloc();
                    obj_cgroup_charge();
                    mod_objcg_state();
                  } /* kmem_cache_alloc_lru */
                  workingset_update_node();
                  workingset_update_node();
                  __mod_lruvec_page_state() {
                    __mod_lruvec_state() {
                      __mod_node_page_state();
                      __mod_memcg_lruvec_state() {
                        cgroup_rstat_updated();
                      } /* __mod_memcg_lruvec_state */
                    } /* __mod_lruvec_state */
                  } /* __mod_lruvec_page_state */
                  _raw_spin_unlock_irq() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irq */
                } /* __filemap_add_folio */
                folio_add_lru() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* folio_add_lru */
              } /* filemap_add_folio */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int() {
                folio_create_empty_buffers() {
                  folio_alloc_buffers() {
                    alloc_buffer_head() {
                      kmem_cache_alloc() {
                        should_failslab();
                        __get_obj_cgroup_from_memcg();
                        obj_cgroup_charge();
                        mod_objcg_state();
                      } /* kmem_cache_alloc */
                      preempt_count_add();
                      preempt_count_sub();
                    } /* alloc_buffer_head */
                  } /* folio_alloc_buffers */
                  _raw_spin_lock() {
                    preempt_count_add();
                  } /* _raw_spin_lock */
                  _raw_spin_unlock() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock */
                } /* folio_create_empty_buffers */
                ext4_da_get_block_prep() {
                  ext4_es_lookup_extent() {
                    _raw_read_lock() {
                      preempt_count_add();
                    } /* _raw_read_lock */
                    _raw_read_unlock() {
                      preempt_count_sub();
                    } /* _raw_read_unlock */
                  } /* ext4_es_lookup_extent */
                  down_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* down_read */
                  ext4_da_reserve_space() {
                    __dquot_alloc_space() {
                      _raw_spin_lock() {
                        preempt_count_add();
                      } /* _raw_spin_lock */
                      ext4_get_reserved_space();
                      _raw_spin_unlock() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock */
                    } /* __dquot_alloc_space */
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    ext4_claim_free_clusters() {
                      ext4_has_free_clusters();
                    } /* ext4_claim_free_clusters */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                  } /* ext4_da_reserve_space */
                  ext4_es_insert_delayed_block() {
                    _raw_write_lock() {
                      preempt_count_add();
                    } /* _raw_write_lock */
                    __es_remove_extent() {
                      __es_tree_search.isra.0();
                    } /* __es_remove_extent */
                    __es_insert_extent() {
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                    } /* __es_insert_extent */
                    _raw_write_unlock() {
                      preempt_count_sub();
                    } /* _raw_write_unlock */
                  } /* ext4_es_insert_delayed_block */
                  up_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* up_read */
                } /* ext4_da_get_block_prep */
                clean_bdev_aliases() {
                  filemap_get_folios();
                } /* clean_bdev_aliases */
              } /* __block_write_begin_int */
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty() {
                  folio_memcg_lock();
                  __folio_mark_dirty() {
                    _raw_spin_lock_irqsave() {
                      preempt_count_add();
                    } /* _raw_spin_lock_irqsave */
                    inode_to_bdi();
                    __mod_lruvec_page_state() {
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                    } /* __mod_lruvec_page_state */
                    __mod_zone_page_state();
                    __mod_node_page_state();
                    mem_cgroup_track_foreign_dirty_slowpath() {
                      __msecs_to_jiffies();
                    } /* mem_cgroup_track_foreign_dirty_slowpath */
                    _raw_spin_unlock_irqrestore() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock_irqrestore */
                  } /* __folio_mark_dirty */
                  folio_memcg_unlock();
                  __mark_inode_dirty();
                } /* mark_buffer_dirty */
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              inode_to_bdi();
              filemap_alloc_folio() {
                folio_alloc() {
                  alloc_pages() {
                    policy_nodemask();
                    policy_node();
                    __alloc_pages() {
                      should_fail_alloc_page();
                      get_page_from_freelist() {
                        node_dirty_ok() {
                          node_page_state();
                          node_page_state();
                          node_page_state();
                          node_page_state();
                        } /* node_dirty_ok */
                        preempt_count_add();
                        _raw_spin_trylock() {
                          preempt_count_add();
                        } /* _raw_spin_trylock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        preempt_count_sub();
                      } /* get_page_from_freelist */
                    } /* __alloc_pages */
                  } /* alloc_pages */
                } /* folio_alloc */
              } /* filemap_alloc_folio */
              filemap_add_folio() {
                __filemap_add_folio() {
                  __mem_cgroup_charge() {
                    get_mem_cgroup_from_mm();
                    charge_memcg() {
                      try_charge_memcg();
                      mem_cgroup_charge_statistics() {
                        __count_memcg_events() {
                          cgroup_rstat_updated();
                        } /* __count_memcg_events */
                      } /* mem_cgroup_charge_statistics */
                      memcg_check_events();
                    } /* charge_memcg */
                  } /* __mem_cgroup_charge */
                  _raw_spin_lock_irq() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irq */
                  workingset_update_node();
                  __mod_lruvec_page_state() {
                    __mod_lruvec_state() {
                      __mod_node_page_state();
                      __mod_memcg_lruvec_state() {
                        cgroup_rstat_updated();
                      } /* __mod_memcg_lruvec_state */
                    } /* __mod_lruvec_state */
                  } /* __mod_lruvec_page_state */
                  _raw_spin_unlock_irq() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irq */
                } /* __filemap_add_folio */
                folio_add_lru() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* folio_add_lru */
              } /* filemap_add_folio */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int() {
                folio_create_empty_buffers() {
                  folio_alloc_buffers() {
                    alloc_buffer_head() {
                      kmem_cache_alloc() {
                        should_failslab();
                        __get_obj_cgroup_from_memcg();
                        obj_cgroup_charge();
                        mod_objcg_state();
                      } /* kmem_cache_alloc */
                      preempt_count_add();
                      preempt_count_sub();
                    } /* alloc_buffer_head */
                  } /* folio_alloc_buffers */
                  _raw_spin_lock() {
                    preempt_count_add();
                  } /* _raw_spin_lock */
                  _raw_spin_unlock() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock */
                } /* folio_create_empty_buffers */
                ext4_da_get_block_prep() {
                  ext4_es_lookup_extent() {
                    _raw_read_lock() {
                      preempt_count_add();
                    } /* _raw_read_lock */
                    _raw_read_unlock() {
                      preempt_count_sub();
                    } /* _raw_read_unlock */
                  } /* ext4_es_lookup_extent */
                  down_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* down_read */
                  ext4_da_reserve_space() {
                    __dquot_alloc_space() {
                      _raw_spin_lock() {
                        preempt_count_add();
                      } /* _raw_spin_lock */
                      ext4_get_reserved_space();
                      _raw_spin_unlock() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock */
                    } /* __dquot_alloc_space */
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    ext4_claim_free_clusters() {
                      ext4_has_free_clusters();
                    } /* ext4_claim_free_clusters */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                  } /* ext4_da_reserve_space */
                  ext4_es_insert_delayed_block() {
                    _raw_write_lock() {
                      preempt_count_add();
                    } /* _raw_write_lock */
                    __es_remove_extent() {
                      __es_tree_search.isra.0();
                    } /* __es_remove_extent */
                    __es_insert_extent() {
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                    } /* __es_insert_extent */
                    _raw_write_unlock() {
                      preempt_count_sub();
                    } /* _raw_write_unlock */
                  } /* ext4_es_insert_delayed_block */
                  up_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* up_read */
                } /* ext4_da_get_block_prep */
                clean_bdev_aliases() {
                  filemap_get_folios();
                } /* clean_bdev_aliases */
              } /* __block_write_begin_int */
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty() {
                  folio_memcg_lock();
                  __folio_mark_dirty() {
                    _raw_spin_lock_irqsave() {
                      preempt_count_add();
                    } /* _raw_spin_lock_irqsave */
                    inode_to_bdi();
                    __mod_lruvec_page_state() {
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                    } /* __mod_lruvec_page_state */
                    __mod_zone_page_state();
                    __mod_node_page_state();
                    mem_cgroup_track_foreign_dirty_slowpath() {
                      __msecs_to_jiffies();
                    } /* mem_cgroup_track_foreign_dirty_slowpath */
                    _raw_spin_unlock_irqrestore() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock_irqrestore */
                  } /* __folio_mark_dirty */
                  folio_memcg_unlock();
                  __mark_inode_dirty();
                } /* mark_buffer_dirty */
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
        } /* generic_perform_write */
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
      } /* ext4_buffered_write_iter */
    } /* ext4_file_write_iter */
    __fsnotify_parent() {
      dget_parent();
      take_dentry_name_snapshot() {
        _raw_spin_lock() {
          preempt_count_add();
        } /* _raw_spin_lock */
        _raw_spin_unlock() {
          preempt_count_sub();
        } /* _raw_spin_unlock */
      } /* take_dentry_name_snapshot */
      fsnotify() {
        __srcu_read_lock();
        fsnotify_compare_groups();
        fsnotify_handle_inode_event.isra.0() {
          inotify_handle_inode_event() {
            __kmalloc() {
              kmalloc_slab();
              __kmem_cache_alloc_node() {
                should_failslab();
                __get_obj_cgroup_from_memcg();
                obj_cgroup_charge();
                mod_objcg_state();
              } /* __kmem_cache_alloc_node */
            } /* __kmalloc */
            fsnotify_insert_event() {
              _raw_spin_lock() {
                preempt_count_add();
              } /* _raw_spin_lock */
              _raw_spin_unlock() {
                preempt_count_sub();
              } /* _raw_spin_unlock */
              __wake_up() {
                __wake_up_common_lock() {
                  _raw_spin_lock_irqsave() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irqsave */
                  __wake_up_common() {
                    pollwake() {
                      default_wake_function() {
                        try_to_wake_up() {
                          preempt_count_add();
                          _raw_spin_lock_irqsave() {
                            preempt_count_add();
                          } /* _raw_spin_lock_irqsave */
                          select_task_rq_fair() {
                            available_idle_cpu() {
                              hv_vcpu_is_preempted();
                            } /* available_idle_cpu */
                          } /* select_task_rq_fair */
                          ttwu_queue_wakelist() {
                            __smp_call_single_queue() {
                              call_function_single_prep_ipi();
                              native_send_call_func_single_ipi() {
                                hv_send_ipi() {
                                  __send_ipi_one() {
                                    hv_isolation_type_tdx();
                                    hv_isolation_type_snp();
                                  } /* __send_ipi_one */
                                } /* hv_send_ipi */
                              } /* native_send_call_func_single_ipi */
                            } /* __smp_call_single_queue */
                          } /* ttwu_queue_wakelist */
                          _raw_spin_unlock_irqrestore() {
                            preempt_count_sub();
                          } /* _raw_spin_unlock_irqrestore */
                          preempt_count_sub();
                        } /* try_to_wake_up */
                      } /* default_wake_function */
                    } /* pollwake */
                  } /* __wake_up_common */
                  _raw_spin_unlock_irqrestore() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irqrestore */
                } /* __wake_up_common_lock */
              } /* __wake_up */
              kill_fasync();
            } /* fsnotify_insert_event */
          } /* inotify_handle_inode_event */
        } /* fsnotify_handle_inode_event.isra.0 */
        __srcu_read_unlock();
      } /* fsnotify */
      release_dentry_name_snapshot();
      dput();
    } /* __fsnotify_parent */
    preempt_count_add();
    preempt_count_sub();
  } /* vfs_write */
} /* ksys_write */
ksys_write() {
  __fdget_pos() {
    __fget_light();
  } /* __fdget_pos */
  vfs_write() {
    rw_verify_area() {
      security_file_permission() {
        selinux_file_permission() {
          inode_security();
          avc_policy_seqno();
        } /* selinux_file_permission */
      } /* security_file_permission */
    } /* rw_verify_area */
    preempt_count_add();
    preempt_count_sub();
    __get_task_ioprio();
    ext4_file_write_iter() {
      ext4_buffered_write_iter() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        ext4_generic_write_checks() {
          generic_write_checks() {
            generic_write_check_limits();
          } /* generic_write_checks */
        } /* ext4_generic_write_checks */
        file_modified() {
          __file_remove_privs();
          inode_needs_update_time() {
            ktime_get_coarse_real_ts64();
            timestamp_truncate();
          } /* inode_needs_update_time */
        } /* file_modified */
        generic_perform_write() {
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              folio_wait_stable() {
                folio_mapping();
              } /* folio_wait_stable */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int();
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty();
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              inode_to_bdi();
              filemap_alloc_folio() {
                folio_alloc() {
                  alloc_pages() {
                    policy_nodemask();
                    policy_node();
                    __alloc_pages() {
                      should_fail_alloc_page();
                      get_page_from_freelist() {
                        node_dirty_ok() {
                          node_page_state();
                          node_page_state();
                          node_page_state();
                          node_page_state();
                        } /* node_dirty_ok */
                        preempt_count_add();
                        _raw_spin_trylock() {
                          preempt_count_add();
                        } /* _raw_spin_trylock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        preempt_count_sub();
                      } /* get_page_from_freelist */
                    } /* __alloc_pages */
                  } /* alloc_pages */
                } /* folio_alloc */
              } /* filemap_alloc_folio */
              filemap_add_folio() {
                __filemap_add_folio() {
                  __mem_cgroup_charge() {
                    get_mem_cgroup_from_mm();
                    charge_memcg() {
                      try_charge_memcg();
                      mem_cgroup_charge_statistics() {
                        __count_memcg_events() {
                          cgroup_rstat_updated();
                        } /* __count_memcg_events */
                      } /* mem_cgroup_charge_statistics */
                      memcg_check_events();
                    } /* charge_memcg */
                  } /* __mem_cgroup_charge */
                  _raw_spin_lock_irq() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irq */
                  workingset_update_node();
                  __mod_lruvec_page_state() {
                    __mod_lruvec_state() {
                      __mod_node_page_state();
                      __mod_memcg_lruvec_state() {
                        cgroup_rstat_updated();
                      } /* __mod_memcg_lruvec_state */
                    } /* __mod_lruvec_state */
                  } /* __mod_lruvec_page_state */
                  _raw_spin_unlock_irq() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irq */
                } /* __filemap_add_folio */
                folio_add_lru() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* folio_add_lru */
              } /* filemap_add_folio */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int() {
                folio_create_empty_buffers() {
                  folio_alloc_buffers() {
                    alloc_buffer_head() {
                      kmem_cache_alloc() {
                        should_failslab();
                        __get_obj_cgroup_from_memcg();
                        obj_cgroup_charge() {
                          try_charge_memcg();
                          memcg_account_kmem() {
                            __mod_memcg_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_state */
                            page_counter_charge() {
                              propagate_protected_usage();
                              propagate_protected_usage();
                              propagate_protected_usage();
                              propagate_protected_usage();
                            } /* page_counter_charge */
                          } /* memcg_account_kmem */
                          refill_obj_stock();
                        } /* obj_cgroup_charge */
                        mod_objcg_state();
                      } /* kmem_cache_alloc */
                      preempt_count_add();
                      preempt_count_sub();
                    } /* alloc_buffer_head */
                  } /* folio_alloc_buffers */
                  _raw_spin_lock() {
                    preempt_count_add();
                  } /* _raw_spin_lock */
                  _raw_spin_unlock() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock */
                } /* folio_create_empty_buffers */
                ext4_da_get_block_prep() {
                  ext4_es_lookup_extent() {
                    _raw_read_lock() {
                      preempt_count_add();
                    } /* _raw_read_lock */
                    _raw_read_unlock() {
                      preempt_count_sub();
                    } /* _raw_read_unlock */
                  } /* ext4_es_lookup_extent */
                  down_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* down_read */
                  ext4_da_reserve_space() {
                    __dquot_alloc_space() {
                      _raw_spin_lock() {
                        preempt_count_add();
                      } /* _raw_spin_lock */
                      ext4_get_reserved_space();
                      _raw_spin_unlock() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock */
                    } /* __dquot_alloc_space */
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    ext4_claim_free_clusters() {
                      ext4_has_free_clusters();
                    } /* ext4_claim_free_clusters */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                  } /* ext4_da_reserve_space */
                  ext4_es_insert_delayed_block() {
                    _raw_write_lock() {
                      preempt_count_add();
                    } /* _raw_write_lock */
                    __es_remove_extent() {
                      __es_tree_search.isra.0();
                    } /* __es_remove_extent */
                    __es_insert_extent() {
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                    } /* __es_insert_extent */
                    _raw_write_unlock() {
                      preempt_count_sub();
                    } /* _raw_write_unlock */
                  } /* ext4_es_insert_delayed_block */
                  up_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* up_read */
                } /* ext4_da_get_block_prep */
                clean_bdev_aliases() {
                  filemap_get_folios();
                } /* clean_bdev_aliases */
              } /* __block_write_begin_int */
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty() {
                  folio_memcg_lock();
                  __folio_mark_dirty() {
                    _raw_spin_lock_irqsave() {
                      preempt_count_add();
                    } /* _raw_spin_lock_irqsave */
                    inode_to_bdi();
                    __mod_lruvec_page_state() {
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                    } /* __mod_lruvec_page_state */
                    __mod_zone_page_state();
                    __mod_node_page_state();
                    mem_cgroup_track_foreign_dirty_slowpath() {
                      __msecs_to_jiffies();
                    } /* mem_cgroup_track_foreign_dirty_slowpath */
                    _raw_spin_unlock_irqrestore() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock_irqrestore */
                  } /* __folio_mark_dirty */
                  folio_memcg_unlock();
                  __mark_inode_dirty();
                } /* mark_buffer_dirty */
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              inode_to_bdi();
              filemap_alloc_folio() {
                folio_alloc() {
                  alloc_pages() {
                    policy_nodemask();
                    policy_node();
                    __alloc_pages() {
                      should_fail_alloc_page();
                      get_page_from_freelist() {
                        node_dirty_ok() {
                          node_page_state();
                          node_page_state();
                          node_page_state();
                          node_page_state();
                        } /* node_dirty_ok */
                        preempt_count_add();
                        _raw_spin_trylock() {
                          preempt_count_add();
                        } /* _raw_spin_trylock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        preempt_count_sub();
                      } /* get_page_from_freelist */
                    } /* __alloc_pages */
                  } /* alloc_pages */
                } /* folio_alloc */
              } /* filemap_alloc_folio */
              filemap_add_folio() {
                __filemap_add_folio() {
                  __mem_cgroup_charge() {
                    get_mem_cgroup_from_mm();
                    charge_memcg() {
                      try_charge_memcg();
                      mem_cgroup_charge_statistics() {
                        __count_memcg_events() {
                          cgroup_rstat_updated();
                        } /* __count_memcg_events */
                      } /* mem_cgroup_charge_statistics */
                      memcg_check_events();
                    } /* charge_memcg */
                  } /* __mem_cgroup_charge */
                  _raw_spin_lock_irq() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irq */
                  workingset_update_node();
                  __mod_lruvec_page_state() {
                    __mod_lruvec_state() {
                      __mod_node_page_state();
                      __mod_memcg_lruvec_state() {
                        cgroup_rstat_updated();
                      } /* __mod_memcg_lruvec_state */
                    } /* __mod_lruvec_state */
                  } /* __mod_lruvec_page_state */
                  _raw_spin_unlock_irq() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irq */
                } /* __filemap_add_folio */
                folio_add_lru() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* folio_add_lru */
              } /* filemap_add_folio */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int() {
                folio_create_empty_buffers() {
                  folio_alloc_buffers() {
                    alloc_buffer_head() {
                      kmem_cache_alloc() {
                        should_failslab();
                        __get_obj_cgroup_from_memcg();
                        obj_cgroup_charge();
                        mod_objcg_state();
                      } /* kmem_cache_alloc */
                      preempt_count_add();
                      preempt_count_sub();
                    } /* alloc_buffer_head */
                  } /* folio_alloc_buffers */
                  _raw_spin_lock() {
                    preempt_count_add();
                  } /* _raw_spin_lock */
                  _raw_spin_unlock() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock */
                } /* folio_create_empty_buffers */
                ext4_da_get_block_prep() {
                  ext4_es_lookup_extent() {
                    _raw_read_lock() {
                      preempt_count_add();
                    } /* _raw_read_lock */
                    _raw_read_unlock() {
                      preempt_count_sub();
                    } /* _raw_read_unlock */
                  } /* ext4_es_lookup_extent */
                  down_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* down_read */
                  ext4_da_reserve_space() {
                    __dquot_alloc_space() {
                      _raw_spin_lock() {
                        preempt_count_add();
                      } /* _raw_spin_lock */
                      ext4_get_reserved_space();
                      _raw_spin_unlock() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock */
                    } /* __dquot_alloc_space */
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    ext4_claim_free_clusters() {
                      ext4_has_free_clusters();
                    } /* ext4_claim_free_clusters */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                  } /* ext4_da_reserve_space */
                  ext4_es_insert_delayed_block() {
                    _raw_write_lock() {
                      preempt_count_add();
                    } /* _raw_write_lock */
                    __es_remove_extent() {
                      __es_tree_search.isra.0();
                    } /* __es_remove_extent */
                    __es_insert_extent() {
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                    } /* __es_insert_extent */
                    _raw_write_unlock() {
                      preempt_count_sub();
                    } /* _raw_write_unlock */
                  } /* ext4_es_insert_delayed_block */
                  up_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* up_read */
                } /* ext4_da_get_block_prep */
                clean_bdev_aliases() {
                  filemap_get_folios();
                } /* clean_bdev_aliases */
              } /* __block_write_begin_int */
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty() {
                  folio_memcg_lock();
                  __folio_mark_dirty() {
                    _raw_spin_lock_irqsave() {
                      preempt_count_add();
                    } /* _raw_spin_lock_irqsave */
                    inode_to_bdi();
                    __mod_lruvec_page_state() {
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                    } /* __mod_lruvec_page_state */
                    __mod_zone_page_state();
                    __mod_node_page_state();
                    mem_cgroup_track_foreign_dirty_slowpath() {
                      __msecs_to_jiffies();
                    } /* mem_cgroup_track_foreign_dirty_slowpath */
                    _raw_spin_unlock_irqrestore() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock_irqrestore */
                  } /* __folio_mark_dirty */
                  folio_memcg_unlock();
                  __mark_inode_dirty();
                } /* mark_buffer_dirty */
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
        } /* generic_perform_write */
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
      } /* ext4_buffered_write_iter */
    } /* ext4_file_write_iter */
    __fsnotify_parent() {
      dget_parent();
      take_dentry_name_snapshot() {
        _raw_spin_lock() {
          preempt_count_add();
        } /* _raw_spin_lock */
        _raw_spin_unlock() {
          preempt_count_sub();
        } /* _raw_spin_unlock */
      } /* take_dentry_name_snapshot */
      fsnotify() {
        __srcu_read_lock();
        fsnotify_compare_groups();
        fsnotify_handle_inode_event.isra.0() {
          inotify_handle_inode_event() {
            __kmalloc() {
              kmalloc_slab();
              __kmem_cache_alloc_node() {
                should_failslab();
                __get_obj_cgroup_from_memcg();
                obj_cgroup_charge();
                mod_objcg_state();
              } /* __kmem_cache_alloc_node */
            } /* __kmalloc */
            fsnotify_insert_event() {
              _raw_spin_lock() {
                preempt_count_add();
              } /* _raw_spin_lock */
              _raw_spin_unlock() {
                preempt_count_sub();
              } /* _raw_spin_unlock */
              __wake_up() {
                __wake_up_common_lock() {
                  _raw_spin_lock_irqsave() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irqsave */
                  __wake_up_common() {
                    pollwake() {
                      default_wake_function() {
                        try_to_wake_up() {
                          preempt_count_add();
                          _raw_spin_lock_irqsave() {
                            preempt_count_add();
                          } /* _raw_spin_lock_irqsave */
                          select_task_rq_fair() {
                            available_idle_cpu() {
                              hv_vcpu_is_preempted();
                            } /* available_idle_cpu */
                          } /* select_task_rq_fair */
                          ttwu_queue_wakelist() {
                            __smp_call_single_queue() {
                              call_function_single_prep_ipi();
                              native_send_call_func_single_ipi() {
                                hv_send_ipi() {
                                  __send_ipi_one() {
                                    hv_isolation_type_tdx();
                                    hv_isolation_type_snp();
                                  } /* __send_ipi_one */
                                } /* hv_send_ipi */
                              } /* native_send_call_func_single_ipi */
                            } /* __smp_call_single_queue */
                          } /* ttwu_queue_wakelist */
                          _raw_spin_unlock_irqrestore() {
                            preempt_count_sub();
                          } /* _raw_spin_unlock_irqrestore */
                          preempt_count_sub();
                        } /* try_to_wake_up */
                      } /* default_wake_function */
                    } /* pollwake */
                  } /* __wake_up_common */
                  _raw_spin_unlock_irqrestore() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irqrestore */
                } /* __wake_up_common_lock */
              } /* __wake_up */
              kill_fasync();
            } /* fsnotify_insert_event */
          } /* inotify_handle_inode_event */
        } /* fsnotify_handle_inode_event.isra.0 */
        __srcu_read_unlock();
      } /* fsnotify */
      release_dentry_name_snapshot();
      dput();
    } /* __fsnotify_parent */
    preempt_count_add();
    preempt_count_sub();
  } /* vfs_write */
} /* ksys_write */
ksys_write() {
  __fdget_pos() {
    __fget_light();
  } /* __fdget_pos */
  vfs_write() {
    rw_verify_area() {
      security_file_permission() {
        selinux_file_permission() {
          inode_security();
          avc_policy_seqno();
        } /* selinux_file_permission */
      } /* security_file_permission */
    } /* rw_verify_area */
    preempt_count_add();
    preempt_count_sub();
    __get_task_ioprio();
    ext4_file_write_iter() {
      ext4_buffered_write_iter() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        ext4_generic_write_checks() {
          generic_write_checks() {
            generic_write_check_limits();
          } /* generic_write_checks */
        } /* ext4_generic_write_checks */
        file_modified() {
          __file_remove_privs();
          inode_needs_update_time() {
            ktime_get_coarse_real_ts64();
            timestamp_truncate();
          } /* inode_needs_update_time */
        } /* file_modified */
        generic_perform_write() {
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              folio_wait_stable() {
                folio_mapping();
              } /* folio_wait_stable */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int();
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty();
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              inode_to_bdi();
              filemap_alloc_folio() {
                folio_alloc() {
                  alloc_pages() {
                    policy_nodemask();
                    policy_node();
                    __alloc_pages() {
                      should_fail_alloc_page();
                      get_page_from_freelist() {
                        node_dirty_ok() {
                          node_page_state();
                          node_page_state();
                          node_page_state();
                          node_page_state();
                        } /* node_dirty_ok */
                        preempt_count_add();
                        _raw_spin_trylock() {
                          preempt_count_add();
                        } /* _raw_spin_trylock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        preempt_count_sub();
                      } /* get_page_from_freelist */
                    } /* __alloc_pages */
                  } /* alloc_pages */
                } /* folio_alloc */
              } /* filemap_alloc_folio */
              filemap_add_folio() {
                __filemap_add_folio() {
                  __mem_cgroup_charge() {
                    get_mem_cgroup_from_mm();
                    charge_memcg() {
                      try_charge_memcg();
                      mem_cgroup_charge_statistics() {
                        __count_memcg_events() {
                          cgroup_rstat_updated();
                        } /* __count_memcg_events */
                      } /* mem_cgroup_charge_statistics */
                      memcg_check_events();
                    } /* charge_memcg */
                  } /* __mem_cgroup_charge */
                  _raw_spin_lock_irq() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irq */
                  workingset_update_node();
                  __mod_lruvec_page_state() {
                    __mod_lruvec_state() {
                      __mod_node_page_state();
                      __mod_memcg_lruvec_state() {
                        cgroup_rstat_updated();
                      } /* __mod_memcg_lruvec_state */
                    } /* __mod_lruvec_state */
                  } /* __mod_lruvec_page_state */
                  _raw_spin_unlock_irq() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irq */
                } /* __filemap_add_folio */
                folio_add_lru() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* folio_add_lru */
              } /* filemap_add_folio */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int() {
                folio_create_empty_buffers() {
                  folio_alloc_buffers() {
                    alloc_buffer_head() {
                      kmem_cache_alloc() {
                        should_failslab();
                        __get_obj_cgroup_from_memcg();
                        obj_cgroup_charge();
                        mod_objcg_state();
                      } /* kmem_cache_alloc */
                      preempt_count_add();
                      preempt_count_sub();
                    } /* alloc_buffer_head */
                  } /* folio_alloc_buffers */
                  _raw_spin_lock() {
                    preempt_count_add();
                  } /* _raw_spin_lock */
                  _raw_spin_unlock() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock */
                } /* folio_create_empty_buffers */
                ext4_da_get_block_prep() {
                  ext4_es_lookup_extent() {
                    _raw_read_lock() {
                      preempt_count_add();
                    } /* _raw_read_lock */
                    _raw_read_unlock() {
                      preempt_count_sub();
                    } /* _raw_read_unlock */
                  } /* ext4_es_lookup_extent */
                  down_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* down_read */
                  ext4_da_reserve_space() {
                    __dquot_alloc_space() {
                      _raw_spin_lock() {
                        preempt_count_add();
                      } /* _raw_spin_lock */
                      ext4_get_reserved_space();
                      _raw_spin_unlock() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock */
                    } /* __dquot_alloc_space */
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    ext4_claim_free_clusters() {
                      ext4_has_free_clusters();
                    } /* ext4_claim_free_clusters */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                  } /* ext4_da_reserve_space */
                  ext4_es_insert_delayed_block() {
                    _raw_write_lock() {
                      preempt_count_add();
                    } /* _raw_write_lock */
                    __es_remove_extent() {
                      __es_tree_search.isra.0();
                    } /* __es_remove_extent */
                    __es_insert_extent() {
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                    } /* __es_insert_extent */
                    _raw_write_unlock() {
                      preempt_count_sub();
                    } /* _raw_write_unlock */
                  } /* ext4_es_insert_delayed_block */
                  up_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* up_read */
                } /* ext4_da_get_block_prep */
                clean_bdev_aliases() {
                  filemap_get_folios();
                } /* clean_bdev_aliases */
              } /* __block_write_begin_int */
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty() {
                  folio_memcg_lock();
                  __folio_mark_dirty() {
                    _raw_spin_lock_irqsave() {
                      preempt_count_add();
                    } /* _raw_spin_lock_irqsave */
                    inode_to_bdi();
                    __mod_lruvec_page_state() {
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                    } /* __mod_lruvec_page_state */
                    __mod_zone_page_state();
                    __mod_node_page_state();
                    mem_cgroup_track_foreign_dirty_slowpath() {
                      __msecs_to_jiffies();
                    } /* mem_cgroup_track_foreign_dirty_slowpath */
                    _raw_spin_unlock_irqrestore() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock_irqrestore */
                  } /* __folio_mark_dirty */
                  folio_memcg_unlock();
                  __mark_inode_dirty();
                } /* mark_buffer_dirty */
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              inode_to_bdi();
              filemap_alloc_folio() {
                folio_alloc() {
                  alloc_pages() {
                    policy_nodemask();
                    policy_node();
                    __alloc_pages() {
                      should_fail_alloc_page();
                      get_page_from_freelist() {
                        node_dirty_ok() {
                          node_page_state();
                          node_page_state();
                          node_page_state();
                          node_page_state();
                        } /* node_dirty_ok */
                        preempt_count_add();
                        _raw_spin_trylock() {
                          preempt_count_add();
                        } /* _raw_spin_trylock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        preempt_count_sub();
                      } /* get_page_from_freelist */
                    } /* __alloc_pages */
                  } /* alloc_pages */
                } /* folio_alloc */
              } /* filemap_alloc_folio */
              filemap_add_folio() {
                __filemap_add_folio() {
                  __mem_cgroup_charge() {
                    get_mem_cgroup_from_mm();
                    charge_memcg() {
                      try_charge_memcg();
                      mem_cgroup_charge_statistics() {
                        __count_memcg_events() {
                          cgroup_rstat_updated();
                        } /* __count_memcg_events */
                      } /* mem_cgroup_charge_statistics */
                      memcg_check_events();
                    } /* charge_memcg */
                  } /* __mem_cgroup_charge */
                  _raw_spin_lock_irq() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irq */
                  workingset_update_node();
                  __mod_lruvec_page_state() {
                    __mod_lruvec_state() {
                      __mod_node_page_state();
                      __mod_memcg_lruvec_state() {
                        cgroup_rstat_updated();
                      } /* __mod_memcg_lruvec_state */
                    } /* __mod_lruvec_state */
                  } /* __mod_lruvec_page_state */
                  _raw_spin_unlock_irq() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irq */
                } /* __filemap_add_folio */
                folio_add_lru() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* folio_add_lru */
              } /* filemap_add_folio */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int() {
                folio_create_empty_buffers() {
                  folio_alloc_buffers() {
                    alloc_buffer_head() {
                      kmem_cache_alloc() {
                        should_failslab();
                        __get_obj_cgroup_from_memcg();
                        obj_cgroup_charge();
                        mod_objcg_state();
                      } /* kmem_cache_alloc */
                      preempt_count_add();
                      preempt_count_sub();
                    } /* alloc_buffer_head */
                  } /* folio_alloc_buffers */
                  _raw_spin_lock() {
                    preempt_count_add();
                  } /* _raw_spin_lock */
                  _raw_spin_unlock() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock */
                } /* folio_create_empty_buffers */
                ext4_da_get_block_prep() {
                  ext4_es_lookup_extent() {
                    _raw_read_lock() {
                      preempt_count_add();
                    } /* _raw_read_lock */
                    _raw_read_unlock() {
                      preempt_count_sub();
                    } /* _raw_read_unlock */
                  } /* ext4_es_lookup_extent */
                  down_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* down_read */
                  ext4_da_reserve_space() {
                    __dquot_alloc_space() {
                      _raw_spin_lock() {
                        preempt_count_add();
                      } /* _raw_spin_lock */
                      ext4_get_reserved_space();
                      _raw_spin_unlock() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock */
                    } /* __dquot_alloc_space */
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    ext4_claim_free_clusters() {
                      ext4_has_free_clusters();
                    } /* ext4_claim_free_clusters */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                  } /* ext4_da_reserve_space */
                  ext4_es_insert_delayed_block() {
                    _raw_write_lock() {
                      preempt_count_add();
                    } /* _raw_write_lock */
                    __es_remove_extent() {
                      __es_tree_search.isra.0();
                    } /* __es_remove_extent */
                    __es_insert_extent() {
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                      ext4_es_can_be_merged.isra.0();
                    } /* __es_insert_extent */
                    _raw_write_unlock() {
                      preempt_count_sub();
                    } /* _raw_write_unlock */
                  } /* ext4_es_insert_delayed_block */
                  up_read() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* up_read */
                } /* ext4_da_get_block_prep */
                clean_bdev_aliases() {
                  filemap_get_folios();
                } /* clean_bdev_aliases */
              } /* __block_write_begin_int */
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty() {
                  folio_memcg_lock();
                  __folio_mark_dirty() {
                    _raw_spin_lock_irqsave() {
                      preempt_count_add();
                    } /* _raw_spin_lock_irqsave */
                    inode_to_bdi();
                    __mod_lruvec_page_state() {
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                    } /* __mod_lruvec_page_state */
                    __mod_zone_page_state();
                    __mod_node_page_state();
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                    mem_cgroup_track_foreign_dirty_slowpath() {
                      __msecs_to_jiffies();
                    } /* mem_cgroup_track_foreign_dirty_slowpath */
                    _raw_spin_unlock_irqrestore() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock_irqrestore */
                  } /* __folio_mark_dirty */
                  folio_memcg_unlock();
                  __mark_inode_dirty();
                } /* mark_buffer_dirty */
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
        } /* generic_perform_write */
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
      } /* ext4_buffered_write_iter */
    } /* ext4_file_write_iter */
    __fsnotify_parent() {
      dget_parent();
      take_dentry_name_snapshot() {
        _raw_spin_lock() {
          preempt_count_add();
        } /* _raw_spin_lock */
        _raw_spin_unlock() {
          preempt_count_sub();
        } /* _raw_spin_unlock */
      } /* take_dentry_name_snapshot */
      fsnotify() {
        __srcu_read_lock();
        fsnotify_compare_groups();
        fsnotify_handle_inode_event.isra.0() {
          inotify_handle_inode_event() {
            __kmalloc() {
              kmalloc_slab();
              __kmem_cache_alloc_node() {
                should_failslab();
                __get_obj_cgroup_from_memcg();
                obj_cgroup_charge();
                mod_objcg_state();
              } /* __kmem_cache_alloc_node */
            } /* __kmalloc */
            fsnotify_insert_event() {
              _raw_spin_lock() {
                preempt_count_add();
              } /* _raw_spin_lock */
              _raw_spin_unlock() {
                preempt_count_sub();
              } /* _raw_spin_unlock */
              __wake_up() {
                __wake_up_common_lock() {
                  _raw_spin_lock_irqsave() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irqsave */
                  __wake_up_common() {
                    pollwake() {
                      default_wake_function() {
                        try_to_wake_up() {
                          preempt_count_add();
                          _raw_spin_lock_irqsave() {
                            preempt_count_add();
                          } /* _raw_spin_lock_irqsave */
                          select_task_rq_fair() {
                            available_idle_cpu() {
                              hv_vcpu_is_preempted();
                            } /* available_idle_cpu */
                          } /* select_task_rq_fair */
                          ttwu_queue_wakelist() {
                            __smp_call_single_queue() {
                              call_function_single_prep_ipi();
                              native_send_call_func_single_ipi() {
                                hv_send_ipi() {
                                  __send_ipi_one() {
                                    hv_isolation_type_tdx();
                                    hv_isolation_type_snp();
                                  } /* __send_ipi_one */
                                } /* hv_send_ipi */
                              } /* native_send_call_func_single_ipi */
                            } /* __smp_call_single_queue */
                          } /* ttwu_queue_wakelist */
                          _raw_spin_unlock_irqrestore() {
                            preempt_count_sub();
                          } /* _raw_spin_unlock_irqrestore */
                          preempt_count_sub();
                        } /* try_to_wake_up */
                      } /* default_wake_function */
                    } /* pollwake */
                  } /* __wake_up_common */
                  _raw_spin_unlock_irqrestore() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irqrestore */
                } /* __wake_up_common_lock */
              } /* __wake_up */
              kill_fasync();
            } /* fsnotify_insert_event */
          } /* inotify_handle_inode_event */
        } /* fsnotify_handle_inode_event.isra.0 */
        __srcu_read_unlock();
      } /* fsnotify */
      release_dentry_name_snapshot();
      dput();
    } /* __fsnotify_parent */
    preempt_count_add();
    preempt_count_sub();
  } /* vfs_write */
} /* ksys_write */
ksys_write() {
  __fdget_pos() {
    __fget_light();
  } /* __fdget_pos */
  vfs_write() {
    rw_verify_area() {
      security_file_permission() {
        selinux_file_permission() {
          inode_security();
          avc_policy_seqno();
        } /* selinux_file_permission */
      } /* security_file_permission */
    } /* rw_verify_area */
    preempt_count_add();
    preempt_count_sub();
    __get_task_ioprio();
    ext4_file_write_iter() {
      ext4_buffered_write_iter() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        ext4_generic_write_checks() {
          generic_write_checks() {
            generic_write_check_limits();
          } /* generic_write_checks */
        } /* ext4_generic_write_checks */
        file_modified() {
          __file_remove_privs();
          inode_needs_update_time() {
            ktime_get_coarse_real_ts64();
            timestamp_truncate();
          } /* inode_needs_update_time */
        } /* file_modified */
        generic_perform_write() {
          fault_in_readable();
          ext4_da_write_begin() {
            ext4_nonda_switch();
            __filemap_get_folio() {
              filemap_get_entry();
              folio_wait_stable() {
                folio_mapping();
              } /* folio_wait_stable */
            } /* __filemap_get_folio */
            __block_write_begin() {
              __block_write_begin_int();
            } /* __block_write_begin */
          } /* ext4_da_write_begin */
          preempt_count_add();
          preempt_count_sub();
          ext4_da_write_end() {
            block_write_end() {
              __block_commit_write() {
                mark_buffer_dirty();
              } /* __block_commit_write */
            } /* block_write_end */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
          } /* ext4_da_write_end */
          __cond_resched();
          balance_dirty_pages_ratelimited() {
            balance_dirty_pages_ratelimited_flags() {
              inode_to_bdi();
              inode_to_bdi();
              preempt_count_add();
              preempt_count_sub();
            } /* balance_dirty_pages_ratelimited_flags */
          } /* balance_dirty_pages_ratelimited */
        } /* generic_perform_write */
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
      } /* ext4_buffered_write_iter */
    } /* ext4_file_write_iter */
    __fsnotify_parent() {
      dget_parent();
      take_dentry_name_snapshot() {
        _raw_spin_lock() {
          preempt_count_add();
        } /* _raw_spin_lock */
        _raw_spin_unlock() {
          preempt_count_sub();
        } /* _raw_spin_unlock */
      } /* take_dentry_name_snapshot */
      fsnotify() {
        __srcu_read_lock();
        fsnotify_compare_groups();
        fsnotify_handle_inode_event.isra.0() {
          inotify_handle_inode_event() {
            __kmalloc() {
              kmalloc_slab();
              __kmem_cache_alloc_node() {
                should_failslab();
                __get_obj_cgroup_from_memcg();
                obj_cgroup_charge();
                mod_objcg_state();
              } /* __kmem_cache_alloc_node */
            } /* __kmalloc */
            fsnotify_insert_event() {
              _raw_spin_lock() {
                preempt_count_add();
              } /* _raw_spin_lock */
              _raw_spin_unlock() {
                preempt_count_sub();
              } /* _raw_spin_unlock */
              __wake_up() {
                __wake_up_common_lock() {
                  _raw_spin_lock_irqsave() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irqsave */
                  __wake_up_common();
                  _raw_spin_unlock_irqrestore() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irqrestore */
                } /* __wake_up_common_lock */
              } /* __wake_up */
              kill_fasync();
            } /* fsnotify_insert_event */
          } /* inotify_handle_inode_event */
        } /* fsnotify_handle_inode_event.isra.0 */
        __srcu_read_unlock();
      } /* fsnotify */
      release_dentry_name_snapshot();
      dput();
    } /* __fsnotify_parent */
    preempt_count_add();
    preempt_count_sub();
  } /* vfs_write */
} /* ksys_write */
__do_sys_get_pid_in_crt();
__do_sys_get_pid_in_crt();