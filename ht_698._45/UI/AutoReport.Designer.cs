namespace ht_698._45.UI
{
    partial class AutoReport
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
            this.txt_报文 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tl_COM = new System.Windows.Forms.ToolStripStatusLabel();
            this.tl_baut = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ck_费控 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rd_自动 = new System.Windows.Forms.RadioButton();
            this.txt_确认 = new System.Windows.Forms.TextBox();
            this.rd_手动 = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tl_监控 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Report_display = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Report_display)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_报文
            // 
            this.txt_报文.Location = new System.Drawing.Point(3, 70);
            this.txt_报文.Multiline = true;
            this.txt_报文.Name = "txt_报文";
            this.txt_报文.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_报文.Size = new System.Drawing.Size(517, 423);
            this.txt_报文.TabIndex = 1;
            this.txt_报文.DoubleClick += new System.EventHandler(this.txt_报文_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_报文);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Report_display);
            this.splitContainer1.Size = new System.Drawing.Size(908, 493);
            this.splitContainer1.SplitterDistance = 521;
            this.splitContainer1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tl_COM,
            this.tl_baut});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(521, 26);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tl_COM
            // 
            this.tl_COM.AutoSize = false;
            this.tl_COM.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tl_COM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tl_COM.Name = "tl_COM";
            this.tl_COM.Size = new System.Drawing.Size(100, 21);
            // 
            // tl_baut
            // 
            this.tl_baut.AutoSize = false;
            this.tl_baut.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tl_baut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tl_baut.Name = "tl_baut";
            this.tl_baut.Size = new System.Drawing.Size(150, 21);
            this.tl_baut.Text = "               ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ck_费控);
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
            // ck_费控
            // 
            this.ck_费控.AutoSize = true;
            this.ck_费控.Location = new System.Drawing.Point(451, 20);
            this.ck_费控.Name = "ck_费控";
            this.ck_费控.Size = new System.Drawing.Size(48, 16);
            this.ck_费控.TabIndex = 8;
            this.ck_费控.Text = "费控";
            this.ck_费控.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 15);
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
            this.txt_确认.Location = new System.Drawing.Point(207, 15);
            this.txt_确认.Name = "txt_确认";
            this.txt_确认.Size = new System.Drawing.Size(156, 21);
            this.txt_确认.TabIndex = 5;
            this.txt_确认.Text = "080101 01 33200200";
            // 
            // rd_手动
            // 
            this.rd_手动.AutoSize = true;
            this.rd_手动.Location = new System.Drawing.Point(130, 19);
            this.rd_手动.Name = "rd_手动";
            this.rd_手动.Size = new System.Drawing.Size(71, 16);
            this.rd_手动.TabIndex = 4;
            this.rd_手动.Text = "手动发送";
            this.rd_手动.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tl_监控,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(521, 29);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(78, 26);
            this.toolStripButton1.Text = "串口配置";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Report_display
            // 
            this.Report_display.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.Report_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report_display.Location = new System.Drawing.Point(0, 0);
            this.Report_display.Name = "Report_display";
            this.Report_display.Size = new System.Drawing.Size(383, 493);
            this.Report_display.TabIndex = 1;
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
            // AutoReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(908, 493);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AutoReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主动上报";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoReport_FormClosing);
            this.Load += new System.EventHandler(this.AutoReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Report_display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_报文;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tl_COM;
        private System.Windows.Forms.ToolStripStatusLabel tl_baut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ck_费控;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rd_自动;
        private System.Windows.Forms.TextBox txt_确认;
        private System.Windows.Forms.RadioButton rd_手动;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tl_监控;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private DevExpress.XtraTreeList.TreeList Report_display;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}