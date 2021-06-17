# Attributes

An attribute is a declarative tag that is used to convey information to runtime about the behaviors of various elements like classes, methods, structures, enumerators, assemblies etc. in your program. You can add declarative information to a program by using an attribute. A declarative tag is depicted by square ([ ]) brackets placed above the element it is used for.

Attributes are used for adding metadata, such as compiler instruction and other information such as comments, description, methods and classes to a program. The .Net Framework provides two types of attributes: the pre-defined attributes and custom built attributes.

## AttributeUsage
The pre-defined attribute AttributeUsage describes how a custom attribute class can be used. It specifies the types of items to which the attribute can be applied.
```cs
[AttributeUsage(
   AttributeTargets.Class |
   AttributeTargets.Constructor |
   AttributeTargets.Field |
   AttributeTargets.Method |
   AttributeTargets.Property, 
   AllowMultiple = true)]
```

## Use Attributes to mark a method

You can add declarative information to a program by using an attribute.

An attribute defines additional information that is associated with a class, structure, method, and so on.

- An attribute is supported by a class that inherits System.Attribute.
- All attribute classes must be subclasses of System.Attribute.
- This built-in attribute AttributeUsage specifies the types of items to which the attribute can be applied.
using System.Diagnostics;

```cs
class MainClass
{
    [Conditional("DEBUG")]
    public void Validate()
    {
    }
}
```
C# defines three built-in attributes:
- AttributeUsage,
- Conditional,
- Obsolete.

## Assembly-Level Attributes

Attribute                                      |Meaning
--|--
AssemblyCompanyAttribute                       |basic company information
AssemblyCopyrightAttribute                     |any copyright information
AssemblyCultureAttribute                       |information on cultures or languages
AssemblyDescriptionAttribute                   |a description of the product
AssemblyKeyFileAttribute                       |the name of the file containing the key pair
AssemblyOperatingSystemAttribute               |operating system
AssemblyProcessorAttribute                     |processors to support
AssemblyProductAttribute                       |Provides product information
AssemblyTrademarkAttribute                     |Provides trademark information
AssemblyVersionAttribute                      |assembly's version information, in the format <major.minor.build.revision>


## Custom Attributes

```cs
using System;
using System.Collections.Generic;
using System.Text;

    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Constructor |
                    AttributeTargets.Field |
                    AttributeTargets.Method |
                    AttributeTargets.Property,
                    AllowMultiple = true)]
    public class BugFixAttribute : System.Attribute
    {
        public int      BugID;
        public string   Date;
        public string   Programmer;
        public string   Comment;

        public BugFixAttribute(int bugID,string programmer,string date){
            this.BugID = bugID;
            this.Programmer = programmer;
            this.Date = date;
        }
    }
    [BugFixAttribute(1, "B", "01/04/05",Comment = "value")]
    public class MyMath
    {
        public double DoFunc1(double param1)
        {
            return param1 + DoFunc2(param1);
        }

        public double DoFunc2(double param1)
        {
            return param1 / 3;
        }
    }
```

## Providing an Attribute Constructor

```cs
using System;
public class CommandLineSwitchAliasAttribute : Attribute
{
   public CommandLineSwitchAliasAttribute(string alias)
   {
       Alias = alias;
   }
   public string Alias
   {
      get { return _Alias; }
      set { _Alias = value; }
  }
  private string _Alias;
}
class CommandLineInfo
{
  [CommandLineSwitchAliasAttribute("?")]
  public bool Help
  {
      get { return _Help; }
      set { _Help = value; }
  }
  private bool _Help;

}
```

## Retrieving a Specific Attribute and Checking Its Initialization

```cs
using System;
using System.Reflection;
public class CommandLineSwitchAliasAttribute : Attribute
{
    public CommandLineSwitchAliasAttribute(string alias)
    {
        Alias = alias;
    }
    public string Alias
    {
        get { return _Alias; }
        set { _Alias = value; }
    }
    private string _Alias;
}
class CommandLineInfo
{
    [CommandLineSwitchAliasAttribute("?")]
    public bool Help
    {
        get { return _Help; }
        set { _Help = value; }
    }
    private bool _Help;

}


class MainClass
{
    static void Main()
    {
        PropertyInfo property = typeof(CommandLineInfo).GetProperty("Help");
        CommandLineSwitchAliasAttribute attribute = (CommandLineSwitchAliasAttribute)property.GetCustomAttributes(typeof(CommandLineSwitchAliasAttribute), false)[0];
        if (attribute.Alias == "?")
        {
            Console.WriteLine("Help(?)");
        };
    }
}
```

## Saving a Document Using System.SerializableAttribute

