using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Vision_Guided_Robot_Application
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Check if application is already run?
            string thisProcessName = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(p => p.ProcessName == thisProcessName) > 1)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            //Application.Run(new ModbusTest());
        }
    }
}
