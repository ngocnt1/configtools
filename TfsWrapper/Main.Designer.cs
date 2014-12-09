namespace TfsWrapper
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTF = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.cbRecursive = new System.Windows.Forms.CheckBox();
            this.cbFilter = new System.Windows.Forms.CheckBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.folderTarget = new ConfigSync.Para.FolderPicker();
            this.folderSrc = new ConfigSync.Para.FolderPicker();
            this.rdoVs2010 = new System.Windows.Forms.RadioButton();
            this.rdoVs2012 = new System.Windows.Forms.RadioButton();
            this.rdoVs2013 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVS = new System.Windows.Forms.TextBox();
            this.btnCompareFiles = new System.Windows.Forms.Button();
            this.fileTarget = new ConfigSync.Para.FilePicker();
            this.fileSrc = new ConfigSync.Para.FilePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoVs2015 = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TFS Installation";
            // 
            // txtTF
            // 
            this.txtTF.Location = new System.Drawing.Point(128, 31);
            this.txtTF.Name = "txtTF";
            this.txtTF.ReadOnly = true;
            this.txtTF.Size = new System.Drawing.Size(456, 20);
            this.txtTF.TabIndex = 1;
            this.txtTF.Text = "c:\\Program Files (x86)\\Microsoft Visual Studio 11.0\\Common7\\IDE\\TF.exe";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(509, 160);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // cbRecursive
            // 
            this.cbRecursive.AutoSize = true;
            this.cbRecursive.Checked = true;
            this.cbRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecursive.Location = new System.Drawing.Point(128, 126);
            this.cbRecursive.Name = "cbRecursive";
            this.cbRecursive.Size = new System.Drawing.Size(74, 17);
            this.cbRecursive.TabIndex = 5;
            this.cbRecursive.Text = "Recursive";
            this.cbRecursive.UseVisualStyleBackColor = true;
            // 
            // cbFilter
            // 
            this.cbFilter.AutoSize = true;
            this.cbFilter.Checked = true;
            this.cbFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFilter.Location = new System.Drawing.Point(203, 127);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(80, 17);
            this.cbFilter.TabIndex = 7;
            this.cbFilter.Text = "Filter:(! ; *.*)";
            this.cbFilter.UseVisualStyleBackColor = true;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtFilter.Location = new System.Drawing.Point(280, 125);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(304, 21);
            this.txtFilter.TabIndex = 8;
            this.txtFilter.Text = "!*.dll;!obj\\;!bin\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Password:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(124, 8);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(135, 20);
            this.txtUser.TabIndex = 11;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(124, 31);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(135, 20);
            this.txtPwd.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(629, 230);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.folderTarget);
            this.tabPage1.Controls.Add(this.folderSrc);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtTF);
            this.tabPage1.Controls.Add(this.btnCompare);
            this.tabPage1.Controls.Add(this.txtFilter);
            this.tabPage1.Controls.Add(this.cbFilter);
            this.tabPage1.Controls.Add(this.cbRecursive);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(621, 204);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Compare Folders";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // folderTarget
            // 
            this.folderTarget.FolderPath = "";
            this.folderTarget.Label = "Target Folder:";
            this.folderTarget.Location = new System.Drawing.Point(47, 89);
            this.folderTarget.Name = "folderTarget";
            this.folderTarget.Size = new System.Drawing.Size(488, 22);
            this.folderTarget.TabIndex = 10;
            // 
            // folderSrc
            // 
            this.folderSrc.FolderPath = "";
            this.folderSrc.Label = "Source Folder:";
            this.folderSrc.Location = new System.Drawing.Point(45, 60);
            this.folderSrc.Name = "folderSrc";
            this.folderSrc.Size = new System.Drawing.Size(488, 22);
            this.folderSrc.TabIndex = 10;
            // 
            // rdoVs2010
            // 
            this.rdoVs2010.AutoSize = true;
            this.rdoVs2010.Location = new System.Drawing.Point(519, 27);
            this.rdoVs2010.Name = "rdoVs2010";
            this.rdoVs2010.Size = new System.Drawing.Size(64, 17);
            this.rdoVs2010.TabIndex = 9;
            this.rdoVs2010.Tag = "c:\\Program Files (x86)\\Microsoft Visual Studio 10.0\\Common7\\IDE\\TF.exe";
            this.rdoVs2010.Text = "Vs 2010";
            this.rdoVs2010.UseVisualStyleBackColor = true;
            this.rdoVs2010.CheckedChanged += new System.EventHandler(this.vsCheckedChanged);
            // 
            // rdoVs2012
            // 
            this.rdoVs2012.AutoSize = true;
            this.rdoVs2012.Location = new System.Drawing.Point(449, 27);
            this.rdoVs2012.Name = "rdoVs2012";
            this.rdoVs2012.Size = new System.Drawing.Size(64, 17);
            this.rdoVs2012.TabIndex = 9;
            this.rdoVs2012.Tag = "c:\\Program Files (x86)\\Microsoft Visual Studio 11.0\\Common7\\IDE\\TF.exe";
            this.rdoVs2012.Text = "Vs 2012";
            this.rdoVs2012.UseVisualStyleBackColor = true;
            this.rdoVs2012.CheckedChanged += new System.EventHandler(this.vsCheckedChanged);
            // 
            // rdoVs2013
            // 
            this.rdoVs2013.AutoSize = true;
            this.rdoVs2013.Checked = true;
            this.rdoVs2013.Location = new System.Drawing.Point(367, 27);
            this.rdoVs2013.Name = "rdoVs2013";
            this.rdoVs2013.Size = new System.Drawing.Size(64, 17);
            this.rdoVs2013.TabIndex = 9;
            this.rdoVs2013.TabStop = true;
            this.rdoVs2013.Tag = "c:\\Program Files (x86)\\Microsoft Visual Studio 12.0\\Common7\\IDE\\TF.exe";
            this.rdoVs2013.Text = "Vs 2013";
            this.rdoVs2013.UseVisualStyleBackColor = false;
            this.rdoVs2013.CheckedChanged += new System.EventHandler(this.vsCheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtVS);
            this.tabPage2.Controls.Add(this.btnCompareFiles);
            this.tabPage2.Controls.Add(this.fileTarget);
            this.tabPage2.Controls.Add(this.fileSrc);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(621, 204);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compare Files";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "VS Installation";
            // 
            // txtVS
            // 
            this.txtVS.Location = new System.Drawing.Point(100, 13);
            this.txtVS.Name = "txtVS";
            this.txtVS.ReadOnly = true;
            this.txtVS.Size = new System.Drawing.Size(456, 20);
            this.txtVS.TabIndex = 3;
            this.txtVS.Text = "c:\\Program Files (x86)\\Microsoft Visual Studio 11.0\\Common7\\IDE\\devenv.exe";
            // 
            // btnCompareFiles
            // 
            this.btnCompareFiles.Location = new System.Drawing.Point(481, 133);
            this.btnCompareFiles.Name = "btnCompareFiles";
            this.btnCompareFiles.Size = new System.Drawing.Size(75, 23);
            this.btnCompareFiles.TabIndex = 1;
            this.btnCompareFiles.Text = "Compare";
            this.btnCompareFiles.UseVisualStyleBackColor = true;
            this.btnCompareFiles.Click += new System.EventHandler(this.btnCompareFiles_Click);
            // 
            // fileTarget
            // 
            this.fileTarget.FilePath = "";
            this.fileTarget.Filter = "All| *.*";
            this.fileTarget.Label = "Target File:";
            this.fileTarget.Location = new System.Drawing.Point(11, 83);
            this.fileTarget.Name = "fileTarget";
            this.fileTarget.Size = new System.Drawing.Size(586, 23);
            this.fileTarget.TabIndex = 0;
            // 
            // fileSrc
            // 
            this.fileSrc.FilePath = "";
            this.fileSrc.Filter = "All| *.*";
            this.fileSrc.Label = "Source File:";
            this.fileSrc.Location = new System.Drawing.Point(8, 44);
            this.fileSrc.Name = "fileSrc";
            this.fileSrc.Size = new System.Drawing.Size(586, 23);
            this.fileSrc.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.rdoVs2010);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.rdoVs2012);
            this.panel1.Controls.Add(this.rdoVs2015);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.rdoVs2013);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 59);
            this.panel1.TabIndex = 13;
            // 
            // rdoVs2015
            // 
            this.rdoVs2015.AutoSize = true;
            this.rdoVs2015.Checked = true;
            this.rdoVs2015.Location = new System.Drawing.Point(288, 27);
            this.rdoVs2015.Name = "rdoVs2015";
            this.rdoVs2015.Size = new System.Drawing.Size(64, 17);
            this.rdoVs2015.TabIndex = 9;
            this.rdoVs2015.TabStop = true;
            this.rdoVs2015.Tag = "c:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\Common7\\IDE\\TF.exe";
            this.rdoVs2015.Text = "Vs 2015";
            this.rdoVs2015.UseVisualStyleBackColor = true;
            this.rdoVs2015.CheckedChanged += new System.EventHandler(this.vsCheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 289);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "TFS Wrapper";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTF;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.CheckBox cbRecursive;
        private System.Windows.Forms.CheckBox cbFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private ConfigSync.Para.FilePicker fileSrc;
        private ConfigSync.Para.FilePicker fileTarget;
        private System.Windows.Forms.Button btnCompareFiles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVS;
        private System.Windows.Forms.RadioButton rdoVs2013;
        private System.Windows.Forms.RadioButton rdoVs2010;
        private System.Windows.Forms.RadioButton rdoVs2012;
        private ConfigSync.Para.FolderPicker folderTarget;
        private ConfigSync.Para.FolderPicker folderSrc;
        private System.Windows.Forms.RadioButton rdoVs2015;
    }
}

