namespace ht_698._45.UI
{
    partial class DisplayItem
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
            this.txt_Help = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Clear = new System.Windows.Forms.Button();
            this.lsv_Dis = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.tv_disItem = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // txt_Help
            // 
            this.txt_Help.Location = new System.Drawing.Point(100, 29);
            this.txt_Help.MaxLength = 8;
            this.txt_Help.Name = "txt_Help";
            this.txt_Help.Size = new System.Drawing.Size(80, 21);
            this.txt_Help.TabIndex = 39;
            this.txt_Help.TextChanged += new System.EventHandler(this.txt_Help_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "标识搜索";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(348, 395);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(50, 23);
            this.btn_Cancel.TabIndex = 37;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(348, 349);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(50, 23);
            this.btn_OK.TabIndex = 36;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Location = new System.Drawing.Point(348, 285);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(50, 23);
            this.btn_Down.TabIndex = 35;
            this.btn_Down.Text = "Down";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Location = new System.Drawing.Point(348, 238);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(50, 23);
            this.btn_Up.TabIndex = 34;
            this.btn_Up.Text = "UP";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "显示项";
            this.columnHeader1.Width = 50;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(348, 177);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(50, 23);
            this.btn_Clear.TabIndex = 33;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // lsv_Dis
            // 
            this.lsv_Dis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsv_Dis.FullRowSelect = true;
            this.lsv_Dis.GridLines = true;
            this.lsv_Dis.LabelEdit = true;
            this.lsv_Dis.Location = new System.Drawing.Point(431, 65);
            this.lsv_Dis.Name = "lsv_Dis";
            this.lsv_Dis.Size = new System.Drawing.Size(419, 369);
            this.lsv_Dis.TabIndex = 30;
            this.lsv_Dis.UseCompatibleStateImageBehavior = false;
            this.lsv_Dis.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "数据标识";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "序号";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "显示项名称";
            this.columnHeader4.Width = 180;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(348, 75);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(50, 23);
            this.btn_Add.TabIndex = 31;
            this.btn_Add.Text = ">>";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(348, 119);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(50, 23);
            this.btn_Remove.TabIndex = 32;
            this.btn_Remove.Text = "<<";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // tv_disItem
            // 
            this.tv_disItem.CheckBoxes = true;
            this.tv_disItem.Location = new System.Drawing.Point(22, 65);
            this.tv_disItem.Name = "tv_disItem";
            this.tv_disItem.Size = new System.Drawing.Size(299, 369);
            this.tv_disItem.TabIndex = 29;
            // 
            // DisplayItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(870, 463);
            this.Controls.Add(this.txt_Help);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.lsv_Dis);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.tv_disItem);
            this.Name = "DisplayItem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电能表显示项目";
            this.Load += new System.EventHandler(this.DisplayItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Help;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.ListView lsv_Dis;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.TreeView tv_disItem;
    }
}