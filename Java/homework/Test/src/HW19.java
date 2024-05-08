import java.io.FileReader;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;

public class HW19 {
    public static void main(String[] args) {
        // ArrayList<String> lists = new ArrayList<String>();
        // ArrayList<? extends Object> lists = new ArrayList<String>();
        ArrayList<? super String> lists = new ArrayList<Object>();
        // lists.add("lists");
        lists.add(String.class.getSuperclass().getName());
        // ArrayList<String> lists = new ArrayList();
        // ArrayList lists = new ArrayList<String>();
        System.out.println(lists.get(0));
    }
}


class Holder<T> {
    T value;
    public Holder (T value) {this.value = value;}
    public T getValue () {return value;}
}

class RawHolder {
    Object value;

    public RawHolder(Object value) {
        this.value = value;
    }

    public Object getValue() {
        return value;
    }
}

class Run {
    public static void main(String[] args) {
        
        Holder<String> h1 = new Holder<>("aaa");
        String s1 = h1. getValue ();
        System.out.println(s1);
        
        RawHolder h2 = new RawHolder("aaa");
        String s2 = (String)h2.getValue();
        System.out.println(s2);

        // Holder<String> h3 = new Holder<> (Integer.valueOf(111));  
        // String s3 = h3. getValue ();
        // System.out.println(s3);
        
        RawHolder h4 = new RawHolder (Integer.valueOf(111));
        String s4 = (String)h4.getValue();
        System.out.println(s4);

        // List<?> c1 = new ArrayList<String> (); c1.add (new Object ());//
        // List<?> c2 = new ArrayList<String> (); c2.add (new String ("1"));//
        // List<?> c3 = new ArrayList<String> (); c3.add ("1"); //不能加入任何东西
        // List<?> c4 = new ArrayList<String> (); c4.add(null);

    }
}

class Shape {}
class Circle extends Shape {}
class Triangle extends Shape {}
class Test2_9 {
    public static void main (String [] args) {
        List<? extends Shape> list1 = new ArrayList<Triangle> ();
        List<? extends Shape> list2 = new ArrayList<Circle> ();

        // System.out.println(list1 instanceof List<Triangle>);        //(1) 运行时已经没有这个类型(擦除)
        System.out.println(list2 instanceof List);                //(2)
        System.out.println(list1.getClass() == list2.getClass());        //(3)
    }
}


class Fruit {
    @Override
    public String toString() {
        return Fruit.class.getName()+"\n";
    }
}

class Apple extends Fruit {
    @Override
    public String toString() {
        return super.toString()+Apple.class.getName()+"\n";
    }
}

class Jonathane extends Apple {
    @Override
    public String toString() {
        return super.toString()+Jonathane.class.getName()+"\n";
    }
}

class Orange extends Fruit {
    @Override
    public String toString() {
        return super.toString()+Orange.class.getName()+"\n";
    }
}

class ListTest<T,E> {
    public static void main(String[] args) {
        ArrayList<Fruit> list = new ArrayList<Fruit>();
        list.add(new Fruit());
        list.add(new Apple());
        // list.add(new Object());//err     

        for (Fruit fruit : list) {//取出时解释为Fruit类型
            System.out.println(fruit.getClass().getName());//输出实际类型
        }
        System.out.println(list.getClass().getName());//java.util.ArrayList
        System.out.println(list.toString());//java.util.ArrayList


        ArrayList<String> StringList = new ArrayList<String>();
        ArrayList<String>[] ListArr = new ArrayList[10];//元素为ArrayList
        // ArrayList<String>[] ListArr = new ArrayList<String>[10];//不行
        ListArr[0] = StringList;
        System.out.println(ListArr.getClass().getName());
        System.out.println(ListArr[0].getClass().getName());

        String[] StringArr = new String[10];
        StringArr[0] = new String("String Element");
        System.out.println(StringArr.getClass().getName());
        System.out.println(StringArr[0].getClass().getName());

        // int[] intArr = new int[10];
        // System.out.println(intArr.getClass().getName());
        
        List<? super Integer> x1 = new ArrayList<Number> ();
        // List<? super Number> x2 = new ArrayList<Integer> ();
        // List<? super Number> x3 = new ArrayList<Short> ();
        // List<? super Integer> x4 = new ArrayList<Short> ();
        List<? extends Number> x5 = new ArrayList<Integer> ();
        // List<? extends Number> x6 = new ArrayList<Object> ();
        List<Number> x7 = new ArrayList<> ();
        List<? extends Comparable<Double>> x8 = new ArrayList<Double> ();
        // List<? extends Number> x9 = new ArrayList<int> ();

    }
}









