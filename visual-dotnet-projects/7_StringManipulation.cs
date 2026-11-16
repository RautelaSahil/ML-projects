using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==========================================================================");
        Console.WriteLine("       Dynamic String Manipulation Methods & Properties in C#             ");
        Console.WriteLine("==========================================================================");

        Console.Write("Enter a string (or press ENTER to use default): ");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
        {
            input = "  Visual .NET Programming in CSharp Language  ";
        }

        Console.WriteLine("\n[1] ORIGINAL INPUT STRING:");
        Console.WriteLine("--> Raw String : \"" + input + "\"");

        // 1. String Properties
        Console.WriteLine("\n[2] STRING PROPERTIES:");
        Console.WriteLine("--> Length                   : " + input.Length);
        if (input.Length > 0)
        {
            Console.WriteLine("--> First Character (Chars[0]): '" + input[0] + "'");
            Console.WriteLine("--> Last Character           : '" + input[input.Length - 1] + "'");
        }

        // 2. String Case Manipulation
        Console.WriteLine("\n[3] CASE CONVERSION:");
        Console.WriteLine("--> ToUpper()                : \"" + input.ToUpper() + "\"");
        Console.WriteLine("--> ToLower()                : \"" + input.ToLower() + "\"");

        // 3. Trimming
        Console.WriteLine("\n[4] TRIMMING METHODS:");
        string trimmed = input.Trim();
        Console.WriteLine("--> Trim()                   : \"" + trimmed + "\" (Length: " + trimmed.Length + ")");
        Console.WriteLine("--> TrimStart()              : \"" + input.TrimStart() + "\"");
        Console.WriteLine("--> TrimEnd()                : \"" + input.TrimEnd() + "\"");

        // 4. Searching & Inspecting
        Console.WriteLine("\n[5] SEARCHING & CHECKING:");
        Console.WriteLine("--> Contains(\"CSharp\")        : " + trimmed.Contains("CSharp"));
        Console.WriteLine("--> StartsWith(\"Visual\")      : " + trimmed.StartsWith("Visual"));
        Console.WriteLine("--> EndsWith(\"Language\")     : " + trimmed.EndsWith("Language"));
        Console.WriteLine("--> IndexOf(\"NET\")           : " + trimmed.IndexOf("NET"));

        // 5. Extraction & Modification
        Console.WriteLine("\n[6] EXTRACTION & MODIFICATION:");
        if (trimmed.Length >= 6)
        {
            Console.WriteLine("--> Substring(0, 6)          : \"" + trimmed.Substring(0, 6) + "\"");
        }
        Console.WriteLine("--> Replace(\"CSharp\", \"VB.NET\") : \"" + trimmed.Replace("CSharp", "VB.NET") + "\"");
        Console.WriteLine("--> Insert(0, \"Advanced \")     : \"" + trimmed.Insert(0, "Advanced ") + "\"");
        if (trimmed.Length > 11)
        {
            Console.WriteLine("--> Remove(7, 4)             : \"" + trimmed.Remove(7, 4) + "\"");
        }

        // 6. Splitting & Joining
        Console.WriteLine("\n[7] SPLIT AND JOIN:");
        string[] words = trimmed.Split(' ');
        Console.WriteLine("--> Split into words count   : " + words.Length);
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine("    Word[" + i + "] = " + words[i]);
        }
        Console.WriteLine("--> String.Join(\"-\", words)  : " + string.Join("-", words));

        // 7. Dynamic Mutable String via StringBuilder
        Console.WriteLine("\n[8] DYNAMIC MODIFICATION USING STRINGBUILDER:");
        StringBuilder sb = new StringBuilder(trimmed);
        Console.WriteLine("--> Initial StringBuilder    : " + sb.ToString());
        sb.Append(" - Lab Task 2026");
        Console.WriteLine("--> After Append()           : " + sb.ToString());
        sb.Insert(0, ">> ");
        Console.WriteLine("--> After Insert()           : " + sb.ToString());
        sb.Replace("Visual", "Modern");
        Console.WriteLine("--> After Replace()          : " + sb.ToString());

        Console.WriteLine("\n==========================================================================");
    }
}
