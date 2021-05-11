# Using The ThreadPool
 
A thread pool takes away all the need to manage your threads - all you have to do is essentially say "hey! someone should go do this work!", and a thread in the process' thread pool will pick up the task and go execute it. And that is all there is to it. Granted, you still have to keep threads from stepping on each other's toes, and you probably care about when these 'work items' are completed - but it is at least a really easy way to queue up a work item.

In fact, working with the ThreadPool is so easy, I'm going to throw all the code at you at once. Below is a pretty simple test app that gives 5 (or NumThreads) work items to theThreadPool, waits for them all to complete, and then prints out all the answers. I will walk through the code step by step below:
```cs
using System;
using System.Threading;

namespace ThreadPoolTest
{
  class Program
  {
    private const int NumThreads = 5;

    private static int[] inputArray;
    private static double[] resultArray;
    private static ManualResetEvent[] resetEvents;

    private static void Main(string[] args)
    {
      inputArray = new int[NumThreads];
      resultArray = new double[NumThreads];
      resetEvents = new ManualResetEvent[NumThreads];

      Random rand = new Random();
      for (int s = 0; s < NumThreads; s++)
      {
        inputArray[s] = rand.Next(1,5000000);
        resetEvents[s] = new ManualResetEvent(false);
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), (object)s);
      }

      Console.WriteLine("Waiting...");

      WaitHandle.WaitAll(resetEvents);

      Console.WriteLine("And the answers are: ");
      for (int i = 0; i < NumThreads; i++)
        Console.WriteLine(inputArray[i] + " -> " + resultArray[i]);
    }

    private static void DoWork(object o)
    {
      int index = (int)o;

      for (int i = 1; i < inputArray[index]; i++)
        resultArray[index] += 1.0 / (i * (i + 1));

      resetEvents[index].Set();
    }
  }
}
```
We have three arrays at the top of the program: one for input to the work items (`inputArray`), one for the results (`resultArray`), and one for the *ManualResetEvents* (`resetEvents`). The first two are self explanatory, but what is a `ManualResetEvent` ? Well, it is an object that allows one thread to signal another thread when something happens. In the case of this code, we use these events to signal the main thread that a work item has been completed.

So we initialize these arrays, and then we get to a for loop, which is where we will be pushing out these work items. First, we make a random value for the initial input (cause random stuff is always more fun!), then we create a ManualResetEvent with its signaled state initially set to false, and then we queue the work item. Thats right, all you have to do to push a work item out for the ThreadPool to do is callThreadPool.QueueUserWorkItem.

So what are we queuing here? Well, we are saying that a thread in the thread pool should run the method DoWork, with the argument s. Any method that you want to queue up for the thread pool to run needs to take one argument, an object, and return void. The argument will end up being whatever you passed in as the second argument to the QueueUserWorkItem call - and in this case is the 'index' of this work item (the index in the various arrays that it needs to work with). And it makes sense that the method would have to return void - because it isn't actually returning 'to' anything, it is running out there all on its own as a separate thread.

So what are we doing in this DoWork function? Not that much in this case, just a simple summation. The important part is the very last call of the function, which is hit when all the work for this work item is done - resetEvents[index].Set(). This triggers theManualResetEvent for this work item - signaling the main thread that the work is all done here.
Back up in main thread land, after it has pushed all these work items onto theThreadPool queue, we hit the very important call WaitHandle.WaitAll(resetEvents). This causes the main thread to block here until all the ManualResetEvent objects in theresetEvents array signal. When all of them have signaled, that means that all the work units have been completed, and so we continue on and print out all the results. The results change because we are seeding with random values, but here is one example output:
```cs
Waiting...
And the answers are:
3780591 -> 0.991001809831479
3555614 -> 0.991163782231558
2072717 -> 0.989816715560308
2264396 -> 0.989982111762391
544144 -> 0.99066981542858
```
Pretty simple, eh? There are a couple things to note, though. 
- The default thread pool size for a process is 25 threads, and while you can change this number, this resource is not infinite. 
- If all of the threads in the pool are currently occupied with other tasks, new work items will be queued up, but they won't get worked on until one of the occupied threads finishes its current task. 
- This generally isn't a problem unless you are giving the pool very large quantities of work. And really, you should never assume that a task is executed immediately after you queue it, because there is no guarantee of that at all.
