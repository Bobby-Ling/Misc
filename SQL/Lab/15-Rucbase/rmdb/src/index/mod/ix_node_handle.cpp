#include "ix_node_handle.h"

#include <algorithm> // for std::upper_bound and std::lower_bound
#include <iterator>  // fro std::begin and std::end
#include "MemoryIterator.h" // iterator for IxNodeHandle

// #include "logger.h"
// using namespace logger;
// ConsoleLogger Log;


/**
 * @file ix_node_handle.cpp
 * @brief 对本实验这个坑爹的B+树数据结构的一些总体注解
 * @attention 内部节点KV一一对应(一般看到的图是K+1==V), 所以每个内部节点会在<keys[0],rids[0]>存储第一个子节点的K和指向这个子节点的Rid
 *            而叶子节点则只存了自己的KV对
 *
 */

 /**
 * @brief 在当前node中查找第一个>=target的key_idx
 *
 * @return key_idx，范围为[0,num_key)，如果返回的key_idx=num_key，则表示target大于最后一个key
 * @return 注意index为0表示keys[0]>=key, 根据实验中的B+树, 对于内部节点, 即代表左子树;
 *         对于叶子节点, 满足key>=keys[0], 所以index==0就代表key==keys[0](或未找到)
 * @note 返回key index（同时也是rid index），作为slot no
 */
int IxNodeHandle::lower_bound(const char *target) const {
    // Todo:
    // 查找当前节点中第一个大于等于target的key，并返回key的位置给上层
    // 提示: 可以采用多种查找方式，如顺序遍历、二分查找等；使用ix_compare()函数进行比较

    // 获得key调用get_key(); 值value为Rid类型, 对于内部结点, 其Rid中的page_no表示指向的孩子结点的页面编号. 
    Log(Level::Info) << "IxNodeHandle::lower_bound";
    // return lower_bound1(target);

    auto IxNodeHandleKeyIterator = MemoryIterator<>(keys, file_hdr->col_len, page_hdr->num_key);
    auto result = std::lower_bound(IxNodeHandleKeyIterator.begin(), IxNodeHandleKeyIterator.end(), target,
        [this](const MemoryIterator<>::dereference_type &a, const MemoryIterator<>::dereference_type &value) {
            // ix_compare return <:-1 >:1 =:0
            return -1 == ix_compare(a, value, file_hdr->col_type, file_hdr->col_len);
        }
    );
    int ans = std::distance(IxNodeHandleKeyIterator.begin(), result);
    Log(Level::Debug) << ToString() << "ans:" << ans << " target:" << *(int *)target;
    Log(Level::Error, ans != lower_bound1(target)) << "lower_bound():" << ans << " lower_bound1():" << lower_bound1(target);
    return ans;
}
int IxNodeHandle::lower_bound1(const char *target) const {
    // Todo:
    // 查找当前节点中第一个大于等于target的key，并返回key的位置给上层
    // 提示: 可以采用多种查找方式，如顺序遍历、二分查找等；使用ix_compare()函数进行比较
    int num_key_now = page_hdr->num_key;
    ColType type = file_hdr->col_type;
    int col_len = file_hdr->col_len;
    int idx = -1;
    if (1) {
        //待写的二分查找
        for (int i = 0; i < num_key_now; ++i) {
            // printf("当前的i为%d,get_key(i)为%d,target为%d\n",i,*get_key(i),*target);
            if (ix_compare(get_key(i), target, type, col_len) >= 0) {
                idx = i; //表示找到了
                break;
            }
        }
        if (idx == -1)
            idx = num_key_now;
    }
    else {//顺序查找
        // printf("当前的num_key为%d\n",num_key_now); 
        for (int i = 0; i < num_key_now; ++i) {
            // printf("当前的i为%d,get_key(i)为%d,target为%d\n",i,*get_key(i),*target);
            if (ix_compare(get_key(i), target, type, col_len) >= 0) {
                idx = i; //表示找到了
                break;
            }
        }
        if (idx == -1)
            idx = num_key_now;
    }
    Log(Level::Debug) << ToString() << "idx:" << idx << " target:" << *(int *)target;
    return idx;
}
/**
 * @brief 在当前node中查找第一个>target的key_idx
 *
 * @return key_idx，范围为[1,num_key)，如果返回的key_idx=num_key，则表示target大于等于最后一个key
 * @note 注意此处的范围从1开始
 * @note 原因是keys[0]代表左子树
 */
