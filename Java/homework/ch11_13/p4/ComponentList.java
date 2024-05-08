package homework.ch11_13.p4;

import java.util.ArrayList;

/**
 * Component对象的容器类，用于保存复合组件的子组件.
 * 从ArrayList派生，实现了ComponentIterator接口.
 * 定义这个类是为了实现组件树的CompositeIterator.
 * 由于是从ArrayList派生，因此继承了ArrayList的所有方法.
 */
public class ComponentList
        extends ArrayList<Component>
        implements ComponentIterator{
    /**
     * 记录自定义迭代器当前迭代的位置
     */
    private int position;

    public ComponentList(){}

    @Override
    public boolean hasNext() {
        return false;
    }

    @Override
    public Component next() {
        return null;
    }

    public ComponentIterator createIterator(){
        return this;
    }
}
