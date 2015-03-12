namespace TfsWrapper
{
    partial class CompareListOfFiles
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstViewLeft = new System.Windows.Forms.ListView();
            this.lstViewRight = new System.Windows.Forms.ListView();
            this.fileSystemWatcherLeft = new System.IO.FileSystemWatcher();
            this.fileSystemWatcherRight = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherRight)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstViewLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstViewRight);
            this.splitContainer1.Size = new System.Drawing.Size(1234, 724);
            this.splitContainer1.SplitterDistance = 653;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstViewLeft
            // 
            this.lstViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViewLeft.FullRowSelect = true;
            this.lstViewLeft.GridLines = true;
            this.lstViewLeft.Location = new System.Drawing.Point(0, 0);
            this.lstViewLeft.Name = "lstViewLeft";
            this.lstViewLeft.Size = new System.Drawing.Size(653, 724);
            this.lstViewLeft.TabIndex = 0;
            this.lstViewLeft.UseCompatibleStateImageBehavior = false;
            this.lstViewLeft.View = System.Windows.Forms.View.Details;
            // 
            // lstViewRight
            // 
            this.lstViewRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViewRight.FullRowSelect = true;
            this.lstViewRight.GridLines = true;
            this.lstViewRight.Location = new System.Drawing.Point(0, 0);
            this.lstViewRight.Name = "lstViewRight";
            this.lstViewRight.Size = new System.Drawing.Size(577, 724);
            this.lstViewRight.TabIndex = 0;
            this.lstViewRight.UseCompatibleStateImageBehavior = false;
            this.lstViewRight.View = System.Windows.Forms.View.Details;
            // 
            // fileSystemWatcherLeft
            // 
            this.fileSystemWatcherLeft.EnableRaisingEvents = true;
            this.fileSystemWatcherLeft.SynchronizingObject = this;
            this.fileSystemWatcherLeft.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcherLeft_Changed);
            // 
            // fileSystemWatcherRight
            // 
            this.fileSystemWatcherRight.EnableRaisingEvents = true;
            this.fileSystemWatcherRight.SynchronizingObject = this;
            this.fileSystemWatcherRight.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcherRight_Changed);
            // 
            // CompareListOfFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 724);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CompareListOfFiles";
            this.Text = "CompareListOfFiles Tools";
            this.Load += new System.EventHandler(this.CompareListOfFiles_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstViewLeft;
        private System.Windows.Forms.ListView lstViewRight;
        private System.IO.FileSystemWatcher fileSystemWatcherLeft;
        private System.IO.FileSystemWatcher fileSystemWatcherRight;
    }
}