```cs
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
  public static void Main()
  {
      Stream stream;
      Document documentBefore = new Document();
      documentBefore.Title ="test";
      Document documentAfter;

      using (stream = File.Open(documentBefore.Title + ".bin", FileMode.Create))
      {
          BinaryFormatter formatter = new BinaryFormatter();
          formatter.Serialize(stream, documentBefore);
      }

      using (stream = File.Open(documentBefore.Title + ".bin", FileMode.Open))
      {
          BinaryFormatter formatter = new BinaryFormatter();
          documentAfter = (Document)formatter.Deserialize(stream);
      }

      Console.WriteLine(documentAfter.Title);
  }
}
[Serializable]
class Document
{

  public string Title = null;
  public string Data = null;

  [NonSerialized]
  public long _WindowHandle = 0;

  class Image
  {
  }
  [NonSerialized]
                            private Image Picture = new Image();
}
```

## Obsolete Attribute 

The Obsolete attribute is short for System.ObsoleteAttribute
The Obsolete attribute lets you mark a program element as obsolete.

It has this general form:
```cs
[Obsolete("message")]
```
A second form of Obsolete is shown here:
```cs
[Obsolete("message", error)]
```
error is a Boolean value.
If error is true, then the obsolete item generates a compilation error rather than a warning.

Example:
```cs
using System; 
 
class MainClass { 
 
  [Obsolete("Use myMeth2, instead.")]  
  static int myMethod(int a, int b) { 
    return 0; 
  } 
 
  // Improved version of myMethod. 
  static int myMethod2(int a, int b) { 
    return 1; 
  } 
 
  public static void Main() { 
   // warning displayed for this 
    Console.WriteLine("4 / 3 is " + myMethod(4, 3)); 
 
   // no warning here 
    Console.WriteLine("4 / 3 is " + myMethod2(4, 3));  
  } 
}
```

## warn the user that Method is obsolete

```cs
using System;

class MainClass
{

  
  [Obsolete("Method1 has been replaced by NewMethod1", false)]
  public static int Method1()
  {
    return 1;
  }

  public static void Main() 
  {

    Console.WriteLine(Method1());


  }

}
```

## Obsolete attribute: throw an error
```cs
using System;

class MainClass
{
  
  [Obsolete("Method2 has been replaced by NewMethod2", true)]
  public static int Method2()
  {
    return 2;
  }

  public static void Main() 
  {
    Console.WriteLine(Method2());
  }

}
```

# Conditional Attribute :

- The Conditional Attribute allows you to create conditional methods.
- A conditional method is invoked only when a specific symbol has been defined via #define.
Otherwise, the method is bypassed.
- A conditional method offers an alternative to conditional compilation using #if.
- Conditional is another name for System.Diagnostics.ConditionalAttribute.
- To use the Conditional attribute, you must include the System.Diagnostics namespace.

Conditional methods have a few restrictions.
- Conditional methods must return void.
- Conditional methods must be members of a class, not an interface.
- Conditional methods cannot be preceded with the override keyword.

```cs
#define TRIAL 
 
using System; 
using System.Diagnostics; 
 
class MainClass { 
 
  [Conditional("TRIAL")]  
  void trial() { 
    Console.WriteLine("Trial version, not for distribution."); 
  } 
 
  [Conditional("RELEASE")]  
  void release() { 
    Console.WriteLine("Final release version."); 
  } 
 
  public static void Main() { 
    MainClass t = new MainClass(); 
 
    t.trial(); // call only if TRIAL is defined 
    t.release(); // called only if RELEASE is defined 
  } 
}
```

## Conditional attribute setting in Compile parameter
```cs
// csc /define:DEBUG MainClass.cs

using System;
using System.Diagnostics;  

public class MyClass {

  [Conditional("DEBUG")]
  public void OnlyWhenDebugIsDefined( ) {
    Console.WriteLine("DEBUG is defined");
  }
}



public class MainClass {

  public static void Main( ) {

    MyClass f = new MyClass( );
    f.OnlyWhenDebugIsDefined( );
  }
}
```

## Attribute Definition
```cs
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
public class AuthorAttribute : System.Attribute
{
    public string Company; 
    public string Name;    

    public AuthorAttribute(string name)
    {
        this.Name = name;
        Company = "";
    }
}


[Author("Name1")]
[Author("Name2", Company = "Ltd.")]
class MainClass
{
    public static void Main()
    {
        Type type = typeof(MainClass);

        object[] attrs = type.GetCustomAttributes(typeof(AuthorAttribute), true);

        foreach (AuthorAttribute a in attrs)
        {
            Console.WriteLine(a.Name + ", " + a.Company);
        }
    }
}
```

