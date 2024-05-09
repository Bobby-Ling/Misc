package homework.ch11_13.p3;

import java.util.ArrayList;
import java.util.List;

/**
 * 课程类
 */
public class Course implements Cloneable {
    /**
     * 课程名称
     */
    private String courseName="";

    /**
     * 选修课程的学生列表，保存在ArrayList里
     */
    private List<Person> students = new ArrayList<Person>();

    /**
     * 课程的授课老师
     */
    private Person teacher;

    public Course(String courseName, Person teacher) {
        this.courseName = courseName==null?"":courseName;
        this.teacher = teacher;
    }


    public String getCourseName() {
        return courseName;
    }

    public List<Person> getStudents() {
        return students;
    }

    public Person getTeacher() {
        return teacher;
    }

    public int getNumberOfStudent() {
        return students.size();
    }

    /**
     * 选修课程。
     * 应该把选修的学生加入到学生列表里。
     * 注意同一个学生只能选修一次，内部的ArrayList里不能出现重复的学生
     *
     * @param s
     */
    public void register(Person s) {
        if (students.contains(s)) {
            return;
        }
        students.add(s);
    }

    /**
     * 取消选修
     * 应该把取消选修的学生从学生名单里删除
     *
     * @param s
     */
    public void unregister(Person s) {
        students.remove(s);//不包含则不会修改
    }

    /**
     * @return 描述Course对象信息的字符串
     * (应该包括课程名称、教师的详细信息，每个学生的详细信息，学生总数)
     */
    @Override
    public String toString() {
        StringBuilder info = new StringBuilder();
        info.append("Course Name: " + courseName + "\n");
        info.append("Teacher: " + teacher.toString() + "\n");
        info.append("Students: " + students.toString() + "\n");
        return info.toString();
    }

    /**
     * @param o 另外一个对象
     * @return 当二个对象当二个对象所有数据成员的内容相等，返回true。
     * 注意学生名单内容也要相等
     * （元素个数相等，每个List里的每个对象在另外一个List里都有唯一的内容相等的元素，但次序可以不同）
     */
    @Override
    public boolean equals(Object o) {
        if (o instanceof Course anotherCourse) {//模式变量
            if (this == o) return true;
            return this.courseName.equals(anotherCourse.courseName) &&
                    this.teacher.equals(anotherCourse.teacher) &&
                    this.students.size() == anotherCourse.students.size() &&
                    this.students.containsAll(anotherCourse.students);
        }
        return false;
    }

    /**
     * @return 克隆出来的对象
     * @throws CloneNotSupportedException
     */
    @Override
    public Object clone() throws CloneNotSupportedException {
        Course clone = (Course) super.clone();
        clone.students = new ArrayList<Person>();
        for (Person p : students) {
            clone.students.add((Person) p.clone());
        }
        clone.courseName = new String(courseName);
        clone.teacher = (Person) teacher.clone();
        return clone;
    }
}
