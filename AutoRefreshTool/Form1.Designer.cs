namespace AutoRefreshTool
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddlMaxInterval = new System.Windows.Forms.ToolStripComboBox();
            this.btnAutoRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbUrl = new System.Windows.Forms.ToolStripTextBox();
            this.btnGo = new System.Windows.Forms.ToolStripButton();
            this.lbTime = new System.Windows.Forms.ToolStripLabel();
            this.lbHits = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_Clock = new System.Windows.Forms.Timer(this.components);
            this.tbTimer = new System.Windows.Forms.MaskedTextBox();
            this.lbTimer = new System.Windows.Forms.Label();
            this.cbTimer = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbRefreshCompletly = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(1262, 692);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            this.webBrowser1.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser1_ProgressChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ContextMenuStrip = this.contextMenuStrip1;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddlMaxInterval,
            this.btnAutoRefresh,
            this.toolStripSeparator1,
            this.tbUrl,
            this.btnGo,
            this.lbTime,
            this.lbHits});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1262, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 48);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ddlMaxInterval
            // 
            this.ddlMaxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMaxInterval.Items.AddRange(new object[] {
            "2",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "15",
            "20",
            "25",
            "30"});
            this.ddlMaxInterval.Name = "ddlMaxInterval";
            this.ddlMaxInterval.Size = new System.Drawing.Size(75, 25);
            this.ddlMaxInterval.ToolTipText = "Maximium Interval";
            // 
            // btnAutoRefresh
            // 
            this.btnAutoRefresh.CheckOnClick = true;
            this.btnAutoRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAutoRefresh.Image = global::AutoRefreshTool.Properties.Resources.method;
            this.btnAutoRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAutoRefresh.Name = "btnAutoRefresh";
            this.btnAutoRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnAutoRefresh.Text = "Auto Refresh";
            this.btnAutoRefresh.Click += new System.EventHandler(this.btnAutoRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbUrl
            // 
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(500, 25);
            this.tbUrl.Text = "http://dn30-cms-stage.bonnierdigitalservices.se/Querying/PlugIns/SolrAdmin.aspx";
            // 
            // btnGo
            // 
            this.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGo.Image = global::AutoRefreshTool.Properties.Resources.arrow;
            this.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(23, 22);
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // lbTime
            // 
            this.lbTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(16, 22);
            this.lbTime.Text = "...";
            this.lbTime.Visible = false;
            // 
            // lbHits
            // 
            this.lbHits.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbHits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lbHits.Name = "lbHits";
            this.lbHits.Size = new System.Drawing.Size(30, 22);
            this.lbHits.Text = "0 hit";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 90000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer_Clock
            // 
            this.timer_Clock.Enabled = true;
            this.timer_Clock.Interval = 1000;
            this.timer_Clock.Tick += new System.EventHandler(this.timer_Clock_Tick);
            // 
            // tbTimer
            // 
            this.tbTimer.Location = new System.Drawing.Point(706, 2);
            this.tbTimer.Mask = "00/00/0000 90:00";
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.Size = new System.Drawing.Size(162, 20);
            this.tbTimer.TabIndex = 2;
            this.tbTimer.ValidatingType = typeof(System.DateTime);
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Location = new System.Drawing.Point(648, 6);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(53, 13);
            this.lbTimer.TabIndex = 3;
            this.lbTimer.Text = "Timer Off:";
            // 
            // cbTimer
            // 
            this.cbTimer.AutoSize = true;
            this.cbTimer.Enabled = false;
            this.cbTimer.Location = new System.Drawing.Point(875, 4);
            this.cbTimer.Name = "cbTimer";
            this.cbTimer.Size = new System.Drawing.Size(81, 17);
            this.cbTimer.TabIndex = 4;
            this.cbTimer.Text = "Active timer";
            this.cbTimer.UseVisualStyleBackColor = true;
            this.cbTimer.CheckedChanged += new System.EventHandler(this.cbTimer_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DN.se";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cbRefreshCompletly
            // 
            this.cbRefreshCompletly.AutoSize = true;
            this.cbRefreshCompletly.Location = new System.Drawing.Point(974, 4);
            this.cbRefreshCompletly.Name = "cbRefreshCompletly";
            this.cbRefreshCompletly.Size = new System.Drawing.Size(111, 17);
            this.cbRefreshCompletly.TabIndex = 5;
            this.cbRefreshCompletly.Text = "Refresh Completly";
            this.cbRefreshCompletly.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 695);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1262, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 717);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbRefreshCompletly);
            this.Controls.Add(this.cbTimer);
            this.Controls.Add(this.lbTimer);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton btnAutoRefresh;
        private System.Windows.Forms.ToolStripTextBox tbUrl;
        private System.Windows.Forms.Timer timer_Clock;
        private System.Windows.Forms.ToolStripLabel lbTime;
        private System.Windows.Forms.MaskedTextBox tbTimer;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.CheckBox cbTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbHits;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripComboBox ddlMaxInterval;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbRefreshCompletly;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
    }
}

