using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==========================================================================");
        Console.WriteLine("          Handling Multiple Exceptions in C# (try-catch-finally)          ");
        Console.WriteLine("==========================================================================");

        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine("\nSelect an exception scenario to test:");
            Console.WriteLine("  1. DivideByZeroException       (Divide an integer by 0)");
            Console.WriteLine("  2. IndexOutOfRangeException     (Access invalid array element)");
            Console.WriteLine("  3. FormatException              (Parse non-numeric text to int)");
            Console.WriteLine("  4. OverflowException            (Enter a number exceeding int limits)");
            Console.WriteLine("  5. NullReferenceException       (Access member of null object)");
            Console.WriteLine("  6. Successful Execution         (No exception thrown)");
            Console.WriteLine("  7. Run All Tests Automatically");
            Console.WriteLine("  8. Exit");
            Console.Write("\nEnter choice (1-8): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "8")
            {
                keepRunning = false;
                Console.WriteLine("Exiting program. Goodbye!");
                break;
            }
            else if (choice == "7")
            {
                RunAllTests();
                break;
            }
            else
            {
                ExecuteScenario(choice);
            }
        }

        Console.WriteLine("==========================================================================");
    }

    static void ExecuteScenario(string choice)
    {
        int[] numbers = new int[] { 10, 20, 30, 40, 50 };

        try
        {
            Console.WriteLine("[TRY BLOCK STARTED]");

            switch (choice)
            {
                case "1":
                    Console.Write("Enter numerator (e.g. 50): ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter denominator (enter 0 to trigger exception): ");
                    int den = Convert.ToInt32(Console.ReadLine());
                    int result = num / den; // Integer division by 0 throws DivideByZeroException
                    Console.WriteLine("Result: " + num + " / " + den + " = " + result);
                    break;

                case "2":
                    Console.WriteLine("Array length is " + numbers.Length + " (valid indices: 0 to 4).");
                    Console.Write("Enter index to retrieve (e.g. 10 to trigger error): ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Value at index " + index + " = " + numbers[index]);
                    break;

                case "3":
                    Console.Write("Enter an integer value (enter letters like 'abc' to trigger error): ");
                    string text = Console.ReadLine();
                    int parsed = int.Parse(text);
                    Console.WriteLine("Successfully parsed integer: " + parsed);
                    break;

                case "4":
                    Console.Write("Enter a number exceeding 2,147,483,647 (e.g. 999999999999): ");
                    string bigText = Console.ReadLine();
                    int bigNum = checked(int.Parse(bigText));
                    Console.WriteLine("Parsed value: " + bigNum);
                    break;

                case "5":
                    Console.WriteLine("Triggering NullReferenceException...");
                    string nullStr = null;
                    int length = nullStr.Length; // Accessing null object
                    Console.WriteLine("String length: " + length);
                    break;

                case "6":
                    Console.WriteLine("Performing safe math: 100 / 5 = " + (100 / 5));
                    Console.WriteLine("Accessing numbers[2] = " + numbers[2]);
                    break;

                default:
                    Console.WriteLine("Invalid choice! Please select 1 through 8.");
                    break;
            }

            Console.WriteLine("[TRY BLOCK COMPLETED WITHOUT ERROR]");
        }
        // Specific Exception Handler 1: Division by Zero
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("\n[CAUGHT DivideByZeroException]");
            Console.WriteLine("--> Message : " + ex.Message);
            Console.WriteLine("--> Reason  : Cannot divide an integer by zero in arithmetic operations.");
        }
        // Specific Exception Handler 2: Array Index Out of Range
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("\n[CAUGHT IndexOutOfRangeException]");
            Console.WriteLine("--> Message : " + ex.Message);
            Console.WriteLine("--> Reason  : Array index was outside the valid bounds of the array.");
        }
        // Specific Exception Handler 3: Invalid Format
        catch (FormatException ex)
        {
            Console.WriteLine("\n[CAUGHT FormatException]");
            Console.WriteLine("--> Message : " + ex.Message);
            Console.WriteLine("--> Reason  : Input string was not in a format recognized as valid.");
        }
        // Specific Exception Handler 4: Numeric Overflow
        catch (OverflowException ex)
        {
            Console.WriteLine("\n[CAUGHT OverflowException]");
            Console.WriteLine("--> Message : " + ex.Message);
            Console.WriteLine("--> Reason  : The number is too large or too small for a 32-bit signed integer.");
        }
        // Specific Exception Handler 5: Null Reference
        catch (NullReferenceException ex)
        {
            Console.WriteLine("\n[CAUGHT NullReferenceException]");
            Console.WriteLine("--> Message : " + ex.Message);
            Console.WriteLine("--> Reason  : Attempted to dereference an object variable pointing to null.");
        }
        // General Catch-All Handler (Must be placed last)
        catch (Exception ex)
        {
            Console.WriteLine("\n[CAUGHT Generic Exception: " + ex.GetType().Name + "]");
            Console.WriteLine("--> Message : " + ex.Message);
        }
        // Finally Block (Always executes, regardless of exception or success)
        finally
        {
            Console.WriteLine("\n[FINALLY BLOCK]");
            Console.WriteLine("--> The 'finally' block is always executed for cleanup / closing resources.");
            Console.WriteLine("--------------------------------------------------------------------------");
        }
    }

    static void RunAllTests()
    {
        Console.WriteLine("--- Running Automated Tests for All Exceptions ---\n");

        string[] tests = new string[] { "1", "2", "3", "4", "5", "6" };
        string[] testNames = new string[]
        {
            "DivideByZeroException",
            "IndexOutOfRangeException",
            "FormatException",
            "OverflowException",
            "NullReferenceException",
            "Successful Run (No Exception)"
        };

        for (int i = 0; i < tests.Length; i++)
        {
            Console.WriteLine(">>> TEST " + (i + 1) + ": " + testNames[i] + " <<<");
            try
            {
                if (tests[i] == "1") { int a = 10, b = 0; int c = a / b; }
                else if (tests[i] == "2") { int[] arr = new int[2]; int val = arr[5]; }
                else if (tests[i] == "3") { int parsed = int.Parse("NotANumber"); }
                else if (tests[i] == "4") { int over = int.Parse("99999999999999"); }
                else if (tests[i] == "5") { string s = null; int len = s.Length; }
                else if (tests[i] == "6") { Console.WriteLine("Safe operations executed successfully!"); }
            }
            catch (DivideByZeroException ex) { Console.WriteLine("[CAUGHT] DivideByZeroException: " + ex.Message); }
            catch (IndexOutOfRangeException ex) { Console.WriteLine("[CAUGHT] IndexOutOfRangeException: " + ex.Message); }
            catch (FormatException ex) { Console.WriteLine("[CAUGHT] FormatException: " + ex.Message); }
            catch (OverflowException ex) { Console.WriteLine("[CAUGHT] OverflowException: " + ex.Message); }
            catch (NullReferenceException ex) { Console.WriteLine("[CAUGHT] NullReferenceException: " + ex.Message); }
            catch (Exception ex) { Console.WriteLine("[CAUGHT] General Exception: " + ex.Message); }
            finally { Console.WriteLine("[FINALLY] Cleanup complete.\n"); }
        }
    }
}
