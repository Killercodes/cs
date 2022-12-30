void Main()
{
	var cdr = new MacroScript();
	cdr.LoadScript();
	cdr.Run("say-hi");
}

// Define other methods and classes here
public class MacroScript
{
	Dictionary<string,byte> GetKey = new Dictionary<string,byte>();
	List<commandline> coamandList; //list
	
	const string KEYPRESS = "KEYPRESS ";
	const string KEYDOWN = "KEYDOWN ";
	const string KEYUP = "KEYUP ";
	const string START = "START ";
	const string DELAY = "DELAY ";
	const string SENDKEY = "SENDKEY ";
	const string RCLICK = "RCLICK ";
	const string LCLICK = "LCLICK";
	const string MCLICK = "MCLICK";
	
	
	
	public MacroScript() //constructor
	{
		coamandList = new List<commandline>(); 
		Initialize();//initilaize
		LoadScript(); //populate
		
	}
	
	public void LoadScript(string fileName="macro.txt")
	{
		coamandList = new List<commandline>();
		var allLines = File.ReadAllLines(fileName);
		
		foreach(string line in allLines)
		{
			if(line.StartsWith("#"))
				continue;
				
			var cmdline = line.Split(':');
			if(cmdline.Count() < 2)
				continue;
				
			var keyword = cmdline[0];
			var action = cmdline[1];
						
			var keywordsCollection = new List<string>(); 
			foreach(var k in keyword.Split('|'))
			{
				keywordsCollection.Add(k.Trim('"'));
			}
					
			var  actionCollection = new List<Action>();
			foreach(var a in action.Split('|'))
			{
				var cmd = a.Trim();//.Split(' ');
				
				if(cmd.StartsWith(KEYPRESS))
				{
					cmd = cmd.Replace(KEYPRESS,null);
					actionCollection.Add(()=>{ Robot.Keyboard.KeyPress(Robot.Keyboard.GetKey[cmd],0); });
				}
				else if(cmd.StartsWith(KEYDOWN))
				{
					cmd = cmd.Replace(KEYDOWN,null);
					actionCollection.Add(()=>{ Robot.Keyboard.KeyDown(Robot.Keyboard.GetKey[cmd]); });
				}
				else if(cmd.StartsWith(KEYUP))
				{
					cmd = cmd.Replace(KEYUP,null);
					actionCollection.Add(()=>{ Robot.Keyboard.KeyUp(Robot.Keyboard.GetKey[cmd]); });
				}
				else if(cmd.StartsWith(DELAY))
				{
					cmd = cmd.Replace(DELAY,null);
					actionCollection.Add(()=>{ Robot.Keyboard.Delay(int.Parse(cmd)); });
				}
				else if(cmd.StartsWith(START))
				{
					cmd = cmd.Replace(START,null);
					actionCollection.Add(()=>{ Process.Start(cmd.Split(',')[0],cmd.Split(',')[1]); });
				}
				else if(cmd.StartsWith(SENDKEY))
				{
					cmd = cmd.Replace(SENDKEY,null);
					actionCollection.Add(()=>{ SendKeys.SendWait(cmd); });
				}
				
				//actionCollection.Add(()=> {Console.WriteLine($"Executing: {arg.Trim()}");} );
			}
			
			//
			keywordsCollection.Dump();
			actionCollection.Dump();
			
			coamandList.Add(new commandline(keywordsCollection,actionCollection));
		}
		
		//coamandList.Dump(); //1rsrpr4441rsrpr444 Hi vinod
	}
	
	public void Run(string command)
	{
		command = command.Replace('-',' ');
		command.Dump("command");
		
		var cmds = coamandList
		.Where(c => c.Command.Contains(command))
		.ToList();
		
		
		foreach(var c in cmds)
		{
			var allActions = c.Actions;
			
			foreach(var a in allActions)
			{
				a.Invoke();
			}
		}
		
	}
	
