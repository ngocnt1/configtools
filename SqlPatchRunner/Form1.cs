using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

//Microsoft.SqlServer.Smo.dll
using Microsoft.SqlServer.Management.Smo;
//Microsoft.SqlServer.ConnectionInfo.dll
using Microsoft.SqlServer.Management.Common;

namespace SqlPatchRunner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void ReloadFileList()
        {
            listFiles.Items.Clear();
            foreach (var item in Directory.GetFiles(txtScriptsFolder.Text, "*.sql", SearchOption.TopDirectoryOnly))
            {
                listFiles.Items.Add(item);
            }
            lbScriptsAmount.Text = string.Format("{0} script(s)", listFiles.Items.Count);
        }
        bool TestConnection()
        {
            bool _test = false;
            using (SqlConnection connection = new SqlConnection(txtCS.Text))
            {
                connection.Open();
                _test = connection.State == ConnectionState.Open;
                connection.Close();
            }
            return _test;
        }
        void RunScript()
        {
            string scriptDirectory = txtScriptsFolder.Text;
            string sqlConnectionString = txtCS.Text;
            //DirectoryInfo di = new DirectoryInfo(scriptDirectory);
            //FileInfo[] rgFiles = di.GetFiles("*.sql");

            for (int i = 0; i < listFiles.Items.Count; i++)
            {
                string _file = listFiles.Items[i].ToString();
                FileInfo fileInfo = new FileInfo(_file);
                string script = fileInfo.OpenText().ReadToEnd();
                SqlConnection connection = new SqlConnection(sqlConnectionString);
                Server server = new Server(new ServerConnection(connection));
                server.ConnectionContext.ExecuteNonQuery(script);

                File.Move(_file, _file + ".done");
                listFiles.Items[i] = "[Done] >" + listFiles.Items[i];
            }

        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtScriptsFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnLockScripts_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnLockScripts.Tag.Equals("0"))
                {
                    ReloadFileList();
                    bool _connection = TestConnection();
                    lbSumDbConnection.Text = _connection ? "Db Connection established" : "Db Connection could not be established";
                    lbSumDbConnection.ForeColor = _connection ? Color.Green : Color.Red;
                }

                btnLockScripts.Tag = btnLockScripts.Tag.Equals("0") ? "1" : "0";
                btnLockScripts.Text = btnLockScripts.Tag.Equals("0") ? "Lock" : "Unlock";

                btnFolder.Enabled =
                txtCS.Enabled =
                txtScriptsFolder.Enabled = btnLockScripts.Tag.Equals("0");

                btnRun.Enabled = !txtCS.Enabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                btnRun.Enabled = false;
                RunScript();
                btnLockScripts.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnRun.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + Application.ProductVersion;
        }

    }
}
