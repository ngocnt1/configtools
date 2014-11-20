using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace AutoCopy
{
    public partial class Main : Form
    {
        bool processing;
        Dictionary<string, long> files = new Dictionary<string, long>();
        public Main()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbFolder.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.SelectedPath = tbFolder.Text;
            if (folderBrowserDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbDestination.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", Application.ProductName, Application.ProductVersion);
            this.State();
        }

        void State()
        {
            panel1.Enabled = !cbActive.Checked;
        }

        void Monitor()
        {
            if (Directory.Exists(tbFolder.Text))
            {
                lbStatus.Text = string.Format("Files: {0} {1}",
                    Directory.GetFiles(tbFolder.Text).Count(), processing ? " | Copying ...." : "");
            }
        }

        private void cbActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.State();
                if (cbActive.Checked)
                {
                    string[] _settings = tbFiles.Lines;
                    files.Clear();
                    foreach (var item in _settings)
                    {
                        files.Add(item.Split('|')[0], long.Parse(item.Split('|')[1]));
                    }
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Monitor();

            try
            {
                if (
                    cbActive.Checked
                    && !processing
                    && Directory.Exists(tbFolder.Text)
                    && Directory.Exists(tbDestination.Text)
                    )
                {
                    processing = true;
                    try
                    {
                        foreach (var item in Directory.GetFiles(tbFolder.Text))
                        {
                            FileInfo fi = new FileInfo(item);
                            string filename = Path.GetFileName(item);
                            if (files.ContainsKey(filename) && fi.Length >= files[filename])
                            {
                                File.Move(item, Path.Combine(tbDestination.Text, filename));
                            }
                        }
                    }
                    finally
                    {
                        processing = false;
                    }
                }
            }
            catch (Exception)
            {
                ;
            }
        }


    }
}
