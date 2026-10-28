package Assignment1;

public class StudentGradeCalculator {
    public static void main(String[] args) {

        // Student information
        String studentName = "Page Hayes";
        String major = "Applied Computer Science";
        String course = "CMPS 360";

        // Student grades
        double grade1 = 90;
        double grade2 = 91;
        double grade3 = 95;

        // Calculate average grade
        double average = (grade1 + grade2 + grade3) / 3;

        // Display student information
        System.out.println("Student Name: " + studentName);
        System.out.println("Major: " + major);
        System.out.println("Course: " + course);

        // Display grades and average
        System.out.println("Grade 1: " + grade1);
        System.out.println("Grade 2: " + grade2);
        System.out.println("Grade 3: " + grade3);
        System.out.println("Average Grade: " + average);

        // Determine pass or fail
        if (average >= 70) {
         System.out.println("Status: Passed");
         } else {
         System.out.println("Status: Failed");
        }
    }
}