int IxNodeHandle::upper_bound(const char *target) const {
    // Todo:
    // 查找当前节点中第一个大于target的key，并返回key的位置给上层
    // 提示: 可以采用多种查找方式：顺序遍历、二分查找等；使用ix_compare()函数进行比较

    Log(Level::Info) << "IxNodeHandle::upper_bound";
    // return upper_bound1(target);

    auto IxNodeHandleKeyIterator = MemoryIterator<>(keys, file_hdr->col_len, page_hdr->num_key);
    auto result = std::upper_bound(IxNodeHandleKeyIterator.begin() + 1, IxNodeHandleKeyIterator.end(), target,
        [this](const MemoryIterator<>::dereference_type &a, const MemoryIterator<>::dereference_type &value) {
            // ix_compare return <:-1 >:1 =:0
            return -1 == ix_compare(a, value, file_hdr->col_type, file_hdr->col_len);
        }
    );
    int ans = std::distance(IxNodeHandleKeyIterator.begin(), result);
    Log(Level::Debug) << ToString() << "ans:" << ans << " target:" << *(int *)target;
    Log(Level::Error, ans != upper_bound1(target)) << "upper_bound():" << ans << " upper_bound1():" << upper_bound1(target);
    return ans;
}
int IxNodeHandle::upper_bound1(const char *target) const {
    // Todo:
    // 查找当前节点中第一个大于target的key，并返回key的位置给上层
    // 提示: 可以采用多种查找方式：顺序遍历、二分查找等；使用ix_compare()函数进行比较
    int num_key_now = page_hdr->num_key;
    ColType type = file_hdr->col_type;
    int col_len = file_hdr->col_len;
    int idx = -1;
    if (1) {
        //待写的二分查找
        for (int i = 1; i < num_key_now; ++i) {
            if (ix_compare(get_key(i), target, type, col_len) > 0) {
                idx = i; //表示找到了
                break;
            }
        }
        if (idx == -1)
            idx = num_key_now;
    }
    else {//顺序查找
        for (int i = 1; i < num_key_now; ++i) {
            if (ix_compare(get_key(i), target, type, col_len) > 0) {
                idx = i; //表示找到了
                break;
            }
        }
        if (idx == -1)
            idx = num_key_now;
    }

    return idx;
}
/**
 * @brief 用于叶子结点根据key来查找该结点中的键值对
 * 值value作为传出参数，函数返回是否查找成功
 *
 * @param key 目标key
 * @param[out] value 传出参数，目标key对应的Rid
 * @return 目标key是否存在
 */
bool IxNodeHandle::LeafLookup(const char *key, Rid **value) {
    // Todo:
    // 1. 在叶子节点中获取目标key所在位置
    // 2. 判断目标key是否存在
    // 3. 如果存在，获取key对应的Rid，并赋值给传出参数value
    // 提示：可以调用lower_bound()和get_rid()函数。

    Log(Level::Info) << "IxNodeHandle::LeafLookup";
    // return LeafLookup1(key, value);

    // key是唯一的; 对于叶子节点, 满足key>=keys[0], 所以index==0就代表key==keys[0](或未找到)
    int index = lower_bound(key);
    if (index == page_hdr->num_key) {
        return false;
    }
    if (index == 0) {
        if (ix_compare(get_key(index), key, file_hdr->col_type, file_hdr->col_len) != 0) {
            // 未找到
            Log(Level::Warning) << "未找到";
            return false;
        }
    }
    // 找到了当前的index
    // 实际上就是根据同样的index对Rid数组进行索引
    *value = get_rid(index);
    Log(Level::Debug) << ToString() << "key: " << *(int *)key << " value:" << (*value)->page_no;
    return true;
}
bool IxNodeHandle::LeafLookup1(const char *key, Rid **value) {
    // Todo:
    // 1. 在叶子节点中获取目标key所在位置
    // 2. 判断目标key是否存在
    // 3. 如果存在，获取key对应的Rid，并赋值给传出参数value
    // 提示：可以调用lower_bound()和get_rid()函数。
    int num_key_now = page_hdr->num_key;
    ColType type = file_hdr->col_type;
    int col_len = file_hdr->col_len;
    //因为貌似不含有重复值，所以注意利用
    int idx = lower_bound(key);
    if (ix_compare(get_key(idx), key, type, col_len) == 0) {//表示找到了，否则没有找到
        *value = get_rid(idx);
        return true;
    }
    return false;
}
/**
 * 用于内部结点（非叶子节点）查找目标key所在的孩子结点（子树）
 * @param key 目标key
 * @return page_id_t 目标key所在的孩子节点（子树）的存储页面编号
 */
