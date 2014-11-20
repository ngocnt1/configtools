namespace ConfigSync.Para
{
    partial class FilePicker
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
            this.btnOpenWWW = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.filePara = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnOpenWWW
            // 
            this.btnOpenWWW.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenWWW.Location = new System.Drawing.Point(547, 0);
            this.btnOpenWWW.Name = "btnOpenWWW";
            this.btnOpenWWW.Size = new System.Drawing.Size(39, 23);
            this.btnOpenWWW.TabIndex = 5;
            this.btnOpenWWW.Text = "...";
            this.btnOpenWWW.UseVisualStyleBackColor = true;
            this.btnOpenWWW.Click += new System.EventHandler(this.btnOpenWWW_Click);
            // 
            // tbPath
            // 
            this.tbPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPath.Location = new System.Drawing.Point(85, 0);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(462, 20);
            this.tbPath.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4);
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "[Parameter file]";
            // 
            // filePara
            // 
            this.filePara.Filter = "Xml Parameter | *.xml";
            this.filePara.FileOk += new System.ComponentModel.CancelEventHandler(this.filePara_FileOk);
            // 
            // FilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnOpenWWW);
            this.Controls.Add(this.label3);
            this.Name = "FilePicker";
            this.Size = new System.Drawing.Size(586, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenWWW;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog filePara;
    }
}
