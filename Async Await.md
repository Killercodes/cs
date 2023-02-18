# Async Await



```cs
using System;
using System.Threading.Tasks;

class Example
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting the program");

        // Call a method asynchronously
        int result = await LongRunningMethod();

        Console.WriteLine("Result: " + result);
        Console.WriteLine("Program complete");
    }

    static async Task<int> LongRunningMethod()
    {
        Console.WriteLine("Long running method started");

        // Wait for 3 seconds asynchronously
        await Task.Delay(3000);

        Console.WriteLine("Long running method completed");

        // Return a value
        return 42;
    }
}
```

In the above example, the Main method is marked as async, which allows us to use the await keyword to call a method asynchronously. The LongRunningMethod is also marked as async and returns a Task<int>, which represents an asynchronous operation that will return an integer value.

When the program runs, it will print "Starting the program" to the console, call LongRunningMethod asynchronously, and wait for it to complete. LongRunningMethod will print "Long running method started", wait for 3 seconds using Task.Delay, print "Long running method completed", and return the value 42. The Main method will then print "Result: 42" and "Program complete" to the console.

This is just a simple example, but async and await can be used for many different types of asynchronous operations in C#, such as calling web services, reading from files, and more.
