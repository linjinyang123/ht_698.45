using System;
namespace ht_698._45.UI
{
    partial class CommParam
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
            this.comboBoxDelayTime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSerialName = new System.Windows.Forms.ComboBox();
            this.labelSerial = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.btn_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDelayTime
            // 
            this.comboBoxDelayTime.FormattingEnabled = true;
            this.comboBoxDelayTime.Location = new System.Drawing.Point(111, 218);
            this.comboBoxDelayTime.Name = "comboBoxDelayTime";
            this.comboBoxDelayTime.Size = new System.Drawing.Size(81, 20);
            this.comboBoxDelayTime.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "数据接收等待时间";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxParity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxStopBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxDataBits);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxBaudRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxSerialName);
            this.groupBox1.Controls.Add(this.labelSerial);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 180);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(59, 144);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(121, 20);
            this.comboBoxParity.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "校验位";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(59, 112);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(121, 20);
            this.comboBoxStopBits.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 60;
            this.label3.Text = "停止位";
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Location = new System.Drawing.Point(59, 80);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(121, 20);
            this.comboBoxDataBits.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 58;
            this.label2.Text = "数据位";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(59, 48);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaudRate.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 56;
            this.label1.Text = "波特率";
            // 
            // comboBoxSerialName
            // 
            this.comboBoxSerialName.FormattingEnabled = true;
            this.comboBoxSerialName.Location = new System.Drawing.Point(59, 16);
            this.comboBoxSerialName.Name = "comboBoxSerialName";
            this.comboBoxSerialName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSerialName.TabIndex = 55;
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Location = new System.Drawing.Point(4, 19);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(41, 12);
            this.labelSerial.TabIndex = 54;
            this.labelSerial.Text = "端口号";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Save,
            this.btn_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(231, 25);
            this.toolStrip1.TabIndex = 16;
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
            // CommParam
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(231, 272);
            this.Controls.Add(this.comboBoxDelayTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommParam";
            this.ShowIcon = false;
            this.Text = "串口参数配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommParam_FormClosing);
            this.Load += new System.EventHandler(this.CommParam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDelayTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSerialName;
        private System.Windows.Forms.Label labelSerial;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private System.Windows.Forms.ToolStripButton btn_Close;
    }
}