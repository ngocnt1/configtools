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
    public partial class FilePicker : UserControl
    {
        public FilePicker()
        {
            InitializeComponent();
        }

        public string FilePath
        {
            get
            {                
                return tbPath.Text;
            }
            set { tbPath.Text = value; }
        }

        [Browsable(true)]
        public string Label
        {
            get { return label3.Text; }
            set { label3.Text = value; }
        }

        [Browsable(true)]
        public string Filter
        {
            get { return filePara.Filter; }
            set { filePara.Filter = value; }
        }

        public void SavePath()
        {
            try
            {
                string _log = Path.Combine(Application.StartupPath, Path.GetFileNameWithoutExtension(FilePath) + ".txt");
                if (!string.IsNullOrWhiteSpace(FilePath))
                {
                   
                    using (FileStream fs = File.Open(_log, FileMode.OpenOrCreate))
                    {
                        StreamReader sr = new StreamReader(fs);
                        if (sr.ReadToEnd().Contains(FilePath))
                        {
                            sr.Close();
                        }
                        else
                        {
                            StreamWriter sw = new StreamWriter(fs);
                            sw.WriteLine(FilePath);
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

        private void filePara_FileOk(object sender, CancelEventArgs e)
        {
            tbPath.Text = filePara.FileName;
        }

        private void btnOpenWWW_Click(object sender, EventArgs e)
        {
            filePara.FileName = tbPath.Text;
            filePara.ShowDialog();
        }
    }
}
