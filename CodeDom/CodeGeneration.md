Code Generation `CodeCompileUnit`
===



```cs
void Main()
{	
	
	
	//string readCode = File.ReadAllText(@"C:\test2.cs");
	var csu0 = CreateCode(@"Console.WriteLine(""hello"");");
	CodeDomProvider provider = new CSharpCodeProvider();
	CompilerResults results = provider.CompileAssemblyFromDom(new CompilerParameters(), csu0 /*arbitrary number*/);
	results.Dump();
	
	 Assembly assembly = results.CompiledAssembly;
        Type program = assembly.GetType($"TestNamespace.TestClass");
        MethodInfo main = program.GetMethod("TestMethod");

        //runtit
        main.Invoke(null, null);
		
} 

// Define other methods and classes here


public CodeCompileUnit CreateCode(string CodeBody)
{
    CodeNamespace code_namespace = new CodeNamespace("TestNamespace");

    // add the class to the namespace, add using statements
    CodeTypeDeclaration code_class = new CodeTypeDeclaration("TestClass");
    code_namespace.Types.Add(code_class);
    code_namespace.Imports.Add(new CodeNamespaceImport("System"));

    // set function details
    CodeMemberMethod method = new CodeMemberMethod();
    method.Attributes = MemberAttributes.Public | MemberAttributes.Static;
    method.ReturnType = new CodeTypeReference(typeof(void));
    method.Name = "TestMethod";

    // add the user typed code
    method.Statements.Add(new CodeSnippetExpression(CodeBody));

    // add the method to the class
    code_class.Members.Add(method);

    // create a CodeCompileUnit to pass to our compiler
    CodeCompileUnit ccu = new CodeCompileUnit();
    ccu.Namespaces.Add(code_namespace);

    return ccu;
}
```
