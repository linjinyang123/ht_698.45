namespace ht_698._45.UI
{
    partial class regist
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
            this.label4 = new System.Windows.Forms.Label();
            this.btn_退出 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_注册 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_注册码 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_机器码 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Location = new System.Drawing.Point(153, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(353, 60);
            this.label4.TabIndex = 30;
            this.label4.Text = "说明：\r\n\r\n获取注册码，请联系无锡市恒通电器有限公司的上位机开发工程师\r\n\r\n本软件严禁用于商业用途，违者必究。";
            // 
            // btn_退出
            // 
            this.btn_退出.Location = new System.Drawing.Point(338, 208);
            this.btn_退出.Name = "btn_退出";
            this.btn_退出.Size = new System.Drawing.Size(128, 33);
            this.btn_退出.TabIndex = 29;
            this.btn_退出.Text = "退出";
            this.btn_退出.UseVisualStyleBackColor = true;
            this.btn_退出.Click += new System.EventHandler(this.btn_退出_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 28;
            // 
            // btn_注册
            // 
            this.btn_注册.Location = new System.Drawing.Point(169, 208);
            this.btn_注册.Name = "btn_注册";
            this.btn_注册.Size = new System.Drawing.Size(128, 33);
            this.btn_注册.TabIndex = 27;
            this.btn_注册.Text = "注册";
            this.btn_注册.UseVisualStyleBackColor = true;
            this.btn_注册.Click += new System.EventHandler(this.btn_注册_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "注册码";
            // 
            // txt_注册码
            // 
            this.txt_注册码.Location = new System.Drawing.Point(96, 154);
            this.txt_注册码.Name = "txt_注册码";
            this.txt_注册码.Size = new System.Drawing.Size(489, 21);
            this.txt_注册码.TabIndex = 25;
            this.txt_注册码.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_注册码.TextChanged += new System.EventHandler(this.txt_注册码_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "机器码";
            // 
            // txt_机器码
            // 
            this.txt_机器码.Location = new System.Drawing.Point(96, 96);
            this.txt_机器码.Name = "txt_机器码";
            this.txt_机器码.Size = new System.Drawing.Size(489, 21);
            this.txt_机器码.TabIndex = 23;
            this.txt_机器码.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regist
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(635, 267);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_退出);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_注册);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_注册码);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_机器码);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "regist";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.regist_FormClosing);
            this.Load += new System.EventHandler(this.regist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_退出;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_注册;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_注册码;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_机器码;
    }
}