## Attribute with supplement information
```cs
using System;

[AttributeUsage(AttributeTargets.All)] 
public class MyAttribute : Attribute { 
  string remark;
 
  public string supplement;
 
  public MyAttribute(string comment) { 
    remark = comment; 
    supplement = "None"; 
  } 
 
}
```

## Use a named attribute parameter

```cs
using System;  
using System.Reflection; 
  
[AttributeUsage(AttributeTargets.All)] 
public class MyAttribute : Attribute { 
  public string remark;
 
  public string supplement; 
 
  public MyAttribute(string comment) { 
    remark = comment; 
    supplement = "None"; 
  } 
 
  public string Remark { 
    get { 
      return remark; 
    } 
  } 
}  
 
[MyAttribute("This class uses an attribute.", 
                 supplement = "This is additional info.")] 
class UseAttrib { 
} 
 
class MainClass {  
  public static void Main() {  
    Type t = typeof(UseAttrib); 
 
    Console.Write("Attributes in " + t.Name + ": "); 
 
    object[] attribs = t.GetCustomAttributes(false);  
    foreach(object o in attribs) { 
      Console.WriteLine(o); 
    } 
 
    // Retrieve the MyAttribute. 
    Type tRemAtt = typeof(MyAttribute); 
    MyAttribute ra = (MyAttribute) 
          Attribute.GetCustomAttribute(t, tRemAtt); 
 
    Console.Write("Remark: "); 
    Console.WriteLine(ra.remark); 
 
    Console.Write("Supplement: "); 
    Console.WriteLine(ra.supplement); 
  }  
}
```

## Use a property as a named attribute parameter

```cs
using System;  
using System.Reflection; 
  
[AttributeUsage(AttributeTargets.All)] 
public class MyAttribute : Attribute { 
  public string remark;
 
  public int priority; 
 
  public string supplement; 
 
  public MyAttribute(string comment) { 
    remark = comment; 
    supplement = "None"; 
  } 
 
  public string Remark { 
    get { 
      return remark; 
    } 
  } 
 
  public int Priority { 
    get { 
      return priority; 
    } 
    set { 
      priority = value; 
    } 
  } 
}  
 
[MyAttribute("This class uses an attribute.", 
                 supplement = "This is additional info.", 
                 Priority = 10)] 
class UseAttrib { 
} 
 
class MainClass {  
  public static void Main() {  
    Type t = typeof(UseAttrib); 
 
    Console.Write("Attributes in " + t.Name + ": "); 
 
    object[] attribs = t.GetCustomAttributes(false);  
    foreach(object o in attribs) { 
      Console.WriteLine(o); 
    } 
 
    // Retrieve the MyAttribute. 
    Type tRemAtt = typeof(MyAttribute); 
    MyAttribute ra = (MyAttribute) 
          Attribute.GetCustomAttribute(t, tRemAtt); 
 
    Console.Write("Remark: "); 
    Console.WriteLine(ra.remark); 
 
    Console.Write("Supplement: "); 
    Console.WriteLine(ra.supplement); 
 
    Console.WriteLine("Priority: " + ra.priority); 
  }  
}
```

## custom attribute based on bool value

```cs
using System;

public class TrueFalseAttribute : Attribute
{
  bool bWritten;

  public bool Written()
  {
    return bWritten;
  }

  public TrueFalseAttribute(bool Written)
  {
    bWritten = Written;
  }
}

[TrueFalseAttribute(true)]
public class Class1
{
}

[TrueFalseAttribute(false)]
public class Class2
{
}

class MainClass
{
  public static void Main() 
  {
    TrueFalseAttribute u;
    Console.Write("Class1 TrueFalseAttribute attribute: ");
    u = (TrueFalseAttribute) Attribute.GetCustomAttribute(typeof(Class1), typeof(TrueFalseAttribute));
    Console.WriteLine(u.Written());
    Console.Write("Class2 TrueFalseAttribute attribute: ");
    u = (TrueFalseAttribute) Attribute.GetCustomAttribute(typeof(Class2), typeof(TrueFalseAttribute));
    Console.WriteLine(u.Written());
  }
}
```

# Attribute Reflection

