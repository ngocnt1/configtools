using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConfigSync.Para
{
    public partial class FolderPicker : UserControl
    {
        public FolderPicker()
        {
            InitializeComponent();
        }

        public string FolderPath
        {
            get {                
                return tbPath.Text; }
            set { tbPath.Text = value; }
        }

        [Browsable(true)]
        public string Label
        {
            get { return label3.Text; }
            set { label3.Text = value; }
        }

        public void SavePath()
        {
            try
            {
                string _log = Path.Combine(Application.StartupPath, "Config.txt");
                if (!string.IsNullOrWhiteSpace(FolderPath))
                {
                    
                    using (FileStream fs = File.Open(_log, FileMode.OpenOrCreate))
                    {
                        StreamReader sr = new StreamReader(fs);
                        if (sr.ReadToEnd().Contains(FolderPath))
                        {
                            sr.Close();
                        }
                        else
                        {
                            StreamWriter sw = new StreamWriter(fs);
                            sw.WriteLine(FolderPath);
                            sw.Flush();
                            fs.Flush();
                            sw.Close();
                        }
                    }
                }
                var _src = new AutoCompleteStringCollection();
                using (FileStream fs = File.Open(_log, FileMode.OpenOrCreate))
                {
                    StreamReader sr = new StreamReader(fs);
                    while (!sr.EndOfStream)
                    {
                        _src.Add(sr.ReadLine());
                    }
                    tbPath.AutoCompleteCustomSource = _src;
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog()== DialogResult.OK)
            {
                this.FolderPath = folderBrowser.SelectedPath;
            } 
        }
    }
}
