namespace ht_698._45.UI
{
    partial class SetIP
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_net = new System.Windows.Forms.RadioButton();
            this.rd_dir_net = new System.Windows.Forms.RadioButton();
            this.textBoxTimeOut = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_net);
            this.groupBox1.Controls.Add(this.rd_dir_net);
            this.groupBox1.Location = new System.Drawing.Point(35, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 73);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "加密选择";
            // 
            // rd_net
            // 
            this.rd_net.AutoSize = true;
            this.rd_net.Location = new System.Drawing.Point(125, 35);
            this.rd_net.Name = "rd_net";
            this.rd_net.Size = new System.Drawing.Size(83, 16);
            this.rd_net.TabIndex = 18;
            this.rd_net.Text = "网络服务器";
            this.rd_net.UseVisualStyleBackColor = true;
            // 
            // rd_dir_net
            // 
            this.rd_dir_net.AutoSize = true;
            this.rd_dir_net.Checked = true;
            this.rd_dir_net.Location = new System.Drawing.Point(12, 35);
            this.rd_dir_net.Name = "rd_dir_net";
            this.rd_dir_net.Size = new System.Drawing.Size(107, 16);
            this.rd_dir_net.TabIndex = 17;
            this.rd_dir_net.TabStop = true;
            this.rd_dir_net.Text = "网络直连(内网)";
            this.rd_dir_net.UseVisualStyleBackColor = true;
            // 
            // textBoxTimeOut
            // 
            this.textBoxTimeOut.Location = new System.Drawing.Point(96, 115);
            this.textBoxTimeOut.Name = "textBoxTimeOut";
            this.textBoxTimeOut.Size = new System.Drawing.Size(130, 21);
            this.textBoxTimeOut.TabIndex = 33;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(96, 73);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(130, 21);
            this.textBoxPort.TabIndex = 32;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(96, 28);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(130, 21);
            this.textBoxIP.TabIndex = 31;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(173, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 28);
            this.button2.TabIndex = 30;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(20, 230);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(88, 29);
            this.buttonOK.TabIndex = 29;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "超时时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "IP地址";
            // 
            // SetIP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(284, 287);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxTimeOut);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetIP";
            this.ShowIcon = false;
            this.Text = "IP参数设置";
            this.Load += new System.EventHandler(this.SetIP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_net;
        private System.Windows.Forms.RadioButton rd_dir_net;
        private System.Windows.Forms.TextBox textBoxTimeOut;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}