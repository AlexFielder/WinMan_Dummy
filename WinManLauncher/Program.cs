using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinManLauncher
{
    class Program
    {
        [DllImport("User32.dll", SetLastError = true)]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd);

        //...
        private static void Main()
        {
            Process p = Process.Start(@"C:\Users\Alex.Fielder\Source\Repos\WinMan_Dummy\WinMan_Dummy\bin\Debug\WinMan.exe");
            p.WaitForInputIdle();
            IntPtr h = p.MainWindowHandle;
            while (p.MainWindowHandle == IntPtr.Zero)
            {
                System.Threading.Thread.Sleep(100);
            }
            ActivateApp("winman.exe");
            //ActivateApp("Logon - Winman Live");
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("1");
        }

        static void ActivateApp(string processName)
        {
            Process[] p = Process.GetProcessesByName(processName);

            // Activate the first application we find with this name
            if (p.Count() > 0)
                SetForegroundWindow(p[0].MainWindowHandle);
        }
    }
}
