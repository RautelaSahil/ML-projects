using System;

class Student
{
    // Member fields
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string Course { get; set; }

    // 1. Default Constructor (Parameterless)
    public Student()
    {
        StudentId = 1000;
        Name = "Default Student";
        Age = 18;
        Address = "Not Provided";
        Course = "General Studies";
        Console.WriteLine("[INFO] Default Constructor Called.");
    }

    // 2. Parameterized Constructor
    public Student(int id, string name, int age, string address, string course)
    {
        StudentId = id;
        Name = name;
        Age = age;
        Address = address;
        Course = course;
        Console.WriteLine("[INFO] Parameterized Constructor Called for: " + name);
    }

    // Method to display student information
    public void DisplayInfo()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Student ID : " + StudentId);
        Console.WriteLine("Name       : " + Name);
        Console.WriteLine("Age        : " + Age);
        Console.WriteLine("Address    : " + Address);
        Console.WriteLine("Course     : " + Course);
        Console.WriteLine("--------------------------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("  Student Information using C# Constructors       ");
        Console.WriteLine("==================================================");

        // 1. Object creation using Default Constructor
        Console.WriteLine("\n--> Creating Student 1 using Default Constructor:");
        Student student1 = new Student();
        student1.DisplayInfo();

        // 2. Object creation using Parameterized Constructor
        Console.WriteLine("\n--> Creating Student 2 using Parameterized Constructor:");
        Student student2 = new Student(101, "Sahil Rautela", 21, "Dehradun, Uttarakhand", "B.Tech CSE");
        student2.DisplayInfo();

        // 3. Dynamic User Input using Parameterized Constructor
        Console.WriteLine("\n--> Creating Student 3 from User Input:");
        Console.Write("Enter Student ID : ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id)) id = 102;

        Console.Write("Enter Name       : ");
        string name = Console.ReadLine();
        if (string.IsNullOrEmpty(name)) name = "Aarav Sharma";

        Console.Write("Enter Age        : ");
        int age;
        if (!int.TryParse(Console.ReadLine(), out age)) age = 20;

        Console.Write("Enter Address    : ");
        string address = Console.ReadLine();
        if (string.IsNullOrEmpty(address)) address = "Delhi, India";

        Console.Write("Enter Course     : ");
        string course = Console.ReadLine();
        if (string.IsNullOrEmpty(course)) course = "Computer Science";

        Console.WriteLine();
        Student student3 = new Student(id, name, age, address, course);
        student3.DisplayInfo();

        Console.WriteLine("==================================================");
    }
}
