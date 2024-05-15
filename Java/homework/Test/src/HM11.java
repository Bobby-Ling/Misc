public class HM11 {
    public static void main(String[] args){
        C6 c=new D6();
        c.m(1.0f);
        c.m(1);
    }
}
class C6 {
    public void m(double n){
        System.out.println("C");
    }
}
class D6 extends C6 {
    public void m(float n){
        System.out.println("D float");
    }
    public void m(int n){
        System.out.println("D int");
    }
    public void m(double n){
        System.out.println("D");
    }
}