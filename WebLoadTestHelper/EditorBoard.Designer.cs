namespace WebLoadTestHelper
{
    partial class EditorBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorBoard));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tbUrl = new System.Windows.Forms.ToolStripTextBox();
            this.btnGO = new System.Windows.Forms.ToolStripButton();
            this.btnGather = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tbDeviceUrl = new System.Windows.Forms.ToolStripTextBox();
            this.btnGetSrcs = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtHTML = new System.Windows.Forms.TextBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.btnGatherLinkFromHTML = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtLinks = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbMaxLinks = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.lbTotalLines = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImportUrlsFromIISLog = new System.Windows.Forms.ToolStripButton();
            this.txtWebTest = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnGen = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.txtThinkTimes = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.txtTimeGoal = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lbLinks = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileOpen = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabs.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1234, 583);
            this.tabs.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.wb);
            this.tabPage2.Controls.Add(this.toolStrip3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1226, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WebSite";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(3, 28);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.ScriptErrorsSuppressed = true;
            this.wb.Size = new System.Drawing.Size(1220, 526);
            this.wb.TabIndex = 1;
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            this.wb.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb_Navigating);
            this.wb.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.wb_ProgressChanged);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.tbUrl,
            this.btnGO,
            this.btnGather,
            this.toolStripLabel4,
            this.tbDeviceUrl,
            this.btnGetSrcs});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1220, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel3.Text = "Address";
            // 
            // tbUrl
            // 
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(500, 25);
            // 
            // btnGO
            // 
            this.btnGO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGO.Image = global::WebLoadTestHelper.Properties.Resources.cswebsitetemplate;
            this.btnGO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(23, 22);
            this.btnGO.Text = "Go";
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnGather
            // 
            this.btnGather.Image = global::WebLoadTestHelper.Properties.Resources.search;
            this.btnGather.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGather.Name = "btnGather";
            this.btnGather.Size = new System.Drawing.Size(62, 22);
            this.btnGather.Text = "Gather";
            this.btnGather.Click += new System.EventHandler(this.btnGather_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel4.Text = "Device Url:";
            // 
            // tbDeviceUrl
            // 
            this.tbDeviceUrl.Name = "tbDeviceUrl";
            this.tbDeviceUrl.Size = new System.Drawing.Size(300, 25);
            // 
            // btnGetSrcs
            // 
            this.btnGetSrcs.Image = ((System.Drawing.Image)(resources.GetObject("btnGetSrcs.Image")));
            this.btnGetSrcs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetSrcs.Name = "btnGetSrcs";
            this.btnGetSrcs.Size = new System.Drawing.Size(69, 22);
            this.btnGetSrcs.Text = "Get Srcs";
            this.btnGetSrcs.Click += new System.EventHandler(this.btnGetSrcs_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtHTML);
            this.tabPage3.Controls.Add(this.toolStrip4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1226, 557);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "HTML";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtHTML
            // 
            this.txtHTML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHTML.Location = new System.Drawing.Point(3, 28);
            this.txtHTML.Multiline = true;
            this.txtHTML.Name = "txtHTML";
            this.txtHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHTML.Size = new System.Drawing.Size(1220, 526);
            this.txtHTML.TabIndex = 0;
            this.txtHTML.TextChanged += new System.EventHandler(this.txtHTML_TextChanged);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGatherLinkFromHTML});
            this.toolStrip4.Location = new System.Drawing.Point(3, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(1220, 25);
            this.toolStrip4.TabIndex = 1;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // btnGatherLinkFromHTML
            // 
            this.btnGatherLinkFromHTML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGatherLinkFromHTML.Image = ((System.Drawing.Image)(resources.GetObject("btnGatherLinkFromHTML.Image")));
            this.btnGatherLinkFromHTML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGatherLinkFromHTML.Name = "btnGatherLinkFromHTML";
            this.btnGatherLinkFromHTML.Size = new System.Drawing.Size(76, 22);
            this.btnGatherLinkFromHTML.Text = "Gather Links";
            this.btnGatherLinkFromHTML.Click += new System.EventHandler(this.btnGatherLinkFromHTML_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1226, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "*.webtest";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtLinks);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtWebTest);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(1220, 551);
            this.splitContainer1.SplitterDistance = 593;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtLinks
            // 
            this.txtLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLinks.Location = new System.Drawing.Point(0, 25);
            this.txtLinks.Multiline = true;
            this.txtLinks.Name = "txtLinks";
            this.txtLinks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLinks.Size = new System.Drawing.Size(593, 526);
            this.txtLinks.TabIndex = 1;
            this.txtLinks.TextChanged += new System.EventHandler(this.txtLinks_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tbMaxLinks,
            this.toolStripButton1,
            this.toolStripButton2,
            this.lbTotalLines,
            this.toolStripSeparator1,
            this.btnImportUrlsFromIISLog});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(593, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel2.Text = "MaxLinks:";
            // 
            // tbMaxLinks
            // 
            this.tbMaxLinks.Name = "tbMaxLinks";
            this.tbMaxLinks.Size = new System.Drawing.Size(100, 25);
            this.tbMaxLinks.Text = "1000";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(62, 22);
            this.toolStripButton1.Text = "Gather";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(54, 22);
            this.toolStripButton2.Text = "Clear";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // lbTotalLines
            // 
            this.lbTotalLines.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbTotalLines.Name = "lbTotalLines";
            this.lbTotalLines.Size = new System.Drawing.Size(16, 22);
            this.lbTotalLines.Text = "...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnImportUrlsFromIISLog
            // 
            this.btnImportUrlsFromIISLog.Image = global::WebLoadTestHelper.Properties.Resources.itemPicker;
            this.btnImportUrlsFromIISLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportUrlsFromIISLog.Name = "btnImportUrlsFromIISLog";
            this.btnImportUrlsFromIISLog.Size = new System.Drawing.Size(101, 22);
            this.btnImportUrlsFromIISLog.Text = "Import IIS Log";
            this.btnImportUrlsFromIISLog.Click += new System.EventHandler(this.btnImportUrlsFromIISLog_Click);
            // 
            // txtWebTest
            // 
            this.txtWebTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWebTest.Location = new System.Drawing.Point(0, 25);
            this.txtWebTest.Multiline = true;
            this.txtWebTest.Name = "txtWebTest";
            this.txtWebTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWebTest.Size = new System.Drawing.Size(623, 526);
            this.txtWebTest.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnGen,
            this.btnCopy,
            this.toolStripSeparator2,
            this.btnSave,
            this.toolStripLabel5,
            this.txtThinkTimes,
            this.toolStripLabel6,
            this.txtTimeGoal});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(623, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel1.Text = ".webtest";
            // 
            // btnGen
            // 
            this.btnGen.Image = global::WebLoadTestHelper.Properties.Resources.cppunittestproj;
            this.btnGen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(74, 22);
            this.btnGen.Text = "Generate";
            this.btnGen.ToolTipText = "Generate";
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click_1);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::WebLoadTestHelper.Properties.Resources.cswebsitetemplate;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(55, 22);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::WebLoadTestHelper.Properties.Resources.webrole_cs;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabel5.Text = "Think time:";
            // 
            // txtThinkTimes
            // 
            this.txtThinkTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThinkTimes.Name = "txtThinkTimes";
            this.txtThinkTimes.Size = new System.Drawing.Size(100, 25);
            this.txtThinkTimes.Text = "5";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel6.Text = "TimeGoal:";
            // 
            // txtTimeGoal
            // 
            this.txtTimeGoal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeGoal.Name = "txtTimeGoal";
            this.txtTimeGoal.Size = new System.Drawing.Size(100, 25);
            this.txtTimeGoal.Text = "0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.lbLinks});
            this.statusStrip1.Location = new System.Drawing.Point(0, 583);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1234, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            this.progressBar1.Visible = false;
            // 
            // lbLinks
            // 
            this.lbLinks.Name = "lbLinks";
            this.lbLinks.Size = new System.Drawing.Size(16, 17);
            this.lbLinks.Text = "...";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "WebTest|*.webtest";
            // 
            // EditorBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 605);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditorBoard";
            this.Text = "Crawl URL for Web Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabs.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtLinks;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox txtWebTest;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripTextBox tbUrl;
        private System.Windows.Forms.ToolStripButton btnGO;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox tbMaxLinks;
        private System.Windows.Forms.ToolStripLabel lbTotalLines;
        private System.Windows.Forms.ToolStripButton btnGen;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnGather;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbLinks;
        private System.Windows.Forms.ToolStripButton btnImportUrlsFromIISLog;
        private System.Windows.Forms.OpenFileDialog fileOpen;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tbDeviceUrl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripButton btnGetSrcs;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtHTML;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton btnGatherLinkFromHTML;
        private System.Windows.Forms.ToolStripTextBox txtThinkTimes;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripTextBox txtTimeGoal;
    }
}

