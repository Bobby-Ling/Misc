package homework.ch11_13.p3;

import org.testng.Assert;
import org.testng.annotations.Test;
/**
 *
 */
public class Person implements Cloneable {

    private String name= "";
    private int age;

    public Person() {
    }

    public Person(String name, int age) {
        this.name = name==null?"":name;
        this.age = age;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name==null?"":name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Person anotherPerson) {
            if (this == obj) return true;
            return this.name.equals(anotherPerson.name) &&
                    this.age == anotherPerson.age;
        }
        return false;
    }

    @Override
    public String toString() {
        return "name: " + name + ", age: " + age;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        Person clone = (Person) super.clone();
        clone.age = age;
        clone.name = new String(name);
        return clone;
    }
}

class PersonTest {
    public static void main(String[] args)throws CloneNotSupportedException {
        Person person = new Person("John Doe", 23);
        Person person1 = new Person("John Doe", 23);
        System.out.println(person.equals(person1));
//        System.out.println(person.equals(null));

//        testTestClone();
        testTestEquals();
    }
    public static void testTestClone() throws CloneNotSupportedException {
        Person p = new Person("aaa", 20);
        Person cloned = (Person)p.clone();
        Assert.assertTrue(p.equals(cloned) && p.getName() != cloned.getName());
    }


    public static void testTestEquals() {
        int age = 20;
        String name = "aaa";
        Person p1 = new Person(name, age);
        Person p2 = new Person(name, age);
        Assert.assertTrue(p1.equals(p2));
        p1 = new Person();
        p2 = new Person();
        Assert.assertTrue(p1.equals(p2), "new Person().equals(new Person（）) test error");
        p1 = new Person((String)null, 20);
        p2 = new Person((String)null, 20);
        Assert.assertTrue(p1.equals(p2), "new Person(null,20).equals(new Person（null,20）) test error");
        p1 = new Person((String)null, 20);
        p2 = new Person((String)null, 30);
        Assert.assertTrue(!p1.equals(p2), "new Person(null,20).equals(new Person（null,30）) test error");
        p1 = new Person("aaa", 20);
        p2 = new Person((String)null, 20);
        Assert.assertTrue(!p1.equals(p2), "new Person(\"aaa\",20).equals(new Person（null,20）) test error");
    }
}