using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSTools
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        #region PS Tools
        Process CreateRunningProcess()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.ErrorDialog = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            process.StartInfo = startInfo;
            return process;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<string> TCPPing()
        {
            return await Task.Factory.StartNew<string>(() =>
            {
                try
                {
                    btnRunTCPPing.Enabled = false;
                    Process process = CreateRunningProcess();
                    process.StartInfo.FileName = Path.Combine(Application.StartupPath, @"Pstools\psping.exe");
                    process.StartInfo.Arguments = string.Format(
                        " {0} {1} {2}",
                        cbIPv.SelectedIndex == 0 ? "-4" : "-6",
                        txtDes.Text,
                        cbHistogram.Checked ? "-" + numHistogram.Value : "");

                    process.Start();

                    string res = string.Format("============{0}========={1}Arguments: {2}{1}{3}{1}",
                        DateTime.Now, Environment.NewLine,
                        process.StartInfo.Arguments,
                        process.StandardOutput.ReadToEnd());
                   
                    process.WaitForExit();

                    return res;
                }
                finally
                {
                    btnRunTCPPing.Enabled = true;
                }
            });

        }
        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            cbIPv.SelectedIndex = 0;
        }

        private async void btnRunTCPPing_Click(object sender, EventArgs e)
        {
            await TCPPing().ContinueWith(x =>
            {
                txtTCPPingResult.Text += x.Result;
            });
        }
    }
}
