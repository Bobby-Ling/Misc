package homework.ch11_13.p1;

import java.util.ArrayList;

public class TaskServiceImpl implements TaskService {
    ArrayList<Task> tasks = new ArrayList<Task>();

    @Override
    public void addTask(Task t) {
        tasks.add(t);
    }

    @Override
    public void exeuteTasks() {
        tasks.forEach((t) -> {});

        for (Task taskInst:tasks){
            taskInst.execute();
        }
    }
}
