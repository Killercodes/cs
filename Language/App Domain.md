# App Domain

An application domain is a mechanism (similar to a process in an operating system) used within the Common Language Infrastructure (CLI) to isolate executed software applications from one another so that they do not affect each other. Each application domain has its own virtual address space which scopes the resources for the application domain using that address space.

> Creating multiple application domains in the same process is not possible in .NET Core and .NET 5+.

## Creating 
```cs
using System;

class MainClass
{
  public static void Main() 
  {
    AppDomain d = AppDomain.CreateDomain("NewDomain");
    Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
    Console.WriteLine(d.FriendlyName);
  }
}
```

## Use AppDomain to execute Assembly
```cs
using System;

class MainClass
{
    public static void Main(string[] args)
    {
        if (AppDomain.CurrentDomain.FriendlyName != "NewAppDomain")
        {
            AppDomain domain = AppDomain.CreateDomain("NewAppDomain");

            domain.ExecuteAssembly("MainClass.exe", null, args);
        }

        foreach (string s in args)
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName + " : " + s);
        }
    }
}
```

## Get and set data to AppDomain 
```cs
using System;
using System.Reflection;
using System.Collections;

class MainClass
{
    public static void Main() 
    {
        AppDomain domain = AppDomain.CreateDomain("Test");

        ArrayList list = new ArrayList();
        list.Add("d");
        list.Add("c");
        list.Add("f");

        domain.SetData("Pets", list);

        foreach (string s in (ArrayList)domain.GetData("Pets"))
        {
            Console.WriteLine("  - " + s);
        }
    }
}
```

## Print All Assemblies In AppDomain
```cs
using System;
using System.Reflection;
using System.Windows.Forms;
  
public class MainClass
{
  public static int Main(string[] args)
  {
    AppDomain defaultAD = AppDomain.CurrentDomain;
    Console.WriteLine("This call loaded System.Windows.Forms.dll and System.dll");

    Assembly[] loadedAssemblies = defaultAD.GetAssemblies();      
    Console.WriteLine("Here are the assemblies loaded in {0}\n",defaultAD.FriendlyName);
    foreach(Assembly a in loadedAssemblies)
    {
      Console.WriteLine("-> Name: {0}", a.GetName().Name);
      Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
    }

    return 0;
  }
}
```

## Make a new AppDomain in the current process
```cs
using System;
using System.Reflection;
using System.Windows.Forms;
  
public class MainClass
{
  public static int Main(string[] args)
  {
    AppDomain defaultAD = AppDomain.CreateDomain("SecondAppDomain");

    Assembly[] loadedAssemblies = defaultAD.GetAssemblies();      
    Console.WriteLine("Here are the assemblies loaded in {0}\n",defaultAD.FriendlyName);
    foreach(Assembly a in loadedAssemblies)
    {
      Console.WriteLine("-> Name: {0}", a.GetName().Name);
      Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
    }

    return 0;
  }
}
```

## Handle AppDomain Event: DomainUnload 
```cs
using System;
using System.Reflection;
using System.Windows.Forms;
  
public class MainClass
{
  public static void defaultAD_DomainUnload(object sender, EventArgs e)
  {
    Console.WriteLine("Unloaded defaultAD!");
  }
  private static void defaultAD_ProcessExit(object sender, EventArgs e)
  {
    Console.WriteLine("Unloaded defaultAD!");
  }

  public static int Main(string[] args)
  {
    AppDomain defaultAD = AppDomain.CreateDomain("SecondAppDomain");

    defaultAD.DomainUnload += new EventHandler(defaultAD_DomainUnload);
    defaultAD.ProcessExit +=new EventHandler(defaultAD_ProcessExit);

    // Now unload anotherAD.
    AppDomain.Unload(defaultAD);

    return 0;
  }
}
```

## Create object using AppDomain
```cs
using System;
using System.Runtime.Remoting;

class MainClass
{
  [MTAThread]
  static void Main(string[] args)
  {
    AppDomain Domain2 = AppDomain.CreateDomain("AppDomainB");
    MainClass MyMyClass = (MainClass)Domain2.CreateInstanceAndUnwrap("YourNameSpace", "YourClassName");

  }
}
```

## An object in another application domain 
```cs
using System;
using System.Runtime.Remoting;
using System.Reflection;

class MainClass
{

  public static void Main() 
  {
    AppDomain d = AppDomain.CreateDomain("NewDomain");
    
    ObjectHandle hobj = d.CreateInstance("AnotherDomain", "SimpleObject");
    SimpleObject so = (SimpleObject) hobj.Unwrap();
    Console.WriteLine(so.Display("make this uppercase"));
  }

}


[Serializable]
public class SimpleObject 
{

  public String Display(String inString)
  {
    return(inString.ToUpper());
  }

}
```

## Unloading an application domain 
```cs
using System;
using System.Runtime.Remoting;
using System.Reflection;

class MainClass
{
  public static void Main() 
  {
    AppDomain d = AppDomain.CreateDomain("NewDomain");
    
    ObjectHandle hobj = d.CreateInstance("AnotherDomain", "SimpleObject");
    SimpleObject so = (SimpleObject) hobj.Unwrap();
    Console.WriteLine(so.Display("make this uppercase"));

    AppDomain.Unload(d);
    Console.WriteLine(so.Display("make this uppercase"));

  }

}


[Serializable]
public class SimpleObject 
{

  public String Display(String inString)
  {
    return(inString.ToUpper());
  }

}
```

## Configure the application domain setup information
```cs
using System;

class MainClass
{
    public static void Main()
    {
        AppDomainSetup setupInfo = new AppDomainSetup();


        setupInfo.ApplicationBase = @"C:\MyRootDirectory";
        setupInfo.ConfigurationFile = "MyApp.config";
        setupInfo.PrivateBinPath = "bin;plugins;external";

        AppDomain newDomain = AppDomain.CreateDomain("My New AppDomain", null, setupInfo);

    }
}
```

