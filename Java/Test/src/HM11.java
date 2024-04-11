public class HM11 {
    public static void main(String[] args){
        C c=new D();
        c.m(1.0f);
        c.m(1);
    }
}
class C{
    public void m(double n){
        System.out.println("C");
    }
}
class D extends  C{
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