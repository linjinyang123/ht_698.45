﻿namespace ht_698._45.UI
{
    partial class Variable
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
            this.lsv_变量 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlb_Read = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlb_Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlb_Excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlb_Exit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tree_变量 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.lsv_变量)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsv_变量
            // 
            this.lsv_变量.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lsv_变量.Appearance.FixedLine.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lsv_变量.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lsv_变量.Appearance.FixedLine.Options.UseBackColor = true;
            this.lsv_变量.Appearance.FixedLine.Options.UseBorderColor = true;
            this.lsv_变量.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn6,
            this.treeListColumn4});
            this.lsv_变量.Cursor = System.Windows.Forms.Cursors.Default;
            this.lsv_变量.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsv_变量.Location = new System.Drawing.Point(0, 37);
            this.lsv_变量.Name = "lsv_变量";
            this.lsv_变量.Size = new System.Drawing.Size(685, 455);
            this.lsv_变量.TabIndex = 2;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "对象名称";
            this.treeListColumn1.FieldName = "对象名称";
            this.treeListColumn1.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 128;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "对象标识OAD";
            this.treeListColumn2.FieldName = "对象标识OAD";
            this.treeListColumn2.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 69;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "数据";
            this.treeListColumn6.FieldName = "数据";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.OptionsColumn.AllowSort = false;
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 2;
            this.treeListColumn6.Width = 92;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "说明";
            this.treeListColumn4.FieldName = "说明";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.OptionsColumn.AllowSort = false;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 202;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlb_Read,
            this.toolStripSeparator1,
            this.tlb_Stop,
            this.toolStripSeparator2,
            this.tlb_Excel,
            this.toolStripSeparator3,
            this.tlb_Exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(685, 34);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlb_Read
            // 
            this.tlb_Read.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlb_Read.Image = global::ht_698._45.Properties.Resources.读取;
            this.tlb_Read.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlb_Read.Name = "tlb_Read";
            this.tlb_Read.Size = new System.Drawing.Size(85, 31);
            this.tlb_Read.Text = "属性抄读";
            this.tlb_Read.Click += new System.EventHandler(this.tlb_Read_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // tlb_Stop
            // 
            this.tlb_Stop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlb_Stop.Image = global::ht_698._45.Properties.Resources.暂停;
            this.tlb_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlb_Stop.Name = "tlb_Stop";
            this.tlb_Stop.Size = new System.Drawing.Size(57, 31);
            this.tlb_Stop.Text = "停止";
            this.tlb_Stop.Click += new System.EventHandler(this.tlb_Stop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // tlb_Excel
            // 
            this.tlb_Excel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlb_Excel.Image = global::ht_698._45.Properties.Resources.excel;
            this.tlb_Excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlb_Excel.Name = "tlb_Excel";
            this.tlb_Excel.Size = new System.Drawing.Size(92, 31);
            this.tlb_Excel.Text = "导出Excel";
            this.tlb_Excel.Click += new System.EventHandler(this.tlb_Excel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 34);
            // 
            // tlb_Exit
            // 
            this.tlb_Exit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlb_Exit.Image = global::ht_698._45.Properties.Resources.退出;
            this.tlb_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlb_Exit.Name = "tlb_Exit";
            this.tlb_Exit.Size = new System.Drawing.Size(57, 31);
            this.tlb_Exit.Text = "退出";
            this.tlb_Exit.Click += new System.EventHandler(this.tlb_Exit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree_变量);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lsv_变量);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(928, 492);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 3;
            // 
            // tree_变量
            // 
            this.tree_变量.CheckBoxes = true;
            this.tree_变量.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_变量.Location = new System.Drawing.Point(0, 0);
            this.tree_变量.Name = "tree_变量";
            this.tree_变量.Size = new System.Drawing.Size(239, 492);
            this.tree_变量.TabIndex = 0;
            this.tree_变量.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_变量_AfterCheck);
            // 
            // Variable
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(928, 492);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Variable";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "变量";
            this.Load += new System.EventHandler(this.Variable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lsv_变量)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList lsv_变量;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlb_Read;
        private System.Windows.Forms.ToolStripButton tlb_Stop;
        private System.Windows.Forms.ToolStripButton tlb_Excel;
        private System.Windows.Forms.ToolStripButton tlb_Exit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tree_变量;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}