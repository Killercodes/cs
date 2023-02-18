# Get File Size

```cs
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Specify the path to the text file
        string filePath = @"C:\path\to\file.txt";

        // Read the text from the file
        string fileText = File.ReadAllText(filePath);

        // Get the file size in bytes
        long fileSizeBytes = new FileInfo(filePath).Length;

        // Convert the file size to kilobytes (KB)
        double fileSizeKB = fileSizeBytes / 1024.0;

        // Print the file text and size in KB to the console
        Console.WriteLine("File text: " + fileText);
        Console.WriteLine("File size: " + fileSizeKB.ToString("N2") + " KB");
    }
}
```
In the above example, replace the filePath variable with the path to the text file that you want to read. The program uses the File.ReadAllText method to read the entire text content of the file into a string variable. It then uses the FileInfo class to get the length of the file in bytes and converts it to kilobytes by dividing by 1024. Finally, it prints the file text and size in KB to the console.

Note that if the file is very large, it may not be efficient to read the entire text content into a single string variable. In that case, you may want to read the file contents line-by-line or use a different approach to read the file in chunks.

