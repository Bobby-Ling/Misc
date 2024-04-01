public class HW9 {
    public static void main(String[] args) {
        A[] array = new A[10];
    }
}

/**
 * A
 */
class A {
    static int count = 0;
    protected int j;

    public A() {
        System.out.println("A" + count + " ");
        count++;
    }

}

class AA {
    private long i = 0;

    AA(int i) {
        this.i = i;
    }

    String AA(long i) {
        this.i = i;
        return "i = " + this.i;
    }
}

class Test_1_6 {
    public static void main(String[] args) {
        System.out.println(new AA(10).AA(20));
    }
}

class B extends A {
    public void m() {
        new A().j = 10;
        this.j = 10;
    }
}

class Circle {
    private double radius;
    public static int count = 0;

    public Circle(double r) {
        radius = r;
        count++;
    }

    public Circle() {
        this(1.0);
    }

    public static void main(String[] args) {
        Circle c1 = new Circle();
        Circle c2 = new Circle(15.0);
        c1.count++;
        c2.count++;
        Circle.count++;
        System.out.println("count =" + count);
    }
}
