C# Repl
=====

The class
```cs

public class REPL
{	
	public delegate void CompilerStatus(string state);
	public event CompilerStatus Status;
	
	private string CodeFile = string.Empty;
	private string Code = string.Empty;
	private bool CompileToExe = false;
	private bool CompileToDll = false;
	private bool CompileInMemory = false;
	private string OutputFile = string.Empty;
	private string references = string.Empty;
	private string Namespace = string.Empty;
	private string Class = string.Empty;
	private string Method = string.Empty;
	private CompilerParameters compilerParams;
	
	
	private void _status(string stat)
	{
		if(Status != null){
			Status(stat);
		}
	}
	
	
	private REPL(string fileName)
	{
		CodeFile = fileName;
	}
	
	public static REPL Execute(string fileName)
	{
		REPL instance = new REPL(fileName);
		//instance.CompileExecutable = false;
		instance.CompileInMemory = true;
		instance.CompileToExe = true;
		instance.CompileToDll = false;
		return instance;
	}
	
	public static REPL CompileDll(string fileName)
	{
		REPL instance = new REPL(fileName);
		//instance.CompileExecutable = false;
		instance.CompileInMemory = false;
		instance.CompileToExe = false;
		instance.CompileToDll = true;
		return instance;
	}
	
	public static REPL CompileExe(string fileName)
	{
		REPL instance = new REPL(fileName);
		//instance.CompileExecutable = true;
		instance.CompileInMemory = false;
		instance.CompileToExe = true;
		instance.CompileToDll = false;
		return instance;
	}
	
	public bool Run(string runtimeParameter = null)
	{
		compilerParams = new CompilerParameters();
		if(this.CompileInMemory == true)
		{
			CodesAnalysis();			
			compilerParams.GenerateExecutable = true; 
			compilerParams.GenerateInMemory = true;			
			compilerParams.TreatWarningsAsErrors = false;
			compilerParams.WarningLevel = 3;
			compilerParams.ReferencedAssemblies.AddRange(ReferncedAssemblies(null));
			compilerParams.CompilerOptions = "/optimize";
			//compilerParams.MainClass = "CRM365.Program";
			
			//Execute		
			$"{Code} {Class} {Method}".Dump();
			ExecuteScript(compilerParams,Code,Class,Method);			
			return true;
		}
		else
		{
			if(CompileToExe == true)
			{
				CodesAnalysis();
				compilerParams.GenerateExecutable = true; 
				compilerParams.GenerateInMemory = false;
				compilerParams.OutputAssembly = OutputFile;
				compilerParams.TreatWarningsAsErrors = false;
				compilerParams.WarningLevel = 3;
				compilerParams.ReferencedAssemblies.AddRange(ReferncedAssemblies(null));
				compilerParams.CompilerOptions = "/optimize";
				compilerParams.IncludeDebugInformation = true;
				//Compile
				
				return true;
			}
			else if(CompileToDll == true)
			{
				CodesAnalysis();
				compilerParams.GenerateExecutable = false; 
				compilerParams.GenerateInMemory = false;
				compilerParams.OutputAssembly = OutputFile;
				compilerParams.TreatWarningsAsErrors = false;
				compilerParams.WarningLevel = 3;
				compilerParams.ReferencedAssemblies.AddRange(ReferncedAssemblies(null));
				compilerParams.CompilerOptions = "/optimize";
				compilerParams.IncludeDebugInformation = true;
				
				//Compile
				
				return true;
			}

		}
			
		return false;
	}
	
	private void CodesAnalysis()
	{
		Code = File.ReadAllText(CodeFile);
		var allLines = File.ReadLines(CodeFile).Take(100).ToList();
		
		
		foreach(string line in allLines)
		{
			if(line.StartsWith("//#reference"))
			{
				references = Keyword(line);
			}
			
			if(line.StartsWith("namespace"))
			{	
				Namespace = Keyword(line);
			}
			
			if(line.Contains("class"))
			{
				Class = Keyword(line);
			}
			
			if(line.EndsWith("()"))
			{
				Method = Keyword(line);
			}
		}
	}
	
	private string Keyword(string line)
	{
		line = line.Replace("//#reference",null);
		line = line.Replace("#path",null);
		line = line.Replace("#import",null);
		line = line.Replace("#include",null);
		line = line.Replace("<",null);
		line = line.Replace(">",null);
		line = line.Replace("namespace",null);
		line = line.Replace("{",null);
		line = line.Replace("}",null);
		line = line.Replace("public",null);
		line = line.Replace("private",null);
		line = line.Replace("internal",null);
		line = line.Replace("protected",null);
		line = line.Replace("class",null);
		line = line.Replace("static",null);
		line = line.Replace("void",null);
		line = line.Replace("()",null);
		line = line.Replace("(",null);
		line = line.Replace(")",null);
		return line.Trim();
	}
	
	private string[] ReferncedAssemblies(string refFile)
	{		
		List<string> dllReferences = new List<string>();
		
		if(string.IsNullOrEmpty(refFile))
			refFile = CodeFile;
		
		refFile.Dump();
		var allLines = File.ReadLines(refFile);
		string dllPath = null;
		
		foreach(string line in allLines)
		{
			if(line.StartsWith("#path"))
			{
				dllPath = Keyword(line);
			}
			
			if(line.StartsWith("#import"))
			{
				dllReferences.Add(string.Format("{0}\\{1}",dllPath,Keyword(line)));
			}
			
			if(line.StartsWith("#include"))
			{
				dllReferences.Add(string.Format("{0}",Keyword(line)));
			}
			
			/*
			if(line.StartsWith("ref#"))
			{
				dllReferences.Add(string.Format("{0}\\{1}",dllPath,Keyword(line)));
			}
			*/
		
		}
		
		return dllReferences.ToArray();
	}
	
	public void ExecuteScript(CompilerParameters compParms,string sourceCode,string className, string methodName)
	{		
		//compile
		var csProvider = new CSharpCodeProvider();
    	CompilerResults compilerResults = csProvider.CompileAssemblyFromSource(compParms, sourceCode);
		compilerResults.Dump();
		if(compilerResults.Errors.Count > 0)
        {
            // Display compilation errors.
            Console.WriteLine("Errors building {0} into {1}", className, compilerResults.PathToAssembly);
            foreach(CompilerError ce in compilerResults.Errors)
            {
                Console.WriteLine("  {0}", ce.ToString());
                Console.WriteLine();
            }
        }
        else
        {
            // Display a successful compilation message.
            Console.WriteLine("Source {0} built into {1} successfully.", className, compilerResults.PathToAssembly);
        }
		
		//Execute
		//object Instance = compilerResults.CompiledAssembly.CreateInstance(className);
		//Instance.Dump();
		//Instance.GetMethod("Run", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
    	
		//MethodInfo mi = Instance.GetType().GetMethod(methodName);
    	//mi.Invoke(Instance, null); 
		compilerResults.CompiledAssembly.Dump();
		
		MethodInfo method = compilerResults.CompiledAssembly.EntryPoint;
		method.DeclaringType.ToString().Dump("method.DeclaringType.ToString()");
		method.Dump("method");
		object obj = compilerResults.CompiledAssembly.CreateInstance(method.DeclaringType.ToString());
		method.Invoke(obj, null);
	}
	
	
	public void Compile(CompilerParameters compParms,string sourceCode,string className)
	{		
		//compile
		_status("- Compilation started..");
		_status("- GenerateExecutable = false");
		_status("- GenerateInMemory = false");
		_status("- OutputAssembly = " + compParms.OutputAssembly);
		_status("- TreatWarningsAsErrors = false");
		_status("- WarningLevel = 3");
		
		//_status("- ReferencedAssemblies = " + assemblies.ToArray().Count());
		
		var csProvider = new CSharpCodeProvider();
    	CompilerResults compilerResults = csProvider.CompileAssemblyFromSource(compParms, sourceCode);

		if(compilerResults.Errors.Count > 0)
        {
            // Display compilation errors.
            _status("\n[:(] Errors building " + className + " into " + compilerResults.PathToAssembly);
			int errorCount = 1;
            foreach(CompilerError ce in compilerResults.Errors)
			{
                _status(string.Format("  - ERROR {5} ==> {0} {1} on Line {2} column {3} on File {4}",ce.ErrorNumber,ce.ErrorText,ce.Line,ce.Column,ce.FileName,errorCount));      
				errorCount++;
			}
        }
        else
        {
			compilerResults.CompiledAssembly.Dump();
            // Display a successful compilation message.
            _status("\n[:)] Source " + className + " built into " + compilerResults.PathToAssembly + " successfully.");
        }
	}
}
```

the `test2.csx` file
```cs
//#non-reference<reference.ref>
/*
#path <C:\Sw Install\ForReference>
#import <System.dll>
#import <System.IO.dll>
#import <System.Linq.dll>
*/

using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;


namespace CRM365
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("This is the Main Method: he he ");

            var p = new Program();
            p.Run("This is parameter for Run function");
        }

        public void Run(string parameters)
        {
            Console.WriteLine("Run() called");
            Console.Write("You typed:{0} as parameters", parameters);
            Console.ReadLine();
        }
    }
}

```

The Main method

```cs
void Main()
{	
	
	string path = @"test2.csx";
	string readCode = File.ReadAllText(path);

	//readCode.Dump();
	var rpl = REPL.Execute(path);
	rpl.Run();	
} 
```


---
