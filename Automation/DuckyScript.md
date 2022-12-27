Macro Script
===

## The Script
```cmd
# This is a comment
STRING this is a string ~
STRINGLN  this will type with enter at last
KEY {A 4}
DELAY 3000
KEY {K} 
KEY a+(CB) 
STRING and this is ~ character
STRINGLN dir
DELAY 2000
EXECUTE chrome.exe,https://www.youtube.com
STRINGLN REM this is it



```


## Intrepreter
```cs
public class DuckyScript
{
	public Dictionary<string,Action> CommandLines {get;set;}
	
	public DuckyScript(string fileName)
	{
		CommandLines = new Dictionary<string,Action>();
		
		ParseMacro(fileName);
	}
	
	public bool Execute()
	{
		foreach(var kv in CommandLines)
		{
			kv.Key.Dump();
			kv.Value.Invoke();
		}
		
		return true;
	}
	
	
	private void ParseMacro(string filapath)
	{
		var file = File.ReadAllLines(@"C:\temp\cmd.txt");
				
		foreach(string line in file)
		{
			if(line.StartsWith("# "))
			{
				line.Dump("#");
				var cmd = line;//.Replace("REM ","");
			}
			else if(line.StartsWith("STRING "))
			{
				var cmd = line.Replace("STRING","");
				CommandLines["STRING"] = ()=> SendKeys.SendWait(cmd);
			}
			else if(line.StartsWith("STRINGLN "))
			{
				var cmd = line.Replace("STRINGLN ","");
				cmd+= " {ENTER}";
				CommandLines["STRINGLN"] = ()=> SendKeys.SendWait(cmd);
			}
			else if(line.StartsWith("KEY "))
			{
				var cmd = line.Replace("KEY ","");
				CommandLines["KEY"] = ()=> SendKeys.SendWait(cmd);
			}
			else if(line.StartsWith("DELAY "))
			{
				var cmd = line.Replace("DELAY ","");
				int delay = int.Parse(cmd);
				CommandLines["DELAY"] = ()=> Thread.Sleep(delay);
			}
			else if(line.StartsWith("EXECUTE "))
			{
				var cmd = line.Replace("EXECUTE ","");
				var arg = cmd.Split(',');
				CommandLines["EXECUTE"] = ()=> Process.Start(arg[0],arg[1]);
			}
		}
		
		//actionList.Dump();
	}
}
```
## Excute
```cs
void Main()
{
	var file = @"C:\cmd.txt";
	
	var ds = new DuckyScript(file);
	ds.Execute();
}
```

---
