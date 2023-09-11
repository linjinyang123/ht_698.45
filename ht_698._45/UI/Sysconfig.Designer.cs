namespace ht_698._45.UI
{
    partial class Sysconfig
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
            this.cb_raoma33 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_fe = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_AddType = new System.Windows.Forms.ComboBox();
            this.tbx_间隔 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_间隔单位 = new System.Windows.Forms.ComboBox();
            this.chb_系统时间 = new System.Windows.Forms.CheckBox();
            this.tbx_ClientAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_时间 = new System.Windows.Forms.TextBox();
            this.rd_有时标 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_无时标 = new System.Windows.Forms.RadioButton();
            this.txt_fe = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_帧字节 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_raoma33
            // 
            this.cb_raoma33.AutoSize = true;
            this.cb_raoma33.Location = new System.Drawing.Point(50, 53);
            this.cb_raoma33.Name = "cb_raoma33";
            this.cb_raoma33.Size = new System.Drawing.Size(216, 16);
            this.cb_raoma33.TabIndex = 28;
            this.cb_raoma33.Text = "扰码开启/关闭（发送帧加/减0x33）";
            this.cb_raoma33.UseVisualStyleBackColor = true;
            this.cb_raoma33.CheckedChanged += new System.EventHandler(this.cb_raoma33_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "客户机地址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "FE个数";
            // 
            // cb_fe
            // 
            this.cb_fe.AutoSize = true;
            this.cb_fe.Checked = true;
            this.cb_fe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_fe.Location = new System.Drawing.Point(50, 24);
            this.cb_fe.Name = "cb_fe";
            this.cb_fe.Size = new System.Drawing.Size(144, 16);
            this.cb_fe.TabIndex = 25;
            this.cb_fe.Text = "发生数据前唤醒字符数";
            this.cb_fe.UseVisualStyleBackColor = true;
            this.cb_fe.CheckedChanged += new System.EventHandler(this.cb_fe_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "间隔";
            // 
            // cmb_AddType
            // 
            this.cmb_AddType.FormattingEnabled = true;
            this.cmb_AddType.Location = new System.Drawing.Point(143, 122);
            this.cmb_AddType.Name = "cmb_AddType";
            this.cmb_AddType.Size = new System.Drawing.Size(137, 20);
            this.cmb_AddType.TabIndex = 29;
            this.cmb_AddType.SelectedIndexChanged += new System.EventHandler(this.cmb_AddType_SelectedIndexChanged);
            // 
            // tbx_间隔
            // 
            this.tbx_间隔.Location = new System.Drawing.Point(6, 114);
            this.tbx_间隔.Name = "tbx_间隔";
            this.tbx_间隔.Size = new System.Drawing.Size(134, 21);
            this.tbx_间隔.TabIndex = 12;
            this.tbx_间隔.Text = "0010";
            this.tbx_间隔.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "间隔单位";
            // 
            // cmb_间隔单位
            // 
            this.cmb_间隔单位.FormattingEnabled = true;
            this.cmb_间隔单位.Items.AddRange(new object[] {
            "秒",
            "分",
            "时",
            "日",
            "月",
            "年"});
            this.cmb_间隔单位.Location = new System.Drawing.Point(6, 88);
            this.cmb_间隔单位.Name = "cmb_间隔单位";
            this.cmb_间隔单位.Size = new System.Drawing.Size(134, 20);
            this.cmb_间隔单位.TabIndex = 10;
            // 
            // chb_系统时间
            // 
            this.chb_系统时间.AutoSize = true;
            this.chb_系统时间.Checked = true;
            this.chb_系统时间.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_系统时间.Location = new System.Drawing.Point(156, 63);
            this.chb_系统时间.Name = "chb_系统时间";
            this.chb_系统时间.Size = new System.Drawing.Size(72, 16);
            this.chb_系统时间.TabIndex = 10;
            this.chb_系统时间.Text = "系统时间";
            this.chb_系统时间.UseVisualStyleBackColor = true;
            this.chb_系统时间.CheckedChanged += new System.EventHandler(this.chb_系统时间_CheckedChanged);
            // 
            // tbx_ClientAdd
            // 
            this.tbx_ClientAdd.Location = new System.Drawing.Point(143, 160);
            this.tbx_ClientAdd.MaxLength = 2;
            this.tbx_ClientAdd.Name = "tbx_ClientAdd";
            this.tbx_ClientAdd.Size = new System.Drawing.Size(137, 21);
            this.tbx_ClientAdd.TabIndex = 32;
            this.tbx_ClientAdd.Text = "A1";
            this.tbx_ClientAdd.TextChanged += new System.EventHandler(this.tbx_ClientAdd_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "服务器地址类型";
            // 
            // tb_时间
            // 
            this.tb_时间.Location = new System.Drawing.Point(6, 61);
            this.tb_时间.Name = "tb_时间";
            this.tb_时间.Size = new System.Drawing.Size(134, 21);
            this.tb_时间.TabIndex = 10;
            this.tb_时间.TextChanged += new System.EventHandler(this.tb_时间_TextChanged);
            // 
            // rd_有时标
            // 
            this.rd_有时标.AutoSize = true;
            this.rd_有时标.Location = new System.Drawing.Point(91, 30);
            this.rd_有时标.Name = "rd_有时标";
            this.rd_有时标.Size = new System.Drawing.Size(59, 16);
            this.rd_有时标.TabIndex = 11;
            this.rd_有时标.Text = "有时标";
            this.rd_有时标.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "下发最大帧长度";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbx_间隔);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_间隔单位);
            this.groupBox1.Controls.Add(this.chb_系统时间);
            this.groupBox1.Controls.Add(this.tb_时间);
            this.groupBox1.Controls.Add(this.rd_有时标);
            this.groupBox1.Controls.Add(this.rd_无时标);
            this.groupBox1.Location = new System.Drawing.Point(44, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 151);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时标";
            // 
            // rd_无时标
            // 
            this.rd_无时标.AutoSize = true;
            this.rd_无时标.Checked = true;
            this.rd_无时标.Location = new System.Drawing.Point(10, 30);
            this.rd_无时标.Name = "rd_无时标";
            this.rd_无时标.Size = new System.Drawing.Size(59, 16);
            this.rd_无时标.TabIndex = 10;
            this.rd_无时标.TabStop = true;
            this.rd_无时标.Text = "无时标";
            this.rd_无时标.UseVisualStyleBackColor = true;
            this.rd_无时标.CheckedChanged += new System.EventHandler(this.rd_无时标_CheckedChanged);
            // 
            // txt_fe
            // 
            this.txt_fe.Location = new System.Drawing.Point(199, 22);
            this.txt_fe.Name = "txt_fe";
            this.txt_fe.Size = new System.Drawing.Size(34, 21);
            this.txt_fe.TabIndex = 26;
            this.txt_fe.Text = "0";
            this.txt_fe.TextChanged += new System.EventHandler(this.txt_fe_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_帧字节
            // 
            this.txt_帧字节.Location = new System.Drawing.Point(145, 88);
            this.txt_帧字节.MaxLength = 2;
            this.txt_帧字节.Name = "txt_帧字节";
            this.txt_帧字节.Size = new System.Drawing.Size(82, 21);
            this.txt_帧字节.TabIndex = 35;
            this.txt_帧字节.Text = "512";
            this.txt_帧字节.TextChanged += new System.EventHandler(this.txt_帧字节_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "字节数";
            // 
            // Sysconfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(324, 360);
            this.Controls.Add(this.cb_raoma33);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_fe);
            this.Controls.Add(this.cmb_AddType);
            this.Controls.Add(this.tbx_ClientAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_fe);
            this.Controls.Add(this.txt_帧字节);
            this.Controls.Add(this.label7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sysconfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统配置";
            this.Load += new System.EventHandler(this.Sysconfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_raoma33;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_fe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_AddType;
        private System.Windows.Forms.TextBox tbx_间隔;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_间隔单位;
        private System.Windows.Forms.CheckBox chb_系统时间;
        private System.Windows.Forms.TextBox tbx_ClientAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_时间;
        private System.Windows.Forms.RadioButton rd_有时标;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_无时标;
        private System.Windows.Forms.TextBox txt_fe;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_帧字节;
        private System.Windows.Forms.Label label7;
    }
}