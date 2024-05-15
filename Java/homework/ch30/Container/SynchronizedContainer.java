package Container;

public class SynchronizedContainer<T> extends Container<T> {
    @Override
    public void add(T t) {
        synchronized (this) {
            System.out.println("add");
            super.add(t);
        }
    }

    @Override
    public T remove(int index) {
        synchronized (this) {
            System.out.println("remove");
            return super.remove(index);
        }
    }

    @Override
    public int size() {
        synchronized (this) {
            System.out.println("size");
            return super.size();
        }
    }

    @Override
    public T get(int index) {
        synchronized (this) {
            System.out.println("get");
            return super.get(index);
        }
    }
}
