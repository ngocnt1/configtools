using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.Win32;
namespace AwdTimer
{
    public partial class Main : Form
    {
        int Deployed = 0;
        bool started = false;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = this.Text + " - " + this.ProductVersion;

                RegistryKey key = Registry.CurrentUser;//.OpenSubKey("Software");
                var awd = key.OpenSubKey("AWD");
                if (awd == null)
                {
                    awd = key.CreateSubKey("AWD", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryOptions.None);
                }

                txtPackDir.Text = string.Format("{0}", awd.GetValue("Package"));
                txtScenerioXml.Text = string.Format("{0}", awd.GetValue("Roots"));
                chkServiceMode.Checked = (awd.GetValue("ServiceMode") as string) == "1";
                timer1.Enabled = (awd.GetValue("Started") as string) == "1";
                txtPackDir.Enabled = txtScenerioXml.Enabled =
                   !timer1.Enabled;
                btnStart.Text = timer1.Enabled ? "Stop" : "Start";
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            btnStart.Text = timer1.Enabled ? "Stop" : "Start";
            txtPackDir.Enabled = txtScenerioXml.Enabled =
                !timer1.Enabled;

            RegistryKey key = Registry.CurrentUser;//.OpenSubKey("Sofware");
            var awd = key.OpenSubKey("AWD", true);
            awd.SetValue("Package", txtPackDir.Text);
            awd.SetValue("Roots", txtScenerioXml.Text);
            awd.SetValue("ServiceMode", chkServiceMode.Checked ? "1" : "0");
            awd.SetValue("Started", timer1.Enabled ? "1" : "0");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string shouldDeploy = Path.Combine(txtPackDir.Text, "_App_Offline.htm");
                if (chkServiceMode.Checked) return;
                if (!started)
                {
                    started = true;
                    try
                    {
                        lbLastUpdate.Text = "last update: " + DateTime.Now.ToString();
                        if (!string.IsNullOrWhiteSpace(txtPackDir.Text) && Directory.Exists(txtPackDir.Text))
                        {

                            if (File.Exists(shouldDeploy))
                            {
                                if (txtScenerioXml.Lines != null)
                                {
                                    foreach (var r in txtScenerioXml.Lines)
                                    {
                                        File.Copy(shouldDeploy, Path.Combine(r, "App_Offline.htm"));
                                    }
                                }
                                Process proc = new Process();
                                proc.StartInfo.CreateNoWindow = false;
                                proc.StartInfo.WorkingDirectory = txtPackDir.Text;
                                proc.StartInfo.FileName = "awd.bat";
                                if (proc.Start())
                                {
                                    proc.WaitForExit();
                                }
                                Deployed++;
                                File.Delete(shouldDeploy);
                                if (txtScenerioXml.Lines != null)
                                {
                                    foreach (var r in txtScenerioXml.Lines)
                                    {
                                        File.Delete(Path.Combine(r, "App_Offline.htm"));
                                    }
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Program.Logger.Error(ex);
                    }
                    finally
                    {

                        started = false;
                    }
                }
                else
                {
                    if (Directory.Exists(shouldDeploy))
                    {
                        btnStart.Enabled = false;
                        btnStart.Text = "Deploying ...";
                    }
                    else
                    {
                        btnStart.Enabled = true;
                        btnStart.Text = timer1.Enabled ? "Stop" : "Start";

                    }
                }
                lbWebroots.Text = string.Format("Webroots: Deployed {0} time(s)", Deployed);
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex);
            }
        }

        private void txtPackDir_TextChanged(object sender, EventArgs e)
        {
            lblPackDir.ForeColor = Directory.Exists(txtPackDir.Text) ? Color.Green : Color.Red;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Show(bool hide)
        {
            hideToolStripMenuItem.Text = hide ? "Show" : "Hide";
            if (hide)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(3000, this.Text, "Minimized to here", ToolTipIcon.Info);
            }
            else
            {
                this.Show();
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(this.Visible);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                Show(true);
                e.Cancel = true;
            }
        }

        private void Main_Layout(object sender, LayoutEventArgs e)
        {
            if (Program.AutoHide)
            {
                this.Show(true);
                Program.AutoHide = false;
            }
        }

        private void btnOpenLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (File.Exists(Path.Combine(Application.StartupPath,"log.txt")))
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        UseShellExecute=true,
                        FileName = Path.Combine(Application.StartupPath, "log.txt"),
                         WindowStyle = ProcessWindowStyle.Normal
                    });
                }
                else
                {
                    MessageBox.Show("No logs");
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
