package ReusableThread;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class ReusableThread extends Thread{
    //TODO 加入需要的数据成员
    private static final Lock lock = new ReentrantLock();
    private static final Condition condition = lock.newCondition();

    LinkedList<Runnable> tasks = new LinkedList<>();
//    Runnable task = null;
    //只定义不带参数的构造函数
    public ReusableThread(){
        super();
    }

    /**
     * 覆盖Thread类的run方法
     */
    @Override
    public void run() {
        //这里必须是永远不结束的循环
        System.out.println("running thread");
        try {
            lock.lock();
            while(true){
//                while(task == null){
                while(tasks.isEmpty()){
                    condition.await();
                    // 这里会释放锁
                }
                // 重新获得锁
                tasks.poll().run();
//                task.run();
//                task = null;
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        } finally {
            lock.unlock();
        }
    }

    /**
     * 提交新的任务
     * @param task 要提交的任务
     */
    public void submit(Runnable task, int index){
        lock.lock();
        tasks.offer(task);
//        this.task = task;
        System.out.println(index+" "+task.toString()+" submitted" );
        condition.signalAll();
        lock.unlock();
    }
}

class ReusableThreadTest {
    public static void main(String[] args) {
        Runnable task1 = new Runnable() {
            static int count=0;
            @Override
            public void run() {
                System.out.println("Thread " + Thread.currentThread().getId() +
                        ": is running " + toString());
                System.out.println(count++);
                try { Thread.sleep(200); }
                catch (InterruptedException e) { e.printStackTrace(); }
            }
            @Override
            public String toString() {
                return "task1";
            }
        };

        Runnable task2 = new Runnable() {
            static int count=0;
            @Override
            public void run() {
                System.out.println("Thread " + Thread.currentThread().getId() +
                        " is running " + toString());
                System.out.println(count++);
                try { Thread.sleep(100); }
                catch (InterruptedException e) { e.printStackTrace(); }
            }
            @Override
            public String toString() {
                return "task2";
            }
        };

        ReusableThread t =new ReusableThread();
        t.start();  //主线程启动子线程
        // 不保证run()在submit之前执行
        for(int i = 0; i < 5; i++){
            t.submit(task1,i);
            try {
                Thread.currentThread().sleep(100);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
            t.submit(task2,i);
        }
    }
}