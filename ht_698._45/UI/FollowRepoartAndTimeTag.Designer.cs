namespace ht_698._45.UI
{
    partial class FollowRepoartAndTimeTag
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
            this.tl_跟随 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tl_跟随)).BeginInit();
            this.SuspendLayout();
            // 
            // tl_跟随
            // 
            this.tl_跟随.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4});
            this.tl_跟随.Cursor = System.Windows.Forms.Cursors.Default;
            this.tl_跟随.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl_跟随.Location = new System.Drawing.Point(0, 0);
            this.tl_跟随.Name = "tl_跟随";
            this.tl_跟随.Size = new System.Drawing.Size(367, 405);
            this.tl_跟随.TabIndex = 1;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "项目";
            this.treeListColumn1.FieldName = "项目";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 119;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "上报OAD";
            this.treeListColumn2.FieldName = "上报OAD";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 112;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "上报内容";
            this.treeListColumn3.FieldName = "上报内容";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 118;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "说明";
            this.treeListColumn4.FieldName = "说明";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            // 
            // FollowRepoartAndTimeTag
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(367, 405);
            this.Controls.Add(this.tl_跟随);
            this.Name = "FollowRepoartAndTimeTag";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "跟随上报信息域和时间标签";
            this.Load += new System.EventHandler(this.FollowRepoartAndTimeTag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tl_跟随)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tl_跟随;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
    }
}