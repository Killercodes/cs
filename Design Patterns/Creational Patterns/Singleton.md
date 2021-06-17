# Singleton Pattern
> defines an Instance operation that lets clients access its unique instance. Instance is a class operation.
> responsible for creating and maintaining its own unique instance.

The Singleton pattern which assures only a single instance (the singleton) of the class can be created.

```cs
using System;

public class SingletonClass
{
    private static SingletonClass instance;

    static SingletonClass()
    {
        instance = new SingletonClass();
    }

    private SingletonClass() { }

    public static SingletonClass Instance
    {
        get { return instance; }
    }

    public void SomeMethod1() { }
    public void SomeMethod2() { }
}

public class MainClass
{
    public static void Main()
    {
        SingletonClass s = SingletonClass.Instance;
        s.SomeMethod1();

        SingletonClass.Instance.SomeMethod2();

    }
}
```

Example 2
```cs
using System;

  class Client
  {
    static void Main(string[] args)
    {
      try{
        Engine eng = Engine.GetEngine();
      }catch (Exception e){
        Console.WriteLine(e.Message);
      }
      
      try{
        Engine eng = Engine.GetEngine();
      }catch (Exception e){
        Console.WriteLine(e.Message);
      }
    }
  }
  sealed class Engine
  {
    private static bool instanceFlag = false;
    public static Engine GetEngine()
    {
      if (!instanceFlag)
      {  
        instanceFlag = true;
        return new Engine();
      }else{
        throw new Exception("An engine has already been created!");
      }
    }
    private Engine()
    {
      Console.WriteLine("An Engine");
    }
  }
  ```
