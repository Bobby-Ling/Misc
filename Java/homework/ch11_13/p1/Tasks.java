package homework.ch11_13.p1;

public class Tasks {
    public static void main(String[] args) {
        Task1 task1=new Task1();
        Task2 task2=new Task2();
        Task3 task3=new Task3();

        TaskServiceImpl tasks=new TaskServiceImpl();
        tasks.addTask(task1);
        tasks.addTask(task2);
        tasks.addTask(task3);
        tasks.exeuteTasks();
    }
}

class Task1 implements Task {
    public void execute(){
        System.out.println( this.getClass().getName()+" executed");
    }
}

class Task2 implements Task {
    public void execute(){
        System.out.println( this.getClass().getName()+" executed");
    }
}

class Task3 implements Task {
    public void execute(){
        System.out.println( this.getClass().getName()+" executed");
    }
}