page_id_t IxNodeHandle::InternalLookup(const char *key) {
    // Todo:
    // 1. 查找当前非叶子节点中目标key所在孩子节点（子树）的位置
    // 2. 获取该孩子节点（子树）所在页面的编号
    // 3. 返回页面编号

    Log(Level::Info) << "IxNodeHandle::InternalLookup";
    // return InternalLookup1(key);

    // 值value为Rid类型, 对于内部结点, 其Rid中的page_no表示指向的孩子结点的页面编号.
    // 而内部结点每个key右边的value指向的孩子结点中的键均大于等于该key, 每个key左边的value指向的孩子结点中的键均小于该key.
    // index:[0,page_hdr->num_key-1]
    int index = lower_bound(key);
    Log(Level::Debug) << ToString() << "key: " << *(int *)key << " value:" << ValueAt(index);
    if (index == page_hdr->num_key) {
        // 没找到表示在最右子树, 则返回rids[index-1].page_no
        return ValueAt(index - 1);
    }
    // index为0表示keys[0]>=key, 对于内部节点, 即代表最左子树;
    if (index == 0) {
        if (ix_compare(get_key(index), key, file_hdr->col_type, file_hdr->col_len) != 0) {
            // 未找到
            Log(Level::Warning) << "不会出现此情况";
        }
        // 等价于, index==0时无论找没找到, 都会返回ValueAt(index)
    }
    else {
        if (ix_compare(get_key(index), key, file_hdr->col_type, file_hdr->col_len) != 0) {
            // {0,4,6,8} key=5, index=1;key=6, index=2
            return ValueAt(index - 1);
        }
    }
    return ValueAt(index);
}
page_id_t IxNodeHandle::InternalLookup1(const char *key) {
    // Todo:
    // 1. 查找当前非叶子节点中目标key所在孩子节点（子树）的位置
    // 2. 获取该孩子节点（子树）所在页面的编号
    // 3. 返回页面编号
    int num_key_now = page_hdr->num_key;
    ColType type = file_hdr->col_type;
    int col_len = file_hdr->col_len;
    //因为貌似不含有重复值，所以注意利用
    int idx = lower_bound(key);
    Log(Level::Debug) << ToString() << "key: " << *(int *)key << " value:" << ValueAt(idx);
    Log(Level::Disabled, idx == num_key_now) << "idx == num_key_now";
    if (ix_compare(get_key(idx), key, type, col_len) == 0) {//表示找到了，否则没有找到
        Log(Level::Warning, idx == num_key_now) << "ix_compare(get_key(idx), key, type, col_len) == 0";
        return ValueAt(idx);
    }
    else if (idx == 0) {//表示新来的这个节点小于目前最小的节点
        Log(Level::Disabled) << "idx == 0";
        return ValueAt(idx);
    }
    else {//如果索引中没有正好等于的，那么就找它最后一个小于它的
        Log(Level::Disabled) << "没有正好等于的";
        return ValueAt(idx - 1);//不会存在最小值不在的情况，因为我们会不断维持最小的值
    }
}
/**
 * @brief 在指定位置插入n个连续的键值对
 * 将key的前n位插入到原来keys中的pos位置；将rid的前n位插入到原来rids中的pos位置
 *
 * @param pos 要插入键值对的位置
 * @param (key, rid) 连续键值对的起始地址，也就是第一个键值对，可以通过(key, rid)来获取n个键值对
 * @param n 键值对数量
 * @note [0,pos)           [pos,num_key)
 *                            key_slot
 *                            /      \
 *                           /        \
 *       [0,pos)     [pos,pos+n)   [pos+n,num_key+n)
 *                      key           key_slot
 */
