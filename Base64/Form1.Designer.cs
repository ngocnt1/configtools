namespace Base64
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEncoded = new System.Windows.Forms.TextBox();
            this.tbDecoded = new System.Windows.Forms.TextBox();
            this.btnEncode = new System.Windows.Forms.ToolStripButton();
            this.btnDecode = new System.Windows.Forms.ToolStripButton();
            this.btnSaveEncoded = new System.Windows.Forms.ToolStripButton();
            this.btnSaveDecoded = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDecodeAndSaveAsBitmap = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEncode,
            this.btnSaveDecoded,
            this.btnDecode,
            this.btnSaveEncoded,
            this.toolStripSeparator1,
            this.btnDecodeAndSaveAsBitmap});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(966, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbEncoded);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbDecoded);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(966, 488);
            this.splitContainer1.SplitterDistance = 496;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encoded";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Decoded";
            // 
            // tbEncoded
            // 
            this.tbEncoded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEncoded.Location = new System.Drawing.Point(0, 13);
            this.tbEncoded.Multiline = true;
            this.tbEncoded.Name = "tbEncoded";
            this.tbEncoded.Size = new System.Drawing.Size(496, 475);
            this.tbEncoded.TabIndex = 1;
            // 
            // tbDecoded
            // 
            this.tbDecoded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDecoded.Location = new System.Drawing.Point(0, 13);
            this.tbDecoded.Multiline = true;
            this.tbDecoded.Name = "tbDecoded";
            this.tbDecoded.Size = new System.Drawing.Size(466, 475);
            this.tbDecoded.TabIndex = 2;
            // 
            // btnEncode
            // 
            this.btnEncode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEncode.Image = ((System.Drawing.Image)(resources.GetObject("btnEncode.Image")));
            this.btnEncode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(57, 22);
            this.btnEncode.Text = "Encoded";
            this.btnEncode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDecode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDecode.Image = ((System.Drawing.Image)(resources.GetObject("btnDecode.Image")));
            this.btnDecode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(58, 22);
            this.btnDecode.Text = "Decoded";
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnSaveEncoded
            // 
            this.btnSaveEncoded.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveEncoded.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveEncoded.Image")));
            this.btnSaveEncoded.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveEncoded.Name = "btnSaveEncoded";
            this.btnSaveEncoded.Size = new System.Drawing.Size(23, 22);
            this.btnSaveEncoded.Text = "Save";
            this.btnSaveEncoded.Click += new System.EventHandler(this.btnSaveEncoded_Click);
            // 
            // btnSaveDecoded
            // 
            this.btnSaveDecoded.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSaveDecoded.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveDecoded.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveDecoded.Image")));
            this.btnSaveDecoded.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveDecoded.Name = "btnSaveDecoded";
            this.btnSaveDecoded.Size = new System.Drawing.Size(23, 22);
            this.btnSaveDecoded.Text = "Save";
            this.btnSaveDecoded.Click += new System.EventHandler(this.btnSaveDecoded_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDecodeAndSaveAsBitmap
            // 
            this.btnDecodeAndSaveAsBitmap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDecodeAndSaveAsBitmap.Image = ((System.Drawing.Image)(resources.GetObject("btnDecodeAndSaveAsBitmap.Image")));
            this.btnDecodeAndSaveAsBitmap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDecodeAndSaveAsBitmap.Name = "btnDecodeAndSaveAsBitmap";
            this.btnDecodeAndSaveAsBitmap.Size = new System.Drawing.Size(136, 22);
            this.btnDecodeAndSaveAsBitmap.Text = "Decode & Save as bitmap";
            this.btnDecodeAndSaveAsBitmap.Click += new System.EventHandler(this.btnDecodeAndSaveAsBitmap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 513);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Base 64 - Encode / Decode";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEncode;
        private System.Windows.Forms.ToolStripButton btnDecode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbEncoded;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDecoded;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton btnSaveDecoded;
        private System.Windows.Forms.ToolStripButton btnSaveEncoded;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDecodeAndSaveAsBitmap;
    }
}

