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
      ext4_inode_attach_jinode();
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
                            available_idle_cpu();
                            available_idle_cpu() {
                              hv_vcpu_is_preempted();
                            } /* available_idle_cpu */
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
ksys_sync() {
  wakeup_flusher_threads() {
    wb_start_writeback() {
      wb_wakeup() {
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        mod_delayed_work_on() {
          try_to_grab_pending() {
            timer_delete() {
              lock_timer_base() {
                _raw_spin_lock_irqsave() {
                  preempt_count_add();
                } /* _raw_spin_lock_irqsave */
              } /* lock_timer_base */
              detach_if_pending();
              _raw_spin_unlock_irqrestore() {
                preempt_count_sub();
              } /* _raw_spin_unlock_irqrestore */
            } /* timer_delete */
          } /* try_to_grab_pending */
          __queue_delayed_work() {
            __queue_work() {
              _raw_spin_lock() {
                preempt_count_add();
              } /* _raw_spin_lock */
              insert_work();
              kick_pool() {
                wake_up_process() {
                  try_to_wake_up() {
                    preempt_count_add();
                    _raw_spin_lock_irqsave() {
                      preempt_count_add();
                    } /* _raw_spin_lock_irqsave */
                    select_task_rq_fair() {
                      available_idle_cpu();
                      available_idle_cpu() {
                        hv_vcpu_is_preempted();
                      } /* available_idle_cpu */
                      available_idle_cpu() {
                        hv_vcpu_is_preempted();
                      } /* available_idle_cpu */
                    } /* select_task_rq_fair */
                    kthread_is_per_cpu();
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
                } /* wake_up_process */
              } /* kick_pool */
              _raw_spin_unlock() {
                preempt_count_sub();
              } /* _raw_spin_unlock */
            } /* __queue_work */
          } /* __queue_delayed_work */
        } /* mod_delayed_work_on */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
      } /* wb_wakeup */
    } /* wb_start_writeback */
  } /* wakeup_flusher_threads */
  iterate_supers() {
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        bdi_split_work_to_wbs();
        wb_wait_for_completion();
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
        mutex_lock();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        _raw_spin_lock() {
          preempt_count_add();
        } /* _raw_spin_lock */
        __iget();
        _raw_spin_unlock() {
          preempt_count_sub();
        } /* _raw_spin_unlock */
        filemap_fdatawait_keep_errors() {
          __filemap_fdatawait_range() {
            filemap_get_folios_tag();
            folio_wait_writeback() {
              folio_mapping();
              folio_wait_bit() {
                _raw_spin_lock_irq() {
                  preempt_count_add();
                } /* _raw_spin_lock_irq */
                _raw_spin_unlock_irq() {
                  preempt_count_sub();
                } /* _raw_spin_unlock_irq */
                io_schedule() {
                  schedule() {
                    preempt_count_add();
                    rcu_note_context_switch();
                    preempt_count_add();
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    preempt_count_sub();
                    update_rq_clock();
                    dequeue_task_fair() {
                      dequeue_entity() {
                        update_curr() {
                          update_min_vruntime();
                          cpuacct_charge();
                          __cgroup_account_cputime() {
                            preempt_count_add();
                            cgroup_rstat_updated();
                            preempt_count_sub();
                          } /* __cgroup_account_cputime */
                        } /* update_curr */
                        __update_load_avg_se();
                        _raw_spin_lock() {
                          preempt_count_add();
                        } /* _raw_spin_lock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        __update_load_avg_cfs_rq();
                        avg_vruntime();
                        update_cfs_group();
                        update_min_vruntime();
                      } /* dequeue_entity */
                      hrtick_update();
                    } /* dequeue_task_fair */
                    pick_next_task_fair() {
                      newidle_balance() {
                        __msecs_to_jiffies();
                      } /* newidle_balance */
                    } /* pick_next_task_fair */
                    put_prev_task_fair() {
                      put_prev_entity() {
                        check_cfs_rq_runtime();
                      } /* put_prev_entity */
                    } /* put_prev_task_fair */
                    pick_next_task_idle();
                    psi_task_switch() {
                      psi_flags_change();
                      psi_group_change() {
                        record_times();
                      } /* psi_group_change */
                      psi_group_change() {
                        record_times();
                      } /* psi_group_change */
                      psi_group_change() {
                        record_times();
                      } /* psi_group_change */
                      psi_group_change() {
                        record_times();
                      } /* psi_group_change */
                    } /* psi_task_switch */
                    __traceiter_sched_switch() {
                      _raw_spin_lock_irqsave() {
                        preempt_count_add();
                      } /* _raw_spin_lock_irqsave */
                      _raw_spin_unlock_irqrestore() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock_irqrestore */
                    } /* __traceiter_sched_switch */
                    finish_task_switch.isra.0() {
                      _raw_spin_unlock() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock */
                    } /* finish_task_switch.isra.0 */
                    preempt_count_sub();
                  } /* schedule */
                } /* io_schedule */
                finish_wait();
              } /* folio_wait_bit */
            } /* folio_wait_writeback */
            folio_wait_writeback();
            folio_wait_writeback();
            __folio_batch_release() {
              lru_add_drain() {
                preempt_count_add();
                lru_add_drain_cpu() {
                  folio_batch_move_lru() {
                    folio_lruvec_lock_irqsave() {
                      _raw_spin_lock_irqsave() {
                        preempt_count_add();
                      } /* _raw_spin_lock_irqsave */
                    } /* folio_lruvec_lock_irqsave */
                    lru_add_fn() {
                      folio_mapping();
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                      __mod_zone_page_state();
                      mem_cgroup_update_lru_size();
                    } /* lru_add_fn */
                    lru_add_fn() {
                      folio_mapping();
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                      __mod_zone_page_state();
                      mem_cgroup_update_lru_size();
                    } /* lru_add_fn */
                    lru_add_fn() {
                      folio_mapping();
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                      __mod_zone_page_state();
                      mem_cgroup_update_lru_size();
                    } /* lru_add_fn */
                    lru_add_fn() {
                      folio_mapping();
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                      __mod_zone_page_state();
                      mem_cgroup_update_lru_size();
                    } /* lru_add_fn */
                    lru_add_fn() {
                      folio_mapping();
                      __mod_lruvec_state() {
                        __mod_node_page_state();
                        __mod_memcg_lruvec_state() {
                          cgroup_rstat_updated();
                        } /* __mod_memcg_lruvec_state */
                      } /* __mod_lruvec_state */
                      __mod_zone_page_state();
                      mem_cgroup_update_lru_size();
                    } /* lru_add_fn */
                    _raw_spin_unlock_irqrestore() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock_irqrestore */
                    release_pages() {
                      __mem_cgroup_uncharge_list();
                      free_unref_page_list();
                    } /* release_pages */
                  } /* folio_batch_move_lru */
                } /* lru_add_drain_cpu */
                preempt_count_sub();
                mlock_drain_local() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* mlock_drain_local */
              } /* lru_add_drain */
              release_pages() {
                __mem_cgroup_uncharge_list();
                free_unref_page_list();
              } /* release_pages */
            } /* __folio_batch_release */
            __cond_resched();
          } /* __filemap_fdatawait_range */
        } /* filemap_fdatawait_keep_errors */
        __cond_resched();
        iput();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        mutex_unlock();
      } /* sync_inodes_sb */
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        bdi_split_work_to_wbs();
        wb_wait_for_completion();
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
        mutex_lock();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        mutex_unlock();
      } /* sync_inodes_sb */
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        bdi_split_work_to_wbs();
        wb_wait_for_completion();
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
        mutex_lock();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        mutex_unlock();
      } /* sync_inodes_sb */
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        bdi_split_work_to_wbs();
        wb_wait_for_completion();
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
        mutex_lock();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        mutex_unlock();
      } /* sync_inodes_sb */
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        bdi_split_work_to_wbs();
        wb_wait_for_completion();
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
        mutex_lock();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        mutex_unlock();
      } /* sync_inodes_sb */
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        bdi_split_work_to_wbs();
        wb_wait_for_completion();
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
        mutex_lock();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        mutex_unlock();
      } /* sync_inodes_sb */
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb();
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        bdi_split_work_to_wbs();
        wb_wait_for_completion();
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
        mutex_lock();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        mutex_unlock();
      } /* sync_inodes_sb */
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        bdi_split_work_to_wbs();
        wb_wait_for_completion();
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
        mutex_lock();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        mutex_unlock();
      } /* sync_inodes_sb */
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_inodes_one_sb() {
      sync_inodes_sb() {
        down_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* down_write */
        bdi_split_work_to_wbs();
        wb_wait_for_completion();
        up_write() {
          preempt_count_add();
          preempt_count_sub();
        } /* up_write */
        mutex_lock();
        _raw_spin_lock_irq() {
          preempt_count_add();
        } /* _raw_spin_lock_irq */
        _raw_spin_unlock_irq() {
          preempt_count_sub();
        } /* _raw_spin_unlock_irq */
        mutex_unlock();
      } /* sync_inodes_sb */
    } /* sync_inodes_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
  } /* iterate_supers */
  iterate_supers() {
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb() {
      ext4_sync_fs() {
        __flush_workqueue() {
          __init_swait_queue_head();
          mutex_lock();
          flush_workqueue_prep_pwqs() {
            _raw_spin_lock_irq() {
              preempt_count_add();
            } /* _raw_spin_lock_irq */
            _raw_spin_unlock_irq() {
              preempt_count_sub();
            } /* _raw_spin_unlock_irq */
            complete() {
              _raw_spin_lock_irqsave() {
                preempt_count_add();
              } /* _raw_spin_lock_irqsave */
              _raw_spin_unlock_irqrestore() {
                preempt_count_sub();
              } /* _raw_spin_unlock_irqrestore */
            } /* complete */
          } /* flush_workqueue_prep_pwqs */
          mutex_unlock();
        } /* __flush_workqueue */
        dquot_writeback_dquots();
        _raw_read_lock() {
          preempt_count_add();
        } /* _raw_read_lock */
        _raw_read_unlock() {
          preempt_count_sub();
        } /* _raw_read_unlock */
        jbd2_journal_start_commit() {
          _raw_write_lock() {
            preempt_count_add();
          } /* _raw_write_lock */
          __jbd2_log_start_commit() {
            __wake_up() {
              __wake_up_common_lock() {
                _raw_spin_lock_irqsave() {
                  preempt_count_add();
                } /* _raw_spin_lock_irqsave */
                __wake_up_common() {
                  autoremove_wake_function() {
                    default_wake_function() {
                      try_to_wake_up() {
                        preempt_count_add();
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        select_task_rq_fair() {
                          available_idle_cpu();
                          available_idle_cpu() {
                            hv_vcpu_is_preempted();
                          } /* available_idle_cpu */
                          available_idle_cpu() {
                            hv_vcpu_is_preempted();
                          } /* available_idle_cpu */
                        } /* select_task_rq_fair */
                        kthread_is_per_cpu();
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
                  } /* autoremove_wake_function */
                } /* __wake_up_common */
                _raw_spin_unlock_irqrestore() {
                  preempt_count_sub();
                } /* _raw_spin_unlock_irqrestore */
              } /* __wake_up_common_lock */
            } /* __wake_up */
          } /* __jbd2_log_start_commit */
          _raw_write_unlock() {
            preempt_count_sub();
          } /* _raw_write_unlock */
        } /* jbd2_journal_start_commit */
      } /* ext4_sync_fs */
    } /* sync_fs_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb() {
      fuse_sync_fs();
    } /* sync_fs_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb() {
      fuse_sync_fs();
    } /* sync_fs_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
  } /* iterate_supers */
  iterate_supers() {
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb() {
      ext4_sync_fs() {
        __flush_workqueue() {
          __init_swait_queue_head();
          mutex_lock();
          flush_workqueue_prep_pwqs() {
            _raw_spin_lock_irq() {
              preempt_count_add();
            } /* _raw_spin_lock_irq */
            _raw_spin_unlock_irq() {
              preempt_count_sub();
            } /* _raw_spin_unlock_irq */
            complete() {
              _raw_spin_lock_irqsave() {
                preempt_count_add();
              } /* _raw_spin_lock_irqsave */
              _raw_spin_unlock_irqrestore() {
                preempt_count_sub();
              } /* _raw_spin_unlock_irqrestore */
            } /* complete */
          } /* flush_workqueue_prep_pwqs */
          mutex_unlock();
        } /* __flush_workqueue */
        dquot_writeback_dquots();
        _raw_read_lock() {
          preempt_count_add();
        } /* _raw_read_lock */
        _raw_read_unlock() {
          preempt_count_sub();
        } /* _raw_read_unlock */
        jbd2_trans_will_send_data_barrier() {
          _raw_read_lock() {
            preempt_count_add();
          } /* _raw_read_lock */
          _raw_read_unlock() {
            preempt_count_sub();
          } /* _raw_read_unlock */
        } /* jbd2_trans_will_send_data_barrier */
        jbd2_journal_start_commit() {
          _raw_write_lock() {
            preempt_count_add();
          } /* _raw_write_lock */
          _raw_write_unlock() {
            preempt_count_sub();
          } /* _raw_write_unlock */
        } /* jbd2_journal_start_commit */
        jbd2_log_wait_commit() {
          _raw_read_lock() {
            preempt_count_add();
          } /* _raw_read_lock */
          _raw_read_unlock() {
            preempt_count_sub();
          } /* _raw_read_unlock */
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
          init_wait_entry();
          prepare_to_wait_event() {
            _raw_spin_lock_irqsave() {
              preempt_count_add();
            } /* _raw_spin_lock_irqsave */
            _raw_spin_unlock_irqrestore() {
              preempt_count_sub();
            } /* _raw_spin_unlock_irqrestore */
          } /* prepare_to_wait_event */
          schedule() {
            preempt_count_add();
            rcu_note_context_switch();
            preempt_count_add();
            _raw_spin_lock() {
              preempt_count_add();
            } /* _raw_spin_lock */
            preempt_count_sub();
            update_rq_clock();
            dequeue_task_fair() {
              dequeue_entity() {
                update_curr() {
                  update_min_vruntime();
                  cpuacct_charge();
                  __cgroup_account_cputime() {
                    preempt_count_add();
                    cgroup_rstat_updated();
                    preempt_count_sub();
                  } /* __cgroup_account_cputime */
                } /* update_curr */
                __update_load_avg_se();
                __update_load_avg_cfs_rq();
                avg_vruntime();
                update_cfs_group();
                update_min_vruntime();
              } /* dequeue_entity */
              hrtick_update();
            } /* dequeue_task_fair */
            pick_next_task_fair() {
              newidle_balance() {
                __msecs_to_jiffies();
              } /* newidle_balance */
            } /* pick_next_task_fair */
            put_prev_task_fair() {
              put_prev_entity() {
                check_cfs_rq_runtime();
              } /* put_prev_entity */
            } /* put_prev_task_fair */
            pick_next_task_idle();
            psi_task_switch() {
              psi_flags_change();
              psi_group_change() {
                record_times();
              } /* psi_group_change */
              psi_group_change() {
                record_times();
              } /* psi_group_change */
              psi_group_change() {
                record_times();
              } /* psi_group_change */
              psi_group_change() {
                record_times();
              } /* psi_group_change */
            } /* psi_task_switch */
            __traceiter_sched_switch() {
              _raw_spin_lock_irqsave() {
                preempt_count_add();
              } /* _raw_spin_lock_irqsave */
              _raw_spin_unlock_irqrestore() {
                preempt_count_sub();
              } /* _raw_spin_unlock_irqrestore */
            } /* __traceiter_sched_switch */
            finish_task_switch.isra.0() {
              _raw_spin_unlock() {
                preempt_count_sub();
              } /* _raw_spin_unlock */
            } /* finish_task_switch.isra.0 */
            preempt_count_sub();
          } /* schedule */
          prepare_to_wait_event() {
            _raw_spin_lock_irqsave() {
              preempt_count_add();
            } /* _raw_spin_lock_irqsave */
            _raw_spin_unlock_irqrestore() {
              preempt_count_sub();
            } /* _raw_spin_unlock_irqrestore */
          } /* prepare_to_wait_event */
          finish_wait() {
            _raw_spin_lock_irqsave() {
              preempt_count_add();
            } /* _raw_spin_lock_irqsave */
            _raw_spin_unlock_irqrestore() {
              preempt_count_sub();
            } /* _raw_spin_unlock_irqrestore */
          } /* finish_wait */
          _raw_read_lock() {
            preempt_count_add();
          } /* _raw_read_lock */
          _raw_read_unlock() {
            preempt_count_sub();
          } /* _raw_read_unlock */
        } /* jbd2_log_wait_commit */
      } /* ext4_sync_fs */
    } /* sync_fs_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb() {
      fuse_sync_fs() {
        kmalloc_trace() {
          __kmem_cache_alloc_node() {
            should_failslab();
          } /* __kmem_cache_alloc_node */
        } /* kmalloc_trace */
        __init_waitqueue_head();
        _raw_spin_lock() {
          preempt_count_add();
        } /* _raw_spin_lock */
        _raw_spin_unlock() {
          preempt_count_sub();
        } /* _raw_spin_unlock */
        kfree() {
          __kmem_cache_free();
        } /* kfree */
        fuse_simple_request() {
          fuse_get_req() {
            fuse_request_alloc() {
              kmem_cache_alloc() {
                should_failslab();
              } /* kmem_cache_alloc */
              __init_waitqueue_head();
            } /* fuse_request_alloc */
            from_kuid() {
              map_id_up();
            } /* from_kuid */
            from_kgid() {
              map_id_up();
            } /* from_kgid */
            pid_nr_ns();
          } /* fuse_get_req */
          fuse_args_to_req();
          _raw_spin_lock() {
            preempt_count_add();
          } /* _raw_spin_lock */
          queue_request_and_unlock() {
            virtio_fs_wake_pending_and_unlock() {
              _raw_spin_unlock() {
                preempt_count_sub();
              } /* _raw_spin_unlock */
              virtio_fs_enqueue_req() {
                fuse_len_args();
                fuse_len_args();
                __kmalloc() {
                  kmalloc_slab();
                  __kmem_cache_alloc_node() {
                    should_failslab();
                  } /* __kmem_cache_alloc_node */
                } /* __kmalloc */
                __virt_addr_valid() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* __virt_addr_valid */
                sg_init_fuse_args.isra.0() {
                  fuse_len_args();
                  __virt_addr_valid() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* __virt_addr_valid */
                } /* sg_init_fuse_args.isra.0 */
                __virt_addr_valid() {
                  preempt_count_add();
                  preempt_count_sub();
                } /* __virt_addr_valid */
                sg_init_fuse_args.isra.0() {
                  fuse_len_args();
                } /* sg_init_fuse_args.isra.0 */
                _raw_spin_lock() {
                  preempt_count_add();
                } /* _raw_spin_lock */
                virtqueue_add_sgs() {
                  __kmalloc() {
                    kmalloc_slab();
                    __kmem_cache_alloc_node() {
                      should_failslab();
                    } /* __kmem_cache_alloc_node */
                  } /* __kmalloc */
                  vring_map_one_sg();
                  vring_map_one_sg();
                  vring_map_one_sg();
                } /* virtqueue_add_sgs */
                _raw_spin_lock() {
                  preempt_count_add();
                } /* _raw_spin_lock */
                _raw_spin_unlock() {
                  preempt_count_sub();
                } /* _raw_spin_unlock */
                virtqueue_kick_prepare();
                _raw_spin_unlock() {
                  preempt_count_sub();
                } /* _raw_spin_unlock */
                virtqueue_notify() {
                  vp_notify();
                } /* virtqueue_notify */
              } /* virtio_fs_enqueue_req */
            } /* virtio_fs_wake_pending_and_unlock */
          } /* queue_request_and_unlock */
          request_wait_answer() {
            init_wait_entry();
            prepare_to_wait_event() {
              _raw_spin_lock_irqsave() {
                preempt_count_add();
              } /* _raw_spin_lock_irqsave */
              _raw_spin_unlock_irqrestore() {
                preempt_count_sub();
              } /* _raw_spin_unlock_irqrestore */
            } /* prepare_to_wait_event */
            schedule() {
              preempt_count_add();
              rcu_note_context_switch();
              preempt_count_add();
              _raw_spin_lock() {
                preempt_count_add();
              } /* _raw_spin_lock */
              preempt_count_sub();
              update_rq_clock();
              dequeue_task_fair() {
                dequeue_entity() {
                  update_curr() {
                    update_min_vruntime();
                    cpuacct_charge();
                    __cgroup_account_cputime() {
                      preempt_count_add();
                      cgroup_rstat_updated();
                      preempt_count_sub();
                    } /* __cgroup_account_cputime */
                  } /* update_curr */
                  __update_load_avg_se();
                  __update_load_avg_cfs_rq();
                  avg_vruntime();
                  update_cfs_group();
                  update_min_vruntime();
                } /* dequeue_entity */
                hrtick_update();
              } /* dequeue_task_fair */
              pick_next_task_fair() {
                newidle_balance() {
                  __msecs_to_jiffies();
                } /* newidle_balance */
              } /* pick_next_task_fair */
              put_prev_task_fair() {
                put_prev_entity() {
                  check_cfs_rq_runtime();
                } /* put_prev_entity */
              } /* put_prev_task_fair */
              pick_next_task_idle();
              psi_task_switch() {
                psi_flags_change();
                psi_group_change() {
                  record_times();
                } /* psi_group_change */
                psi_group_change() {
                  record_times();
                } /* psi_group_change */
                psi_group_change() {
                  record_times();
                } /* psi_group_change */
                psi_group_change() {
                  record_times();
                } /* psi_group_change */
              } /* psi_task_switch */
              __traceiter_sched_switch() {
                _raw_spin_lock_irqsave() {
                  preempt_count_add();
                } /* _raw_spin_lock_irqsave */
                _raw_spin_unlock_irqrestore() {
                  preempt_count_sub();
                } /* _raw_spin_unlock_irqrestore */
              } /* __traceiter_sched_switch */
              finish_task_switch.isra.0() {
                _raw_spin_unlock() {
                  preempt_count_sub();
                } /* _raw_spin_unlock */
              } /* finish_task_switch.isra.0 */
              preempt_count_sub();
            } /* schedule */
            prepare_to_wait_event() {
              _raw_spin_lock_irqsave() {
                preempt_count_add();
              } /* _raw_spin_lock_irqsave */
              _raw_spin_unlock_irqrestore() {
                preempt_count_sub();
              } /* _raw_spin_unlock_irqrestore */
            } /* prepare_to_wait_event */
            finish_wait() {
              _raw_spin_lock_irqsave() {
                preempt_count_add();
              } /* _raw_spin_lock_irqsave */
              _raw_spin_unlock_irqrestore() {
                preempt_count_sub();
              } /* _raw_spin_unlock_irqrestore */
            } /* finish_wait */
          } /* request_wait_answer */
          fuse_put_request() {
            fuse_drop_waiting();
            kmem_cache_free();
          } /* fuse_put_request */
        } /* fuse_simple_request */
      } /* fuse_sync_fs */
    } /* sync_fs_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb();
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    super_lock() {
      down_read() {
        preempt_count_add();
        preempt_count_sub();
      } /* down_read */
    } /* super_lock */
    sync_fs_one_sb() {
      fuse_sync_fs();
    } /* sync_fs_one_sb */
    up_read() {
      preempt_count_add();
      preempt_count_sub();
    } /* up_read */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
  } /* iterate_supers */
  sync_bdevs() {
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    __iget();
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    iput();
    mutex_lock();
    filemap_fdatawrite() {
      __filemap_fdatawrite_range() {
        filemap_fdatawrite_wbc() {
          inode_to_bdi() {
            I_BDEV();
          } /* inode_to_bdi */
          _raw_spin_lock() {
            preempt_count_add();
          } /* _raw_spin_lock */
          wbc_attach_and_unlock_inode() {
            inode_to_bdi() {
              I_BDEV();
            } /* inode_to_bdi */
            _raw_spin_unlock() {
              preempt_count_sub();
            } /* _raw_spin_unlock */
          } /* wbc_attach_and_unlock_inode */
          do_writepages() {
            inode_to_bdi() {
              I_BDEV();
            } /* inode_to_bdi */
            blk_start_plug();
            write_cache_pages() {
              tag_pages_for_writeback() {
                _raw_spin_lock_irq() {
                  preempt_count_add();
                } /* _raw_spin_lock_irq */
                _raw_spin_unlock_irq() {
                  preempt_count_sub();
                } /* _raw_spin_unlock_irq */
              } /* tag_pages_for_writeback */
              filemap_get_folios_tag();
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        sb_mark_inode_writeback() {
                          _raw_spin_lock_irqsave() {
                            preempt_count_add();
                          } /* _raw_spin_lock_irqsave */
                          _raw_spin_unlock_irqrestore() {
                            preempt_count_sub();
                          } /* _raw_spin_unlock_irqrestore */
                        } /* sb_mark_inode_writeback */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                                __slab_alloc.constprop.0() {
                                  preempt_count_add();
                                  ___slab_alloc();
                                  preempt_count_sub();
                                } /* __slab_alloc.constprop.0 */
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge();
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0() {
                                        bio_attempt_back_merge() {
                                          ll_back_merge_fn() {
                                            blk_integrity_merge_bio();
                                          } /* ll_back_merge_fn */
                                          blk_account_io_merge_bio() {
                                            preempt_count_add();
                                            preempt_count_sub();
                                          } /* blk_account_io_merge_bio */
                                        } /* bio_attempt_back_merge */
                                      } /* blk_attempt_bio_merge.part.0 */
                                    } /* blk_attempt_plug_merge */
                                  } /* blk_mq_attempt_bio_merge */
                                  blk_queue_exit();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated() {
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                      } /* cgroup_rstat_updated */
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              folio_clear_dirty_for_io() {
                folio_mapping();
                inode_to_bdi() {
                  I_BDEV();
                } /* inode_to_bdi */
                folio_mkclean();
                __mod_lruvec_page_state() {
                  __mod_lruvec_state() {
                    __mod_node_page_state();
                    __mod_memcg_lruvec_state() {
                      cgroup_rstat_updated();
                    } /* __mod_memcg_lruvec_state */
                  } /* __mod_lruvec_state */
                } /* __mod_lruvec_page_state */
                mod_zone_page_state();
              } /* folio_clear_dirty_for_io */
              inode_to_bdi() {
                I_BDEV();
              } /* inode_to_bdi */
              writepage_cb() {
                blkdev_writepage() {
                  block_write_full_page() {
                    __block_write_full_folio() {
                      mark_buffer_async_write_endio();
                      __folio_start_writeback() {
                        folio_mapping();
                        folio_memcg_lock();
                        inode_to_bdi() {
                          I_BDEV();
                        } /* inode_to_bdi */
                        _raw_spin_lock_irqsave() {
                          preempt_count_add();
                        } /* _raw_spin_lock_irqsave */
                        _raw_spin_lock() {
                          preempt_count_add();
                        } /* _raw_spin_lock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                        __mod_lruvec_page_state() {
                          __mod_lruvec_state() {
                            __mod_node_page_state();
                            __mod_memcg_lruvec_state() {
                              cgroup_rstat_updated();
                            } /* __mod_memcg_lruvec_state */
                          } /* __mod_lruvec_state */
                        } /* __mod_lruvec_page_state */
                        mod_zone_page_state();
                        folio_memcg_unlock();
                      } /* __folio_start_writeback */
                      submit_bh_wbc() {
                        bio_alloc_bioset() {
                          mempool_alloc() {
                            mempool_alloc_slab() {
                              kmem_cache_alloc() {
                                should_failslab();
                              } /* kmem_cache_alloc */
                            } /* mempool_alloc_slab */
                          } /* mempool_alloc */
                          bio_associate_blkg() {
                            kthread_blkcg();
                            bio_associate_blkg_from_css();
                          } /* bio_associate_blkg */
                        } /* bio_alloc_bioset */
                        __bio_add_page();
                        guard_bio_eod();
                        wbc_account_cgroup_owner();
                        submit_bio() {
                          submit_bio_noacct() {
                            should_fail_bio.constprop.0();
                            submit_bio_noacct_nocheck() {
                              blk_cgroup_bio_start();
                              ktime_get();
                              __submit_bio() {
                                blk_mq_submit_bio() {
                                  __get_task_ioprio();
                                  bio_integrity_prep();
                                  blk_mq_attempt_bio_merge() {
                                    blk_attempt_plug_merge() {
                                      blk_rq_merge_ok() {
                                        blk_integrity_merge_bio();
                                      } /* blk_rq_merge_ok */
                                      blk_attempt_bio_merge.part.0();
                                    } /* blk_attempt_plug_merge */
                                    blk_mq_sched_bio_merge();
                                  } /* blk_mq_attempt_bio_merge */
                                  __blk_mq_alloc_requests() {
                                    __blk_mq_tag_busy();
                                    blk_mq_get_tag() {
                                      __blk_mq_get_tag();
                                    } /* blk_mq_get_tag */
                                    blk_mq_rq_ctx_init.isra.0();
                                    ktime_get();
                                  } /* __blk_mq_alloc_requests */
                                  preempt_count_add();
                                  update_io_ticks();
                                  preempt_count_sub();
                                  blk_add_rq_to_plug();
                                } /* blk_mq_submit_bio */
                              } /* __submit_bio */
                            } /* submit_bio_noacct_nocheck */
                          } /* submit_bio_noacct */
                        } /* submit_bio */
                      } /* submit_bh_wbc */
                      folio_unlock();
                    } /* __block_write_full_folio */
                  } /* block_write_full_page */
                } /* blkdev_writepage */
              } /* writepage_cb */
              __folio_batch_release() {
                lru_add_drain() {
                  preempt_count_add();
                  lru_add_drain_cpu();
                  preempt_count_sub();
                  mlock_drain_local() {
                    preempt_count_add();
                    preempt_count_sub();
                  } /* mlock_drain_local */
                } /* lru_add_drain */
                release_pages() {
                  __mem_cgroup_uncharge_list();
                  free_unref_page_list();
                } /* release_pages */
              } /* __folio_batch_release */
              __cond_resched();
            } /* write_cache_pages */
            blk_finish_plug() {
              __blk_flush_plug() {
                blk_mq_flush_plug_list() {
                  blk_mq_flush_plug_list.part.0() {
                    blk_mq_plug_issue_direct() {
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                  vmbus_setevent();
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                      blk_mq_request_issue_directly() {
                        blk_mq_get_budget_and_tag() {
                          scsi_mq_get_budget();
                          scsi_mq_set_rq_budget_token();
                          __blk_mq_get_driver_tag();
                        } /* blk_mq_get_budget_and_tag */
                        __blk_mq_issue_directly() {
                          scsi_queue_rq() {
                            scsi_init_command() {
                              scsi_initialize_rq();
                              init_timer_key();
                            } /* scsi_init_command */
                            sd_init_command() {
                              scsi_alloc_sgtables() {
                                __blk_rq_map_sg();
                              } /* scsi_alloc_sgtables */
                            } /* sd_init_command */
                            blk_mq_start_request() {
                              blk_add_timer();
                            } /* blk_mq_start_request */
                            scsi_log_send();
                            storvsc_queuecommand() {
                              scsi_dma_map() {
                                dma_map_sg_attrs() {
                                  __dma_map_sg_attrs() {
                                    dma_direct_map_sg();
                                  } /* __dma_map_sg_attrs */
                                } /* dma_map_sg_attrs */
                              } /* scsi_dma_map */
                              preempt_count_add();
                              vmbus_sendpacket_mpb_desc() {
                                hv_ringbuffer_write() {
                                  _raw_spin_lock_irqsave() {
                                    preempt_count_add();
                                  } /* _raw_spin_lock_irqsave */
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  hv_copyto_ringbuffer.isra.0();
                                  storvsc_next_request_id() {
                                    blk_mq_unique_tag();
                                  } /* storvsc_next_request_id */
                                  hv_copyto_ringbuffer.isra.0();
                                  _raw_spin_unlock_irqrestore() {
                                    preempt_count_sub();
                                  } /* _raw_spin_unlock_irqrestore */
                                } /* hv_ringbuffer_write */
                              } /* vmbus_sendpacket_mpb_desc */
                              preempt_count_sub();
                            } /* storvsc_queuecommand */
                          } /* scsi_queue_rq */
                        } /* __blk_mq_issue_directly */
                      } /* blk_mq_request_issue_directly */
                    } /* blk_mq_plug_issue_direct */
                  } /* blk_mq_flush_plug_list.part.0 */
                } /* blk_mq_flush_plug_list */
              } /* __blk_flush_plug */
            } /* blk_finish_plug */
          } /* do_writepages */
          wbc_detach_inode();
        } /* filemap_fdatawrite_wbc */
      } /* __filemap_fdatawrite_range */
    } /* filemap_fdatawrite */
    mutex_unlock();
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    __iget();
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    iput();
    mutex_lock();
    filemap_fdatawrite() {
      __filemap_fdatawrite_range() {
        filemap_fdatawrite_wbc() {
          inode_to_bdi() {
            I_BDEV();
          } /* inode_to_bdi */
        } /* filemap_fdatawrite_wbc */
      } /* __filemap_fdatawrite_range */
    } /* filemap_fdatawrite */
    mutex_unlock();
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    iput();
  } /* sync_bdevs */
  sync_bdevs() {
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    __iget();
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    iput();
    mutex_lock();
    filemap_fdatawait_keep_errors() {
      __filemap_fdatawait_range() {
        filemap_get_folios_tag();
        folio_wait_writeback() {
          folio_mapping();
          folio_wait_bit() {
            _raw_spin_lock_irq() {
              preempt_count_add();
            } /* _raw_spin_lock_irq */
            _raw_spin_unlock_irq() {
              preempt_count_sub();
            } /* _raw_spin_unlock_irq */
            io_schedule() {
              schedule() {
                preempt_count_add();
                rcu_note_context_switch();
                preempt_count_add();
                _raw_spin_lock() {
                  preempt_count_add();
                } /* _raw_spin_lock */
                preempt_count_sub();
                update_rq_clock();
                dequeue_task_fair() {
                  dequeue_entity() {
                    update_curr() {
                      update_min_vruntime();
                      cpuacct_charge();
                      __cgroup_account_cputime() {
                        preempt_count_add();
                        cgroup_rstat_updated();
                        preempt_count_sub();
                      } /* __cgroup_account_cputime */
                    } /* update_curr */
                    __update_load_avg_se();
                    __update_load_avg_cfs_rq();
                    avg_vruntime();
                    update_cfs_group();
                    update_min_vruntime();
                  } /* dequeue_entity */
                  hrtick_update();
                } /* dequeue_task_fair */
                pick_next_task_fair() {
                  newidle_balance() {
                    raw_spin_rq_unlock() {
                      _raw_spin_unlock() {
                        preempt_count_sub();
                      } /* _raw_spin_unlock */
                    } /* raw_spin_rq_unlock */
                    update_blocked_averages() {
                      raw_spin_rq_lock_nested() {
                        preempt_count_add();
                        _raw_spin_lock() {
                          preempt_count_add();
                        } /* _raw_spin_lock */
                        preempt_count_sub();
                      } /* raw_spin_rq_lock_nested */
                      update_rq_clock();
                      update_rt_rq_load_avg();
                      update_dl_rq_load_avg();
                      __update_load_avg_cfs_rq();
                      raw_spin_rq_unlock() {
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                      } /* raw_spin_rq_unlock */
                    } /* update_blocked_averages */
                    __msecs_to_jiffies();
                    load_balance() {
                      find_busiest_group() {
                        update_group_capacity() {
                          __msecs_to_jiffies();
                        } /* update_group_capacity */
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                        cpu_util.constprop.0();
                        idle_cpu();
                      } /* find_busiest_group */
                    } /* load_balance */
                    raw_spin_rq_lock_nested() {
                      preempt_count_add();
                      _raw_spin_lock() {
                        preempt_count_add();
                      } /* _raw_spin_lock */
                      preempt_count_sub();
                    } /* raw_spin_rq_lock_nested */
                  } /* newidle_balance */
                } /* pick_next_task_fair */
                put_prev_task_fair() {
                  put_prev_entity() {
                    check_cfs_rq_runtime();
                  } /* put_prev_entity */
                } /* put_prev_task_fair */
                pick_next_task_idle();
                psi_task_switch() {
                  psi_flags_change();
                  psi_group_change() {
                    record_times();
                  } /* psi_group_change */
                  psi_group_change() {
                    record_times();
                  } /* psi_group_change */
                  psi_group_change() {
                    record_times();
                  } /* psi_group_change */
                  psi_group_change() {
                    record_times();
                  } /* psi_group_change */
                } /* psi_task_switch */
                __traceiter_sched_switch() {
                  _raw_spin_lock_irqsave() {
                    preempt_count_add();
                  } /* _raw_spin_lock_irqsave */
                  _raw_spin_unlock_irqrestore() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock_irqrestore */
                } /* __traceiter_sched_switch */
                finish_task_switch.isra.0() {
                  _raw_spin_unlock() {
                    preempt_count_sub();
                  } /* _raw_spin_unlock */
                } /* finish_task_switch.isra.0 */
                preempt_count_sub();
              } /* schedule */
            } /* io_schedule */
            finish_wait();
          } /* folio_wait_bit */
        } /* folio_wait_writeback */
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        folio_wait_writeback();
        __folio_batch_release() {
          lru_add_drain() {
            preempt_count_add();
            lru_add_drain_cpu();
            preempt_count_sub();
            mlock_drain_local() {
              preempt_count_add();
              preempt_count_sub();
            } /* mlock_drain_local */
          } /* lru_add_drain */
          release_pages() {
            __mem_cgroup_uncharge_list();
            free_unref_page_list();
          } /* release_pages */
        } /* __folio_batch_release */
        __cond_resched();
      } /* __filemap_fdatawait_range */
    } /* filemap_fdatawait_keep_errors */
    mutex_unlock();
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    __iget();
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    iput();
    mutex_lock();
    filemap_fdatawait_keep_errors() {
      __filemap_fdatawait_range() {
        filemap_get_folios_tag();
      } /* __filemap_fdatawait_range */
    } /* filemap_fdatawait_keep_errors */
    mutex_unlock();
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_lock() {
      preempt_count_add();
    } /* _raw_spin_lock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    _raw_spin_unlock() {
      preempt_count_sub();
    } /* _raw_spin_unlock */
    iput();
  } /* sync_bdevs */
} /* ksys_sync */
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
          __mnt_want_write_file();
          generic_update_time() {
            inode_update_timestamps() {
              ktime_get_coarse_real_ts64();
              timestamp_truncate();
              inode_maybe_inc_iversion();
            } /* inode_update_timestamps */
            __mark_inode_dirty() {
              ext4_dirty_inode() {
                __ext4_journal_start_sb() {
                  ext4_journal_check_start();
                  jbd2__journal_start() {
                    kmem_cache_alloc() {
                      should_failslab();
                    } /* kmem_cache_alloc */
                    start_this_handle() {
                      kmem_cache_alloc() {
                        should_failslab();
                      } /* kmem_cache_alloc */
                      _raw_read_lock() {
                        preempt_count_add();
                      } /* _raw_read_lock */
                      _raw_read_unlock() {
                        preempt_count_sub();
                      } /* _raw_read_unlock */
                      _raw_write_lock() {
                        preempt_count_add();
                      } /* _raw_write_lock */
                      ktime_get();
                      journal_tag_bytes();
                      round_jiffies_up();
                      add_timer() {
                        lock_timer_base() {
                          _raw_spin_lock_irqsave() {
                            preempt_count_add();
                          } /* _raw_spin_lock_irqsave */
                        } /* lock_timer_base */
                        detach_if_pending();
                        get_nohz_timer_target();
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        _raw_spin_lock() {
                          preempt_count_add();
                        } /* _raw_spin_lock */
                        calc_wheel_index();
                        enqueue_timer();
                        _raw_spin_unlock_irqrestore() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock_irqrestore */
                      } /* add_timer */
                      _raw_write_unlock() {
                        preempt_count_sub();
                      } /* _raw_write_unlock */
                      _raw_read_lock() {
                        preempt_count_add();
                      } /* _raw_read_lock */
                      add_transaction_credits();
                      _raw_read_unlock() {
                        preempt_count_sub();
                      } /* _raw_read_unlock */
                    } /* start_this_handle */
                  } /* jbd2__journal_start */
                } /* __ext4_journal_start_sb */
                __ext4_mark_inode_dirty() {
                  ext4_reserve_inode_write() {
                    ext4_get_inode_loc() {
                      __ext4_get_inode_loc() {
                        ext4_get_group_desc();
                        ext4_inode_table();
                        __getblk_gfp() {
                          __find_get_block() {
                            housekeeping_test_cpu();
                            housekeeping_test_cpu();
                            folio_mark_accessed();
                          } /* __find_get_block */
                        } /* __getblk_gfp */
                      } /* __ext4_get_inode_loc */
                    } /* ext4_get_inode_loc */
                    __ext4_journal_get_write_access() {
                      jbd2_journal_get_write_access() {
                        jbd2_write_access_granted();
                        jbd2_journal_add_journal_head() {
                          preempt_count_add();
                          preempt_count_sub();
                        } /* jbd2_journal_add_journal_head */
                        do_get_write_access() {
                          _raw_spin_lock() {
                            preempt_count_add();
                          } /* _raw_spin_lock */
                          _raw_spin_lock() {
                            preempt_count_add();
                          } /* _raw_spin_lock */
                          __jbd2_journal_file_buffer() {
                            jbd2_journal_grab_journal_head() {
                              preempt_count_add();
                              preempt_count_sub();
                            } /* jbd2_journal_grab_journal_head */
                          } /* __jbd2_journal_file_buffer */
                          _raw_spin_unlock() {
                            preempt_count_sub();
                          } /* _raw_spin_unlock */
                          unlock_buffer() {
                            wake_up_bit();
                          } /* unlock_buffer */
                          _raw_spin_unlock() {
                            preempt_count_sub();
                          } /* _raw_spin_unlock */
                          jbd2_journal_cancel_revoke();
                        } /* do_get_write_access */
                        jbd2_journal_put_journal_head() {
                          preempt_count_add();
                          preempt_count_sub();
                        } /* jbd2_journal_put_journal_head */
                      } /* jbd2_journal_get_write_access */
                    } /* __ext4_journal_get_write_access */
                  } /* ext4_reserve_inode_write */
                  ext4_mark_iloc_dirty() {
                    ext4_fc_track_inode();
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    ext4_fill_raw_inode() {
                      from_kuid() {
                        map_id_up();
                      } /* from_kuid */
                      from_kgid() {
                        map_id_up();
                      } /* from_kgid */
                      from_kprojid() {
                        map_id_up();
                      } /* from_kprojid */
                      ext4_inode_csum_set() {
                        ext4_inode_csum() {
                          crypto_shash_update() {
                            chksum_update();
                          } /* crypto_shash_update */
                          crypto_shash_update() {
                            chksum_update();
                          } /* crypto_shash_update */
                          crypto_shash_update() {
                            chksum_update();
                          } /* crypto_shash_update */
                          crypto_shash_update() {
                            chksum_update();
                          } /* crypto_shash_update */
                          crypto_shash_update() {
                            chksum_update();
                          } /* crypto_shash_update */
                          crypto_shash_update() {
                            chksum_update();
                          } /* crypto_shash_update */
                        } /* ext4_inode_csum */
                      } /* ext4_inode_csum_set */
                    } /* ext4_fill_raw_inode */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                    __ext4_handle_dirty_metadata() {
                      jbd2_journal_dirty_metadata() {
                        _raw_spin_lock() {
                          preempt_count_add();
                        } /* _raw_spin_lock */
                        _raw_spin_lock() {
                          preempt_count_add();
                        } /* _raw_spin_lock */
                        __jbd2_journal_file_buffer() {
                          __jbd2_journal_temp_unlink_buffer();
                        } /* __jbd2_journal_file_buffer */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                        _raw_spin_unlock() {
                          preempt_count_sub();
                        } /* _raw_spin_unlock */
                      } /* jbd2_journal_dirty_metadata */
                    } /* __ext4_handle_dirty_metadata */
                    __brelse();
                  } /* ext4_mark_iloc_dirty */
                } /* __ext4_mark_inode_dirty */
                __ext4_journal_stop() {
                  jbd2_journal_stop() {
                    stop_this_handle() {
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
                    } /* stop_this_handle */
                    kmem_cache_free();
                  } /* jbd2_journal_stop */
                } /* __ext4_journal_stop */
              } /* ext4_dirty_inode */
              _raw_spin_lock() {
                preempt_count_add();
              } /* _raw_spin_lock */
              locked_inode_to_wb_and_lock_list() {
                _raw_spin_unlock() {
                  preempt_count_sub();
                } /* _raw_spin_unlock */
                _raw_spin_lock() {
                  preempt_count_add();
                } /* _raw_spin_lock */
              } /* locked_inode_to_wb_and_lock_list */
              _raw_spin_lock() {
                preempt_count_add();
              } /* _raw_spin_lock */
              inode_io_list_move_locked() {
                wb_io_lists_populated();
              } /* inode_io_list_move_locked */
              _raw_spin_unlock() {
                preempt_count_sub();
              } /* _raw_spin_unlock */
              _raw_spin_unlock() {
                preempt_count_sub();
              } /* _raw_spin_unlock */
            } /* __mark_inode_dirty */
          } /* generic_update_time */
          __mnt_drop_write_file();
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
                  __mark_inode_dirty() {
                    _raw_spin_lock() {
                      preempt_count_add();
                    } /* _raw_spin_lock */
                    _raw_spin_unlock() {
                      preempt_count_sub();
                    } /* _raw_spin_unlock */
                  } /* __mark_inode_dirty */
                } /* mark_buffer_dirty */
              } /* __block_commit_write */
            } /* block_write_end */
            down_write() {
              preempt_count_add();
              preempt_count_sub();
            } /* down_write */
            up_write() {
              preempt_count_add();
              preempt_count_sub();
            } /* up_write */
            unlock_page() {
              folio_unlock();
            } /* unlock_page */
            __ext4_journal_start_sb() {
              ext4_journal_check_start();
              jbd2__journal_start() {
                kmem_cache_alloc() {
                  should_failslab();
                } /* kmem_cache_alloc */
                start_this_handle() {
                  _raw_read_lock() {
                    preempt_count_add();
                  } /* _raw_read_lock */
                  add_transaction_credits();
                  _raw_read_unlock() {
                    preempt_count_sub();
                  } /* _raw_read_unlock */
                } /* start_this_handle */
              } /* jbd2__journal_start */
            } /* __ext4_journal_start_sb */
            __ext4_mark_inode_dirty() {
              ext4_reserve_inode_write() {
                ext4_get_inode_loc() {
                  __ext4_get_inode_loc() {
                    ext4_get_group_desc();
                    ext4_inode_table();
                    __getblk_gfp() {
                      __find_get_block() {
                        housekeeping_test_cpu();
                        housekeeping_test_cpu();
                        folio_mark_accessed();
                      } /* __find_get_block */
                    } /* __getblk_gfp */
                  } /* __ext4_get_inode_loc */
                } /* ext4_get_inode_loc */
                __ext4_journal_get_write_access() {
                  jbd2_journal_get_write_access() {
                    jbd2_write_access_granted();
                  } /* jbd2_journal_get_write_access */
                } /* __ext4_journal_get_write_access */
              } /* ext4_reserve_inode_write */
              ext4_mark_iloc_dirty() {
                ext4_fc_track_inode();
                _raw_spin_lock() {
                  preempt_count_add();
                } /* _raw_spin_lock */
                ext4_fill_raw_inode() {
                  from_kuid() {
                    map_id_up();
                  } /* from_kuid */
                  from_kgid() {
                    map_id_up();
                  } /* from_kgid */
                  from_kprojid() {
                    map_id_up();
                  } /* from_kprojid */
                  ext4_inode_csum_set() {
                    ext4_inode_csum() {
                      crypto_shash_update() {
                        chksum_update();
                      } /* crypto_shash_update */
                      crypto_shash_update() {
                        chksum_update();
                      } /* crypto_shash_update */
                      crypto_shash_update() {
                        chksum_update();
                      } /* crypto_shash_update */
                      crypto_shash_update() {
                        chksum_update();
                      } /* crypto_shash_update */
                      crypto_shash_update() {
                        chksum_update();
                      } /* crypto_shash_update */
                      crypto_shash_update() {
                        chksum_update();
                      } /* crypto_shash_update */
                    } /* ext4_inode_csum */
                  } /* ext4_inode_csum_set */
                } /* ext4_fill_raw_inode */
                _raw_spin_unlock() {
                  preempt_count_sub();
                } /* _raw_spin_unlock */
                __ext4_handle_dirty_metadata() {
                  jbd2_journal_dirty_metadata();
                } /* __ext4_handle_dirty_metadata */
                __brelse();
              } /* ext4_mark_iloc_dirty */
            } /* __ext4_mark_inode_dirty */
            __ext4_journal_stop() {
              jbd2_journal_stop() {
                stop_this_handle() {
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
                } /* stop_this_handle */
                kmem_cache_free();
              } /* jbd2_journal_stop */
            } /* __ext4_journal_stop */
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
                        __slab_alloc.constprop.0() {
                          preempt_count_add();
                          ___slab_alloc();
                          preempt_count_sub();
                        } /* __slab_alloc.constprop.0 */
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
                      kmem_cache_alloc() {
                        should_failslab();
                        __slab_alloc.constprop.0() {
                          preempt_count_add();
                          ___slab_alloc();
                          preempt_count_sub();
                        } /* __slab_alloc.constprop.0 */
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
                            available_idle_cpu();
                            available_idle_cpu() {
                              hv_vcpu_is_preempted();
                            } /* available_idle_cpu */
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
                        __slab_alloc.constprop.0() {
                          preempt_count_add();
                          ___slab_alloc();
                          preempt_count_sub();
                        } /* __slab_alloc.constprop.0 */
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
                            available_idle_cpu();
                            available_idle_cpu() {
                              hv_vcpu_is_preempted();
                            } /* available_idle_cpu */
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
