package homework.ch11_13.p3;

/**
 * 教工类
 */
public class Faculty extends Person {
    private String email= "";
    private int facultyId;
    private String title= "";

    public Faculty() {
    }

    public Faculty(String name,
                   int age,
                   int facultyId,
                   String title,
                   String email) {
        this.setName(name);
        this.setAge(age);
        this.facultyId = facultyId;
        this.title = title==null?"":title;
        this.email = email==null?"":email;
    }


    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email==null?"":email;
    }

    public int getFacultyId() {
        return facultyId;
    }

    public void setFacultyId(int facultyId) {
        this.facultyId = facultyId;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title==null?"":title;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Faculty anotherFaculty) {
            if (this == anotherFaculty) return true;
            return super.equals(obj) &&
                    this.email.equals(anotherFaculty.email) &&
                    this.facultyId == anotherFaculty.facultyId &&
                    this.title.equals(anotherFaculty.title);
        }
        return false;
    }

    @Override
    public String toString() {
        return "\n" + super.toString() + ", " +
                "facultyId: " + facultyId + ", " +
                "title: " + title + ", " +
                "email: " + email + "\n";
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        Faculty clone = (Faculty) super.clone();
        clone.facultyId = facultyId;
        clone.title = new String(title);
        clone.email = new String(email);
        return clone;
    }
}
