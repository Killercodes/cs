using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;


namespace Robot
{
	
	public static class Gui
	{
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		public static string GetActiveWindowTitle()
		{
			const int nChars = 256;
			StringBuilder Buff = new StringBuilder(nChars);
			IntPtr handle = GetForegroundWindow();

			if (GetWindowText(handle, Buff, nChars) > 0)
			{
				return Buff.ToString();
			}
			return null;
		}
		
		public static IntPtr GetActiveWindow()
		{
			IntPtr handle = GetForegroundWindow();
			return handle;
		}
		
		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);
		
		public static void SetActiveWindow(IntPtr hWnd)
		{			
			SetForegroundWindow(hWnd);
		}
		
		public static void SetActiveWindow(string processname)
		{
			Process[] processes = Process.GetProcessesByName(processname);
			SetForegroundWindow(processes[0].MainWindowHandle);
		}
		
		public static Process[] GetProcess(string processname)
		{
			return Process.GetProcessesByName(processname);
		}

		public static Process Run(string exeName)
		{
			return Process.Start(exeName);
		}
		
		public static Process Run(string exeName,string arg)
		{
			return Process.Start(exeName,arg);
		}
	}
	
	public static class Sound
	{
		public static void Speak(string message)
		{
			//
		}
		
	}
	
	
	
	public enum MOUSE_EVENT
	{
	    LEFTDOWN = 0x00000002,
	    LEFTUP = 0x00000004,
	    MIDDLEDOWN = 0x00000020,
	    MIDDLEUP = 0x00000040,
	    MOVE = 0x00000001,
	    ABSOLUTE = 0x00008000,
	    RIGHTDOWN = 0x00000008,
	    RIGHTUP = 0x00000010
	}
	
	public static class Mouse
	{
		
		//This is a replacement for Cursor.Position in WinForms
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		static extern bool SetCursorPos(int x, int y);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

		public const int MOUSEEVENTF_LEFTDOWN = 0x02;
		public const int MOUSEEVENTF_LEFTUP = 0x04;
		public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
		public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
		public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
		public const int MOUSEEVENTF_RIGHTUP = 0x0010;
		public const int MOUSEEVENTF_WHEEL = 0x0800;


		public static void Delay(int delay)
		{
			System.Threading.Thread.Sleep(delay);
		}
		
		//This simulates a left mouse click
		public static void Move(int xpos, int ypos)
		{
			SetCursorPos(xpos, ypos);
		}
		
		public static void MiddleClick(int delay = 100)
		{
			mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
			System.Threading.Thread.Sleep(delay);
			mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
		}
		
		public static void MiddleClickDown(int delay = 100)
		{
			mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
		}
		
		public static void MiddleClickUp(int delay = 100)
		{
			mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
		}
		
		
		public static void LeftClick(int delay = 100)
		{
			mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
			System.Threading.Thread.Sleep(delay);
			mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
		}
		
		public static void LeftClickDown(int delay = 100)
		{
			mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
		}
		
		public static void LeftClickUp(int delay = 100)
		{
			mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
		}
		
		public static void RightClick(int delay = 100)
		{
			mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
			System.Threading.Thread.Sleep(delay);
			mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
		}
		
		public static void RightClickDown(int delay = 100)
		{
			mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
		}
		
		public static void RightClickUp(int delay = 100)
		{
			mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
		}
		
		
		//helper 		
		public static int ToInt(this object ob)
		{
			return (int)ob;
		}

	}
	
	public static class Keyboard
	{	
		
		[DllImport("user32.dll", SetLastError = true)]
		static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
		
		public static void Delay(int delay)
		{
			System.Threading.Thread.Sleep(delay);
		}
		
		public static void KeyDown(KEYCODE keycode)
		{
			keybd_event((byte)keycode, 0x0, 0, 0);// presses ctrl
		}
		
		public static void KeyPress(KEYCODE keycode, int delay)
		{
			keybd_event((byte)keycode, 0x0, 0, 0);// presses ctrl
			System.Threading.Thread.Sleep(delay);
			keybd_event((byte)keycode, 0x0, 2, 0); //releases ctrl
		}
		
		public static void KeyUp(KEYCODE keycode)
		{
			keybd_event((byte)keycode, 0, 2, 0); //release
		}
		
		public static void Type(string message)
		{
			System.Windows.Forms.SendKeys.SendWait(message);
		}
		
		//helper 		
	}
	
	public enum KEYCODE {
		VM_LBUTTON = 0x01,
		VM_RBUTTON = 0x02,
		VK_CANCEL = 0x03,
		VM_MBUTTON = 0x04,
		VM_XBUTTON1 = 0x05,
		VM_XBUTTON2 = 0x06,
		VK_BACK = 0x08,
		VK_TAB = 0x09,
		VK_CLEAR = 0x0C,
		VK_RETURN = 0x0D,
		VK_SHIFT = 0x10,
		VK_CONTROL = 0x11,
		VK_MENU = 0x12,
		VK_PAUSE = 0x13,
		VK_CAPITAL = 0x14,
		VK_KANA = 0x15,
		VK_HANGUEL = 0x15,
		VK_HANGUL = 0x15,
		VK_IME_ON = 0x16,
		VK_JUNJA = 0x17,
		VK_FINAL = 0x18,
		VK_HANJA = 0x19,
		VK_KANJI = 0x19,
		VK_IME_OFF = 0x1A,
		VK_ESCAPE = 0x1B,
		VK_CONVERT = 0x1C,
		VK_NONCONVERT = 0x1D,
		VK_ACCEPT = 0x1E,
		VK_MODECHANGE = 0x1F,
		VK_SPACE = 0x20,
		VK_PRIOR = 0x21,
		VK_NEXT = 0x22,
		VK_END = 0x23,
		VK_HOME = 0x24,
		VK_LEFT = 0x25,
		VK_UP = 0x26,
		VK_RIGHT = 0x27,
		VK_DOWN = 0x28,
		VK_SELECT = 0x29,
		VK_PRINT = 0x2A,
		VK_EXECUTE = 0x2B,
		VK_SNAPSHOT = 0x2C,
		VK_INSERT = 0x2D,
		VK_DELETE = 0x2E,
		VK_HELP = 0x2F,
		VK_0 = 0x30,
		VK_1 = 0x31,
		VK_2 = 0x32,
		VK_3 = 0x33,
		VK_4 = 0x34,
		VK_5 = 0x35,
		VK_6 = 0x36,
		VK_7 = 0x37,
		VK_8 = 0x38,
		VK_9 = 0x39,
		VK_A = 0x41,
		VK_B = 0x42,
		VK_C = 0x43,
		VK_D = 0x44,
		VK_E = 0x45,
		VK_F = 0x46,
		VK_G = 0x47,
		VK_H = 0x48,
		VK_I = 0x49,
		VK_J = 0x4A,
		VK_K = 0x4B,
		VK_L = 0x4C,
		VK_M = 0x4D,
		VK_N = 0x4E,
		VK_O = 0x4F,
		VK_P = 0x50,
		VK_Q = 0x51,
		VK_R = 0x52,
		VK_S = 0x53,
		VK_T = 0x54,
		VK_U = 0x55,
		VK_V = 0x56,
		VK_W = 0x57,
		VK_X = 0x58,
		VK_Y = 0x59,
		VK_Z = 0x5A,
		VK_LWIN = 0x5B,
		VK_RWIN = 0x5C,
		VK_APPS = 0x5D,
		VK_SLEEP = 0x5F,
		VK_NUMPAD0 = 0x60,
		VK_NUMPAD1 = 0x61,
		VK_NUMPAD2 = 0x62,
		VK_NUMPAD3 = 0x63,
		VK_NUMPAD4 = 0x64,
		VK_NUMPAD5 = 0x65,
		VK_NUMPAD6 = 0x66,
		VK_NUMPAD7 = 0x67,
		VK_NUMPAD8 = 0x68,
		VK_NUMPAD9 = 0x69,
		VK_MULTIPLY = 0x6A,
		VK_ADD = 0x6B,
		VK_SEPARATOR = 0x6C,
		VK_SUBTRACT = 0x6D,
		VK_DECIMAL = 0x6E,
		VK_DIVIDE = 0x6F,
		VK_F1 = 0x70,
		VK_F2 = 0x71,
		VK_F3 = 0x72,
		VK_F4 = 0x73,
		VK_F5 = 0x74,
		VK_F6 = 0x75,
		VK_F7 = 0x76,
		VK_F8 = 0x77,
		VK_F9 = 0x78,
		VK_F10 = 0x79,
		VK_F11 = 0x7A,
		VK_F12 = 0x7B,
		VK_F13 = 0x7C,
		VK_F14 = 0x7D,
		VK_F15 = 0x7E,
		VK_F16 = 0x7F,
		VK_F17 = 0x80,
		VK_F18 = 0x81,
		VK_F19 = 0x82,
		VK_F20 = 0x83,
		VK_F21 = 0x84,
		VK_F22 = 0x85,
		VK_F23 = 0x86,
		VK_F24 = 0x87,
		VK_NUMLOCK = 0x90,
		VK_SCROLL = 0x91,
		VK_LSHIFT = 0xA0,
		VK_RSHIFT = 0xA1,
		VK_LCONTROL = 0xA2,
		VK_RCONTROL = 0xA3,
		VK_LMENU = 0xA4,
		VK_RMENU = 0xA5,
		VK_BROWSER_BACK = 0xA6,
		VK_BROWSER_FORWARD = 0xA7,
		VK_BROWSER_REFRESH = 0xA8,
		VK_BROWSER_STOP = 0xA9,
		VK_BROWSER_SEARCH = 0xAA,
		VK_BROWSER_FAVORITES = 0xAB,
		VK_BROWSER_HOME = 0xAC,
		VK_VOLUME_MUTE = 0xAD,
		VK_VOLUME_DOWN = 0xAE,
		VK_VOLUME_UP = 0xAF,
		VK_MEDIA_NEXT_TRACK = 0xB0,
		VK_MEDIA_PREV_TRACK = 0xB1,
		VK_MEDIA_STOP = 0xB2,
		VK_MEDIA_PLAY_PAUSE = 0xB3,
		VK_LAUNCH_MAIL = 0xB4,
		VK_LAUNCH_MEDIA_SELECT = 0xB5,
		VK_LAUNCH_APP1 = 0xB6,
		VK_LAUNCH_APP2 = 0xB7,
		VK_OEM_1 = 0xBA,
		VK_OEM_PLUS = 0xBB,
		VK_OEM_COMMA = 0xBC,
		VK_OEM_MINUS = 0xBD,
		VK_OEM_PERIOD = 0xBE,
		VK_OEM_2 = 0xBF,
		VK_OEM_3 = 0xC0,
		VK_OEM_4 = 0xDB,
		VK_OEM_5 = 0xDC,
		VK_OEM_6 = 0xDD,
		VK_OEM_7 = 0xDE,
		VK_OEM_8 = 0xDF,
		VK_OEM_102 = 0xE2,
		VK_PROCESSKEY = 0xE5,
		VK_PACKET = 0xE7,
		VK_ATTN = 0xF6,
		VK_CRSEL = 0xF7,
		VK_EXSEL = 0xF8,
		VK_EREOF = 0xF9,
		VK_PLAY = 0xFA,
		VK_ZOOM = 0xFB,
		VK_NONAME = 0xFC,
		VK_PA1 = 0xFD,
		VK_OEM_CLEAR = 0xFE
	}
	
}
