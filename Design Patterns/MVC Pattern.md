# MVC Patterns
Model–view–controller (usually known as MVC) is a software design pattern[1] commonly used for developing user interfaces that divides the related program logic into three interconnected elements. This is done to separate internal representations of information from the ways information is presented to and accepted from the user.[2][3]

Traditionally used for desktop graphical user interfaces (GUIs), this pattern has become popular for designing web applications.[

## Components
### Model
The central component of the pattern. It is the application's dynamic data structure, independent of the user interface.[5] It directly manages the data, logic and rules of the application.
### View
Any representation of information such as a chart, diagram or table. Multiple views of the same information are possible, such as a bar chart for management and a tabular view for accountants.
### Controller
Accepts input and converts it to commands for the model or view.[6]
In addition to dividing the application into these components, the model–view–controller design defines the interactions between them.[7]

The model is responsible for managing the data of the application. It receives user input from the controller.
The view renders presentation of the model in a particular format.
The controller responds to the user input and performs interactions on the data model objects. The controller receives the input, optionally validates it and then passes the input to the model.
As with other software patterns, MVC expresses the "core of the solution" to a problem while allowing it to be adapted for each system.[8] Particular MVC designs can vary significantly from the traditional description here.[9]


```cs
using System;
using System.Collections.Generic;
using System.Text;

  interface IController
  {
     void DisplayPrice();
  }

  public class Model
  {
      public double Price()
      {
          return 100;
      }
  }

  public class FirstController: IController
  {
    private Model mod;

    public void DisplayPrice()
    {
      double cost = mod.Price() * 1.15;
      String message = "first USD " + cost.ToString();
      Console.WriteLine(message);
    }

    public FirstController()
    {
      mod = new Model();
    }
  }    

  public class SecondController: IController
  {
    private Model mod;

    public void DisplayPrice()
    {
          double cost = mod.Price()*1.1;
          String message = "second USD " + cost.ToString();
          Console.WriteLine(message);
    }

    public SecondController()
    {
      mod = new Model();
    }
  }
  
    public class Client
    {
        static void Main(string[] args)
        {
          SecondController viewUS = new SecondController();
          viewUS.DisplayPrice();
          FirstController viewNorway = new FirstController();
          viewNorway.DisplayPrice();
        }
    }
```

