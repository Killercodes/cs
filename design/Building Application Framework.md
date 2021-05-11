# Building Application Framework with C#

## Introduction
Frameworks are generalized and customized application, which can be built upon into a complete and fully functional software programs.

In recent years frameworks have been successfully implemented for some specific application domains, most notably user interfaces and data processing. A successful framework is a breakthrough because it means that developers no longer have to start from scratch: if a framework can successfully generate one user interface, it can generate any user interface.
For example, when using Java Applets and servlets, we just need to override some of the methods to set our code running. 
The Java Applet Programming model and the Java Servlets are built upon the Framework Pattern. Microsoft too has implemented the MFC Class Libraries upon the same Pattern.
## Prerequisite
I assume that the reader should be confident working with C#. Other than that If he/she has the basic understanding of Java Applet and Servlet so as to better understand the basic concept behind this.
## Tools
The code is tested with .NET Framework Release Version running on Windows 2000. The application does not need a graphical interface therefore I used a notepad and the C# command line compiler to finish the code.

## Application Framework using C#
In the following article, you'll see how to implement a basic infrastructure for Application Framework Model. The fundamental concept in building application framework is the template method, which is hidden inside the application and controls the flow of the application. This method is characteristically implemented in the base class and cannot be changed.

The first step is to construct the base class for the framework. The base class is the most important class when building application framework. It consists of override able method, which the end user should override to provide customized application. Apart from these, there is also a template method that as mentioned controls the framework processing.

The framework that we are going to built consist of three abstract methods for the end user to implement. These are init, run and destroy which must be implemented in sequence.So the base class for that kind of framework can be implemented as following.
```cs
    // The class is defined abstract because the customized methods have no definitions 
    abstract class AppFramework
    {
        // the constructor which calls the template methods 
        public AppFramework()
        {
            templateMethod();
        }

        // the method required to be implemented by the end user 

        public abstract void init();
        public abstract void run();
        public abstract void destroy();

        // the template method which is the heart of the framework 
        private void templateMethod()
        {
            Console.WriteLine("Initializing Template Engine");
            // template method calling the necessary function in sequence 
            init();
            run();
            destroy();
            Console.WriteLine("Ending Template Engine");
        }

    }
```
One thing that you should avoid is to make the template method virtual. 
Because it then gives the end user ability to override the template method hence changing the whole framework process flow.

## Implementing the Framework
That is all that is required for the application framework builder to do, the end user performs the next step to inherit the framework base class and override all the abstract class defined the framework base class to provide customized functionality.
```cs
    // class derived from the base class 
    class MyClass : AppFramework
    {

        // methods providing customized implementation for the abstract methods 
        override public void init()
        {
            Console.WriteLine("MyClass::init");
        }

        override public void run()
        {
            Console.WriteLine("MyClass::run");
        }

        override public void destroy()
        {
            Console.WriteLine("MyClass::destroy");
        }

        // the main method defined 
        public static void Main(String[] arg)
        {
            MyClass myClass = new MyClass();
        }
    }
```
Although it is not necessary for the Main method to be included in the same class which overrides the framework methods; it could well be in a separate class. 
The complete code listing is as follows.
  ```cs
  internal abstract class AppFramework
    {
        public AppFramework()
        {
            templateMethod();
        }

        public abstract void init();
        public abstract void run();
        public abstract void destroy();

        private void templateMethod()
        {
            Console.WriteLine("Initializing Template Engine");
            init();
            run();
            destroy();
            Console.WriteLine("Ending Template Engine");
        }
    }
 

    class MyClass : AppFramework
    {
        override public void init()
        {
            Console.WriteLine("MyClass::init");
        }

        override public void run()
        {
            Console.WriteLine("MyClass::run");
        }

        override public void destroy()
        {
            Console.WriteLine("MyClass::destroy");
        }

        public static void Main(String[] arg)
        {
            MyClass myClass = new MyClass();
        }
    }
```