void IxNodeHandle::insert_pairs(int pos, const char *key, const Rid *rid, int n) {
    // Todo:
    // 1. 判断pos的合法性
    // 2. 通过key获取n个连续键值对的key值，并把n个key值插入到pos位置
    // 3. 通过rid获取n个连续键值对的rid值，并把n个rid值插入到pos位置
    // 4. 更新当前节点的键数量

    Log(Level::Info) << "IxNodeHandle::insert_pairs";
    Log(Level::Debug) << ToString() << "insert_pairs插入前";
    // insert_pairs1(pos, key, rid, n);
    // Log(Level::Disabled) << ToString() << "insert_pairs插入后";
    // return;

    // XXX 暂定为插入后的KV从pos开始, 即[pos,pos+n) 且不考虑重复
    // 插入前: keys:[0,pos),            [pos,num_key) 且num_key:[1,btree_order]
    // 插入后: keys:[0,pos),[pos,pos+n),[pos+n,num_key+n)
    // pos:[0,num_key] num_key+n:[1,btree_order]
    // e.g. keys={0,1,2}, key=k, pos=0 -> {k,0,1,2}; pos=2 -> {0,1,k,2}; pos=3 -> {0,1,2,k}
    if (!(0 <= pos && pos <= page_hdr->num_key) && !(page_hdr->num_key + n <= file_hdr->btree_order)) {
        Log(Level::Error) << "IxNodeHandle::insert_pairs 插入不合法";
        return;
    }
    Log(Level::Debug) << ToString() << "准备insert_pairs插入 pos: " << pos << " n:" << n
        << " key: " << *(int *)key << " value:" << rid[0].page_no;
    // [pos+n,num_key+n) <- [pos,num_key) 
    memmove(get_key(pos + n), get_key(pos), n * file_hdr->col_len);
    memmove(&rids[pos + n], &rids[pos], n * sizeof(Rid));
    // [pos,pos+n) <- [key,key+n)
    memcpy(get_key(pos), key, n * file_hdr->col_len);
    memcpy(&rids[pos], rid, n * sizeof(Rid));

    // memmove(get_key(pos + n), get_key(pos), n * file_hdr->col_len);
    // memmove(rids + (pos + n), rids + pos, n * sizeof(Rid));
    // memcpy(keys + pos * file_hdr->col_len, key, n * file_hdr->col_len);
    // memcpy(rids + pos, rid, sizeof(Rid) * n);
    page_hdr->num_key += n;
    Log(Level::Debug) << ToString() << "insert_pairs插入后";
}
void IxNodeHandle::insert_pairs1(int pos, const char *key, const Rid *rid, int n) {
    // Todo:
    // 1. 判断pos的合法性
    // 2. 通过key获取n个连续键值对的key值，并把n个key值插入到pos位置
    // 3. 通过rid获取n个连续键值对的rid值，并把n个rid值插入到pos位置
    // 4. 更新当前节点的键数量
    //在这里我实现的时候默认了连续的数组都是有序的，并且保证了插入的位置也是对的位置，并且进行了去重
    int num_key_now = page_hdr->num_key;
    ColType type = file_hdr->col_type;
    int col_len = file_hdr->col_len;
    //去重，先去重再判断，注意，只要key重复那么rid就一定重复，因为key一定是不重复的，换句话说，key为码
    char *tmp_key = new char[col_len * n];
    Rid *tmp_rid = new Rid[n];
    int real_n = 0;//真正要插入的n个数
    // printf("要插入的n是%d\n",n);
    //无论如何第一个值一定要进入待插区
    memcpy(tmp_key, key, col_len);
    memcpy(tmp_rid, rid, sizeof(Rid));
    real_n++;
    for (int i = 1; i < n; ++i) {
        const char *key_i = key + i;
        const char *key_i2 = key + i - 1;
        // printf("key_i,key_i2 : %d, %d\n",*key_i,*key_i2);
        if (ix_compare(key_i, key_i2, type, col_len) == 0) {
            //如果二者相等，那么我就不插
            Log(Level::Debug) << "如果二者相等，那么我就不插";
        }
        else {//如果不等，那么我
            printf("在insert_pairs力，应该进入一次\n");
            memcpy(tmp_key + col_len * real_n, key + col_len * i, col_len);
            memcpy(tmp_rid + real_n, rid + i, sizeof(Rid));
            real_n ++;
        }
    }
    //此时的real_n是数量而不是坐标了
// printf("real_n为%d\n",real_n);
    if ((pos + real_n) * col_len > file_hdr->keys_size) {//判断如果不合法，那么就直接不插入，或许还有其他的
        printf("不应该到达这里啊啊啊啊----------------------\n");
    }
    else {//如果合法的话，那么我就插入,注意，此处仅仅考虑了插入一个值的情况，所以不排序，默认位置找的是对的，也不再这里对pos之前和之后的值去重了，在Insert那里去重
        memmove(keys + (pos + real_n) * col_len, keys + pos * col_len, col_len * (num_key_now - pos));
        memmove(rids + (pos + real_n), rids + pos, sizeof(Rid) * (num_key_now - pos));
        memcpy(keys + pos * col_len, tmp_key, col_len * real_n);
        memcpy(rids + pos, tmp_rid, sizeof(Rid) * real_n);
        // for(int i = 0; i <= num_key_now; ++i){
        //     printf("插完后的第%d个值是%d\n",i,*get_key(i));
        // }
    }
    page_hdr->num_key += real_n;
    return;

}
/**
 * @brief 用于在结点中的指定位置插入单个键值对
 */
