package homework.ch11_13.p4;

/**
 * 迭代器接口，用于遍历组件树里的每一个组件
 */
public interface ComponentIterator {
    /**
     *
     * @return 如果元素还没有迭代完，返回true;否则返回false
     */
    public boolean hasNext();
    public Component next();
}
