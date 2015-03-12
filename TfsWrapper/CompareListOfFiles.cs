using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading.Tasks;

namespace TfsWrapper
{
    public partial class CompareListOfFiles : Form
    {
        public string FolderLeft { get; set; }
        public string FolderRight { get; set; }


        public CompareListOfFiles(string folderLeft, string folderRight)
        {
            this.FolderLeft = folderLeft;
            this.FolderRight = folderRight;

            InitializeComponent();

            ConfigColumns(lstViewLeft);
            ConfigColumns(lstViewRight);
            //lstViewLeft.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            //lstViewLeft.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

        }

        void ConfigColumns(ListView lv)
        {
            lv.Columns.Add("File name", -2, HorizontalAlignment.Left);
            lv.Columns.Add("Size", -2, HorizontalAlignment.Left);
            lv.View = View.Details;
        }

        private void CompareListOfFiles_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(FolderLeft))
                {
                    throw new Exception("Not found:" + FolderLeft);
                }

                if (!Directory.Exists(FolderRight))
                {
                    throw new Exception("Not found:" + FolderRight);
                }

                fileSystemWatcherLeft.Path = FolderLeft;
                fileSystemWatcherRight.Path = FolderRight;


                this.Compare();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        delegate void UniversalVoidDelegate();
        /// <summary>
        /// 
        /// </summary>
        void Compare()
        {
            try
            {
                //Task.Factory.StartNew(() =>
                //{
                //    if (lstViewLeft.InvokeRequired)
                //    {
                //        this.Invoke(new UniversalVoidDelegate(() =>
                //        {
                List<FileInfo> leftFiles = new List<FileInfo>(Directory.GetFiles(FolderLeft, "*.*", SearchOption.TopDirectoryOnly).Select(x => new FileInfo(x)));
                List<FileInfo> rightFiles = new List<FileInfo>(Directory.GetFiles(FolderRight, "*.*", SearchOption.TopDirectoryOnly).Select(x => new FileInfo(x)));

                var files = leftFiles.Select(x => x.Name).Union(rightFiles.Select(x => x.Name)).ToArray();

                lstViewLeft.Items.Clear();
                lstViewRight.Items.Clear();

                for (int i = 0; i < files.Count(); i++)
                {
                    var fl = leftFiles.FirstOrDefault(x=>x.Name==files[i]);
                    var fr = rightFiles.FirstOrDefault(x => x.Name == files[i]);
                    lstViewLeft.Items.Add(this.CreateItem(fl, files[i]));
                    lstViewRight.Items.Add(this.CreateItem(fr, files[i]));
                }

             
                //        }));
                //    }

                //});

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ListViewItem CreateItem(FileInfo file, string fileName)
        {
            ListViewItem li = new ListViewItem(file.Name);
            li.SubItems.Add(file.Length.ToString());

            //  li.SubItems.Add(file.Length.ToString());
            // sub1.Name = "columnHeader1";
            return li;
        }

        /// <summary>
        /// File watcher 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemWatcherLeft_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                ;
            }
        }

        /// <summary>
        /// File watcher 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemWatcherRight_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                ;
            }
        }
    }
}
