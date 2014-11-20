using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace AWDSvc
{
    public partial class Timer : ServiceBase
    {
        private System.Timers.Timer _AWDTIMER = new System.Timers.Timer();
        static bool started = false;
        public Timer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //txtPackDir.Text = string.Format("{0}", awd.GetValue("Package"));
            //txtScenerioXml.Text = string.Format("{0}", awd.GetValue("Roots"));

            _AWDTIMER.AutoReset = true;
            _AWDTIMER.Interval = 5000;  // 5 seconds
            _AWDTIMER.Elapsed += AWDTIMER_Elapsed;
            _AWDTIMER.Start();

            EventLog.WriteEntry("Auto deployment service started.");
        }
        void AWDTIMER_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {      
                if (!started)
                {
                    _AWDTIMER.Stop();
                    started = true;
                    var reg = Reg;
                    var packPath = string.Format("{0}", reg.GetValue("Package"));
                    Process proc = new Process();
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.WorkingDirectory = packPath;
                    proc.StartInfo.FileName = "awd.bat";
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.RedirectStandardOutput = false;
                    proc.StartInfo.RedirectStandardError = false;
                    proc.StartInfo.ErrorDialog = false;

                    if (proc.Start())
                    {
                        proc.WaitForExit();
                    }
                    _AWDTIMER.Start();
                    started = false;
                }               
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ex.Message);
                _AWDTIMER.Start();
                started = false;
            }           
        }
        RegistryKey Reg
        {
            get
            {
                RegistryKey key = Registry.CurrentUser;
                var awd = key.OpenSubKey("AWD");
                if (awd == null)
                {
                    awd = key.CreateSubKey("AWD", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryOptions.None);
                }
                return awd;
            }
        }

        void _AWDTIMER_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                var reg = Reg;
                var packPath = string.Format("{0}", reg.GetValue("Package"));
                var roots = string.Format("{0}", reg.GetValue("Roots"));
                var isStarted = (reg.GetValue("Started") as string) == "1";
                var isServiceMode = (reg.GetValue("ServiceMode") as string) == "1";
                if (!isStarted || !isServiceMode) return;
                string shouldDeploy = Path.Combine(packPath, "_App_Offline.htm");
                if (!started)
                {
                    started = true;
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(packPath) && Directory.Exists(packPath))
                        {

                            if (File.Exists(shouldDeploy))
                            {
                                if (roots != null)
                                {
                                    foreach (var r in roots.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
                                    {
                                        File.Copy(shouldDeploy, Path.Combine(r, "App_Offline.htm"));
                                    }
                                }

                                //using (Runspace runspace = RunspaceFactory.CreateRunspace())
                                //{
                                //    runspace.Open();
                                //    PowerShell ps = PowerShell.Create();
                                //    ps.Runspace = runspace;
                                //    Command cmd = new Command(Path.Combine(packPath, "awd.ps1"), true);
                                //    ps.Commands.AddCommand(cmd);
                                //   // ps.Commands.AddScript(Path.Combine(packPath, "awd.ps1"), true);
                                //    ps.Commands.AddArgument("Web.Test");
                                //    StringBuilder result = new StringBuilder();
                                //    foreach (PSObject r in ps.Invoke())
                                //    {
                                //        result.AppendLine(r.ToString());
                                //    }

                                //    EventLog.WriteEntry(result.ToString());
                                //}

                                Process proc = new Process();
                                proc.StartInfo.CreateNoWindow = true;
                                proc.StartInfo.WorkingDirectory = packPath;
                                proc.StartInfo.FileName = "awd.bat";
                                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                proc.StartInfo.RedirectStandardOutput = true;
                                proc.StartInfo.RedirectStandardError = true;
                                proc.StartInfo.ErrorDialog = false;

                                if (proc.Start())
                                {
                                    proc.WaitForExit();
                                }
                                // Deployed++;
                                File.Delete(shouldDeploy);
                                if (roots != null)
                                {
                                    foreach (var r in roots.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
                                    {
                                        File.Delete(Path.Combine(r, "App_Offline.htm"));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {

                        started = false;
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ex.Message);
            }
        }

        protected override void OnStop()
        {
            _AWDTIMER.Stop();
            EventLog.WriteEntry("Auto deployment service stopped.");
        }
    }
}
