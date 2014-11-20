namespace ConfigSync.Para
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("VPP");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sites");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("PageTypeBuilder");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("BurstCache");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Debug");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("SMTP");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Proxy");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Services");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Web.config", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("appSettings");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("platformSettings");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("ServicePlus");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("FinancialHubSettings");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Solr");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Others");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderPicker = new ConfigSync.Para.FolderPicker();
            this.filePickerCms = new ConfigSync.Para.FilePicker();
            this.filePickerWWW = new ConfigSync.Para.FilePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.btnReloadEPi = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbEPiSel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.paraWWW = new ConfigSync.Para.ParaUserControl();
            this.paraCms = new ConfigSync.Para.ParaUserControl();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.treeView = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.errors = new System.Windows.Forms.ToolStripDropDownButton();
            this.warnings = new System.Windows.Forms.ToolStripDropDownButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.folderPicker);
            this.panel1.Controls.Add(this.filePickerCms);
            this.panel1.Controls.Add(this.filePickerWWW);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnReloadEPi);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1377, 100);
            this.panel1.TabIndex = 0;
            // 
            // folderPicker
            // 
            this.folderPicker.FilePath = "";
            this.folderPicker.Label = "Webroot folder";
            this.folderPicker.Location = new System.Drawing.Point(86, 9);
            this.folderPicker.Name = "folderPicker";
            this.folderPicker.Size = new System.Drawing.Size(604, 20);
            this.folderPicker.TabIndex = 6;
            // 
            // filePickerCms
            // 
            this.filePickerCms.FilePath = "";
            this.filePickerCms.Filter = "Xml Parameter | *.xml";
            this.filePickerCms.Label = "CMS Parameter file";
            this.filePickerCms.Location = new System.Drawing.Point(67, 35);
            this.filePickerCms.Name = "filePickerCms";
            this.filePickerCms.Size = new System.Drawing.Size(623, 23);
            this.filePickerCms.TabIndex = 5;
            // 
            // filePickerWWW
            // 
            this.filePickerWWW.FilePath = "";
            this.filePickerWWW.Filter = "Xml Parameter | *.xml";
            this.filePickerWWW.Label = "WWW Parameter file";
            this.filePickerWWW.Location = new System.Drawing.Point(57, 61);
            this.filePickerWWW.Name = "filePickerWWW";
            this.filePickerWWW.Size = new System.Drawing.Size(633, 23);
            this.filePickerWWW.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(893, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Reload Para";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnReloadPara_Click);
            // 
            // btnReloadEPi
            // 
            this.btnReloadEPi.Location = new System.Drawing.Point(811, 48);
            this.btnReloadEPi.Name = "btnReloadEPi";
            this.btnReloadEPi.Size = new System.Drawing.Size(75, 36);
            this.btnReloadEPi.TabIndex = 3;
            this.btnReloadEPi.Text = "Reload EPi";
            this.btnReloadEPi.UseVisualStyleBackColor = true;
            this.btnReloadEPi.Click += new System.EventHandler(this.btnReloadEPi_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(716, 48);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 36);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 100);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitter2);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.tbEPiSel);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.paraWWW);
            this.splitContainer1.Panel2.Controls.Add(this.paraCms);
            this.splitContainer1.Panel2.Controls.Add(this.splitter3);
            this.splitContainer1.Panel2.Controls.Add(this.treeView);
            this.splitContainer1.Size = new System.Drawing.Size(1377, 605);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitter2
            // 
            this.splitter2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 244);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(229, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 244);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 359);
            this.panel2.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(11, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tbEPiSel
            // 
            this.tbEPiSel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbEPiSel.Location = new System.Drawing.Point(0, 13);
            this.tbEPiSel.Multiline = true;
            this.tbEPiSel.Name = "tbEPiSel";
            this.tbEPiSel.Size = new System.Drawing.Size(229, 231);
            this.tbEPiSel.TabIndex = 0;
            this.tbEPiSel.Text = "pageRootId\r\npageStartId\r\nsiteUrl\r\nuiOptimizeTreeForSpeed\r\nuiDefaultPanelTab";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Site\'s sttributes should be updated";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(733, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 603);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // paraWWW
            // 
            this.paraWWW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paraWWW.FilePath = null;
            this.paraWWW.Location = new System.Drawing.Point(733, 0);
            this.paraWWW.Name = "paraWWW";
            this.paraWWW.RefTree = null;
            this.paraWWW.Size = new System.Drawing.Size(407, 603);
            this.paraWWW.TabIndex = 2;
            // 
            // paraCms
            // 
            this.paraCms.Dock = System.Windows.Forms.DockStyle.Left;
            this.paraCms.FilePath = null;
            this.paraCms.Location = new System.Drawing.Point(379, 0);
            this.paraCms.Name = "paraCms";
            this.paraCms.RefTree = null;
            this.paraCms.Size = new System.Drawing.Size(354, 603);
            this.paraCms.TabIndex = 1;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(376, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 603);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.LineColor = System.Drawing.Color.DarkGray;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.Name = "VPP";
            treeNode1.Text = "VPP";
            treeNode2.Name = "Sites";
            treeNode2.Text = "Sites";
            treeNode3.Name = "PageTypeBuilder";
            treeNode3.Text = "PageTypeBuilder";
            treeNode4.Name = "BurstCache";
            treeNode4.Text = "BurstCache";
            treeNode5.Name = "Debug";
            treeNode5.Text = "Debug";
            treeNode6.Name = "SMTP";
            treeNode6.Text = "SMTP";
            treeNode7.Name = "Proxy";
            treeNode7.Text = "Proxy";
            treeNode8.Name = "Services";
            treeNode8.Text = "Services";
            treeNode9.Name = "Web.config";
            treeNode9.Text = "Web.config";
            treeNode10.Name = "appSettings";
            treeNode10.Text = "appSettings";
            treeNode11.Name = "platformSettings";
            treeNode11.Text = "platformSettings";
            treeNode12.Name = "ServicePlus";
            treeNode12.Text = "ServicePlus";
            treeNode13.Name = "FinancialHubSettings";
            treeNode13.Text = "FinancialHubSettings";
            treeNode14.Name = "Solr";
            treeNode14.Text = "Solr";
            treeNode15.Name = "Others";
            treeNode15.Text = "Others";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(376, 603);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errors,
            this.warnings});
            this.statusStrip1.Location = new System.Drawing.Point(0, 683);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1377, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // errors
            // 
            this.errors.ForeColor = System.Drawing.Color.Red;
            this.errors.Name = "errors";
            this.errors.Size = new System.Drawing.Size(13, 20);
            // 
            // warnings
            // 
            this.warnings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.warnings.ForeColor = System.Drawing.Color.Red;
            this.warnings.Image = ((System.Drawing.Image)(resources.GetObject("warnings.Image")));
            this.warnings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.warnings.Name = "warnings";
            this.warnings.Size = new System.Drawing.Size(13, 20);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 705);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReloadEPi;
        private System.Windows.Forms.TextBox tbEPiSel;
        private ParaUserControl paraCms;
        private FilePicker filePickerWWW;
        private FilePicker filePickerCms;
        private ParaUserControl paraWWW;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton errors;
        private FolderPicker folderPicker;
        private System.Windows.Forms.ToolStripDropDownButton warnings;
        private System.Windows.Forms.Splitter splitter3;
    }
}

