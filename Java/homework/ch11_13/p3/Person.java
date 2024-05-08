package homework.ch11_13.p3;

/**
 *
 */
public class Person implements Cloneable {

    private String name;
    private int age;

    public Person() {
    }

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
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
        clone.name = name;
        return clone;
    }
}

class PersonTest {
    public static void main(String[] args) {
        Person person = new Person("John Doe", 23);
        Person person1 = new Person("John Doe", 23);
        System.out.println(person.equals(person1));
//        System.out.println(person.equals(null));
    }
}