package student;

public class binary {
    Student root;

    binary() {
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

    void delete(int id) {
        root = deleteRec(root, id);
    }

    Student deleteRec(Student root, int id) {
        if (root == null) return root;

        if (id < root.id) {
            root.left = deleteRec(root.left, id);
        } else if (id > root.id) {
            root.right = deleteRec(root.right, id);
        } else {
            if (root.left == null)
                return root.right;
            else if (root.right == null)
                return root.left;

            root.id = minValue(root.right);
            root.right = deleteRec(root.right, root.id);
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
        inOrderTraversal();
    }

    void inOrderTraversal() {
        inOrderTraversalRec(root);
    }

    void inOrderTraversalRec(Student root) {
        if (root != null) {
            inOrderTraversalRec(root.left);
            System.out.println("ID: " + root.id + ", Grade: " +
                    root.grade + ", Name: " + root.name +
                    ", Rank: " + root.rank);

            inOrderTraversalRec(root.right);
        }
    }
}
