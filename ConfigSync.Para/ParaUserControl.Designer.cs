namespace ConfigSync.Para
{
    partial class ParaUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("VPP");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sites");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Others");
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbFile = new System.Windows.Forms.Label();
            this.treeViewEPiServer = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 35);
            this.panel1.TabIndex = 0;
            // 
            // lbFile
            // 
            this.lbFile.AutoSize = true;
            this.lbFile.Location = new System.Drawing.Point(4, 10);
            this.lbFile.Name = "lbFile";
            this.lbFile.Size = new System.Drawing.Size(57, 13);
            this.lbFile.TabIndex = 0;
            this.lbFile.Text = "[FileName]";
            // 
            // treeViewEPiServer
            // 
            this.treeViewEPiServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewEPiServer.LineColor = System.Drawing.Color.DarkGray;
            this.treeViewEPiServer.Location = new System.Drawing.Point(0, 35);
            this.treeViewEPiServer.Name = "treeViewEPiServer";
            treeNode1.Name = "VPP";
            treeNode1.Text = "VPP";
            treeNode2.Name = "Sites";
            treeNode2.Text = "Sites";
            treeNode3.Name = "Others";
            treeNode3.Text = "Others";
            this.treeViewEPiServer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeViewEPiServer.ShowNodeToolTips = true;
            this.treeViewEPiServer.Size = new System.Drawing.Size(354, 480);
            this.treeViewEPiServer.TabIndex = 2;
            this.treeViewEPiServer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewEPiServer_NodeMouseClick);
            // 
            // ParaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewEPiServer);
            this.Controls.Add(this.panel1);
            this.Name = "ParaUserControl";
            this.Size = new System.Drawing.Size(354, 515);
            this.Load += new System.EventHandler(this.ParaUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbFile;
        private System.Windows.Forms.TreeView treeViewEPiServer;
    }
}
