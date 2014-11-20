using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace AwdTimer
{
    static class Program
    {
        public static ILog Logger
        {
            get
            {
                return LogManager.GetLogger(typeof(Program));
            }
        }
        internal static bool AutoHide = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var current = Process.GetCurrentProcess();
            if (!Process.GetProcesses().Any(x => x.ProcessName == current.ProcessName && x.Id != current.Id))
            {
                if (args != null && args.Length > 0 && args[0].Equals("-autohide"))
                {
                    AutoHide = true;
                }
                Application.Run(new Main());
            }
            else
            {
                MessageBox.Show("This program has been running already.");
            }
        }
    }
}
