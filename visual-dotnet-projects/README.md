# Visual .NET Lab Tasks

Clean, standalone, directly runnable C# source files for the lab assignments.

---

### Files Index

| # | File | Description |
|---|------|-------------|
| 1 | `1_HelloWorld.cs` | Prints "Hello World" in C#. |
| 2 | `2_DynamicArithmetic.cs` | Dynamic calculator accepting runtime inputs for `+`, `-`, `*`, and `/` (with division-by-zero handling). |
| 3 | `3_VBDll_Inheritance.cs` | Cross-language inheritance (C# class inheriting from base `Person` class, with `3_Person.vb`). |
| 4 | `4_StudentGrade.cs` | Calculates total, percentage, pass/fail, and grade for 3 subjects using `if-else`. |
| 5 | `5_EmployeeSalary.cs` | Calculates 10 employees' salary using a `for` loop for inputs and a `foreach` loop to display the salary slip. |
| 6 | `6_StudentConstructors.cs` | Displays student info (Name, Age, Address, Course) using both default and parameterized constructors. |
| 7 | `7_StringManipulation.cs` | Dynamic string manipulation demonstrating string properties (`Length`, indexer), methods (`ToUpper`, `Trim`, `Substring`, `Replace`, `Split`), and `StringBuilder`. |
| 8 | `8_Encapsulation.cs` | Demonstrates encapsulation using `get` and `set` properties (data hiding, validation, read-only properties). |
| 9 | `9_Polymorphism.cs` | Demonstrates both compile-time polymorphism (method overloading) and run-time polymorphism (method overriding via `virtual` and `override`). |
| 10 | `10_MultipleExceptions.cs` | Demonstrates handling multiple exceptions (`DivideByZeroException`, `IndexOutOfRangeException`, `FormatException`, `OverflowException`, `NullReferenceException`, and `finally` block). |

---

### How to Compile & Run

#### In PowerShell / Command Prompt:
Using the Windows built-in C# compiler (`csc.exe`):

```powershell
$csc = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"

# Run any program by number:
& $csc 6_StudentConstructors.cs; .\6_StudentConstructors.exe
& $csc 7_StringManipulation.cs; .\7_StringManipulation.exe
& $csc 8_Encapsulation.cs; .\8_Encapsulation.exe
& $csc 9_Polymorphism.cs; .\9_Polymorphism.exe
& $csc 10_MultipleExceptions.cs; .\10_MultipleExceptions.exe
```

#### In Visual Studio:
Open any `.cs` file directly or copy-paste it into any C# Console Application project and press **Ctrl+F5**.
