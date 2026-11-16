using System;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double BasicSalary { get; set; }
    public double HRA { get; set; } // House Rent Allowance (20%)
    public double DA { get; set; }  // Dearness Allowance (10%)
    public double PF { get; set; }  // Provident Fund (12%)
    public double NetSalary { get; set; }

    public static Employee CalculateSalary(int id, string name, double basicSalary)
    {
        double hra = basicSalary * 0.20;
        double da = basicSalary * 0.10;
        double pf = basicSalary * 0.12;
        double gross = basicSalary + hra + da;
        double net = gross - pf;

        return new Employee
        {
            Id = id,
            Name = name,
            BasicSalary = basicSalary,
            HRA = hra,
            DA = da,
            PF = pf,
            NetSalary = net
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================================================");
        Console.WriteLine("          10 Employees Salary Calculation System (C# Loops Demo)                 ");
        Console.WriteLine("=================================================================================");

        const int TotalEmployees = 10;
        Employee[] employees = new Employee[TotalEmployees];

        Console.WriteLine("\n[PART 1: Using a 'FOR' Loop to Take Input for " + TotalEmployees + " Employees]");
        Console.Write("Do you want to enter custom data manually, or load 10 sample employee records? (M = Manual / S = Sample) [default: S]: ");
        string choice = Console.ReadLine();
        if (choice != null)
        {
            choice = choice.Trim().ToUpper();
        }
        else
        {
            choice = "S";
        }

        if (choice == "M")
        {
            // FOR LOOP to take user input for 10 employees
            for (int i = 0; i < TotalEmployees; i++)
            {
                Console.WriteLine("\n--- Employee #{0} of {1} ---", i + 1, TotalEmployees);
                Console.Write("Enter Employee Name : ");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    name = "Employee_" + (i + 1);
                }

                double basic = 0;
                while (true)
                {
                    Console.Write("Enter Basic Salary  : ");
                    if (double.TryParse(Console.ReadLine(), out basic) && basic > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Please enter a valid positive salary!");
                }

                employees[i] = Employee.CalculateSalary(i + 1, name, basic);
            }
        }
        else
        {
            // FOR LOOP to populate 10 employees dynamically
            string[] sampleNames = new string[]
            {
                "Sahil Rautela", "Aarav Sharma", "Priya Verma", "Rohan Mehta", "Ananya Singh",
                "Vikram Malhotra", "Sneha Patel", "Aditya Joshi", "Pooja Nair", "Karan Kapoor"
            };

            double[] sampleBasics = new double[]
            {
                65000, 52000, 48000, 71000, 55000,
                80000, 45000, 60000, 58000, 75000
            };

            Console.WriteLine("\nPopulating 10 employee records via FOR loop...");
            for (int i = 0; i < TotalEmployees; i++)
            {
                employees[i] = Employee.CalculateSalary(i + 1, sampleNames[i], sampleBasics[i]);
                Console.WriteLine("  Loaded Employee #{0}: {1} (Basic: Rs. {2:N0})", i + 1, sampleNames[i], sampleBasics[i]);
            }
        }

        // [PART 2: Using a 'FOREACH' Loop to Display the Salaries]
        Console.WriteLine("\n=================================================================================");
        Console.WriteLine("[PART 2: Using a 'FOREACH' Loop to Display Salaries]");
        Console.WriteLine("=================================================================================");
        Console.WriteLine(string.Format("{0,-5} {1,-18} {2,12} {3,11} {4,11} {5,11} {6,13}",
            "ID", "Employee Name", "Basic (Rs.)", "HRA (20%)", "DA (10%)", "PF (12%)", "Net Salary (Rs.)"));
        Console.WriteLine(new string('-', 85));

        double grandTotalNetSalary = 0;

        // FOREACH LOOP TO DISPLAY EACH EMPLOYEE'S SALARY
        foreach (Employee emp in employees)
        {
            Console.WriteLine(string.Format("{0,-5} {1,-18} {2,12:N2} {3,11:N2} {4,11:N2} {5,11:N2} {6,13:N2}",
                emp.Id, emp.Name, emp.BasicSalary, emp.HRA, emp.DA, emp.PF, emp.NetSalary));

            grandTotalNetSalary += emp.NetSalary;
        }

        Console.WriteLine(new string('-', 85));
        Console.WriteLine(string.Format("{0,-5} {1,-18} {2,59:N2}", "TOTAL", "10 Employees", grandTotalNetSalary));
        Console.WriteLine("=================================================================================");
    }
}
