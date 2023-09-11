namespace ht_698._45.UI
{
    partial class feesCharge
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_读错误状态字 = new System.Windows.Forms.Button();
            this.btn_读执行状态字 = new System.Windows.Forms.Button();
            this.txt_状态字显示 = new System.Windows.Forms.TextBox();
            this.gbx_明文合闸 = new System.Windows.Forms.GroupBox();
            this.txt_密码 = new System.Windows.Forms.TextBox();
            this.label_密码 = new System.Windows.Forms.Label();
            this.btn_明文合闸 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_保电状态 = new System.Windows.Forms.TextBox();
            this.txt_告警状态 = new System.Windows.Forms.TextBox();
            this.txt_继电器命令状态 = new System.Windows.Forms.TextBox();
            this.btn_保电状态 = new System.Windows.Forms.Button();
            this.btn_告警状态 = new System.Windows.Forms.Button();
            this.btn_读命令状态 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_间隔 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_间隔单位 = new System.Windows.Forms.ComboBox();
            this.dtp_ValidTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_限电延时 = new System.Windows.Forms.TextBox();
            this.txt_告警延时 = new System.Windows.Forms.TextBox();
            this.txt_继电器编号 = new System.Windows.Forms.TextBox();
            this.cbx_合闸方式 = new System.Windows.Forms.ComboBox();
            this.btn_Control = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_Control = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.gbx_明文合闸.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_读错误状态字);
            this.groupBox2.Controls.Add(this.btn_读执行状态字);
            this.groupBox2.Controls.Add(this.txt_状态字显示);
            this.groupBox2.Location = new System.Drawing.Point(307, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 251);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "控制命令状态字/错误字（只读）";
            // 
            // btn_读错误状态字
            // 
            this.btn_读错误状态字.Location = new System.Drawing.Point(136, 30);
            this.btn_读错误状态字.Name = "btn_读错误状态字";
            this.btn_读错误状态字.Size = new System.Drawing.Size(85, 30);
            this.btn_读错误状态字.TabIndex = 2;
            this.btn_读错误状态字.Text = "读错误状态字";
            this.btn_读错误状态字.UseVisualStyleBackColor = true;
            this.btn_读错误状态字.Click += new System.EventHandler(this.btn_读错误状态字_Click);
            // 
            // btn_读执行状态字
            // 
            this.btn_读执行状态字.Location = new System.Drawing.Point(15, 30);
            this.btn_读执行状态字.Name = "btn_读执行状态字";
            this.btn_读执行状态字.Size = new System.Drawing.Size(90, 30);
            this.btn_读执行状态字.TabIndex = 1;
            this.btn_读执行状态字.Text = "读执行状态字";
            this.btn_读执行状态字.UseVisualStyleBackColor = true;
            this.btn_读执行状态字.Click += new System.EventHandler(this.btn_读执行状态字_Click);
            // 
            // txt_状态字显示
            // 
            this.txt_状态字显示.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_状态字显示.Location = new System.Drawing.Point(3, 76);
            this.txt_状态字显示.Multiline = true;
            this.txt_状态字显示.Name = "txt_状态字显示";
            this.txt_状态字显示.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_状态字显示.Size = new System.Drawing.Size(234, 172);
            this.txt_状态字显示.TabIndex = 0;
            this.txt_状态字显示.TextChanged += new System.EventHandler(this.txt_状态字显示_TextChanged);
            this.txt_状态字显示.DoubleClick += new System.EventHandler(this.txt_状态字显示_DoubleClick);
            // 
            // gbx_明文合闸
            // 
            this.gbx_明文合闸.Controls.Add(this.txt_密码);
            this.gbx_明文合闸.Controls.Add(this.label_密码);
            this.gbx_明文合闸.Controls.Add(this.btn_明文合闸);
            this.gbx_明文合闸.Location = new System.Drawing.Point(0, 307);
            this.gbx_明文合闸.Name = "gbx_明文合闸";
            this.gbx_明文合闸.Size = new System.Drawing.Size(117, 95);
            this.gbx_明文合闸.TabIndex = 40;
            this.gbx_明文合闸.TabStop = false;
            // 
            // txt_密码
            // 
            this.txt_密码.Location = new System.Drawing.Point(42, 61);
            this.txt_密码.MaxLength = 8;
            this.txt_密码.Name = "txt_密码";
            this.txt_密码.Size = new System.Drawing.Size(69, 21);
            this.txt_密码.TabIndex = 41;
            this.txt_密码.Text = "00000000";
            this.txt_密码.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_密码
            // 
            this.label_密码.AutoSize = true;
            this.label_密码.Location = new System.Drawing.Point(6, 64);
            this.label_密码.Name = "label_密码";
            this.label_密码.Size = new System.Drawing.Size(29, 12);
            this.label_密码.TabIndex = 40;
            this.label_密码.Text = "密码";
            // 
            // btn_明文合闸
            // 
            this.btn_明文合闸.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_明文合闸.Location = new System.Drawing.Point(9, 16);
            this.btn_明文合闸.Name = "btn_明文合闸";
            this.btn_明文合闸.Size = new System.Drawing.Size(102, 39);
            this.btn_明文合闸.TabIndex = 31;
            this.btn_明文合闸.Text = "明文合闸";
            this.btn_明文合闸.UseVisualStyleBackColor = true;
            this.btn_明文合闸.Click += new System.EventHandler(this.btn_明文合闸_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_保电状态);
            this.groupBox3.Controls.Add(this.txt_告警状态);
            this.groupBox3.Controls.Add(this.txt_继电器命令状态);
            this.groupBox3.Controls.Add(this.btn_保电状态);
            this.groupBox3.Controls.Add(this.btn_告警状态);
            this.groupBox3.Controls.Add(this.btn_读命令状态);
            this.groupBox3.Location = new System.Drawing.Point(307, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 136);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "控制状态字（只读）";
            // 
            // txt_保电状态
            // 
            this.txt_保电状态.Location = new System.Drawing.Point(136, 94);
            this.txt_保电状态.Name = "txt_保电状态";
            this.txt_保电状态.Size = new System.Drawing.Size(90, 21);
            this.txt_保电状态.TabIndex = 7;
            // 
            // txt_告警状态
            // 
            this.txt_告警状态.Location = new System.Drawing.Point(136, 58);
            this.txt_告警状态.Name = "txt_告警状态";
            this.txt_告警状态.Size = new System.Drawing.Size(90, 21);
            this.txt_告警状态.TabIndex = 6;
            // 
            // txt_继电器命令状态
            // 
            this.txt_继电器命令状态.Location = new System.Drawing.Point(136, 23);
            this.txt_继电器命令状态.Name = "txt_继电器命令状态";
            this.txt_继电器命令状态.Size = new System.Drawing.Size(90, 21);
            this.txt_继电器命令状态.TabIndex = 5;
            // 
            // btn_保电状态
            // 
            this.btn_保电状态.Location = new System.Drawing.Point(6, 94);
            this.btn_保电状态.Name = "btn_保电状态";
            this.btn_保电状态.Size = new System.Drawing.Size(110, 25);
            this.btn_保电状态.TabIndex = 4;
            this.btn_保电状态.Text = "读保电状态";
            this.btn_保电状态.UseVisualStyleBackColor = true;
            this.btn_保电状态.Click += new System.EventHandler(this.btn_保电状态_Click);
            // 
            // btn_告警状态
            // 
            this.btn_告警状态.Location = new System.Drawing.Point(6, 55);
            this.btn_告警状态.Name = "btn_告警状态";
            this.btn_告警状态.Size = new System.Drawing.Size(110, 25);
            this.btn_告警状态.TabIndex = 3;
            this.btn_告警状态.Text = "读告警状态";
            this.btn_告警状态.UseVisualStyleBackColor = true;
            this.btn_告警状态.Click += new System.EventHandler(this.btn_告警状态_Click);
            // 
            // btn_读命令状态
            // 
            this.btn_读命令状态.Location = new System.Drawing.Point(6, 20);
            this.btn_读命令状态.Name = "btn_读命令状态";
            this.btn_读命令状态.Size = new System.Drawing.Size(110, 25);
            this.btn_读命令状态.TabIndex = 2;
            this.btn_读命令状态.Text = "读继电器命令状态";
            this.btn_读命令状态.UseVisualStyleBackColor = true;
            this.btn_读命令状态.Click += new System.EventHandler(this.btn_读命令状态_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "间隔";
            // 
            // tbx_间隔
            // 
            this.tbx_间隔.Location = new System.Drawing.Point(163, 278);
            this.tbx_间隔.MaxLength = 4;
            this.tbx_间隔.Name = "tbx_间隔";
            this.tbx_间隔.Size = new System.Drawing.Size(87, 21);
            this.tbx_间隔.TabIndex = 38;
            this.tbx_间隔.Text = "0010";
            this.tbx_间隔.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "间隔单位";
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
            this.cmb_间隔单位.Location = new System.Drawing.Point(163, 249);
            this.cmb_间隔单位.Name = "cmb_间隔单位";
            this.cmb_间隔单位.Size = new System.Drawing.Size(87, 20);
            this.cmb_间隔单位.TabIndex = 34;
            // 
            // dtp_ValidTime
            // 
            this.dtp_ValidTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_ValidTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ValidTime.Location = new System.Drawing.Point(98, 217);
            this.dtp_ValidTime.Name = "dtp_ValidTime";
            this.dtp_ValidTime.Size = new System.Drawing.Size(161, 21);
            this.dtp_ValidTime.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "有效时间：";
            // 
            // txt_限电延时
            // 
            this.txt_限电延时.BackColor = System.Drawing.SystemColors.Window;
            this.txt_限电延时.Location = new System.Drawing.Point(98, 143);
            this.txt_限电延时.MaxLength = 4;
            this.txt_限电延时.Name = "txt_限电延时";
            this.txt_限电延时.Size = new System.Drawing.Size(161, 21);
            this.txt_限电延时.TabIndex = 30;
            this.txt_限电延时.Text = "0000";
            // 
            // txt_告警延时
            // 
            this.txt_告警延时.BackColor = System.Drawing.SystemColors.Window;
            this.txt_告警延时.Location = new System.Drawing.Point(98, 107);
            this.txt_告警延时.MaxLength = 2;
            this.txt_告警延时.Name = "txt_告警延时";
            this.txt_告警延时.Size = new System.Drawing.Size(161, 21);
            this.txt_告警延时.TabIndex = 29;
            this.txt_告警延时.Text = "00";
            // 
            // txt_继电器编号
            // 
            this.txt_继电器编号.BackColor = System.Drawing.SystemColors.Window;
            this.txt_继电器编号.Location = new System.Drawing.Point(98, 73);
            this.txt_继电器编号.MaxLength = 2;
            this.txt_继电器编号.Name = "txt_继电器编号";
            this.txt_继电器编号.Size = new System.Drawing.Size(161, 21);
            this.txt_继电器编号.TabIndex = 28;
            this.txt_继电器编号.Text = "01";
            // 
            // cbx_合闸方式
            // 
            this.cbx_合闸方式.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_合闸方式.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_合闸方式.FormattingEnabled = true;
            this.cbx_合闸方式.Items.AddRange(new object[] {
            "自动合闸/直接合闸",
            "非自动合闸/合闸允许"});
            this.cbx_合闸方式.Location = new System.Drawing.Point(98, 179);
            this.cbx_合闸方式.Name = "cbx_合闸方式";
            this.cbx_合闸方式.Size = new System.Drawing.Size(161, 22);
            this.cbx_合闸方式.TabIndex = 27;
            // 
            // btn_Control
            // 
            this.btn_Control.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Control.Location = new System.Drawing.Point(123, 326);
            this.btn_Control.Name = "btn_Control";
            this.btn_Control.Size = new System.Drawing.Size(84, 44);
            this.btn_Control.TabIndex = 3;
            this.btn_Control.Text = "控制发送";
            this.btn_Control.UseVisualStyleBackColor = true;
            this.btn_Control.Click += new System.EventHandler(this.btn_Control_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "合闸方式：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "限电时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "告警延时：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "继电器编号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "控制类型：";
            // 
            // cbx_Control
            // 
            this.cbx_Control.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Control.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_Control.FormattingEnabled = true;
            this.cbx_Control.Items.AddRange(new object[] {
            "跳闸",
            "合闸",
            "报警",
            "报警解除",
            "保电",
            "保电解除"});
            this.cbx_Control.Location = new System.Drawing.Point(98, 36);
            this.cbx_Control.Name = "cbx_Control";
            this.cbx_Control.Size = new System.Drawing.Size(161, 22);
            this.cbx_Control.TabIndex = 19;
            this.cbx_Control.SelectedIndexChanged += new System.EventHandler(this.cbx_Control_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbx_明文合闸);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbx_间隔);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmb_间隔单位);
            this.groupBox1.Controls.Add(this.dtp_ValidTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btn_Control);
            this.groupBox1.Controls.Add(this.txt_限电延时);
            this.groupBox1.Controls.Add(this.txt_告警延时);
            this.groupBox1.Controls.Add(this.txt_继电器编号);
            this.groupBox1.Controls.Add(this.cbx_合闸方式);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbx_Control);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 408);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "远程控制";
            // 
            // feesCharge
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(575, 432);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "feesCharge";
            this.ShowIcon = false;
            this.Text = "远程控制";
            this.Load += new System.EventHandler(this.feesCharge_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbx_明文合闸.ResumeLayout(false);
            this.gbx_明文合闸.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_读错误状态字;
        private System.Windows.Forms.Button btn_读执行状态字;
        private System.Windows.Forms.TextBox txt_状态字显示;
        private System.Windows.Forms.GroupBox gbx_明文合闸;
        private System.Windows.Forms.TextBox txt_密码;
        private System.Windows.Forms.Label label_密码;
        private System.Windows.Forms.Button btn_明文合闸;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_保电状态;
        private System.Windows.Forms.TextBox txt_告警状态;
        private System.Windows.Forms.TextBox txt_继电器命令状态;
        private System.Windows.Forms.Button btn_保电状态;
        private System.Windows.Forms.Button btn_告警状态;
        private System.Windows.Forms.Button btn_读命令状态;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_间隔;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_间隔单位;
        private System.Windows.Forms.DateTimePicker dtp_ValidTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_限电延时;
        private System.Windows.Forms.TextBox txt_告警延时;
        private System.Windows.Forms.TextBox txt_继电器编号;
        private System.Windows.Forms.ComboBox cbx_合闸方式;
        private System.Windows.Forms.Button btn_Control;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_Control;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}