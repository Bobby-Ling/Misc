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

class Circle1 {
    private double radius;
    public static int count = 0;

    public Circle1(double r) {
        radius = r;
        count++;
    }

    public Circle1() {
        this(1.0);
    }

    public static void main(String[] args) {
        Circle1 c1 = new Circle1();
        Circle1 c2 = new Circle1(15.0);
        c1.count++;
        c2.count++;
        Circle1.count++;
        System.out.println("count =" + count);
    }
}
