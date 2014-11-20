namespace TimeZoneUtil
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
            this.zoneList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStandardName = new System.Windows.Forms.Label();
            this.lbCopy = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAdjustment = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // zoneList
            // 
            this.zoneList.FormattingEnabled = true;
            this.zoneList.Location = new System.Drawing.Point(12, 77);
            this.zoneList.Name = "zoneList";
            this.zoneList.Size = new System.Drawing.Size(482, 21);
            this.zoneList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Zones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Standard Name:";
            // 
            // lbStandardName
            // 
            this.lbStandardName.AutoSize = true;
            this.lbStandardName.Location = new System.Drawing.Point(49, 148);
            this.lbStandardName.Name = "lbStandardName";
            this.lbStandardName.Size = new System.Drawing.Size(16, 13);
            this.lbStandardName.TabIndex = 3;
            this.lbStandardName.Text = "...";
            // 
            // lbCopy
            // 
            this.lbCopy.AutoSize = true;
            this.lbCopy.Location = new System.Drawing.Point(10, 148);
            this.lbCopy.Name = "lbCopy";
            this.lbCopy.Size = new System.Drawing.Size(31, 13);
            this.lbCopy.TabIndex = 4;
            this.lbCopy.TabStop = true;
            this.lbCopy.Tag = "lbStandardName";
            this.lbCopy.Text = "Copy";
            this.lbCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbCopy_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ajusment Rulet:";
            // 
            // lbAdjustment
            // 
            this.lbAdjustment.AutoSize = true;
            this.lbAdjustment.Location = new System.Drawing.Point(49, 207);
            this.lbAdjustment.Name = "lbAdjustment";
            this.lbAdjustment.Size = new System.Drawing.Size(16, 13);
            this.lbAdjustment.TabIndex = 3;
            this.lbAdjustment.Text = "...";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(97, 50);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(16, 13);
            this.lbTime.TabIndex = 5;
            this.lbTime.Text = "...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 347);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbCopy);
            this.Controls.Add(this.lbAdjustment);
            this.Controls.Add(this.lbStandardName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoneList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Time Zones Info";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox zoneList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbStandardName;
        private System.Windows.Forms.LinkLabel lbCopy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbAdjustment;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer1;
    }
}

