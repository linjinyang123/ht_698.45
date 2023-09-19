namespace ht_698._45.UI
{
    partial class FrmCollection
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmbCpuNumber = new System.Windows.Forms.ComboBox();
            this.cmbDataLength = new System.Windows.Forms.ComboBox();
            this.label141 = new System.Windows.Forms.Label();
            this.txtSpaceTruncation = new System.Windows.Forms.TextBox();
            this.label140 = new System.Windows.Forms.Label();
            this.btnSoftwarePlaintext = new System.Windows.Forms.Button();
            this.txtClosingAddress = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtMatchFails = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.chkAutomaticMatch = new System.Windows.Forms.CheckBox();
            this.radExpresslyBound = new System.Windows.Forms.CheckBox();
            this.txtKeyIndex = new System.Windows.Forms.TextBox();
            this.btnSoftwareComparison = new System.Windows.Forms.Button();
            this.btnLoadingFiles = new System.Windows.Forms.Button();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.txtDataAddress = new System.Windows.Forms.TextBox();
            this.txtFactorAddress = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(252)))));
            this.groupBox6.Controls.Add(this.cmbCpuNumber);
            this.groupBox6.Controls.Add(this.cmbDataLength);
            this.groupBox6.Controls.Add(this.label141);
            this.groupBox6.Controls.Add(this.txtSpaceTruncation);
            this.groupBox6.Controls.Add(this.label140);
            this.groupBox6.Controls.Add(this.btnSoftwarePlaintext);
            this.groupBox6.Controls.Add(this.txtClosingAddress);
            this.groupBox6.Controls.Add(this.label43);
            this.groupBox6.Controls.Add(this.txtMatchFails);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.chkAutomaticMatch);
            this.groupBox6.Controls.Add(this.radExpresslyBound);
            this.groupBox6.Controls.Add(this.txtKeyIndex);
            this.groupBox6.Controls.Add(this.btnSoftwareComparison);
            this.groupBox6.Controls.Add(this.btnLoadingFiles);
            this.groupBox6.Controls.Add(this.label63);
            this.groupBox6.Controls.Add(this.label64);
            this.groupBox6.Controls.Add(this.txtDataAddress);
            this.groupBox6.Controls.Add(this.txtFactorAddress);
            this.groupBox6.Controls.Add(this.label65);
            this.groupBox6.Controls.Add(this.label66);
            this.groupBox6.Location = new System.Drawing.Point(3, 26);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(803, 124);
            this.groupBox6.TabIndex = 113;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "软件比对（起始地址和截止地址输入十六进制）";
            // 
            // cmbCpuNumber
            // 
            this.cmbCpuNumber.FormattingEnabled = true;
            this.cmbCpuNumber.Items.AddRange(new object[] {
            "0",
            "F"});
            this.cmbCpuNumber.Location = new System.Drawing.Point(734, 30);
            this.cmbCpuNumber.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCpuNumber.Name = "cmbCpuNumber";
            this.cmbCpuNumber.Size = new System.Drawing.Size(52, 20);
            this.cmbCpuNumber.TabIndex = 99;
            this.cmbCpuNumber.Text = "0";
            // 
            // cmbDataLength
            // 
            this.cmbDataLength.FormattingEnabled = true;
            this.cmbDataLength.Items.AddRange(new object[] {
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.cmbDataLength.Location = new System.Drawing.Point(246, 30);
            this.cmbDataLength.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDataLength.Name = "cmbDataLength";
            this.cmbDataLength.Size = new System.Drawing.Size(73, 20);
            this.cmbDataLength.TabIndex = 98;
            this.cmbDataLength.Text = "256";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(171, 33);
            this.label141.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(53, 12);
            this.label141.TabIndex = 86;
            this.label141.Text = "数据长度";
            // 
            // txtSpaceTruncation
            // 
            this.txtSpaceTruncation.Location = new System.Drawing.Point(474, 33);
            this.txtSpaceTruncation.Margin = new System.Windows.Forms.Padding(4);
            this.txtSpaceTruncation.MaxLength = 8;
            this.txtSpaceTruncation.Name = "txtSpaceTruncation";
            this.txtSpaceTruncation.Size = new System.Drawing.Size(84, 21);
            this.txtSpaceTruncation.TabIndex = 85;
            this.txtSpaceTruncation.Text = "00020700";
            this.txtSpaceTruncation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(277, 77);
            this.label140.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(77, 12);
            this.label140.TabIndex = 84;
            this.label140.Text = "程序空间截址";
            // 
            // btnSoftwarePlaintext
            // 
            this.btnSoftwarePlaintext.Enabled = false;
            this.btnSoftwarePlaintext.Location = new System.Drawing.Point(111, 70);
            this.btnSoftwarePlaintext.Margin = new System.Windows.Forms.Padding(4);
            this.btnSoftwarePlaintext.Name = "btnSoftwarePlaintext";
            this.btnSoftwarePlaintext.Size = new System.Drawing.Size(93, 29);
            this.btnSoftwarePlaintext.TabIndex = 83;
            this.btnSoftwarePlaintext.Text = "明软比对";
            this.btnSoftwarePlaintext.UseVisualStyleBackColor = true;
            // 
            // txtClosingAddress
            // 
            this.txtClosingAddress.Location = new System.Drawing.Point(382, 72);
            this.txtClosingAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtClosingAddress.MaxLength = 8;
            this.txtClosingAddress.Name = "txtClosingAddress";
            this.txtClosingAddress.Size = new System.Drawing.Size(76, 21);
            this.txtClosingAddress.TabIndex = 82;
            this.txtClosingAddress.Text = "00020700";
            this.txtClosingAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(429, 36);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 12);
            this.label43.TabIndex = 81;
            this.label43.Text = "截址";
            // 
            // txtMatchFails
            // 
            this.txtMatchFails.Location = new System.Drawing.Point(376, 33);
            this.txtMatchFails.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatchFails.Name = "txtMatchFails";
            this.txtMatchFails.Size = new System.Drawing.Size(45, 21);
            this.txtMatchFails.TabIndex = 80;
            this.txtMatchFails.Text = "0";
            this.txtMatchFails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(328, 36);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(29, 12);
            this.label38.TabIndex = 79;
            this.label38.Text = "失败";
            // 
            // chkAutomaticMatch
            // 
            this.chkAutomaticMatch.AutoSize = true;
            this.chkAutomaticMatch.Location = new System.Drawing.Point(108, 32);
            this.chkAutomaticMatch.Margin = new System.Windows.Forms.Padding(4);
            this.chkAutomaticMatch.Name = "chkAutomaticMatch";
            this.chkAutomaticMatch.Size = new System.Drawing.Size(48, 16);
            this.chkAutomaticMatch.TabIndex = 78;
            this.chkAutomaticMatch.Text = "自动";
            this.chkAutomaticMatch.UseVisualStyleBackColor = true;
            // 
            // radExpresslyBound
            // 
            this.radExpresslyBound.AutoSize = true;
            this.radExpresslyBound.Location = new System.Drawing.Point(211, 76);
            this.radExpresslyBound.Margin = new System.Windows.Forms.Padding(4);
            this.radExpresslyBound.Name = "radExpresslyBound";
            this.radExpresslyBound.Size = new System.Drawing.Size(48, 16);
            this.radExpresslyBound.TabIndex = 77;
            this.radExpresslyBound.Text = "明文";
            this.radExpresslyBound.UseVisualStyleBackColor = true;
            // 
            // txtKeyIndex
            // 
            this.txtKeyIndex.Location = new System.Drawing.Point(633, 30);
            this.txtKeyIndex.Margin = new System.Windows.Forms.Padding(4);
            this.txtKeyIndex.MaxLength = 2;
            this.txtKeyIndex.Name = "txtKeyIndex";
            this.txtKeyIndex.Size = new System.Drawing.Size(42, 21);
            this.txtKeyIndex.TabIndex = 74;
            this.txtKeyIndex.Text = "09";
            this.txtKeyIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSoftwareComparison
            // 
            this.btnSoftwareComparison.Location = new System.Drawing.Point(18, 26);
            this.btnSoftwareComparison.Margin = new System.Windows.Forms.Padding(4);
            this.btnSoftwareComparison.Name = "btnSoftwareComparison";
            this.btnSoftwareComparison.Size = new System.Drawing.Size(82, 29);
            this.btnSoftwareComparison.TabIndex = 66;
            this.btnSoftwareComparison.Text = "密文比对";
            this.btnSoftwareComparison.UseVisualStyleBackColor = true;
            // 
            // btnLoadingFiles
            // 
            this.btnLoadingFiles.Location = new System.Drawing.Point(18, 70);
            this.btnLoadingFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadingFiles.Name = "btnLoadingFiles";
            this.btnLoadingFiles.Size = new System.Drawing.Size(82, 29);
            this.btnLoadingFiles.TabIndex = 75;
            this.btnLoadingFiles.Text = "载入文件";
            this.btnLoadingFiles.UseVisualStyleBackColor = true;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(704, 34);
            this.label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(17, 12);
            this.label63.TabIndex = 67;
            this.label63.Text = "补";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(566, 36);
            this.label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(53, 12);
            this.label64.TabIndex = 70;
            this.label64.Text = "密钥索引";
            // 
            // txtDataAddress
            // 
            this.txtDataAddress.Location = new System.Drawing.Point(701, 72);
            this.txtDataAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataAddress.MaxLength = 8;
            this.txtDataAddress.Name = "txtDataAddress";
            this.txtDataAddress.Size = new System.Drawing.Size(85, 21);
            this.txtDataAddress.TabIndex = 73;
            this.txtDataAddress.Text = "00000000";
            this.txtDataAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFactorAddress
            // 
            this.txtFactorAddress.Location = new System.Drawing.Point(532, 74);
            this.txtFactorAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtFactorAddress.MaxLength = 8;
            this.txtFactorAddress.Name = "txtFactorAddress";
            this.txtFactorAddress.Size = new System.Drawing.Size(86, 21);
            this.txtFactorAddress.TabIndex = 72;
            this.txtFactorAddress.Text = "00000000";
            this.txtFactorAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(463, 78);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(53, 12);
            this.label65.TabIndex = 68;
            this.label65.Text = "因子起址";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(626, 78);
            this.label66.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(53, 12);
            this.label66.TabIndex = 69;
            this.label66.Text = "数据起址";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 168);
            this.groupBox1.TabIndex = 114;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "应用集合";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(18, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(768, 112);
            this.listBox1.TabIndex = 0;
            // 
            // FrmCollection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(819, 403);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Name = "FrmCollection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "集合类接口";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbCpuNumber;
        private System.Windows.Forms.ComboBox cmbDataLength;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.TextBox txtSpaceTruncation;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Button btnSoftwarePlaintext;
        private System.Windows.Forms.TextBox txtClosingAddress;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtMatchFails;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.CheckBox chkAutomaticMatch;
        private System.Windows.Forms.CheckBox radExpresslyBound;
        private System.Windows.Forms.TextBox txtKeyIndex;
        private System.Windows.Forms.Button btnSoftwareComparison;
        private System.Windows.Forms.Button btnLoadingFiles;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox txtDataAddress;
        private System.Windows.Forms.TextBox txtFactorAddress;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
    }
}