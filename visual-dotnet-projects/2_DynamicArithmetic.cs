using System;

class DynamicArithmetic
{
    static void Main(string[] args)
    {
        Console.WriteLine("======================================================");
        Console.WriteLine("    Dynamic Arithmetic Calculator using C#            ");
        Console.WriteLine("======================================================");

        double num1 = 0;
        double num2 = 0;
        bool validInput = false;

        while (!validInput)
        {
            try
            {
                Console.Write("Enter first number  : ");
                num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter second number : ");
                num2 = Convert.ToDouble(Console.ReadLine());
                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numerical values!\n");
            }
        }

        // Calculations
        double addition = num1 + num2;
        double subtraction = num1 - num2;
        double multiplication = num1 * num2;

        Console.WriteLine("\n------------------- Calculation Results -------------------");
        Console.WriteLine("Addition       ({0} + {1}) = {2}", num1, num2, addition);
        Console.WriteLine("Subtraction    ({0} - {1}) = {2}", num1, num2, subtraction);
        Console.WriteLine("Multiplication ({0} * {1}) = {2}", num1, num2, multiplication);

        if (num2 != 0)
        {
            double division = num1 / num2;
            Console.WriteLine("Division       ({0} / {1}) = {2:F4}", num1, num2, division);
        }
        else
        {
            Console.WriteLine("Division       ({0} / {1}) = Error: Division by zero is undefined.", num1, num2);
        }

        Console.WriteLine("===========================================================");
    }
}
