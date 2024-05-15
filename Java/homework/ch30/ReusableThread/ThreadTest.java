package ReusableThread;

public class ThreadTest {
    public static void main(String[] args){
        Runnable task = ()->{ System.out.println("task is running"); };
        Thread t = new Thread(task);
        t.start();
        try { Thread.sleep(1000); }
        catch (InterruptedException e) { e.printStackTrace(); }
        System.out.println(t.isAlive()); //当线程任务结束后，isAlive返回false
        t.start();  //一旦线程结束，不可再start，否则抛出异常
    }
}
