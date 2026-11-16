using System;

class StudentGrade
{
    static void Main(string[] args)
    {
        Console.WriteLine("==========================================================");
        Console.WriteLine("    Student Result & Grade Evaluation using If-Else       ");
        Console.WriteLine("==========================================================");

        Console.Write("Enter Student Name   : ");
        string studentName = Console.ReadLine();
        if (string.IsNullOrEmpty(studentName) || studentName.Trim().Length == 0)
        {
            studentName = "Student";
        }

        Console.Write("Enter Roll Number    : ");
        string rollNo = Console.ReadLine();
        if (string.IsNullOrEmpty(rollNo))
        {
            rollNo = "N/A";
        }

        double marks1 = ReadMarks("Subject 1 (Maths)       ");
        double marks2 = ReadMarks("Subject 2 (Physics)     ");
        double marks3 = ReadMarks("Subject 3 (Programming) ");

        double totalMarks = marks1 + marks2 + marks3;
        double percentage = totalMarks / 3.0;

        string grade;
        string resultStatus;

        // Using if-else condition to determine result and grade
        if (marks1 < 40 || marks2 < 40 || marks3 < 40)
        {
            resultStatus = "FAIL";
            grade = "F (Failed in one or more subjects)";
        }
        else
        {
            resultStatus = "PASS";

            if (percentage >= 90)
            {
                grade = "A+ (Outstanding)";
            }
            else if (percentage >= 80)
            {
                grade = "A (Excellent)";
            }
            else if (percentage >= 70)
            {
                grade = "B (Very Good)";
            }
            else if (percentage >= 60)
            {
                grade = "C (Good)";
            }
            else if (percentage >= 50)
            {
                grade = "D (Satisfactory)";
            }
            else
            {
                grade = "E (Pass)";
            }
        }

        // Display Report Card
        Console.WriteLine("\n------------------- STUDENT REPORT CARD -------------------");
        Console.WriteLine("Name             : " + studentName);
        Console.WriteLine("Roll Number      : " + rollNo);
        Console.WriteLine("Marks (Sub 1)    : {0}/100", marks1);
        Console.WriteLine("Marks (Sub 2)    : {0}/100", marks2);
        Console.WriteLine("Marks (Sub 3)    : {0}/100", marks3);
        Console.WriteLine("Total Marks      : {0}/300", totalMarks);
        Console.WriteLine("Percentage       : {0:F2}%", percentage);
        Console.WriteLine("Result Status    : " + resultStatus);
        Console.WriteLine("Grade Assigned   : " + grade);
        Console.WriteLine("===========================================================");
    }

    static double ReadMarks(string subjectName)
    {
        double marks;
        while (true)
        {
            Console.Write("Enter marks for " + subjectName + " (0-100): ");
            if (double.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
            {
                return marks;
            }
            Console.WriteLine("Invalid marks! Please enter a number between 0 and 100.");
        }
    }
}
