using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace KeyHook
{
    public class GenerateEvent
    {
        public void Generate(int Keytype, EventHandler eve)
        {
            var interceptKeyboard = new InterceptKeyboard();

            //interceptKeyboard.KeyDownEvent += InterceptKeyboard_KeyDownEvent;
            //interceptKeyboard.KeyUpEvent += InterceptKeyboard_KeyUpEvent;
            //interceptKeyboard.Start();

        }

        //private static void InterceptKeyboard_KeyUpEvent(object sender, InterceptKeyboard.OriginalKeyEventArg e)
        //{
        //    Console.WriteLine("Keyup KeyCode {0}", e.KeyCode);
        //}

        //private static void InterceptKeyboard_KeyDownEvent(object sender, InterceptKeyboard.OriginalKeyEventArg e)
        //{
        //    Console.WriteLine("Keydown KeyCode {0}", e.KeyCode);
        //}

    }

    abstract class Keyboardhook
    {
        [Flags]
        public enum HBDLLHOOKSTRUCTFlags : uint
        {
            KEYEVENTF_EXTENDEDKEY = 0x0001,
            KEYEVENTF_KEYUP = 0x0002,
            KEYEVENTF_SCANCODE = 0x0008,
            KEYEVENTF_UNICODE = 0x0004,
        }

        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public HBDLLHOOKSTRUCTFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        public const int WH_KEYBOARD_LL = 0x000D;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;

        #region Win32 Methods
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        #region Delegate
        private delegate IntPtr KeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Fields
        private static KeyboardProc proc;
        private static IntPtr hookId = IntPtr.Zero;
        #endregion

        public static event EventHandler KeyEvent = delegate { };

        public void Start()
        {
            if (hookId == IntPtr.Zero)
            {
                proc = HookProcedure;
                using (var curProcess = Process.GetCurrentProcess())
                {
                    using (ProcessModule curModule = curProcess.MainModule)
                    {
                        hookId = SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                    }
                }

            }
        }

        public void Stop()
        {
            UnhookWindowsHookEx(hookId);
            hookId = IntPtr.Zero;
        }

        public virtual IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }
    }
    class InterceptKeyboard : Keyboardhook
    {
        //inputEvent

        public class OriginalKeyEventArg : EventArgs
        {
            public int KeyCode { get; }

            public OriginalKeyEventArg(int keyCode)
            {
                KeyCode = keyCode;
            }
        }

        public delegate void KeyEventHandler(object sender, OriginalKeyEventArg e);
        public event KeyEventHandler KeyDownEvent;
        public event KeyEventHandler KeyUpEvent;

        protected void OnKeyDownEvent(int keyCode)
        {
            KeyDownEvent?.Invoke(this, new OriginalKeyEventArg(keyCode));
        }

        protected void OnKeyUpEvent(int keyCode)
        {
            KeyUpEvent?.Invoke(this, new OriginalKeyEventArg(keyCode));
        }

        public override IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                var kb = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                var vkCode = (int)kb.vkCode;
                OnKeyDownEvent(vkCode);
            }
            else if (nCode >= 0 && (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP))
            {
                var kb = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                var vkCode = (int)kb.vkCode;
                OnKeyUpEvent(vkCode);
            }

            return base.HookProcedure(nCode, wParam, lParam);
        }
    }
}