	void Initialize()
	{
		GetKey["VM_LBUTTON"]  = 0x01;//	Left mouse button
		GetKey["VM_RBUTTON"]  = 0x02;//	Right mouse button
		GetKey["VK_CANCEL"]  = 0x03;//	Control-break processing
		GetKey["VM_MBUTTON"]  = 0x04;//	Middle mouse button (three-button mouse)
		GetKey["VM_XBUTTON1"]  = 0x05;//	X1 mouse button
		GetKey["VM_XBUTTON2"]  = 0x06;//	X2 mouse button
		GetKey["VK_BACK"]  = 0x08;//	BACKSPACE key
		GetKey["VK_TAB"]  = 0x09;//		TAB key
		GetKey["VK_CLEAR"]  = 0x0C;//	CLEAR key
		GetKey["VK_RETURN"]  = 0x0D;//	ENTER key
		GetKey["VK_SHIFT"]  = 0x10;//	SHIFT key
		GetKey["VK_CONTROL"]  = 0x11;//	CTRL key
		GetKey["VK_MENU"]  = 0x12;//	ALT key
		GetKey["VK_PAUSE"]  = 0x13;//	PAUSE key
		GetKey["VK_CAPITAL"]  = 0x14;//	CAPS LOCK key
		GetKey["VK_SPACE"]  = 0x20;//	SPACEBAR
		GetKey["VK_PRIOR"]  = 0x21;//	PAGE UP key
		GetKey["VK_NEXT"]  = 0x22;//	PAGE DOWN key
		GetKey["VK_END"]  = 0x23;//		END key
		GetKey["VK_HOME"]  = 0x24;//	HOME key
		GetKey["VK_LEFT"]  = 0x25;//	LEFT ARROW key
		GetKey["VK_UP"]  = 0x26;//		UP ARROW key
		GetKey["VK_RIGHT"]  = 0x27;//	RIGHT ARROW key
		GetKey["VK_DOWN"]  = 0x28;//	DOWN ARROW key
		GetKey["VK_SELECT"]  = 0x29;//	SELECT key
		GetKey["VK_PRINT"]  = 0x2A;//	PRINT key
		GetKey["VK_EXECUTE"]  = 0x2B;//	EXECUTE key
		GetKey["VK_SNAPSHOT"]  = 0x2C;//	PRINT SCREEN key
		GetKey["VK_INSERT"]  = 0x2D;//	INS key
		GetKey["VK_DELETE"]  = 0x2E;//	DEL key
		GetKey["VK_HELP"]  = 0x2F;//	HELP key
		GetKey["0"] = 0x30;	//	0 key
		GetKey["1"] = 0x31;	//	1 key
		GetKey["2"] = 0x32;	//	2 key
		GetKey["3"] = 0x33;	//	3 key
		GetKey["4"] = 0x34;	//	4 key
		GetKey["5"] = 0x35;	//	5 key
		GetKey["6"] = 0x36;	//	6 key
		GetKey["7"] = 0x37;	//	7 key
		GetKey["8"] = 0x38;	//	8 key
		GetKey["9"] = 0x39;	//	9 key
		GetKey["A"] = 0x41; //	A key
		GetKey["B"] = 0x42; //	B key
		GetKey["C"] = 0x43; //	C key
		GetKey["D"] = 0x44; //	D key
		GetKey["E"] = 0x45; //	E key
		GetKey["F"] = 0x46; //	F key
		GetKey["G"] = 0x47; //	G key
		GetKey["H"] = 0x48; //	H key
		GetKey["I"] = 0x49; //	I key
		GetKey["J"] = 0x4A; //	J key
		GetKey["K"] = 0x4B; //	K key
		GetKey["L"] = 0x4C; //	L key
		GetKey["M"] = 0x4D; //	M key
		GetKey["N"] = 0x4E; //	N key
		GetKey["O"] = 0x4F; //	O key
		GetKey["P"] = 0x50; //	P key
		GetKey["Q"] = 0x51; //	Q key
		GetKey["R"] = 0x52; //	R key
		GetKey["S"] = 0x53; //	S key
		GetKey["T"] = 0x54; //	T key
		GetKey["U"] = 0x55; //	U key
		GetKey["V"] = 0x56; //	V key
		GetKey["W"] = 0x57; //	W key
		GetKey["X"] = 0x58; //	X key
		GetKey["Y"] = 0x59; //	Y key
		GetKey["Z"] = 0x5A; //	Z key
		GetKey["VK_LWIN"]  = 0x5B; //	Left Windows key (Natural keyboard)
		GetKey["VK_RWIN"]  = 0x5C; //	Right Windows key (Natural keyboard)
		GetKey["VK_APPS"]  = 0x5D; //	Applications key (Natural keyboard)
		GetKey["VK_SLEEP"]  = 0x5F; //	Computer Sleep key
		GetKey["VK_NUMPAD0"]  = 0x60; //	Numeric keypad 0 key
		GetKey["VK_NUMPAD1"]  = 0x61; //	Numeric keypad 1 key
		GetKey["VK_NUMPAD2"]  = 0x62; //	Numeric keypad 2 key
		GetKey["VK_NUMPAD3"]  = 0x63; //	Numeric keypad 3 key
		GetKey["VK_NUMPAD4"]  = 0x64; //	Numeric keypad 4 key
		GetKey["VK_NUMPAD5"]  = 0x65; //	Numeric keypad 5 key
		GetKey["VK_NUMPAD6"]  = 0x66; //	Numeric keypad 6 key
		GetKey["VK_NUMPAD7"]  = 0x67; //	Numeric keypad 7 key
		GetKey["VK_NUMPAD8"]  = 0x68; //	Numeric keypad 8 key
		GetKey["VK_NUMPAD9"]  = 0x69; //	Numeric keypad 9 key
		GetKey["VK_MULTIPLY"]  = 0x6A; //	Multiply key
		GetKey["VK_ADD"]  = 0x6B; //	Add key
		GetKey["VK_SEPARATOR"]  = 0x6C; //	Separator key
		GetKey["VK_SUBTRACT"]  = 0x6D; //	Subtract key
		GetKey["VK_DECIMAL"]  = 0x6E; //	Decimal key
		GetKey["VK_DIVIDE"]  = 0x6F; //	Divide key
		GetKey["VK_F1"]  = 0x70; //	F1 key
		GetKey["VK_F2"]  = 0x71; //	F2 key
		GetKey["VK_F3"]  = 0x72; //	F3 key
		GetKey["VK_F4"]  = 0x73; //	F4 key
		GetKey["VK_F5"]  = 0x74; //	F5 key
		GetKey["VK_F6"]  = 0x75; //	F6 key
		GetKey["VK_F7"]  = 0x76; //	F7 key
		GetKey["VK_F8"]  = 0x77; //	F8 key
		GetKey["VK_F9"]  = 0x78; //	F9 key
		GetKey["VK_F10"]  = 0x79; //	F10 key
		GetKey["VK_F11"]  = 0x7A; //	F11 key
		GetKey["VK_F12"]  = 0x7B; //	F12 key
		GetKey["VK_F13"]  = 0x7C; //	F13 key
		GetKey["VK_F14"]  = 0x7D; //	F14 key
		GetKey["VK_F15"]  = 0x7E; //	F15 key
		GetKey["VK_F16"]  = 0x7F; //	F16 key
		GetKey["VK_F17"]  = 0x80; //	F17 key
		GetKey["VK_F18"]  = 0x81; //	F18 key
		GetKey["VK_F19"]  = 0x82; //	F19 key
		GetKey["VK_F20"]  = 0x83; //	F20 key
		GetKey["VK_F21"]  = 0x84; //	F21 key
		GetKey["VK_F22"]  = 0x85; //	F22 key
		GetKey["VK_F23"]  = 0x86; //	F23 key
		GetKey["VK_F24"]  = 0x87; //	F24 key
		GetKey["VK_NUMLOCK"]  = 0x90; //	NUM LOCK key
		GetKey["VK_SCROLL"]  = 0x91; //	SCROLL LOCK key
		GetKey["VK_LSHIFT"]  = 0xA0; //	Left SHIFT key
		GetKey["VK_RSHIFT"]  = 0xA1; //	Right SHIFT key
		GetKey["VK_LCONTROL"]  = 0xA2; //	Left CONTROL key
		GetKey["VK_RCONTROL"]  = 0xA3; //	Right CONTROL key
		GetKey["VK_LMENU"]  = 0xA4; //	Left ALT key
		GetKey["VK_RMENU"]  = 0xA5; //	Right ALT key
		GetKey["VK_BROWSER_BACK"]  = 0xA6; //	Browser Back key
		GetKey["VK_BROWSER_FORWARD"]  = 0xA7; //	Browser Forward key
		GetKey["VK_BROWSER_REFRESH"]  = 0xA8; //	Browser Refresh key
		GetKey["VK_BROWSER_STOP"]  = 0xA9; //	Browser Stop key
		GetKey["VK_BROWSER_SEARCH"]  = 0xAA; //	Browser Search key
		GetKey["VK_BROWSER_FAVORITES"]  = 0xAB; //	Browser Favorites key
		GetKey["VK_BROWSER_HOME"]  = 0xAC; //	Browser Start and Home key
		GetKey["VK_VOLUME_MUTE"]  = 0xAD; //	Volume Mute key
		GetKey["VK_VOLUME_DOWN"]  = 0xAE; //	Volume Down key
		GetKey["VK_VOLUME_UP"]  = 0xAF; //	Volume Up key
		GetKey["VK_MEDIA_NEXT_TRACK"]  = 0xB0; //	Next Track key
		GetKey["VK_MEDIA_PREV_TRACK"]  = 0xB1; //	Previous Track key
		GetKey["VK_MEDIA_STOP"]  = 0xB2; //	Stop Media key
		GetKey["VK_MEDIA_PLAY_PAUSE"]  = 0xB3; //	Play/Pause Media key
		GetKey["VK_LAUNCH_MAIL"]  = 0xB4; //	Start Mail key
		GetKey["VK_LAUNCH_MEDIA_SELECT"]  = 0xB5; //	Select Media key
		GetKey["VK_LAUNCH_APP1"]  = 0xB6; //	Start Application 1 key
		GetKey["VK_LAUNCH_APP2"]  = 0xB7; //	Start Application 2 key
		GetKey["VK_OEM_1"]  = 0xBA; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key
		GetKey["VK_OEM_PLUS"]  = 0xBB; //	For any country/region, the '+' key
		GetKey["VK_OEM_COMMA"]  = 0xBC; //	For any country/region, the ',' key
		GetKey["VK_OEM_MINUS"]  = 0xBD; //	For any country/region, the '-' key
		GetKey["VK_OEM_PERIOD"]  = 0xBE; //	For any country/region, the '.' key
		GetKey["VK_OEM_2"]  = 0xBF; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key
		GetKey["VK_OEM_3"]  = 0xC0; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key
		GetKey["VK_OEM_4"]  = 0xDB; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key
		GetKey["VK_OEM_5"]  = 0xDC; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\|' key
		GetKey["VK_OEM_6"]  = 0xDD; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key
		GetKey["VK_OEM_7"]  = 0xDE; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key
		GetKey["VK_OEM_8"]  = 0xDF; //	Used for miscellaneous characters; it can vary by keyboard.
		GetKey["VK_OEM_102"]  = 0xE2; //	The <> keys on the US standard keyboard, or the \\| key on the non-US 102-key keyboard
		GetKey["VK_PACKET"]  = 0xE7; //	Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
		GetKey["VK_ATTN"]  = 0xF6; //	Attn key
		GetKey["VK_CRSEL"]  = 0xF7; //	CrSel key
		GetKey["VK_EXSEL"]  = 0xF8; //	ExSel key
		GetKey["VK_EREOF"]  = 0xF9; //	Erase EOF key
		GetKey["VK_PLAY"]  = 0xFA; //	Play key
		GetKey["VK_ZOOM"]  = 0xFB; //	Zoom key
		GetKey["VK_NONAME"]  = 0xFC; //	Reserved
		GetKey["VK_PA1"]  = 0xFD; //	PA1 key
		GetKey["VK_OEM_CLEAR"]  = 0xFE; //	Clear key
	}
	
}

public class commandline
{
	public List<string> Command {get;set;}
	//public string Keyword {get;set;}
	//public string Argument {get;set;}
	public List<Action> Actions {get;set;}
	
	/*
	public commandline(string keyword,string arg,List<Action> action)
	{
		this.Keyword = keyword;
		this.Argument = arg;
		this.Actions = action;
	}
	*/
	
	public commandline(List<string> input,List<Action> action)
	{
		this.Command = input;
		this.Actions = action;
	}
}