class Base0 {
    public void func() {
        System.out.println(this.getClass().getName()+"  Base0");
    }
}

class Base1 extends Base0 {
    public void func() {
        System.out.println(this.getClass().getName()+"  Base1");
    }
}

class Derived extends Base1 {
    public void func() {
        System.out.println(this.getClass().getName()+"  Derived");
    }

    public Derived() {
        this.func();
        super.func();

        try {
            // Method m =Base0.class.getMethod("func");
            Method m =Base0.class.getDeclaredMethod("func");
            System.out.println(m.toGenericString());
            m.invoke(this);            
        } catch (Exception e) {
            System.out.println(e.toString());
        }
        // try {
        //     Class base0clz = this.getClass().getSuperclass().getSuperclass();
        //     System.out.println(base0clz.getName());
        //     Method m = base0clz.getDeclaredMethod("func");
        //     System.out.println(m.toGenericString());
        //     m.invoke(this);
        // } catch (Exception e) {
        //     System.out.println(e.toString());
        // }

        // try {
        //     Class base1clz = this.getClass().getSuperclass();
        //     System.out.println(base1clz.getName());
        //     Method m1 = base1clz.getMethod("func");
        //     System.out.println(m1.toGenericString());
        //     m1.invoke(this);
        // } catch (Exception e) {
        //     System.out.println(e.toString());
        // }
    }
    public static void main(String[] args) {
        Derived a=new Derived();
    }
}


class A {}
class B extends A {}
class C extends B {}
class D extends C {}

class Test {
    public static <T> void m(List<? super T> list1, List<? extends T> list2) {
    }
    public static void main(String[] args) {
        // A.
        List<B> l1 = new ArrayList<> ();
        List<B> l2 = new ArrayList<> ();
        Test.m (l1, l2);
        // B.
        List<B> l3 = new ArrayList<> ();
        List<D> l4 = new ArrayList<> ();
        Test.m (l3, l4);//D
        // C. 
        // List<B> l5 = new ArrayList<> ();
        // List<A> l6 = new ArrayList<> ();
        // Test.m (l5, l6);
        // D.
        List<C> l7 = new ArrayList<> ();
        List<D> l8 = new ArrayList<> ();
        Test.m (l7, l8);//D
        // E.
        // List<C> l7 = new ArrayList<> ();
        // List<D> l8 = new ArrayList<> (); 
        // Test.<B>m (l7, l8);
        // F.
        // List<D> l9 = new ArrayList<> ();
        // List<C> l10 = new ArrayList<> ();
        // Test.m (l9, l10);
    }
}

class A1 {}
class B1 extends A1 {}
class Test2 {
    public static void m1(List<? extends A1> list) {}
    public static void m2(List<A1> list) {}
    public static void m3(List<? super A1> list) { }
    public static void main (String [] args) {
        List<A1> listA = new ArrayList<A1> ();
        List<B1> listB = new ArrayList<B1> ();
        List<Object> listO = new ArrayList<Object> ();
        List<Object> listO1 = new ArrayList<> ();//自动推导
        List listO2 = new ArrayList<Object> ();//参数类型->原始类型
        List<Object> listO3 = new ArrayList ();//原始类型->参数类型
        List listO4 = new ArrayList();
                
    m1(listA);//C
    m2(listA);//C
    m3(listA);//C

    m1(listB);//C
    // m2(listB);//A
    // m3(listB);//A

    // m1(listO);//A
    // m2(listO);//A
    m3(listO);//C

    // m1(listO1);//A
    // m2(listO1);//A
    m3(listO1);//C

    m1(listO2);//
    m2(listO2);//
    m3(listO2);//

    // m1(listO3);//A
    // m2(listO3);//A
    m3(listO3);//C

    }
}
