using System;

// Note:
// Option 1 (Standalone): Directly runnable as pure C# inheriting base class Person.
// Option 2 (With VB DLL): 
//   1. Compile VB DLL:  vbc /target:library /out:VBLibrary.dll 3_Person.vb
//   2. Compile C# App:  csc /d:USE_VB_DLL /r:VBLibrary.dll 3_VBDll_Inheritance.cs

#if USE_VB_DLL
using VBLibrary;
#else
namespace VBLibrary
{
    // Representation of base class defined in VB DLL
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("[Base Class: Person (from VB DLL)]");
            Console.WriteLine("  Name : " + Name);
            Console.WriteLine("  Age  : " + Age);
        }

        public virtual string GetRole()
        {
            return "Base Person (Defined in VB DLL)";
        }
    }
}
#endif

namespace CrossLanguageInheritance
{
    // C# Derived Class inheriting from Person
    public class Student : VBLibrary.Person
    {
        public string RollNumber { get; set; }
        public string Course { get; set; }
        public double Marks { get; set; }

        public Student(string name, int age, string rollNumber, string course, double marks)
            : base(name, age)
        {
            RollNumber = rollNumber;
            Course = course;
            Marks = marks;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("[C# Derived Class: Student]");
            Console.WriteLine("  Roll Number : " + RollNumber);
            Console.WriteLine("  Course      : " + Course);
            Console.WriteLine("  Marks       : " + Marks);
            Console.WriteLine("  Role        : " + GetRole());
        }

        public override string GetRole()
        {
            return "Student (Specialized via Cross-Language Inheritance in C#)";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("    Cross-Language Inheritance: Visual Basic DLL in C# Console App        ");
            Console.WriteLine("==========================================================================");

            Student student = new Student("Sahil Rautela", 21, "CS-2026-042", "Computer Science & Engineering", 94.5);
            student.DisplayInfo();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("Proof of Inheritance:");
            Console.WriteLine("  Is Student an instance of Person? : " + (student is VBLibrary.Person));
            Console.WriteLine("  Base Type of Student              : " + typeof(Student).BaseType.FullName);
            Console.WriteLine("==========================================================================");
        }
    }
}
