namespace AwdTimer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbLastUpdate = new System.Windows.Forms.Label();
            this.lblPackDir = new System.Windows.Forms.Label();
            this.txtPackDir = new System.Windows.Forms.TextBox();
            this.lbWebroots = new System.Windows.Forms.Label();
            this.txtScenerioXml = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkServiceMode = new System.Windows.Forms.CheckBox();
            this.btnOpenLog = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(229, 58);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 24);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbLastUpdate
            // 
            this.lbLastUpdate.AutoSize = true;
            this.lbLastUpdate.Location = new System.Drawing.Point(19, 364);
            this.lbLastUpdate.Name = "lbLastUpdate";
            this.lbLastUpdate.Size = new System.Drawing.Size(0, 13);
            this.lbLastUpdate.TabIndex = 1;
            // 
            // lblPackDir
            // 
            this.lblPackDir.AutoSize = true;
            this.lblPackDir.Location = new System.Drawing.Point(13, 13);
            this.lblPackDir.Name = "lblPackDir";
            this.lblPackDir.Size = new System.Drawing.Size(69, 13);
            this.lblPackDir.TabIndex = 2;
            this.lblPackDir.Text = "Package Dir:";
            // 
            // txtPackDir
            // 
            this.txtPackDir.Location = new System.Drawing.Point(81, 10);
            this.txtPackDir.Name = "txtPackDir";
            this.txtPackDir.Size = new System.Drawing.Size(231, 20);
            this.txtPackDir.TabIndex = 3;
            this.txtPackDir.TextChanged += new System.EventHandler(this.txtPackDir_TextChanged);
            // 
            // lbWebroots
            // 
            this.lbWebroots.AutoSize = true;
            this.lbWebroots.Location = new System.Drawing.Point(13, 62);
            this.lbWebroots.Name = "lbWebroots";
            this.lbWebroots.Size = new System.Drawing.Size(56, 13);
            this.lbWebroots.TabIndex = 2;
            this.lbWebroots.Text = "Webroots:";
            // 
            // txtScenerioXml
            // 
            this.txtScenerioXml.Location = new System.Drawing.Point(16, 88);
            this.txtScenerioXml.Multiline = true;
            this.txtScenerioXml.Name = "txtScenerioXml";
            this.txtScenerioXml.Size = new System.Drawing.Size(300, 267);
            this.txtScenerioXml.TabIndex = 3;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Auto Deploy Schedule";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 54);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(96, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chkServiceMode
            // 
            this.chkServiceMode.AutoSize = true;
            this.chkServiceMode.Location = new System.Drawing.Point(81, 37);
            this.chkServiceMode.Name = "chkServiceMode";
            this.chkServiceMode.Size = new System.Drawing.Size(92, 17);
            this.chkServiceMode.TabIndex = 4;
            this.chkServiceMode.Text = "Service Mode";
            this.chkServiceMode.UseVisualStyleBackColor = true;
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.AutoSize = true;
            this.btnOpenLog.Location = new System.Drawing.Point(257, 364);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(55, 13);
            this.btnOpenLog.TabIndex = 5;
            this.btnOpenLog.TabStop = true;
            this.btnOpenLog.Text = "Open logs";
            this.btnOpenLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnOpenLog_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 393);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.chkServiceMode);
            this.Controls.Add(this.txtScenerioXml);
            this.Controls.Add(this.lbWebroots);
            this.Controls.Add(this.txtPackDir);
            this.Controls.Add(this.lblPackDir);
            this.Controls.Add(this.lbLastUpdate);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWD Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Main_Layout);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbLastUpdate;
        private System.Windows.Forms.Label lblPackDir;
        private System.Windows.Forms.TextBox txtPackDir;
        private System.Windows.Forms.Label lbWebroots;
        private System.Windows.Forms.TextBox txtScenerioXml;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkServiceMode;
        private System.Windows.Forms.LinkLabel btnOpenLog;
    }
}

