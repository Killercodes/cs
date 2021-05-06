# What's new in C# 9

## Top Level Statements
Before C# 9, a simple "Hello, world" in Visual Studio required the following volume of code:
```cs
class Program
{
  static void Main()
  {
    System.Console.WriteLine ("Hello, world");
  }
}
```
With C# 9, we can finally cut the clutter! A program can now comprise purely of top-level statements:  */
```cs
System.Console.WriteLine ("Hello, world");
```

Top-level statements can be optionally preceded by 'using' directives:
```cs
using System;
Console.WriteLine ("Hello, world");
```

Top-level statements can be followed by methods.
```cs
string greeting = "Hello, world";
HelloWorld();
```

These methods can access variables declared by the top-level statements, making them *local methods* (so they cannot be overloaded):
```cs
void HelloWorld() => greeting.Dump();
```

What's more useful is that top-level statements in C# 9 can also be followed by type and namespace declarations:
```cs
class Foo
{
	public Foo()
	{		
	}
}

namespace Test
{
	class Foo
	{		
	}	
}
```