void IxNodeHandle::insert_pair(int pos, const char *key, const Rid &rid) { insert_pairs(pos, key, &rid, 1); };

/**
 * @brief 用于在结点中插入单个键值对。
 * 函数返回插入后的键值对数量
 * 要保证插入后的顺序并去重
 * @param (key, value) 要插入的键值对
 * @return int 键值对数量
 */
int IxNodeHandle::Insert(const char *key, const Rid &value) {
    // Todo:
    // 1. 查找要插入的键值对应该插入到当前节点的哪个位置
    // 2. 如果key重复则不插入
    // 3. 如果key不重复则插入键值对
    // 4. 返回完成插入操作之后的键值对数量

    Log(Level::Info) << "IxNodeHandle::Insert";
    Log(Level::Debug) << ToString() << "Insert插入前 key: " << *(int *)key << " value:" << value.page_no;
    // return Insert1(key, value);

    // e.g.  {3,6} <- 0~2 : index=0, pos=0
    //       {3,6} <- 3   : index=0, pos=x, equal
    //       {3,6} <- 4~5 : index=1, pos=1
    //       {3,6} <- 6   : index=1, pos=x, equal
    //       {3,6} <- 7~  : index=2, pos=2, index == page_hdr->num_key
    // 插入时要保证顺序
    int index = lower_bound(key);
    if (ix_compare(get_key(index), key, file_hdr->col_type, file_hdr->col_len) == 0) {
        // equal
        Log(Level::Debug) << "key已存在";
        return page_hdr->num_key;
    }
    // 现在不存在重复的了, 直接插入
    // XXX 是否越界和num_key的更新在insert_pairs处理
    insert_pair(index, key, value);
    Log(Level::Debug) << ToString() << "Insert插入后 key: " << *(int *)key << " value:" << value.page_no;
    return page_hdr->num_key;
}
int IxNodeHandle::Insert1(const char *key, const Rid &value) {
    // Todo:
    // 1. 查找要插入的键值对应该插入到当前节点的哪个位置
    // 2. 如果key重复则不插入
    // 3. 如果key不重复则插入键值对
    // 4. 返回完成插入操作之后的键值对数量
    int num_key_now = page_hdr->num_key;
    ColType type = file_hdr->col_type;
    int col_len = file_hdr->col_len;
    int pos = lower_bound(key);
    // printf("在Insert函数中，将要插入的key值为%d,应当插入的pos为%d\n",*key,pos);
    if (pos == num_key_now) {  //插入最后即可
        insert_pair(pos, key, value);
        // page_hdr->num_key ++;

        return page_hdr->num_key;
    }
    else if (ix_compare(get_key(pos), key, type, col_len) == 0) {//如果找到了一个大于等于它的数，先看看是否是等于他，如果等于，那么就不插了
        //相等，不插入了
        // printf("%d,  %d\n",*get_key(pos),*key);
        // printf("键值对相等----------------------不该到这里\n");
        return num_key_now;
    }
    else {//否则，既不是找不到，又不是有等于它的，那么pos位置一定比key要大，pos-1比key要小，那么就把他插在pos位置
        // printf("在中间插入应当要到达这里的\n");
        insert_pair(pos, key, value);
        // page_hdr->num_key ++;

        return page_hdr->num_key;
    }
}
/**
 * @brief 用于在结点中的指定位置删除单个键值对
 *
 * @param pos 要删除键值对的位置
 */
