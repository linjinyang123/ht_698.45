namespace ht_698._45.UI
{
    partial class AutoReportCom
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.btn_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSerialName = new System.Windows.Forms.ComboBox();
            this.labelSerial = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Save,
            this.btn_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(252, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Save
            // 
            this.btn_Save.Image = global::ht_698._45.Properties.Resources.保存__1_;
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(52, 22);
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Image = global::ht_698._45.Properties.Resources.关闭;
            this.btn_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(52, 22);
            this.btn_Close.Text = "关闭";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxBaudRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxSerialName);
            this.groupBox1.Controls.Add(this.labelSerial);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 125);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "2400,E,8,1",
            "4800,E,8,1",
            "9600,E,8,1",
            "19200,E,8,1"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(59, 73);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaudRate.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 56;
            this.label1.Text = "波特率";
            // 
            // comboBoxSerialName
            // 
            this.comboBoxSerialName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialName.FormattingEnabled = true;
            this.comboBoxSerialName.Location = new System.Drawing.Point(59, 21);
            this.comboBoxSerialName.Name = "comboBoxSerialName";
            this.comboBoxSerialName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSerialName.TabIndex = 55;
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Location = new System.Drawing.Point(11, 24);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(41, 12);
            this.labelSerial.TabIndex = 54;
            this.labelSerial.Text = "端口号";
            // 
            // AutoReportCom
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(252, 171);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "AutoReportCom";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主动上报串口配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoReportCom_FormClosing);
            this.Load += new System.EventHandler(this.AutoReportCom_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private System.Windows.Forms.ToolStripButton btn_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSerialName;
        private System.Windows.Forms.Label labelSerial;
    }
}