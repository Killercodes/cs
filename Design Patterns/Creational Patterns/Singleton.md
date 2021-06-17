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
