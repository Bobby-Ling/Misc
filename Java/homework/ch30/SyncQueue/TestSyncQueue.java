package SyncQueue;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class TestSyncQueue {
    public static void main(String[] args){
//        SyncQueue<Integer> syncQueue = new SyncQueue1<Integer>();
        SyncQueue<Integer> syncQueue = new SyncQueue2<Integer>();
        Runnable produceTask = ()->{
            while(true){
                try {
                    List<Integer> list = new ArrayList<>();
                    int elementsCount = (int)(Math.random() * 10) + 1;
                    for(int i = 0; i < elementsCount; i++){
                        int r = (int)(Math.random() * 10) + 1;
                        list.add(r);
                    }
                    syncQueue.produce(list);
                    Thread.sleep((int)(Math.random() * 5) + 1);
                }
                catch (InterruptedException e) { e.printStackTrace(); }
            }
        };

        Runnable consumeTask = ()->{
            while (true){
                try{
                    List<Integer> list = syncQueue.consume();
                    Thread.sleep((int)(Math.random() * 10) + 1);
                }
                catch (InterruptedException e) { e.printStackTrace(); }
            }
        };

        ExecutorService es = Executors.newFixedThreadPool(2);
        es.execute(produceTask);
        es.execute(consumeTask);
        es.shutdown();
        while (!es.isTerminated()){}
    }
}
