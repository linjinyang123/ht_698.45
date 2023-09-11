namespace ht_698._45.UI
{
    partial class NewBatch
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tv_Batch = new System.Windows.Forms.TreeView();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(270, 614);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(541, 14);
            this.label1.TabIndex = 52;
            this.label1.Text = "注：数据类型 和 数据长度 针对“设置”或“操作”时使用，“抄读”无需关注";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tv_Batch);
            this.panel2.Location = new System.Drawing.Point(3, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 585);
            this.panel2.TabIndex = 51;
            // 
            // tv_Batch
            // 
            this.tv_Batch.CheckBoxes = true;
            this.tv_Batch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Batch.Location = new System.Drawing.Point(0, 0);
            this.tv_Batch.Name = "tv_Batch";
            this.tv_Batch.Size = new System.Drawing.Size(196, 585);
            this.tv_Batch.TabIndex = 17;
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.Caption = "数据长度集合";
            this.treeListColumn8.FieldName = "数据长度集合";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 7;
            this.treeListColumn8.Width = 228;
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "数据类型集合";
            this.treeListColumn7.FieldName = "数据类型集合";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 6;
            this.treeListColumn7.Width = 116;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "单位";
            this.treeListColumn6.FieldName = "单位";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 5;
            this.treeListColumn6.Width = 56;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "换算(小数位)";
            this.treeListColumn5.FieldName = "换算(小数位)";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.AllowSort = false;
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 87;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "操作标志";
            this.treeListColumn4.ColumnEdit = this.repositoryItemComboBox1;
            this.treeListColumn4.FieldName = "操作标志";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowSort = false;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 64;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "参数";
            this.treeListColumn3.FieldName = "参数";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowSort = false;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 140;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "数据OAD";
            this.treeListColumn2.FieldName = "数据OAD";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 85;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "对象名称";
            this.treeListColumn1.FieldName = "对象名称";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 112;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn8});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.treeList1.Size = new System.Drawing.Size(906, 585);
            this.treeList1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeList1);
            this.panel1.Location = new System.Drawing.Point(273, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 585);
            this.panel1.TabIndex = 50;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(205, 461);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(62, 25);
            this.btn_Cancel.TabIndex = 48;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(205, 420);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(62, 25);
            this.btn_OK.TabIndex = 47;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Location = new System.Drawing.Point(209, 271);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(50, 23);
            this.btn_Down.TabIndex = 46;
            this.btn_Down.Text = "Down";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Location = new System.Drawing.Point(209, 231);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(50, 23);
            this.btn_Up.TabIndex = 45;
            this.btn_Up.Text = "UP";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(209, 150);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(50, 23);
            this.btn_Clear.TabIndex = 44;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(209, 92);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(50, 23);
            this.btn_Remove.TabIndex = 43;
            this.btn_Remove.Text = "<<";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(209, 48);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(50, 23);
            this.btn_Add.TabIndex = 42;
            this.btn_Add.Text = ">>";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(205, 375);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(62, 30);
            this.btn_Save.TabIndex = 49;
            this.btn_Save.Text = "保存方案";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // NewBatch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1183, 642);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Save);
            this.Name = "NewBatch";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建方案";
            this.Load += new System.EventHandler(this.NewBatch_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tv_Batch;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Save;
    }
}