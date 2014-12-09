using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TfsWrapper
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " - " + Application.ProductVersion;

            try
            {
                foreach (var rdo in new RadioButton[] { rdoVs2015, rdoVs2013, rdoVs2012, rdoVs2010 })
                {
                    if (rdo.Visible = File.Exists((string)rdo.Tag))
                    {
                        vsCheckedChanged(rdo, null);
                        break;
                    }
                }

                fileSrc.SavePath();
                fileTarget.SavePath();
                folderSrc.SavePath();
                folderTarget.SavePath();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string lb = btnCompare.Text;
            try
            {
                folderSrc.SavePath();
                folderTarget.SavePath();

                btnCompare.Enabled = false;
                btnCompare.Text = "Close the comparing to continue";
                Process proc = new Process();
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.FileName = string.Format(@"""{0}""", txtTF.Text);
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = string.Format(@"folderdiff ""{0}"" ""{1}"" {2} {3} {4}"
                    , folderSrc.FolderPath
                    , folderTarget.FolderPath
                    , cbRecursive.Checked ? "/recursive" : ""
                    , cbFilter.Checked ? "/filter:" + txtFilter.Text : ""
                    , !string.IsNullOrWhiteSpace(txtUser.Text) && !string.IsNullOrWhiteSpace(txtPwd.Text) ? "/login:" + txtUser.Text + "," + txtPwd.Text : "");
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnCompare.Enabled = true;
                btnCompare.Text = lb;
            }
        }

        private void btnCompareFiles_Click(object sender, EventArgs e)
        {
            string lb = btnCompareFiles.Text;
            try
            {
                fileSrc.SavePath();
                fileTarget.SavePath();

                btnCompareFiles.Enabled = false;
                btnCompareFiles.Text = "Close the comparing to continue";
                Process proc = new Process();
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.FileName = string.Format(@"""{0}""", txtVS.Text);
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = string.Format(@"/diff ""{0}"" ""{1}"""
                    , fileSrc.FilePath
                    , fileTarget.FilePath);
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnCompareFiles.Enabled = true;
                btnCompareFiles.Text = lb;
            }
        }

        private void vsCheckedChanged(object sender, EventArgs e)
        {
            txtVS.Text = txtTF.Text = ((RadioButton)sender).Tag.ToString();
            txtVS.Text = txtVS.Text.Replace("TF.exe", "devenv.exe");
        }
    }
}
