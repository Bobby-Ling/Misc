package homework.ch11_13.p4;

/**
 * 复合组件，包含子组件
 */
public class CompositeComponent extends Component {
    /**
     * 保存子组件,放在ComponentList里
     */
    protected ComponentList children = new ComponentList();

    CompositeComponent() {
    }

    public CompositeComponent(int id, String name, double price) {
        /**
         * CompositeComponent本身的price为0.0
         */
        super(id, name, 0);
    }

    /**
     * 添加子组件
     *
     * @param component
     * @throws UnsupportedOperationException
     */
    @Override
    public void add(Component component) throws UnsupportedOperationException {
        children.add(component);
    }

    /**
     * 删除子组件
     *
     * @param component
     * @throws UnsupportedOperationException
     */
    @Override
    public void remove(Component component) throws UnsupportedOperationException {
        children.remove(component);
    }

    @Override
    public double calcPrice() {
        double sum = 0;
        for (Component component : children) {
            sum += component.calcPrice();
        }
        return sum;
    }

    /**
     * @return 组件的迭代器
     */
    @Override
    public ComponentIterator createIterator() {
        return new CompositeIterator(children.createIterator());
    }

    @Override
    public String toString() {
        return super.toString() + "Sub components of " + super.getName() + "\n" + children.toString() + "\n";
    }

    @Override
    public double getPrice() {
        return calcPrice();
    }
}
