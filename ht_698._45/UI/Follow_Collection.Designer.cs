namespace ht_698._45.UI
{
    partial class Follow_Collection
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
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rb_三本地 = new System.Windows.Forms.RadioButton();
            this.rb_单本地 = new System.Windows.Forms.RadioButton();
            this.rb_三远程 = new System.Windows.Forms.RadioButton();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_新增上报跟随 = new System.Windows.Forms.Button();
            this.btn_新增列表 = new System.Windows.Forms.Button();
            this.btn_上报列表 = new System.Windows.Forms.Button();
            this.lsv_上报列表 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rb_单远程 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_set_上报方式 = new System.Windows.Forms.Button();
            this.btn_read_上报方式 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_set = new System.Windows.Forms.Button();
            this.btn_read = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_follow = new System.Windows.Forms.DataGridView();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lsv_上报列表)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_follow)).BeginInit();
            this.SuspendLayout();
            // 
            // Column1
            // 
            this.Column1.HeaderText = "选择";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = 40;
            // 
            // rb_三本地
            // 
            this.rb_三本地.AutoSize = true;
            this.rb_三本地.Location = new System.Drawing.Point(121, 67);
            this.rb_三本地.Name = "rb_三本地";
            this.rb_三本地.Size = new System.Drawing.Size(83, 16);
            this.rb_三本地.TabIndex = 2;
            this.rb_三本地.Text = "三相本地表";
            this.rb_三本地.UseVisualStyleBackColor = true;
            this.rb_三本地.CheckedChanged += new System.EventHandler(this.rb_三本地_CheckedChanged);
            // 
            // rb_单本地
            // 
            this.rb_单本地.AutoSize = true;
            this.rb_单本地.Location = new System.Drawing.Point(121, 32);
            this.rb_单本地.Name = "rb_单本地";
            this.rb_单本地.Size = new System.Drawing.Size(83, 16);
            this.rb_单本地.TabIndex = 2;
            this.rb_单本地.Text = "单相本地表";
            this.rb_单本地.UseVisualStyleBackColor = true;
            this.rb_单本地.CheckedChanged += new System.EventHandler(this.rb_单本地_CheckedChanged);
            // 
            // rb_三远程
            // 
            this.rb_三远程.AutoSize = true;
            this.rb_三远程.Location = new System.Drawing.Point(19, 67);
            this.rb_三远程.Name = "rb_三远程";
            this.rb_三远程.Size = new System.Drawing.Size(83, 16);
            this.rb_三远程.TabIndex = 1;
            this.rb_三远程.Text = "三相远程表";
            this.rb_三远程.UseVisualStyleBackColor = true;
            this.rb_三远程.CheckedChanged += new System.EventHandler(this.rb_三远程_CheckedChanged);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "发生时上报";
            this.Column4.Name = "Column4";
            this.Column4.Width = 75;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "结束时上报";
            this.Column3.Name = "Column3";
            this.Column3.Width = 75;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "读写结果";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "上报方式";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "读写结果(上报方式)";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(949, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "新增上报事件列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lsv_上报列表);
            this.splitContainer2.Size = new System.Drawing.Size(943, 432);
            this.splitContainer2.SplitterDistance = 273;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btn_新增上报跟随);
            this.panel2.Controls.Add(this.btn_新增列表);
            this.panel2.Controls.Add(this.btn_上报列表);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 432);
            this.panel2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 36);
            this.label5.TabIndex = 10;
            this.label5.Text = "注：抄读新增上报列表（33200200）\r\n时，返回新增主动上报和跟随上报事\r\n件OAD\r\n";
            // 
            // btn_新增上报跟随
            // 
            this.btn_新增上报跟随.Location = new System.Drawing.Point(37, 184);
            this.btn_新增上报跟随.Name = "btn_新增上报跟随";
            this.btn_新增上报跟随.Size = new System.Drawing.Size(124, 39);
            this.btn_新增上报跟随.TabIndex = 9;
            this.btn_新增上报跟随.Text = "新增上报列表(跟随)";
            this.btn_新增上报跟随.UseVisualStyleBackColor = true;
            this.btn_新增上报跟随.Click += new System.EventHandler(this.btn_新增上报跟随_Click);
            // 
            // btn_新增列表
            // 
            this.btn_新增列表.Location = new System.Drawing.Point(37, 110);
            this.btn_新增列表.Name = "btn_新增列表";
            this.btn_新增列表.Size = new System.Drawing.Size(124, 39);
            this.btn_新增列表.TabIndex = 8;
            this.btn_新增列表.Text = "新增上报列表(主动)";
            this.btn_新增列表.UseVisualStyleBackColor = true;
            this.btn_新增列表.Click += new System.EventHandler(this.btn_新增列表_Click);
            // 
            // btn_上报列表
            // 
            this.btn_上报列表.Location = new System.Drawing.Point(37, 36);
            this.btn_上报列表.Name = "btn_上报列表";
            this.btn_上报列表.Size = new System.Drawing.Size(124, 39);
            this.btn_上报列表.TabIndex = 7;
            this.btn_上报列表.Text = "需上报对象列表";
            this.btn_上报列表.UseVisualStyleBackColor = true;
            this.btn_上报列表.Click += new System.EventHandler(this.btn_上报列表_Click);
            // 
            // lsv_上报列表
            // 
            this.lsv_上报列表.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lsv_上报列表.Appearance.FixedLine.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lsv_上报列表.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lsv_上报列表.Appearance.FixedLine.Options.UseBackColor = true;
            this.lsv_上报列表.Appearance.FixedLine.Options.UseBorderColor = true;
            this.lsv_上报列表.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn4});
            this.lsv_上报列表.Cursor = System.Windows.Forms.Cursors.Default;
            this.lsv_上报列表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsv_上报列表.Location = new System.Drawing.Point(0, 0);
            this.lsv_上报列表.Name = "lsv_上报列表";
            this.lsv_上报列表.Size = new System.Drawing.Size(666, 432);
            this.lsv_上报列表.TabIndex = 7;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "序号";
            this.treeListColumn1.FieldName = "序号";
            this.treeListColumn1.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 32;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "对象标识OAD";
            this.treeListColumn2.FieldName = "对象标识OAD";
            this.treeListColumn2.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 132;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "项目说明";
            this.treeListColumn4.FieldName = "项目说明";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 2;
            this.treeListColumn4.Width = 234;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "对象名称";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 150;
            // 
            // rb_单远程
            // 
            this.rb_单远程.AutoSize = true;
            this.rb_单远程.Checked = true;
            this.rb_单远程.Location = new System.Drawing.Point(19, 32);
            this.rb_单远程.Name = "rb_单远程";
            this.rb_单远程.Size = new System.Drawing.Size(83, 16);
            this.rb_单远程.TabIndex = 1;
            this.rb_单远程.TabStop = true;
            this.rb_单远程.Text = "单相远程表";
            this.rb_单远程.UseVisualStyleBackColor = true;
            this.rb_单远程.CheckedChanged += new System.EventHandler(this.rb_单远程_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(957, 464);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(949, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "跟随上报集合";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_follow);
            this.splitContainer1.Size = new System.Drawing.Size(943, 432);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSkip);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn_set_上报方式);
            this.panel1.Controls.Add(this.btn_read_上报方式);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_set);
            this.panel1.Controls.Add(this.btn_read);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 432);
            this.panel1.TabIndex = 2;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(75, 395);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(96, 32);
            this.btnSkip.TabIndex = 8;
            this.btnSkip.Text = "一键跳转";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "----->";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "----->";
            // 
            // btn_set_上报方式
            // 
            this.btn_set_上报方式.Location = new System.Drawing.Point(75, 304);
            this.btn_set_上报方式.Name = "btn_set_上报方式";
            this.btn_set_上报方式.Size = new System.Drawing.Size(96, 32);
            this.btn_set_上报方式.TabIndex = 6;
            this.btn_set_上报方式.Text = "设置上报方式";
            this.btn_set_上报方式.UseVisualStyleBackColor = true;
            this.btn_set_上报方式.Click += new System.EventHandler(this.btn_set_上报方式_Click);
            // 
            // btn_read_上报方式
            // 
            this.btn_read_上报方式.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_read_上报方式.Location = new System.Drawing.Point(75, 249);
            this.btn_read_上报方式.Name = "btn_read_上报方式";
            this.btn_read_上报方式.Size = new System.Drawing.Size(96, 32);
            this.btn_read_上报方式.TabIndex = 4;
            this.btn_read_上报方式.Text = "抄读上报方式";
            this.btn_read_上报方式.UseVisualStyleBackColor = true;
            this.btn_read_上报方式.Click += new System.EventHandler(this.btn_read_上报方式_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "\"基本信息\"->\"设备管理\"页面设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "注：跟随上报\"开启\"与\"关闭\"，请从\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "----->";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "----->";
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(75, 180);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(96, 32);
            this.btn_set.TabIndex = 2;
            this.btn_set.Text = "设置上报状态";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // btn_read
            // 
            this.btn_read.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_read.Location = new System.Drawing.Point(75, 125);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(96, 32);
            this.btn_read.TabIndex = 1;
            this.btn_read.Text = "抄读上报状态";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_三本地);
            this.groupBox1.Controls.Add(this.rb_单本地);
            this.groupBox1.Controls.Add(this.rb_三远程);
            this.groupBox1.Controls.Add(this.rb_单远程);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "电能表类型选择";
            // 
            // dgv_follow
            // 
            this.dgv_follow.AllowUserToAddRows = false;
            this.dgv_follow.AllowUserToDeleteRows = false;
            this.dgv_follow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_follow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgv_follow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_follow.Location = new System.Drawing.Point(0, 0);
            this.dgv_follow.Name = "dgv_follow";
            this.dgv_follow.RowHeadersWidth = 20;
            this.dgv_follow.RowTemplate.Height = 23;
            this.dgv_follow.Size = new System.Drawing.Size(697, 432);
            this.dgv_follow.TabIndex = 0;
            this.dgv_follow.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_follow_CellMouseClick);
            // 
            // Follow_Collection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(957, 464);
            this.Controls.Add(this.tabControl1);
            this.Name = "Follow_Collection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增上报和跟随上报集合(事件类)";
            this.Load += new System.EventHandler(this.Follow_Collection_Load);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lsv_上报列表)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_follow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.RadioButton rb_三本地;
        private System.Windows.Forms.RadioButton rb_单本地;
        private System.Windows.Forms.RadioButton rb_三远程;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_新增上报跟随;
        private System.Windows.Forms.Button btn_新增列表;
        private System.Windows.Forms.Button btn_上报列表;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.RadioButton rb_单远程;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_set_上报方式;
        private System.Windows.Forms.Button btn_read_上报方式;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_follow;
        private DevExpress.XtraTreeList.TreeList lsv_上报列表;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private System.Windows.Forms.Button btnSkip;
    }
}