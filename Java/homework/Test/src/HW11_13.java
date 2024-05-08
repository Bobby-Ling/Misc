import java.io.IOException;

public class HW11_13 {

}

// interface C {

// }

// class B {

// }

// class A extends B implements C {
// public static void main(String[] args) {
// // A a = new A( ); B b = a; C c = b;
// A a = new A();
// B b = a;
// C c1 = a, c2 = new A();
// }
// }

// class Base {
// public Base(String s) {
// System.out.print("B");
// }
// }

// class Derived extends Base {
// public Derived(String s) {
// super(s);//
// System.out.print("D");
// }

// public static void main(String[] args) {
// new Derived("C");
// }
// }

// interface I { }
// class A1 implements I { }
// class B1 extends A1 { }
// class C1 extends B1 {
// public static void main(String[] args) {
// B1 b = new B1();
// // A1 a = b;
// // I i = b;
// if(b instanceof C1)
// {
// C1 c = (C1) b;
// }
// // C1 c = (C1) b; //error
// // B1 d = (B1) (A1) b;
// }
// }

// class MyProgram {
// public static void main(String args[]) {
// try {
// System.out.print("Hello Java.");
// } finally {
// System.out.print("Finally Java.");
// }
// }
// }

class A2 {
    public void draw() {
        System.out.print("Draw A.");
    }

    public void display() {
        this.draw();
        System.out.print("Display A.");
    }
}

class B2 extends A2 {
    public void draw() {
        System.out.print("Draw B.");
    }

    public void display() {
        super.display();
        System.out.print("Display B.");
    }
}

class Test7 {
    public static void main(String[] args) {
        int[] m = new int[5];
        m[4] = 10;
        // m[5]=10;//ArrayIndexOutOfBoundsException

        B2[] objectArr = new B2[5];
        // objectArr[4].display();//NullPointerException
        // objectArr[5].display();//ArrayIndexOutOfBoundsException
        new B2().display();
    }
}

class Test1 {
    public static void main(String args[]) {
        try {
            System.out.print("try.");
            return;
        } catch (Exception e) {
            System.out.print("catch.");
        } finally {
            System.out.print("finally.");
        }
    }
}

class Test2_16 {
    public void m1() throws IOException {
        try {
            throw new IOException();
        } catch (IOException e) {
        }
    }

    public void m2() {
        // m1();
    }
}

class Test2_17 {
    public void m1() throws RuntimeException {
        throw new RuntimeException();
    }

    public void m2() {
        m1();
    }
}

class SuperClass {
    static int i = 10;
    static {
        System.out.println(" static in SuperClass");
    }
    {
        System.out.println("SupuerClass is called");
    }
}

class SubClass extends SuperClass {
    static int i = 15;
    static {
        System.out.println(" static in SubClass");
    }

    SubClass() {
        System.out.println("SubClass is called");
    }

    public static void main(String[] args) {
        int i = SubClass.i;// 第一次使用时装入
        new SubClass();
        new SuperClass();
    }
}

class Test5 {
    public static void main(String... args) {
        C3 o1 = new D3();
        o1.m(1, 1);         // ①    D's m(int,int)          覆盖
        o1.m(1.0, 1.0);     // ②    C's m(double,double)
        o1.m(1.0f, 1.0f);   // ③    C's m(double,double)    (2)和(3)在C中找
        //多态: 从行为上, 覆盖了的就调用覆盖后的(晚期绑定), 没被覆盖的, 根据声明类型判断
        //如果D中m(float,float)覆盖C中的, 则也调用D中的m
    
        D3 o2 = new D3();
        o2.m(1, 1);         // ④    D's m(int,int)          覆盖
        o2.m(1.0, 1.0);     // ⑤    C's m(double,double)
        o2.m(1.0f, 1.0f);   // ⑥    D's m(float,float)      (5)和(6)在D中找

    }
}

class C3 {
    public void m(int x, int y) {
        System.out.println("C's m(int,int)");
    }

    public void m(double x, double y) {
        System.out.println("C's m(double,double)");
    }
}

class D3 extends C3 {
    @Override
    public void m(int x, int y) {
        System.out.println("D's m(int,int)");
    }

    public void m(float x, float y) {
        System.out.println("D's m(float,float)");
    }
}

class Test_Hide_Override {
    public static void main(String... args){
        A4 o = new C4();
        o.m1();			        //① A's m1
        o.m2();			        //② C's m2
        ((B4)o).m1();		    //③ B's m1
        ((A4)(B4)o).m1();		//④ A's m1
        ((A4)(B4)o).m2();		//⑤ C's m2
    }
}

class A4{
    public static void m1(){  System.out.println("A's m1"); }
    public void m2(){ System.out.println("A's m2"); }
}

class B4 extends A4{
    public static void m1(){  System.out.println("B's m1"); }
    public void m2(){ System.out.println("B's m2"); }
}

class C4 extends B4{
    public static void m1(){  System.out.println("C's m1"); }
    public void m2(){ System.out.println("C's m2"); }
}
