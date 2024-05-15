package SyncQueue;

import java.util.List;

/**
 * SyncQueue1<T>实现生产者线程和消费者线程轮流生产数据和消费数据，即如果队列不为空，则生产者线程必须等到消费者线程将队列里的数据消费完后才能向队列生产数据；如果队列为空，则消费者线程必须等待生产者线程向队列生产数据后才能消费数据。这个版本的测试结果应该如下所示：
 * Produce elements: 4 5 3 1 9 6 10 6 7 6
 * Consume elements: 4 5 3 1 9 6 10 6 7 6
 * Produce elements: 2 5 9 9 7 10
 * Consume elements: 2 5 9 9 7 10
 * Produce elements: 8 8 9 2
 * Consume elements: 8 8 9 2
 * @param <T>
 */
public class SyncQueue1<T> extends SyncQueue<T> {
    @Override
    public void produce(List<T> element){
        synchronized(this){
            if(super.list.size() != 0){}
            System.out.println("Produce elements: "+element);
        }
    }


}
