using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DAVIDSystems.Helper
{
    class SingleInstance
    {
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        [DllImport("user32.dll")] private static extern 
            bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")] private static extern
            bool ShowWindowAsync(IntPtr hWnd, SHOWWINDOW nCmdShow);
        [DllImport("user32.dll")] private static extern 
            bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        private const int SW_RESTORE = 9;
        private const int SW_SHOW = 5;
        private const int SW_HIDE = 0;

        public enum SHOWWINDOW : int
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11,
        }

        public static bool IsSecondInstance()
        {
            bool develop = false;
            string proc = Process.GetCurrentProcess().ProcessName;
            Logfile.Instance().WriteToLog("ProcessName: " + proc);

            if (proc.Contains("vshost"))
            {
                develop = true;
            }

            Process[] procs = Process.GetProcessesByName(proc);

            if (procs.Length > 1)
            {
                Logfile.Instance().WriteToLog("There is an instance of the Application already running !");

                Process p = Process.GetCurrentProcess();
                
                int n = 0;        // assume the other process is at index 0

                // if this process id is OUR process ID...

                if (procs[0].Id == p.Id)
                {
                    // then the other process is at index 1
                    n = 1;
                }

                if (develop)
                {
                    procs[n].Kill();
                    return false;
                }

                // get the window handle
                IntPtr hWnd = procs[n].MainWindowHandle;
                // if iconic, we need to restore the window

                if (IsIconic(hWnd) || IsHidden(hWnd))
                {
                    Logfile.Instance().WriteToLog("Try Show Window !");
                    ShowWindowAsync(hWnd, SHOWWINDOW.SW_SHOWNORMAL);
                }
                // bring it to the foreground

                SetForegroundWindow(hWnd);
                // exit our process
 
                return true;
            }

            return false;
        }
        
        private static bool IsHidden(IntPtr hWnd)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(hWnd, ref placement);

            Logfile.Instance().WriteToLog("showCMD = " + placement.showCmd.ToString());

            if (placement.showCmd == SW_HIDE)
            {
                return true;
            }

            return false;
        }
        
        public static IntPtr IntPtrAlloc<T>(T param)
        {
            IntPtr retval = Marshal.AllocHGlobal(Marshal.SizeOf(param));
            Marshal.StructureToPtr(param, retval, false);
            return (retval);
        }

        public static void IntPtrFree(IntPtr preAllocated)
        {
            if (IntPtr.Zero == preAllocated) throw (new Exception("Go Home"));
            Marshal.FreeHGlobal(preAllocated); preAllocated = IntPtr.Zero;
        }

    }
}
