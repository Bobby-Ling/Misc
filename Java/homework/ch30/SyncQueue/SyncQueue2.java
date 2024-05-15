package SyncQueue;

/**
 * SyncQueue2<T>要求有些区别：即生产者线程不管队列是否为空，随时可以向队列生产数据；消费者线程则在队列为空时，必须等待生产者线程向队列生产数据后才能消费数据。这个版本的测试结果应该如下所示：
 * Produce elements: 7 9 2 7 6 8 9 1 7 3
 * Produce elements: 7 5 9 8 8
 * Consume elements: 7 9 2 7 6 8 9 1 7 3 7 5 9 8 8
 * Produce elements: 6 2 8
 * Produce elements: 3 2 5 10 3 4 5 1 6
 * Produce elements: 5 7
 * Consume elements: 6 2 8 3 2 5 10 3 4 5 1 6 5 7
 * Produce elements: 3
 * Consume elements: 3
 * Produce elements: 10 3 4
 * Consume elements: 10 3 4
 * @param <T>
 */
public class SyncQueue2<T> extends SyncQueue<T> {

}
