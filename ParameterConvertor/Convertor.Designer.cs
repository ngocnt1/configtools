namespace ParameterConvertor
{
    partial class Convertor
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSearchPara = new System.Windows.Forms.Button();
            this.txtParaSearch = new System.Windows.Forms.TextBox();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.lnlClearFiles = new System.Windows.Forms.LinkLabel();
            this.lnlClear = new System.Windows.Forms.LinkLabel();
            this.lnlCompare = new System.Windows.Forms.LinkLabel();
            this.lnkAddFile = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEditResult = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdateOrNew = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txtEditValue = new System.Windows.Forms.TextBox();
            this.txtEditXPathMatch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtScope = new System.Windows.Forms.TextBox();
            this.txtEditXMLType = new System.Windows.Forms.TextBox();
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbEditAllowEmpty = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.filePS = new ConfigSync.Para.FilePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.folderSource = new ConfigSync.Para.FolderPicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrivateParameters = new System.Windows.Forms.TextBox();
            this.txtParamFile = new System.Windows.Forms.TextBox();
            this.btnGenAppSettingsConfig = new System.Windows.Forms.Button();
            this.folderPicker1 = new ConfigSync.Para.FolderPicker();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnResolveConfig = new System.Windows.Forms.Button();
            this.filePickerParameter = new ConfigSync.Para.FilePicker();
            this.folderTestConfig = new ConfigSync.Para.FolderPicker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbResolving = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(490, 70);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(103, 6);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(402, 20);
            this.txtFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter by file name:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(43, 112);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(522, 424);
            this.txtResult.TabIndex = 4;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(40, 96);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(40, 13);
            this.lbResult.TabIndex = 2;
            this.lbResult.Text = "Result:";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(490, 548);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(837, 763);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSearchPara);
            this.tabPage1.Controls.Add(this.txtParaSearch);
            this.tabPage1.Controls.Add(this.lstFiles);
            this.tabPage1.Controls.Add(this.lnlClearFiles);
            this.tabPage1.Controls.Add(this.lnlClear);
            this.tabPage1.Controls.Add(this.lnlCompare);
            this.tabPage1.Controls.Add(this.lnkAddFile);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtEditResult);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(829, 737);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PS Parameter Manager";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSearchPara
            // 
            this.btnSearchPara.Location = new System.Drawing.Point(189, 272);
            this.btnSearchPara.Name = "btnSearchPara";
            this.btnSearchPara.Size = new System.Drawing.Size(75, 23);
            this.btnSearchPara.TabIndex = 8;
            this.btnSearchPara.Text = "Search";
            this.btnSearchPara.UseVisualStyleBackColor = true;
            this.btnSearchPara.Click += new System.EventHandler(this.btnSearchPara_Click);
            // 
            // txtParaSearch
            // 
            this.txtParaSearch.Location = new System.Drawing.Point(26, 275);
            this.txtParaSearch.Name = "txtParaSearch";
            this.txtParaSearch.Size = new System.Drawing.Size(159, 20);
            this.txtParaSearch.TabIndex = 7;
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(23, 43);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFiles.Size = new System.Drawing.Size(325, 225);
            this.lstFiles.TabIndex = 6;
            // 
            // lnlClearFiles
            // 
            this.lnlClearFiles.AutoSize = true;
            this.lnlClearFiles.Location = new System.Drawing.Point(310, 22);
            this.lnlClearFiles.Name = "lnlClearFiles";
            this.lnlClearFiles.Size = new System.Drawing.Size(31, 13);
            this.lnlClearFiles.TabIndex = 5;
            this.lnlClearFiles.TabStop = true;
            this.lnlClearFiles.Text = "Clear";
            this.lnlClearFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnlClearFiles_LinkClicked);
            // 
            // lnlClear
            // 
            this.lnlClear.AutoSize = true;
            this.lnlClear.Location = new System.Drawing.Point(69, 312);
            this.lnlClear.Name = "lnlClear";
            this.lnlClear.Size = new System.Drawing.Size(31, 13);
            this.lnlClear.TabIndex = 5;
            this.lnlClear.TabStop = true;
            this.lnlClear.Text = "Clear";
            this.lnlClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnlClear_LinkClicked);
            // 
            // lnlCompare
            // 
            this.lnlCompare.AutoSize = true;
            this.lnlCompare.Location = new System.Drawing.Point(299, 275);
            this.lnlCompare.Name = "lnlCompare";
            this.lnlCompare.Size = new System.Drawing.Size(49, 13);
            this.lnlCompare.TabIndex = 5;
            this.lnlCompare.TabStop = true;
            this.lnlCompare.Text = "Compare";
            this.lnlCompare.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnlCompare_LinkClicked);
            // 
            // lnkAddFile
            // 
            this.lnkAddFile.AutoSize = true;
            this.lnkAddFile.Location = new System.Drawing.Point(109, 22);
            this.lnkAddFile.Name = "lnkAddFile";
            this.lnkAddFile.Size = new System.Drawing.Size(42, 13);
            this.lnkAddFile.TabIndex = 5;
            this.lnkAddFile.TabStop = true;
            this.lnkAddFile.Text = "Add file";
            this.lnkAddFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddFile_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Result:";
            // 
            // txtEditResult
            // 
            this.txtEditResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditResult.Location = new System.Drawing.Point(23, 331);
            this.txtEditResult.Multiline = true;
            this.txtEditResult.Name = "txtEditResult";
            this.txtEditResult.ReadOnly = true;
            this.txtEditResult.Size = new System.Drawing.Size(765, 312);
            this.txtEditResult.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnUpdateOrNew);
            this.groupBox1.Controls.Add(this.btnAddNew);
            this.groupBox1.Controls.Add(this.txtEditValue);
            this.groupBox1.Controls.Add(this.txtEditXPathMatch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtScope);
            this.groupBox1.Controls.Add(this.txtEditXMLType);
            this.groupBox1.Controls.Add(this.txtEditName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbEditAllowEmpty);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(362, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 274);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editor";
            // 
            // btnUpdateOrNew
            // 
            this.btnUpdateOrNew.Location = new System.Drawing.Point(292, 241);
            this.btnUpdateOrNew.Name = "btnUpdateOrNew";
            this.btnUpdateOrNew.Size = new System.Drawing.Size(110, 23);
            this.btnUpdateOrNew.TabIndex = 3;
            this.btnUpdateOrNew.Text = "Add new or update";
            this.btnUpdateOrNew.UseVisualStyleBackColor = true;
            this.btnUpdateOrNew.Click += new System.EventHandler(this.btnUpdateOrNew_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(201, 241);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Add new";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // txtEditValue
            // 
            this.txtEditValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditValue.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtEditValue.Location = new System.Drawing.Point(31, 209);
            this.txtEditValue.Name = "txtEditValue";
            this.txtEditValue.Size = new System.Drawing.Size(371, 21);
            this.txtEditValue.TabIndex = 2;
            // 
            // txtEditXPathMatch
            // 
            this.txtEditXPathMatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditXPathMatch.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtEditXPathMatch.Location = new System.Drawing.Point(31, 155);
            this.txtEditXPathMatch.Name = "txtEditXPathMatch";
            this.txtEditXPathMatch.Size = new System.Drawing.Size(371, 21);
            this.txtEditXPathMatch.TabIndex = 2;
            this.txtEditXPathMatch.Text = "//*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Value:";
            // 
            // txtScope
            // 
            this.txtScope.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtScope.Location = new System.Drawing.Point(31, 48);
            this.txtScope.Name = "txtScope";
            this.txtScope.Size = new System.Drawing.Size(160, 21);
            this.txtScope.TabIndex = 2;
            this.txtScope.Text = ".config$";
            // 
            // txtEditXMLType
            // 
            this.txtEditXMLType.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtEditXMLType.Location = new System.Drawing.Point(222, 101);
            this.txtEditXMLType.Name = "txtEditXMLType";
            this.txtEditXMLType.Size = new System.Drawing.Size(160, 21);
            this.txtEditXMLType.TabIndex = 2;
            this.txtEditXMLType.Text = "XMLFile";
            // 
            // txtEditName
            // 
            this.txtEditName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtEditName.Location = new System.Drawing.Point(31, 101);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(160, 21);
            this.txtEditName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "XPath match:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Scope:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Type:";
            // 
            // cbEditAllowEmpty
            // 
            this.cbEditAllowEmpty.AutoSize = true;
            this.cbEditAllowEmpty.Location = new System.Drawing.Point(322, 190);
            this.cbEditAllowEmpty.Name = "cbEditAllowEmpty";
            this.cbEditAllowEmpty.Size = new System.Drawing.Size(80, 17);
            this.cbEditAllowEmpty.TabIndex = 1;
            this.cbEditAllowEmpty.Text = "AllowEmpty";
            this.cbEditAllowEmpty.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parameter Files:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtResult);
            this.tabPage2.Controls.Add(this.txtFile);
            this.tabPage2.Controls.Add(this.btnConvert);
            this.tabPage2.Controls.Add(this.lbResult);
            this.tabPage2.Controls.Add(this.btnCopy);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.filePS);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(829, 737);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PS to MSBuild Convertor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // filePS
            // 
            this.filePS.FilePath = "";
            this.filePS.Filter = "Xml Parameter | *.xml";
            this.filePS.Label = "PS Parameters";
            this.filePS.Location = new System.Drawing.Point(17, 41);
            this.filePS.Name = "filePS";
            this.filePS.Size = new System.Drawing.Size(586, 23);
            this.filePS.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.folderSource);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.txtPrivateParameters);
            this.tabPage3.Controls.Add(this.txtParamFile);
            this.tabPage3.Controls.Add(this.btnGenAppSettingsConfig);
            this.tabPage3.Controls.Add(this.folderPicker1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(829, 737);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Parameters Editor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // folderSource
            // 
            this.folderSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderSource.FolderPath = "";
            this.folderSource.Label = "Source Folder";
            this.folderSource.Location = new System.Drawing.Point(57, 44);
            this.folderSource.Name = "folderSource";
            this.folderSource.Size = new System.Drawing.Size(677, 21);
            this.folderSource.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(56, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Private Parameters:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Common Parameter File:";
            // 
            // txtPrivateParameters
            // 
            this.txtPrivateParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrivateParameters.Location = new System.Drawing.Point(166, 207);
            this.txtPrivateParameters.Name = "txtPrivateParameters";
            this.txtPrivateParameters.Size = new System.Drawing.Size(545, 20);
            this.txtPrivateParameters.TabIndex = 3;
            this.txtPrivateParameters.Text = "cms_parameters_201";
            // 
            // txtParamFile
            // 
            this.txtParamFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParamFile.Location = new System.Drawing.Point(166, 181);
            this.txtParamFile.Name = "txtParamFile";
            this.txtParamFile.Size = new System.Drawing.Size(545, 20);
            this.txtParamFile.TabIndex = 3;
            this.txtParamFile.Text = "cms_parameters";
            // 
            // btnGenAppSettingsConfig
            // 
            this.btnGenAppSettingsConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenAppSettingsConfig.Location = new System.Drawing.Point(609, 264);
            this.btnGenAppSettingsConfig.Name = "btnGenAppSettingsConfig";
            this.btnGenAppSettingsConfig.Size = new System.Drawing.Size(102, 39);
            this.btnGenAppSettingsConfig.TabIndex = 2;
            this.btnGenAppSettingsConfig.Text = "Generate";
            this.btnGenAppSettingsConfig.UseVisualStyleBackColor = true;
            this.btnGenAppSettingsConfig.Click += new System.EventHandler(this.btnGenAppSettingsConfig_Click);
            // 
            // folderPicker1
            // 
            this.folderPicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderPicker1.FolderPath = "c:\\Awd\\DI\\package\\Parameters\\";
            this.folderPicker1.Label = "Destination Folder";
            this.folderPicker1.Location = new System.Drawing.Point(59, 154);
            this.folderPicker1.Name = "folderPicker1";
            this.folderPicker1.Size = new System.Drawing.Size(680, 21);
            this.folderPicker1.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lbResolving);
            this.tabPage4.Controls.Add(this.txtOutput);
            this.tabPage4.Controls.Add(this.btnResolveConfig);
            this.tabPage4.Controls.Add(this.filePickerParameter);
            this.tabPage4.Controls.Add(this.folderTestConfig);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(829, 737);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Test";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtOutput.Location = new System.Drawing.Point(85, 180);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(650, 515);
            this.txtOutput.TabIndex = 8;
            // 
            // btnResolveConfig
            // 
            this.btnResolveConfig.Location = new System.Drawing.Point(660, 131);
            this.btnResolveConfig.Name = "btnResolveConfig";
            this.btnResolveConfig.Size = new System.Drawing.Size(75, 43);
            this.btnResolveConfig.TabIndex = 7;
            this.btnResolveConfig.Text = "Resolve";
            this.btnResolveConfig.UseVisualStyleBackColor = true;
            this.btnResolveConfig.Click += new System.EventHandler(this.btnResolveConfig_Click);
            // 
            // filePickerParameter
            // 
            this.filePickerParameter.FilePath = "";
            this.filePickerParameter.Filter = "Parameter File | *.xml";
            this.filePickerParameter.Label = "Parameter File";
            this.filePickerParameter.Location = new System.Drawing.Point(52, 89);
            this.filePickerParameter.Name = "filePickerParameter";
            this.filePickerParameter.Size = new System.Drawing.Size(683, 22);
            this.filePickerParameter.TabIndex = 6;
            // 
            // folderTestConfig
            // 
            this.folderTestConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTestConfig.FolderPath = "";
            this.folderTestConfig.Label = "Source Folder";
            this.folderTestConfig.Location = new System.Drawing.Point(52, 62);
            this.folderTestConfig.Name = "folderTestConfig";
            this.folderTestConfig.Size = new System.Drawing.Size(683, 21);
            this.folderTestConfig.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Parameter File|*.xml";
            this.openFileDialog1.Multiselect = true;
            // 
            // lbResolving
            // 
            this.lbResolving.AutoSize = true;
            this.lbResolving.Location = new System.Drawing.Point(85, 160);
            this.lbResolving.Name = "lbResolving";
            this.lbResolving.Size = new System.Drawing.Size(66, 13);
            this.lbResolving.TabIndex = 9;
            this.lbResolving.Text = "Resolving ...";
            this.lbResolving.Visible = false;
            // 
            // Convertor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 763);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Convertor";
            this.Text = "Parameter Convertor";
            this.Load += new System.EventHandler(this.Convertor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private ConfigSync.Para.FilePicker filePS;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEditName;
        private System.Windows.Forms.CheckBox cbEditAllowEmpty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEditXPathMatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEditValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtScope;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnUpdateOrNew;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEditResult;
        private System.Windows.Forms.LinkLabel lnkAddFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel lnlClear;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.LinkLabel lnlClearFiles;
        private System.Windows.Forms.LinkLabel lnlCompare;
        private System.Windows.Forms.TextBox txtEditXMLType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearchPara;
        private System.Windows.Forms.TextBox txtParaSearch;
        private System.Windows.Forms.TabPage tabPage3;
        private ConfigSync.Para.FolderPicker folderPicker1;
        private System.Windows.Forms.Button btnGenAppSettingsConfig;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtParamFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPrivateParameters;
        private System.Windows.Forms.TabPage tabPage4;
        private ConfigSync.Para.FolderPicker folderTestConfig;
        private ConfigSync.Para.FilePicker filePickerParameter;
        private System.Windows.Forms.Button btnResolveConfig;
        private System.Windows.Forms.TextBox txtOutput;
        private ConfigSync.Para.FolderPicker folderSource;
        private System.Windows.Forms.Label lbResolving;
    }
}

