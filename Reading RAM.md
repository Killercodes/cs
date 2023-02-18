# Reading RAM

In C#, you can read the current system memory usage by using the System.Diagnostics namespace. Specifically, you can use the PerformanceCounter class to get the current value of the "Available Bytes" performance counter, which indicates the amount of physical memory available to the system.

Here is an example code that shows how to read the current system memory usage:

```cs
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        PerformanceCounter availableBytesCounter = new PerformanceCounter("Memory", "Available Bytes");
        float availableBytes = availableBytesCounter.NextValue() / 1024 / 1024;
        Console.WriteLine("Available memory: {0} MB", availableBytes);
    }
}
```

In this example, we create a new PerformanceCounter object with the category name "Memory" and the counter name "Available Bytes". We then call the NextValue() method on the counter to get the current value of the counter, which represents the number of bytes of physical memory available to the system. We divide this value by 1024 twice to convert it from bytes to megabytes, and then print the result to the console.
