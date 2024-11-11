package student;

class Student {
    int id, grade;
    String name;
    String rank;
    Student left, right;

    public Student(int id, int grade, String name) {
        this.id = id;
        this.grade = grade;
        this.name = name;
        this.rank = rannk(grade);
        left = right = null;
    }

    String rannk(int grade) {
        if (grade < 5.0) {
            return "fail";
        } else if (grade < 6.5) {
            return "medium";
        } else if (grade < 7.5) {
            return "good";
        } else if (grade < 9.0) {
            return "very Good";
        } else if (grade <= 10.0) {
            return "excellent";
        } else {
            return "invalid";
        }
    }
}