void IxNodeHandle::erase_pair(int pos) {
    // Todo:
    // 1. 删除该位置的key
    // 2. 删除该位置的rid
    // 3. 更新结点的键值对数量

    Log(Level::Info) << "IxNodeHandle::erase_pair";
    // return erase_pair1(pos);

    // pos:[0,num_key)
    if (!(0 <= pos && pos < page_hdr->num_key)) {
        return;
    }
    // e.g. num_keys=5 keys={0,1,2,3,4}, pos=0 -> {1,2,3,4}, ; pos=1 -> {0,2,3,4}
    int n = page_hdr->num_key - pos - 1;
    memmove(get_key(pos), get_key(pos + 1), n * file_hdr->col_len);
    memmove(&rids[pos], &rids[pos + 1], n * sizeof(Rid));
    page_hdr->num_key -= 1;
}
void IxNodeHandle::erase_pair1(int pos) {
    // Todo:
    // 1. 删除该位置的key
    // 2. 删除该位置的rid
    // 3. 更新结点的键值对数量
    int num_key_now = page_hdr->num_key;
    ColType type = file_hdr->col_type;
    int col_len = file_hdr->col_len;
    // printf("要删除的pos是%d,移动的数量是%d,num_key_now是%d\n",pos,(num_key_now - pos - 1),num_key_now);
    if (pos < 0 || pos >= GetSize()) {
        return;
    }
    else {
        memmove(keys + pos * col_len, keys + (pos + 1) * col_len, col_len * (num_key_now - pos - 1));
        memmove(rids + pos, rids + (pos + 1), sizeof(Rid) * (num_key_now - pos - 1));
        page_hdr->num_key --;
    }
    // printf("删除完后的num_key是%d,所有的key分别是:\n",page_hdr->num_key);
    // for(int i =0; i < page_hdr->num_key; ++i){
    //     printf("%d\n",*get_key(i));
    // }
}
/**
 * @brief 用于在结点中删除指定key的键值对。函数返回删除后的键值对数量
 *
 * @param key 要删除的键值对key值
 * @return 完成删除操作后的键值对数量
 */
int IxNodeHandle::Remove(const char *key) {
    // Todo:
    // 1. 查找要删除键值对的位置
    // 2. 如果要删除的键值对存在，删除键值对
    // 3. 返回完成删除操作后的键值对数量

    Log(Level::Info) << "IxNodeHandle::Remove";
    return Remove1(key);

    int index = lower_bound(key);
    if (index == page_hdr->num_key) {
        // 没找到(其实不必判断的, erase_pair会处理)
        return page_hdr->num_key;
    }
    if (index == 0) {
        if (ix_compare(get_key(index), key, file_hdr->col_type, file_hdr->col_len) != 0) {
            // 没找到
            return page_hdr->num_key;
        }
    }
    // 找到了
    erase_pair(index);
    return page_hdr->num_key;
}
int IxNodeHandle::Remove1(const char *key) {
    // Todo:
    // 1. 查找要删除键值对的位置
    // 2. 如果要删除的键值对存在，删除键值对
    // 3. 返回完成删除操作后的键值对数量

    int num_key_now = page_hdr->num_key;
    ColType type = file_hdr->col_type;
    int col_len = file_hdr->col_len;
    int pos = lower_bound(key);
    if (ix_compare(get_key(pos), key, type, col_len) == 0) {
        erase_pair(pos);
        return GetSize();
    }
    return num_key_now;
}
/**
 * @brief 由parent调用，寻找child，返回child在parent中的rid_idx∈[0,page_hdr->num_key)
 *
 * @param child
 * @return int
 */
int IxNodeHandle::find_child(IxNodeHandle *child) {
    int rid_idx;
    for (rid_idx = 0; rid_idx < page_hdr->num_key; rid_idx++) {
        if (get_rid(rid_idx)->page_no == child->GetPageNo()) {
            break;
        }
    }
    assert(rid_idx < page_hdr->num_key);
    return rid_idx;
}

/**
 * @brief used in internal node to remove the last key in root node, and return the last child
 *
 * @return the last child
 */
page_id_t IxNodeHandle::RemoveAndReturnOnlyChild() {
    assert(GetSize() == 1);
    page_id_t child_page_no = ValueAt(0);
    erase_pair(0);
    assert(GetSize() == 0);
    return child_page_no;
}