package student;

class Binary {
    Student root;

    Binary() {
        root = null;
    }

    void add(int id, int grade, String name) {
        root = insertRec(root, id, grade, name);
    }

    Student insertRec(Student root, int id, int grade, String name) {
        if (root == null) {
            root = new Student(id, grade, name);
            return root;
        }
        if (id < root.id)
            root.left = insertRec(root.left, id, grade, name);
        else if (id > root.id)
            root.right = insertRec(root.right, id, grade, name);
        return root;
    }

    boolean edit(int id, int newGrade, String newName) {
        Student student = findStudent(root, id);
        if (student != null) {
            student.grade = newGrade;
            student.name = newName;
            student.rank = student.rannk(newGrade);
            return true;
        }
        return false;
    }

    Student findStudent(Student root, int id) {
        if (root == null || root.id == id)
            return root;
        if (id < root.id)
            return findStudent(root.left, id);
        return findStudent(root.right, id);
    }

    boolean delete(int id) {
        boolean[] isDeleted = new boolean[1];
        root = deleteRec(root, id, isDeleted);
        return isDeleted[0];
    }

    Student deleteRec(Student root, int id, boolean[] isDeleted) {
        if (root == null) return null;

        if (id < root.id) {
            root.left = deleteRec(root.left, id, isDeleted);
        } else if (id > root.id) {
            root.right = deleteRec(root.right, id, isDeleted);
        } else {
            isDeleted[0] = true;
            if (root.left == null)
                return root.right;
            else if (root.right == null)
                return root.left;
            root.id = minValue(root.right);
            root.right = deleteRec(root.right, root.id, isDeleted);
        }
        return root;
    }


    int minValue(Student root) {
        int minv = root.id;
        while (root.left != null) {
            root = root.left;
            minv = root.id;
        }
        return minv;
    }

    boolean search(int id) {
        return searchRec(root, id);
    }

    boolean searchRec(Student root, int id) {
        if (root == null)
            return false;
        if (root.id == id)
            return true;
        if (id < root.id)
            return searchRec(root.left, id);
        else
            return searchRec(root.right, id);
    }

    void sort() {
        Student[] students = createArray();
        bubbleSort(students);
        for (Student student : students) {
            System.out.println("ID: " + student.id + ", Grade: " + student.grade +
                    ", Name: " + student.name + ", Rank: " + student.rank);
        }
    }

    Student[] createArray() {
        java.util.List<Student> list = new java.util.ArrayList<>();
        inOrderList(root, list);
        return list.toArray(new Student[0]);
    }

    void inOrderList(Student root, java.util.List<Student> list) {
        if (root != null) {
            inOrderList(root.left, list);
            list.add(root);
            inOrderList(root.right, list);
        }
    }

    void bubbleSort(Student[] students) {
        int n = students.length;
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - i - 1; j++) {
                if (students[j].id > students[j + 1].grade) {
                    Student temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }
    }
}
