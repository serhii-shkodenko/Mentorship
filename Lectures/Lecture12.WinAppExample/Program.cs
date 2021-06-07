using System;
using System.Threading;
using System.Windows.Forms;

namespace Lecture12.WinAppExample
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Thread.CurrentThread.Name = "MainThread";
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Deadlock());
        }
    }
}