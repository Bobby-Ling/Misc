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
    private int position=0;

    public ComponentList(){
        super();
    }

    @Override
    public boolean hasNext() {
        if(position<super.size())
            return true;
        else
            return false;
    }

    @Override
    public Component next() {
        if(this.hasNext())
            return super.get(position++);
        else
            return null;
    }

    /**
     * 派生自ArrayList，使内部对子元素具备完全操作权限同时，
     * 暴露在外的"迭代器"(其实是this)仅能访问指定的迭代方法
     * @return 保存的复合组件的迭代器
     */
    public ComponentIterator createIterator(){
        return this;
    }
}
