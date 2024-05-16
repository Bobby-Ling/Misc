package ReusableThread;

import java.util.ArrayList;
import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class ReusableThread extends Thread{
    private Runnable runTask = null;  //保存接受的线程任务
    //TODO 加入需要的数据成员
    private final Lock lock = new ReentrantLock();
    private final Condition condition = lock.newCondition();

    ArrayList<Runnable> tasks = new ArrayList<>();
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
            while(true){
                    lock.lock();
                while(runTask == null){
                    condition.await();
                    // 这里会释放锁
                }
                // 重新获得锁
                    lock.unlock();
                runTask.run();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        } finally {
            runTask = null;
            tasks.remove(0);
        }
    }

    /**
     * 提交新的任务
     * @param task 要提交的任务
     */
    public void submit(Runnable task){
        lock.lock();
        tasks.add(task);
        runTask = tasks.get(0);
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
        for(int i = 0; i < 5; i++){
            t.submit(task1);
            t.submit(task2);
        }
    }
}