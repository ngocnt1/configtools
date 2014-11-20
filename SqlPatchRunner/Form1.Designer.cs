namespace SqlPatchRunner
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtScriptsFolder = new System.Windows.Forms.TextBox();
            this.btnLockScripts = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSumDbConnection = new System.Windows.Forms.Label();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lbScriptsAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scripts folder:";
            // 
            // txtScriptsFolder
            // 
            this.txtScriptsFolder.Location = new System.Drawing.Point(103, 22);
            this.txtScriptsFolder.Name = "txtScriptsFolder";
            this.txtScriptsFolder.Size = new System.Drawing.Size(355, 20);
            this.txtScriptsFolder.TabIndex = 1;
            // 
            // btnLockScripts
            // 
            this.btnLockScripts.Location = new System.Drawing.Point(383, 145);
            this.btnLockScripts.Name = "btnLockScripts";
            this.btnLockScripts.Size = new System.Drawing.Size(75, 23);
            this.btnLockScripts.TabIndex = 2;
            this.btnLockScripts.Tag = "0";
            this.btnLockScripts.Text = "Lock";
            this.btnLockScripts.UseVisualStyleBackColor = true;
            this.btnLockScripts.Click += new System.EventHandler(this.btnLockScripts_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Connection string:";
            // 
            // txtCS
            // 
            this.txtCS.Location = new System.Drawing.Point(103, 48);
            this.txtCS.Multiline = true;
            this.txtCS.Name = "txtCS";
            this.txtCS.Size = new System.Drawing.Size(355, 91);
            this.txtCS.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Connection:";
            // 
            // lbSumDbConnection
            // 
            this.lbSumDbConnection.AutoSize = true;
            this.lbSumDbConnection.Location = new System.Drawing.Point(103, 168);
            this.lbSumDbConnection.Name = "lbSumDbConnection";
            this.lbSumDbConnection.Size = new System.Drawing.Size(16, 13);
            this.lbSumDbConnection.TabIndex = 4;
            this.lbSumDbConnection.Text = "...";
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(103, 194);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(355, 199);
            this.listFiles.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Scripts:";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(463, 22);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(30, 23);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(383, 401);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lbScriptsAmount
            // 
            this.lbScriptsAmount.AutoSize = true;
            this.lbScriptsAmount.Location = new System.Drawing.Point(103, 401);
            this.lbScriptsAmount.Name = "lbScriptsAmount";
            this.lbScriptsAmount.Size = new System.Drawing.Size(0, 13);
            this.lbScriptsAmount.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 440);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.lbSumDbConnection);
            this.Controls.Add(this.lbScriptsAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnLockScripts);
            this.Controls.Add(this.txtCS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScriptsFolder);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SQL Script Patcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtScriptsFolder;
        private System.Windows.Forms.Button btnLockScripts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSumDbConnection;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lbScriptsAmount;
    }
}

