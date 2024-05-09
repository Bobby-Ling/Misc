package Container;

/**
 * 数组迭代器
 */
public  class ArrayIterator<T> implements Iterator<T> {
    private int pos = 0;
    private T[] a = null;

    public ArrayIterator(T[] array){
        a = array;
    }

    @Override
    public boolean hasNext() {
        return !(pos >= a.length);
    }

    @Override
    public T next() {
        if(hasNext()){
            T c = a[pos];
            pos ++;
            return c;
        }
        else
            return null;
    }
}
