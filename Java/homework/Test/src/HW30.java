import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class HW30 {
  
}  

class Holder1 {
	private int data = 0;
	public int getData () {return data;}
	public synchronized void inc (int amount) {
		System.out.println(Thread.currentThread().getName() + ": inc " + amount +" "+data);
		int newValue = data + amount;
		try {Thread.sleep(5);
		} catch (InterruptedException e) {}
		data = newValue;
	}
	public void dec (int amount) {
		int newValue = data - amount;
		try {
			Thread.sleep(1);
			System.out.println(Thread.currentThread().getName() + ": dec " + amount+" "+data);
		} catch (InterruptedException e) {}
		data = newValue;
	}
    public static void main (String [] args) {
        ExecutorService es = Executors.newCachedThreadPool();
        Holder1 holder = new Holder1 ();
        int incAmount = 10, decAmount = 5, loops = 1000;
        Runnable incTask = () -> holder.inc(incAmount);
        Runnable decTask = () -> holder.dec(decAmount);
        for (int i = 0; i < loops; i++) {
            es. execute(incTask);
            es. execute(decTask);
        }
        es. shutdown ();
        while (! es. isTerminated ()) {}
    }
}

class Test2_5 {
	public static class Resource {
		private static int value = 0;
		public static int getValue () {return value;}
		public static void inc (int amount) {
			synchronized (Resource.class) {
				int newValue = value + amount;
				try {Thread.sleep(5);} catch (InterruptedException e) {}
				value = newValue;
			}
		}
		public synchronized static void dec (int amount) {
			int newValue = value - amount;
			try {Thread.sleep(2);} catch (InterruptedException e) {}
			value = newValue;
		}
	}
	public static void main (String [] args) {
		ExecutorService es = Executors.newCachedThreadPool();
		int incAmount = 10, decAmount = 5, loops = 100;
		Resource r1 = new Resource ();
		Resource r2 = new Resource ();
		Runnable incTask = () -> r1.inc(incAmount);
		Runnable decTask = () -> r2.dec(decAmount);
		for (int i = 0; i < loops; i++) {es. execute(incTask); es. execute(decTask);}
		es. shutdown ();
		while (! es. isTerminated ()) {}
	}
}
