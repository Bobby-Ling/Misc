package homework.ch11_13.p4;

/**
 * 计算机组件的抽象类，任何一个具体的组件键盘、鼠标、主板、主机都是Component。
 * 注意主机又由一些更小的Component组成，如内存条、CPU，这种组件为复合组件。
 */
public abstract class Component {
    /**
     * 组件的唯一id
     */
    protected int id;
    /**
     * 组件的名字
     */
    protected String name;
    /**
     * 组件的价格
     */
    protected double price;

    public Component() {}
    public Component(int id, String name, double price) {
        this.id = id;
        this.name = name;
        this.price = price;
    }

    public int getId() {
        return id;
    }

    public  void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    @Override
    public String toString() {
        return "id: " + id + ", name: " + name + ", price: " + price;
    }

    /**
     * 基于组件id判断二个组件对象是否相等
     * @param obj
     * @return
     */
    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Component anotherComponent) {
            if(this==anotherComponent) return true;
            return id == anotherComponent.id;
        }
        return false;
    }

    /**
     * 添加子组件，对于没有子组件的AtomicComponent如内存条，
     * 调用这个方法应该抛出UnsupportedOperationException.
     * @param component
     */
    public abstract void add(Component component) throws UnsupportedOperationException;

    /**
     * 计算组件的价格。
     * @return
     */
    public abstract double calcPrice();

    /**
     * 返回组件的迭代器
     * @return
     */
    public abstract ComponentIterator createIterator();

    /**
     * 删除子组件，对于没有子组件的AtomicComponent如内存条，
     * 调用这个方法应该抛出UnsupportedOperationException.
     * @param component
     * @throws UnsupportedOperationException
     */
    public abstract void remove(Component component) throws UnsupportedOperationException;
}
