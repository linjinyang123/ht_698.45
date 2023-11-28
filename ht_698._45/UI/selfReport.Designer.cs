namespace ht_698._45.UI
{
    partial class selfReport
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rd_自动 = new System.Windows.Forms.RadioButton();
            this.txt_确认 = new System.Windows.Forms.TextBox();
            this.rd_手动 = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tl_监控 = new System.Windows.Forms.ToolStripButton();
            this.txt_报文 = new System.Windows.Forms.TextBox();
            this.Report_display = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Report_display)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_报文);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Report_display);
            this.splitContainer1.Size = new System.Drawing.Size(911, 440);
            this.splitContainer1.SplitterDistance = 523;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rd_自动);
            this.groupBox1.Controls.Add(this.txt_确认);
            this.groupBox1.Controls.Add(this.rd_手动);
            this.groupBox1.Location = new System.Drawing.Point(3, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 50);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rd_自动
            // 
            this.rd_自动.AutoSize = true;
            this.rd_自动.Checked = true;
            this.rd_自动.Location = new System.Drawing.Point(6, 19);
            this.rd_自动.Name = "rd_自动";
            this.rd_自动.Size = new System.Drawing.Size(107, 16);
            this.rd_自动.TabIndex = 3;
            this.rd_自动.TabStop = true;
            this.rd_自动.Text = "自动发送确认帧";
            this.rd_自动.UseVisualStyleBackColor = true;
            // 
            // txt_确认
            // 
            this.txt_确认.Location = new System.Drawing.Point(223, 15);
            this.txt_确认.Name = "txt_确认";
            this.txt_确认.Size = new System.Drawing.Size(185, 21);
            this.txt_确认.TabIndex = 5;
            this.txt_确认.Text = "080101 01 33200200";
            // 
            // rd_手动
            // 
            this.rd_手动.AutoSize = true;
            this.rd_手动.Location = new System.Drawing.Point(146, 19);
            this.rd_手动.Name = "rd_手动";
            this.rd_手动.Size = new System.Drawing.Size(71, 16);
            this.rd_手动.TabIndex = 4;
            this.rd_手动.Text = "手动发送";
            this.rd_手动.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tl_监控});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(523, 29);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tl_监控
            // 
            this.tl_监控.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tl_监控.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tl_监控.Name = "tl_监控";
            this.tl_监控.Size = new System.Drawing.Size(78, 26);
            this.tl_监控.Text = "打开监控";
            this.tl_监控.Click += new System.EventHandler(this.tl_监控_Click);
            // 
            // txt_报文
            // 
            this.txt_报文.Location = new System.Drawing.Point(3, 70);
            this.txt_报文.Multiline = true;
            this.txt_报文.Name = "txt_报文";
            this.txt_报文.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_报文.Size = new System.Drawing.Size(517, 367);
            this.txt_报文.TabIndex = 1;
            this.txt_报文.DoubleClick += new System.EventHandler(this.txt_报文_DoubleClick);
            // 
            // Report_display
            // 
            this.Report_display.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.Report_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report_display.Location = new System.Drawing.Point(0, 0);
            this.Report_display.Name = "Report_display";
            this.Report_display.Size = new System.Drawing.Size(384, 440);
            this.Report_display.TabIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "主动上报解析";
            this.treeListColumn1.FieldName = "主动上报解析";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // selfReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(911, 440);
            this.Controls.Add(this.splitContainer1);
            this.Name = "selfReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主动上报";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.selfReport_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Report_display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rd_自动;
        private System.Windows.Forms.TextBox txt_确认;
        private System.Windows.Forms.RadioButton rd_手动;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tl_监控;
        private System.Windows.Forms.TextBox txt_报文;
        private DevExpress.XtraTreeList.TreeList Report_display;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}