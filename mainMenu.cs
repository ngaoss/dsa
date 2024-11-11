package student;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        binary tree = new binary();
        Scanner scanner = new Scanner(System.in);
        int choice;

        do {
            System.out.println("\nMenu:");
            System.out.println("1. add student");
            System.out.println("2. edit student");
            System.out.println("3. delete student");
            System.out.println("4. search student");
            System.out.println("5. sort and display student");
            System.out.println("6. exit");
            System.out.print("enter your choice: ");
            choice = validInput(scanner);

            switch (choice) {
                case 1:
                    System.out.print("enter ID: ");
                    int id = validInput(scanner);
                    System.out.print("enter grade: ");
                    int grade = validInput(scanner);
                    System.out.print("enter name: ");
                    String name = scanner.nextLine();
                    tree.add(id, grade, name);
                    System.out.println("student added successfully.");
                    break;

                case 2:
                    System.out.print("enter ID of student to edit: ");
                    int editId = validInput(scanner);
                    System.out.print("enter new grade: ");
                    int newGrade = validInput(scanner);
                    System.out.print("enter new name: ");
                    String newName = scanner.nextLine();
                    boolean edited = tree.edit(editId, newGrade, newName);
                    if (edited) {
                        System.out.println("student updated successfully.");
                    } else {
                        System.out.println("student not found.");
                    }
                    break;

                case 3:
                    System.out.print("enter ID of student to delete: ");
                    int deleteId = validInput(scanner);
                    tree.delete(deleteId);
                    System.out.println("deleted successfully");
                    break;

                case 4:
                    System.out.print("enter ID of student to search: ");
                    int searchId = validInput(scanner);
                    boolean found = tree.search(searchId);
                    if (found) {
                        System.out.println("student found.");
                    } else {
                        System.out.println("student not found.");
                    }
                    break;

                case 5:
                    System.out.println("students sorted by ID:");
                    tree.sort();
                    scanner.nextLine();
                    break;

                case 6:
                    System.out.println("exiting.....");
                    break;

                default:
                    System.out.println("please try again.");
            }
        } while (choice != 6);

        scanner.close();
    }

    public static int validInput(Scanner scanner) {
        while (true) {
            try {
                return Integer.parseInt(scanner.nextLine());
            } catch (NumberFormatException e) {
                System.out.print("enter a valid number: ");
            }
        }
    }
}