```cs
using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]

public class CodeReviewAttribute: System.Attribute
{
    public CodeReviewAttribute(string reviewer, string date)
    {
        this.reviewer = reviewer;
        this.date = date;
    }
    public string Comment
    {
        get
        {
            return(comment);
        }
        set
        {
            comment = value;
        }
    }
    public string Date
    {
        get
        {
            return(date);
        }
    }
    public string Reviewer
    {
        get
        {
            return(reviewer);
        }
    }
    string reviewer;
    string date;
    string comment;
}

[CodeReview("Name1", "01-12-2000", Comment="comment1")]
[CodeReview("Name2", "01-01-2012", Comment="comment2")]
class Complex
{
}

class MainClass
{
    public static void Main()
    {
        Type type = typeof(Complex);
        foreach (CodeReviewAttribute att in
        type.GetCustomAttributes(typeof(CodeReviewAttribute), false))
        {
            Console.WriteLine("Reviewer: {0}", att.Reviewer);
            Console.WriteLine("Date: {0}", att.Date);
            Console.WriteLine("Comment: {0}", att.Comment);
        }
    }
}
```

## Retrieve Attribute by using reflection
```cs
using System;  
using System.Reflection; 
  
[AttributeUsage(AttributeTargets.All)] 
public class MyAttribute : Attribute { 
  public string remark; 
 
  public MyAttribute(string comment) { 
    remark = comment; 
  } 
 
  public string Remark { 
    get { 
      return remark; 
    } 
  } 
}  
 
[MyAttribute("This class uses an attribute.")] 
class UseAttrib { 
} 
 
class MainClass {  
  public static void Main() {  
    Type t = typeof(UseAttrib); 
 
    Console.Write("Attributes in " + t.Name + ": "); 
 
    object[] attribs = t.GetCustomAttributes(false);  
    foreach(object o in attribs) { 
      Console.WriteLine(o); 
    } 
 
    Console.Write("Remark: "); 
 
    // Retrieve the MyAttribute. 
    Type tRemAtt = typeof(MyAttribute); 
    MyAttribute ra = (MyAttribute) 
          Attribute.GetCustomAttribute(t, tRemAtt); 
 
    Console.WriteLine(ra.remark); 
  }  
}
```

## Use Reflection to get the Attribute 

```cs
using System;

[assembly:System.CLSCompliantAttribute(true)]

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]

public class MyDescriptionAttribute : System.Attribute
{
  private string description;
  public string Desc
  {
    get { return description; }
    set { description = value; }
  }

  public MyDescriptionAttribute() {}
  public MyDescriptionAttribute(string desc) 
  { description = desc;}
}


[MyDescriptionAttribute("Info")]
public class MyClass
{
    public MyClass()
    {
    }
}


public class MainClass
{
  public static int Main(string[] args)
  {

    Type t = typeof(MyClass);
  
    // Get all attributes in the assembly.
    object[] customAtts = t.GetCustomAttributes(false);
  
    // List all info.
    Console.WriteLine("Value of MyDescriptionAttribute");
    foreach(MyDescriptionAttribute v in customAtts)
      Console.WriteLine("-> {0}\n", v.Desc);  

    return 0;
  }
}
```

## Use the GetCustomAttributes method

```cs
using System;

public class TrueFalseAttribute : Attribute
{
  bool bWritten;

  public bool Written()
  {
    return bWritten;
  }

  public TrueFalseAttribute(bool Written)
  {
    bWritten = Written;
  }
}

public class StringAttribute : Attribute
{
  string sStage;

  public string Stage()
  {
    return sStage;
  }

  public StringAttribute(string Stage)
  {
    sStage = Stage;
  }
}

[TrueFalseAttribute(true)]
[StringAttribute("Coding")]
public class Class1
{
}

class MainClass
{
  public static void Main() 
  {
    Console.WriteLine("Class1 attributes: ");object[] aAttributes = Attribute.GetCustomAttributes(typeof(Class1));
    foreach (object attr in aAttributes)
    {
      Console.WriteLine(attr);
    }
  }
}
```

## Load class method by Attribute
```cs
using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
public class ClassTarget : Attribute
{
  public ClassTarget()
  {
  }
}

[AttributeUsage(AttributeTargets.Method )]
public class MethodTarget : Attribute
{
  public MethodTarget()
  {
  }
}

public class MyClass
{
  [MethodTarget]
  public int MyMethod()
  {
    return 5;
  }
}


class MainClass 
{
  public static void Main(string[] args) 
  {

    ClassTarget rs;
    MethodTarget rm;

    Assembly a = Assembly.LoadFrom("MyClass");

    foreach(Type t in a.GetTypes())
    {
      rs = (ClassTarget) Attribute.GetCustomAttribute(t, typeof(ClassTarget));
      if(rs != null)
      {
        foreach(MethodInfo m in t.GetMethods())
        {
          rm = (MethodTarget) Attribute.GetCustomAttribute(m, typeof(MethodTarget));
          if(rm != null)
          {
            Object o = Activator.CreateInstance(t);
            Object[] aa = new Object[0];
            int i = (int) m.Invoke(o, aa);
          }

        }
      }
    }


  }

}
```


