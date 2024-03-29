void Main()
{
	var k = new Dictionary<string,int>();

	k["VM_LBUTTON"]  = 0x01;//	Left mouse button
	k["VM_RBUTTON"]  = 0x02;//	Right mouse button
	k["VK_CANCEL"]  = 0x03;//	Control-break processing
	k["VM_MBUTTON"]  = 0x04;//	Middle mouse button (three-button mouse)
	k["VM_XBUTTON1"]  = 0x05;//	X1 mouse button
	k["VM_XBUTTON2"]  = 0x06;//	X2 mouse button
	//k["-"]  = 0x07;//	Undefined
	k["VK_BACK"]  = 0x08;//	BACKSPACE key
	k["VK_TAB"]  = 0x09;//	TAB key
	//k["-"]  = 0x0A-0B;//	Reserved
	k["VK_CLEAR"]  = 0x0C;//	CLEAR key
	k["VK_RETURN"]  = 0x0D;//	ENTER key
	//k["-"]  = 0x0E-0F;//	Undefined
	k["VK_SHIFT"]  = 0x10;//	SHIFT key
	k["VK_CONTROL"]  = 0x11;//	CTRL key
	k["VK_MENU"]  = 0x12;//	ALT key
	k["VK_PAUSE"]  = 0x13;//	PAUSE key
	k["VK_CAPITAL"]  = 0x14;//	CAPS LOCK key
	k["VK_KANA"]  = 0x15;//	IME Kana mode
	k["VK_HANGUEL"]  = 0x15;//	IME Hanguel mode (maintained for compatibility; use VK_HANGUL)
	k["VK_HANGUL"]  = 0x15;//	IME Hangul mode
	k["VK_IME_ON"]  = 0x16;//	IME On
	k["VK_JUNJA"]  = 0x17;//	IME Junja mode
	k["VK_FINAL"]  = 0x18;//	IME final mode
	k["VK_HANJA"]  = 0x19;//	IME Hanja mode
	k["VK_KANJI"]  = 0x19;//	IME Kanji mode
	k["VK_IME_OFF"]  = 0x1A;//	IME Off
	k["VK_ESCAPE"]  = 0x1B;//	ESC key
	k["VK_CONVERT"]  = 0x1C;//	IME convert
	k["VK_NONCONVERT"]  = 0x1D;//	IME nonconvert
	k["VK_ACCEPT"]  = 0x1E;//	IME accept
	k["VK_MODECHANGE"]  = 0x1F;//	IME mode change request
	k["VK_SPACE"]  = 0x20;//	SPACEBAR
	k["VK_PRIOR"]  = 0x21;//	PAGE UP key
	k["VK_NEXT"]  = 0x22;//	PAGE DOWN key
	k["VK_END"]  = 0x23;//	END key
	k["VK_HOME"]  = 0x24;//	HOME key
	k["VK_LEFT"]  = 0x25;//	LEFT ARROW key
	k["VK_UP"]  = 0x26;//	UP ARROW key
	k["VK_RIGHT"]  = 0x27;//	RIGHT ARROW key
	k["VK_DOWN"]  = 0x28;//	DOWN ARROW key
	k["VK_SELECT"]  = 0x29;//	SELECT key
	k["VK_PRINT"]  = 0x2A;//	PRINT key
	k["VK_EXECUTE"]  = 0x2B;//	EXECUTE key
	k["VK_SNAPSHOT"]  = 0x2C;//	PRINT SCREEN key
	k["VK_INSERT"]  = 0x2D;//	INS key
	k["VK_DELETE"]  = 0x2E;//	DEL key
	k["VK_HELP"]  = 0x2F;//	HELP key
	k["VK_0"] = 0x30;//	0 key
	k["VK_1"] = 0x31;//	1 key
	k["VK_2"] = 0x32;//	2 key
	k["VK_3"] = 0x33;//	3 key
	k["VK_4"] = 0x34;//	4 key
	k["VK_5"] = 0x35;//	5 key
	k["VK_6"] = 0x36;//	6 key
	k["VK_7"] = 0x37;//	7 key
	k["VK_8"] = 0x38;//	8 key
	k["VK_9"] = 0x39;//	9 key
	//k["-"]  = 0x3A-40	Undefined
	k["VK_A"] = 0x41; //	A key
	k["VK_B"] = 0x42; //	B key
	k["VK_C"] = 0x43; //	C key
	k["VK_D"] = 0x44; //	D key
	k["VK_E"] = 0x45; //	E key
	k["VK_F"] = 0x46; //	F key
	k["VK_G"] = 0x47; //	G key
	k["VK_H"] = 0x48; //	H key
	k["VK_I"] = 0x49; //	I key
	k["VK_J"] = 0x4A; //	J key
	k["VK_K"] = 0x4B; //	K key
	k["VK_L"] = 0x4C; //	L key
	k["VK_M"] = 0x4D; //	M key
	k["VK_N"] = 0x4E; //	N key
	k["VK_O"] = 0x4F; //	O key
	k["VK_P"] = 0x50; //	P key
	k["VK_Q"] = 0x51; //	Q key
	k["VK_R"] = 0x52; //	R key
	k["VK_S"] = 0x53; //	S key
	k["VK_T"] = 0x54; //	T key
	k["VK_U"] = 0x55; //	U key
	k["VK_V"] = 0x56; //	V key
	k["VK_W"] = 0x57; //	W key
	k["VK_X"] = 0x58; //	X key
	k["VK_Y"] = 0x59; //	Y key
	k["VK_Z"] = 0x5A; //	Z key
	k["VK_LWIN"]  = 0x5B; //	Left Windows key (Natural keyboard)
	k["VK_RWIN"]  = 0x5C; //	Right Windows key (Natural keyboard)
	k["VK_APPS"]  = 0x5D; //	Applications key (Natural keyboard)
	//k["-"]  = 0x5E	Reserved
	k["VK_SLEEP"]  = 0x5F; //	Computer Sleep key
	k["VK_NUMPAD0"]  = 0x60; //	Numeric keypad 0 key
	k["VK_NUMPAD1"]  = 0x61; //	Numeric keypad 1 key
	k["VK_NUMPAD2"]  = 0x62; //	Numeric keypad 2 key
	k["VK_NUMPAD3"]  = 0x63; //	Numeric keypad 3 key
	k["VK_NUMPAD4"]  = 0x64; //	Numeric keypad 4 key
	k["VK_NUMPAD5"]  = 0x65; //	Numeric keypad 5 key
	k["VK_NUMPAD6"]  = 0x66; //	Numeric keypad 6 key
	k["VK_NUMPAD7"]  = 0x67; //	Numeric keypad 7 key
	k["VK_NUMPAD8"]  = 0x68; //	Numeric keypad 8 key
	k["VK_NUMPAD9"]  = 0x69; //	Numeric keypad 9 key
	k["VK_MULTIPLY"]  = 0x6A; //	Multiply key
	k["VK_ADD"]  = 0x6B; //	Add key
	k["VK_SEPARATOR"]  = 0x6C; //	Separator key
	k["VK_SUBTRACT"]  = 0x6D; //	Subtract key
	k["VK_DECIMAL"]  = 0x6E; //	Decimal key
	k["VK_DIVIDE"]  = 0x6F; //	Divide key
	k["VK_F1"]  = 0x70; //	F1 key
	k["VK_F2"]  = 0x71; //	F2 key
	k["VK_F3"]  = 0x72; //	F3 key
	k["VK_F4"]  = 0x73; //	F4 key
	k["VK_F5"]  = 0x74; //	F5 key
	k["VK_F6"]  = 0x75; //	F6 key
	k["VK_F7"]  = 0x76; //	F7 key
	k["VK_F8"]  = 0x77; //	F8 key
	k["VK_F9"]  = 0x78; //	F9 key
	k["VK_F10"]  = 0x79; //	F10 key
	k["VK_F11"]  = 0x7A; //	F11 key
	k["VK_F12"]  = 0x7B; //	F12 key
	k["VK_F13"]  = 0x7C; //	F13 key
	k["VK_F14"]  = 0x7D; //	F14 key
	k["VK_F15"]  = 0x7E; //	F15 key
	k["VK_F16"]  = 0x7F; //	F16 key
	k["VK_F17"]  = 0x80; //	F17 key
	k["VK_F18"]  = 0x81; //	F18 key
	k["VK_F19"]  = 0x82; //	F19 key
	k["VK_F20"]  = 0x83; //	F20 key
	k["VK_F21"]  = 0x84; //	F21 key
	k["VK_F22"]  = 0x85; //	F22 key
	k["VK_F23"]  = 0x86; //	F23 key
	k["VK_F24"]  = 0x87; //	F24 key
	//k["-"]  = 0x88-8F	Unassigned
	k["VK_NUMLOCK"]  = 0x90; //	NUM LOCK key
	k["VK_SCROLL"]  = 0x91; //	SCROLL LOCK key
	//k["0x92-96	OEM specific
	//k["-"]  = 0x97-9F	Unassigned
	k["VK_LSHIFT"]  = 0xA0; //	Left SHIFT key
	k["VK_RSHIFT"]  = 0xA1; //	Right SHIFT key
	k["VK_LCONTROL"]  = 0xA2; //	Left CONTROL key
	k["VK_RCONTROL"]  = 0xA3; //	Right CONTROL key
	k["VK_LMENU"]  = 0xA4; //	Left ALT key
	k["VK_RMENU"]  = 0xA5; //	Right ALT key
	k["VK_BROWSER_BACK"]  = 0xA6; //	Browser Back key
	k["VK_BROWSER_FORWARD"]  = 0xA7; //	Browser Forward key
	k["VK_BROWSER_REFRESH"]  = 0xA8; //	Browser Refresh key
	k["VK_BROWSER_STOP"]  = 0xA9; //	Browser Stop key
	k["VK_BROWSER_SEARCH"]  = 0xAA; //	Browser Search key
	k["VK_BROWSER_FAVORITES"]  = 0xAB; //	Browser Favorites key
	k["VK_BROWSER_HOME"]  = 0xAC; //	Browser Start and Home key
	k["VK_VOLUME_MUTE"]  = 0xAD; //	Volume Mute key
	k["VK_VOLUME_DOWN"]  = 0xAE; //	Volume Down key
	k["VK_VOLUME_UP"]  = 0xAF; //	Volume Up key
	k["VK_MEDIA_NEXT_TRACK"]  = 0xB0; //	Next Track key
	k["VK_MEDIA_PREV_TRACK"]  = 0xB1; //	Previous Track key
	k["VK_MEDIA_STOP"]  = 0xB2; //	Stop Media key
	k["VK_MEDIA_PLAY_PAUSE"]  = 0xB3; //	Play/Pause Media key
	k["VK_LAUNCH_MAIL"]  = 0xB4; //	Start Mail key
	k["VK_LAUNCH_MEDIA_SELECT"]  = 0xB5; //	Select Media key
	k["VK_LAUNCH_APP1"]  = 0xB6; //	Start Application 1 key
	k["VK_LAUNCH_APP2"]  = 0xB7; //	Start Application 2 key
	//k["-"]  = 0xB8-B9	Reserved
	k["VK_OEM_1"]  = 0xBA; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key
	k["VK_OEM_PLUS"]  = 0xBB; //	For any country/region, the '+' key
	k["VK_OEM_COMMA"]  = 0xBC; //	For any country/region, the ',' key
	k["VK_OEM_MINUS"]  = 0xBD; //	For any country/region, the '-' key
	k["VK_OEM_PERIOD"]  = 0xBE; //	For any country/region, the '.' key
	k["VK_OEM_2"]  = 0xBF; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key
	k["VK_OEM_3"]  = 0xC0; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key
	//k["-"]  = 0xC1-D7	Reserved
	//k["-"]  = 0xD8-DA	Unassigned
	k["VK_OEM_4"]  = 0xDB; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key
	k["VK_OEM_5"]  = 0xDC; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\|' key
	k["VK_OEM_6"]  = 0xDD; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key
	k["VK_OEM_7"]  = 0xDE; //	Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key
	k["VK_OEM_8"]  = 0xDF; //	Used for miscellaneous characters; it can vary by keyboard.
	//k["-"]  = 0xE0	Reserved
	//k["0xE1	OEM specific
	k["VK_OEM_102"]  = 0xE2; //	The <> keys on the US standard keyboard, or the \\| key on the non-US 102-key keyboard
	//k["0xE3-E4	OEM specific
	k["VK_PROCESSKEY"]  = 0xE5;	//IME PROCESS key
	//k["0xE6	OEM specific
	k["VK_PACKET"]  = 0xE7; //	Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
	//k["-"]  = 0xE8	Unassigned
	//k["0xE9-F5	OEM specific
	k["VK_ATTN"]  = 0xF6; //	Attn key
	k["VK_CRSEL"]  = 0xF7; //	CrSel key
	k["VK_EXSEL"]  = 0xF8; //	ExSel key
	k["VK_EREOF"]  = 0xF9; //	Erase EOF key
	k["VK_PLAY"]  = 0xFA; //	Play key
	k["VK_ZOOM"]  = 0xFB; //	Zoom key
	k["VK_NONAME"]  = 0xFC; //	Reserved
	k["VK_PA1"]  = 0xFD; //	PA1 key
	k["VK_OEM_CLEAR"]  = 0xFE; //	Clear key
	
	"public enum KEYB_EVENT {".Dump();
	foreach(var kv in k)
	{
		Console.WriteLine($"    {kv.Key} = 0x{kv.Value.ToString("X2")},");
	}
	"}".Dump();
}
