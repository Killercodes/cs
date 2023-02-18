# Load And Execute dl

When the program runs, it will list the available DLL files, and prompt the user to select a DLL file. It will then list the available types within the selected DLL file, and prompt the user to select a type. Finally, it will list the available methods within the selected type, and prompt the user to select a method. The program will then execute the selected method and print the return value to the console.

Note that this example assumes that the selected method has no parameters and returns an object. You will need to modify the Invoke call to pass in any required parameters and handle the return value appropriately.

```cs
using System;
using System.IO;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        // Specify the directory containing the DLLs
        string dllDirectory = @"C:\path\to\dll\directory";

        // Get the list of DLL files in the directory
        string[] dllFiles = Directory.GetFiles(dllDirectory, "*.dll");

        // Print the list of DLL files
        Console.WriteLine("Select a DLL to load:");
        for (int i = 0; i < dllFiles.Length; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, Path.GetFileName(dllFiles[i]));
        }

        // Read the user's input and load the selected DLL
        Console.Write("Enter the DLL number: ");
        int selectedDllIndex = int.Parse(Console.ReadLine()) - 1;
        string selectedDllFile = dllFiles[selectedDllIndex];
        Assembly assembly = Assembly.LoadFrom(selectedDllFile);

        // Get the list of types in the selected DLL
        Type[] types = assembly.GetTypes();

        // Print the list of types in the selected DLL
        Console.WriteLine("Select a type to load:");
        for (int i = 0; i < types.Length; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, types[i].FullName);
        }

        // Read the user's input and load the selected type
        Console.Write("Enter the type number: ");
        int selectedTypeIndex = int.Parse(Console.ReadLine()) - 1;
        Type selectedType = types[selectedTypeIndex];

        // Get the list of methods in the selected type
        MethodInfo[] methods = selectedType.GetMethods();

        // Print the list of methods in the selected type
        Console.WriteLine("Select a method to execute:");
        for (int i = 0; i < methods.Length; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, methods[i].Name);
        }

        // Read the user's input and execute the selected method
        Console.Write("Enter the method number: ");
        int selectedMethodIndex = int.Parse(Console.ReadLine()) - 1;
        MethodInfo selectedMethod = methods[selectedMethodIndex];
        object result = selectedMethod.Invoke(null, null);

        Console.WriteLine("Method returned: " + result);
    }
}


```
