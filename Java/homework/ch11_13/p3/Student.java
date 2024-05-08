package homework.ch11_13.p3;

public class Student extends Person {
    private String classNo;
    private String department;
    private int studentId;

    public Student() {
    }

    public Student(String name,
                   int age,
                   int studentId,
                   String department,
                   String classNo
    ) {
        this.setName(name);
        this.setAge(age);
        this.studentId = studentId;
        this.department = department;
        this.classNo = classNo;
    }

    public String getClassNo() {
        return classNo;
    }

    public void setClassNo(String classNo) {
        this.classNo = classNo;
    }

    public String getDepartment() {
        return department;
    }

    public void setDepartment(String department) {
        this.department = department;
    }

    public int getStudentId() {
        return studentId;
    }

    public void setStudentId(int studentId) {
        this.studentId = studentId;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Student anotherStudent) {
            if (this == anotherStudent) return true;
            return super.equals(anotherStudent) &&
                    this.classNo.equals(anotherStudent.classNo) &&
                    this.studentId == anotherStudent.studentId &&
                    this.department.equals(anotherStudent.department);
        }
        return false;
    }

    @Override
    public String toString() {
        return "\n" + super.toString() + ", " +
                "classNo: " + classNo + ", " +
                "department: " + department + ", " +
                "studentId: " + studentId;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        Student clone = (Student) super.clone();
        clone.setClassNo(classNo);
        clone.setDepartment(department);
        clone.setStudentId(studentId);
        return clone;
    }
}
