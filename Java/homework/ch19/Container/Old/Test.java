package Container.Old;

/**
 * 迭代器接口，用于遍历组件树里的每一个组件. 注意这不是java.util.Iterator接口
 */
interface Iterator {
    /**
     *  是否还有元素
     * @return 如果元素还没有迭代完，返回true;否则返回false
     */
    boolean hasNext();

    /**
     * 获取下一个元素
     * @return  下一个元素
     */
    Object next();
}

/**
 * 数组迭代器
 */
class  ArrayIterator implements Iterator{
    private int pos = 0;
    private Object[] a = null;

    public ArrayIterator(Object[] array){
        a = array;
    }

    @Override
    public boolean hasNext() {
        return !(pos >= a.length);
    }

    @Override
    public Object next() {
        if(hasNext()){
            Object c = a[pos];
            pos ++;
            return c;
        }
        else
            return null;
    }
}

/**
 * 容器类，内部用Object[]保存元素
 */
class Container {
    private Object[] elements;
    private int elementsCount = 0;
    private int size = 0;

    public Container(int size){
        elements = new Object[size];
        this.size = size;
    }

    public boolean add(Object e){
        if(elementsCount < size){
            elements[elementsCount ++] = e;
            return true;
        }
        else{
            return  false;
        }
    }

    /**
     * 返回容器的迭代器
     * @return
     */
    public Iterator iterator(){
        return new ArrayIterator(elements);
    }
}
public class Test{
    public static void main(String[] args){
        Container container = new Container(6);
        container.add("12");
        container.add("34");
        container.add("56");
        container.add("78");
        container.add("9");
        container.add(10);
        Iterator it = container.iterator();
        while (it.hasNext()){
            String s = (String)it.next();
            if( s != null)
                System.out.println(s);
        }
    }
}
