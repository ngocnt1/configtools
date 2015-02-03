namespace PSTools
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPsPing = new System.Windows.Forms.TabPage();
            this.cbIPv = new System.Windows.Forms.ComboBox();
            this.tabUsages = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTCPPingResult = new System.Windows.Forms.TextBox();
            this.btnRunTCPPing = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPsPing.SuspendLayout();
            this.tabUsages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPsPing);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPsPing
            // 
            this.tabPsPing.Controls.Add(this.cbIPv);
            this.tabPsPing.Controls.Add(this.tabUsages);
            this.tabPsPing.Controls.Add(this.txtDes);
            this.tabPsPing.Controls.Add(this.label1);
            this.tabPsPing.Location = new System.Drawing.Point(4, 22);
            this.tabPsPing.Name = "tabPsPing";
            this.tabPsPing.Padding = new System.Windows.Forms.Padding(3);
            this.tabPsPing.Size = new System.Drawing.Size(570, 497);
            this.tabPsPing.TabIndex = 0;
            this.tabPsPing.Text = "PsPing";
            this.tabPsPing.UseVisualStyleBackColor = true;
            // 
            // cbIPv
            // 
            this.cbIPv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIPv.FormattingEnabled = true;
            this.cbIPv.Items.AddRange(new object[] {
            "IPv4",
            "IPv6"});
            this.cbIPv.Location = new System.Drawing.Point(37, 69);
            this.cbIPv.Name = "cbIPv";
            this.cbIPv.Size = new System.Drawing.Size(73, 21);
            this.cbIPv.TabIndex = 3;
            // 
            // tabUsages
            // 
            this.tabUsages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabUsages.Controls.Add(this.tabPage1);
            this.tabUsages.Controls.Add(this.tabPage2);
            this.tabUsages.Controls.Add(this.tabPage3);
            this.tabUsages.Controls.Add(this.tabPage4);
            this.tabUsages.Location = new System.Drawing.Point(37, 100);
            this.tabUsages.Name = "tabUsages";
            this.tabUsages.SelectedIndex = 0;
            this.tabUsages.Size = new System.Drawing.Size(487, 374);
            this.tabUsages.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtTCPPingResult);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(479, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TCP ping";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(479, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ICMP ping";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(479, 348);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TCP latency";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(479, 348);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "TCP bandwidth";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtDes
            // 
            this.txtDes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDes.Location = new System.Drawing.Point(37, 40);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(487, 20);
            this.txtDes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Destination:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRunTCPPing);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 342);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // txtTCPPingResult
            // 
            this.txtTCPPingResult.BackColor = System.Drawing.Color.Black;
            this.txtTCPPingResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTCPPingResult.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTCPPingResult.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtTCPPingResult.Location = new System.Drawing.Point(212, 3);
            this.txtTCPPingResult.Multiline = true;
            this.txtTCPPingResult.Name = "txtTCPPingResult";
            this.txtTCPPingResult.Size = new System.Drawing.Size(264, 342);
            this.txtTCPPingResult.TabIndex = 1;
            // 
            // btnRunTCPPing
            // 
            this.btnRunTCPPing.Location = new System.Drawing.Point(24, 30);
            this.btnRunTCPPing.Name = "btnRunTCPPing";
            this.btnRunTCPPing.Size = new System.Drawing.Size(75, 23);
            this.btnRunTCPPing.TabIndex = 0;
            this.btnRunTCPPing.Text = "Run";
            this.btnRunTCPPing.UseVisualStyleBackColor = true;
            this.btnRunTCPPing.Click += new System.EventHandler(this.btnRunTCPPing_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 523);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "PS Tool Suite";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPsPing.ResumeLayout(false);
            this.tabPsPing.PerformLayout();
            this.tabUsages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPsPing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.TabControl tabUsages;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cbIPv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTCPPingResult;
        private System.Windows.Forms.Button btnRunTCPPing;
    }
}

