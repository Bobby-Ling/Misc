package homework.ch11_13.p4;

public class AtomicComponent extends Component{
    public AtomicComponent() {}
    public AtomicComponent(int id, String name, double price) {
        super(id, name, price);
    }

    /**
     * 不支持
     * @param component
     * @throws UnsupportedOperationException
     */
    @Override
    public void add(Component component) throws UnsupportedOperationException {
        throw new UnsupportedOperationException("Not supported.");
    }

    /**
     * 不支持
     * @param component
     * @throws UnsupportedOperationException
     */
    @Override
    public void remove(Component component) throws UnsupportedOperationException {
        throw new UnsupportedOperationException("Not supported.");
    }

    @Override
    public double calcPrice() {
        return this.getPrice();
    }

    /**
     * 总是返回一个NullIterator对象。
     * @return
     */
    @Override
    public ComponentIterator createIterator() {
        return new NullIterator();
    }
}
