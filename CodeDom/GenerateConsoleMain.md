**Generate Code ConsoleMain & Execute inMemory**
===

This can be done following these steps: CodeGeneration => InMemory Compilation to Exe ==> Execution.

You can design the construct similar to this:
```cs
public bool RunMain(string code)
{
    const string CODE_NAMESPACE = "CompileOnFly";
    const string CODE_CLASS = "Program";
    const string CODE_METHOD = "Main";

    try
    {
        var code_namespace = new CodeNamespace(CODE_NAMESPACE);

        // add the class to the namespace, add using statements
        var  code_class = new CodeTypeDeclaration(CODE_CLASS);
        code_namespace.Types.Add(code_class);
        code_namespace.Imports.Add(new CodeNamespaceImport("System"));

        // set function details
        var method = new CodeMemberMethod();
        method.Attributes = MemberAttributes.Public | MemberAttributes.Static;
        method.ReturnType = new CodeTypeReference(typeof(void));
        method.Name = CODE_METHOD;

        // add the user typed code
        method.Statements.Add(new CodeSnippetExpression(code));

        // add the method to the class
        code_class.Members.Add(method);

        // create a CodeCompileUnit to pass to our compiler
        CodeCompileUnit code_compileUnit = new CodeCompileUnit();
        code_compileUnit.Namespaces.Add(code_namespace);


        var compilerParameters = new CompilerParameters();
        compilerParameters.ReferencedAssemblies.Add("system.dll");
        compilerParameters.GenerateExecutable = true;
        compilerParameters.GenerateInMemory = true;
        compilerParameters.TreatWarningsAsErrors = true;

        var code_provider = CodeDomProvider.CreateProvider("CSharp");
        var comp_results = code_provider.CompileAssemblyFromDom(compilerParameters, code_compileUnit);

        if (comp_results.Errors.HasErrors)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CompilerError error in comp_results.Errors)
            {
                sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
            }

                   
            throw new InvalidOperationException(sb.ToString());
        }

        //Get assembly, type and the Main method:
        Assembly assembly = comp_results.CompiledAssembly;
        Type program = assembly.GetType($"{CODE_NAMESPACE}.{CODE_CLASS}");
        MethodInfo main = program.GetMethod(CODE_METHOD);

        //runtit
        main.Invoke(null, null);
        return true;

    }
    catch(Exception compileException)
    {
        Console.Write(compileException.ToString());
        return false;
    }
} 
```
n the code above we are actually creating a simple console Program.Main() as
```
namespace CompileOnFly
{
    internal class Program
    {
       static void Main()
        {
            //<your code here>  
        }
    }
}
```
in memory then compiling it as executable in Memory and executing it. But the Main() body //<your code here> is added dynamically with the parameter code to the method.

So If you have a script in the text file script.txt as this:
```cs
Console.Write("Write your name: ");
var name = Console.ReadLine();
Console.WriteLine("Happy new year 2023 " + name);
```
You can simply read all the text and send it as parameter to it:
```cs
 var code = File.ReadAllText(@"script.txt");
 RunMain(code);
  ```
To run the statements in the script.txt file.
