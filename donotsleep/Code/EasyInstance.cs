using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Easy.Logging;

namespace Easy.Instance
{
    class SingleInstance
    {
        [DllImport("user32.dll")]
        private static extern
            bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern
            bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
            bool IsWindowVisible(IntPtr hWnd);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(CallBackPtr lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        private delegate bool CallBackPtr(int hwnd, int lParam);
        private static CallBackPtr callBackPtr = Callback;
        private static List<WinStruct> _WinStructList = new List<WinStruct>();


        private const int SW_RESTORE = 9;
        private const int SW_SHOW = 5;


        private static bool Callback(int hWnd, int lparam)
        {
            StringBuilder sb = new StringBuilder(256);
            int res = GetWindowText((IntPtr)hWnd, sb, 256);
            _WinStructList.Add(new WinStruct { MainWindowHandle = hWnd, WinTitle = sb.ToString() });
            return true;
        }

        public static List<WinStruct> GetWindows()
        {
            _WinStructList = new List<WinStruct>();
            EnumWindows(callBackPtr, IntPtr.Zero);
            return _WinStructList;
        }

        public static bool IsSecondInstance(string title)
        {
            string proc = Process.GetCurrentProcess().ProcessName;
            EasyLog.LogDebug("ProcessName: {0}", proc);

            Process[] procs = Process.GetProcessesByName(proc);

            if (procs.Length > 1)
            {
                EasyLog.LogDebug("There is an instance of the Application already running !");

                IntPtr hWnd = IntPtr.Zero;

                // Find the real windows
                var windows = GetWindows();
                foreach (var window in windows)
                {
                    if (window.WinTitle == title)
                    {
                        hWnd = (IntPtr)window.MainWindowHandle;
                    }
                }

                // get the window handle
                // if iconic, we need to restore the window

                if (IsIconic(hWnd))
                {
                    ShowWindowAsync(hWnd, SW_SHOW);
                }

                if (!IsWindowVisible(hWnd))
                {
                    ShowWindowAsync(hWnd, SW_SHOW);
                }
                // bring it to the foreground

                SetForegroundWindow(hWnd);
                // exit our process

                return true;
            }

            return false;
        }
    }

    public class WinStruct
    {
        public string WinTitle { get; set; }
        public int MainWindowHandle { get; set; }
    }
}
