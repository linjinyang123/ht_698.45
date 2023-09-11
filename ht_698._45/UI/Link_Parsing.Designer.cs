namespace ht_698._45.UI
{
    partial class Link_Parsing
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
            this.txt_LinkData = new System.Windows.Forms.RichTextBox();
            this.txt_Parsing = new System.Windows.Forms.RichTextBox();
            this.btn_Parsing = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(18, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txt_LinkData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_Parsing);
            this.splitContainer1.Size = new System.Drawing.Size(658, 585);
            this.splitContainer1.SplitterDistance = 142;
            this.splitContainer1.TabIndex = 4;
            // 
            // txt_LinkData
            // 
            this.txt_LinkData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_LinkData.Location = new System.Drawing.Point(0, 0);
            this.txt_LinkData.Name = "txt_LinkData";
            this.txt_LinkData.Size = new System.Drawing.Size(658, 142);
            this.txt_LinkData.TabIndex = 0;
            this.txt_LinkData.Text = "";
            // 
            // txt_Parsing
            // 
            this.txt_Parsing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Parsing.Location = new System.Drawing.Point(0, 0);
            this.txt_Parsing.Name = "txt_Parsing";
            this.txt_Parsing.Size = new System.Drawing.Size(658, 439);
            this.txt_Parsing.TabIndex = 0;
            this.txt_Parsing.Text = "";
            // 
            // btn_Parsing
            // 
            this.btn_Parsing.Location = new System.Drawing.Point(698, 47);
            this.btn_Parsing.Name = "btn_Parsing";
            this.btn_Parsing.Size = new System.Drawing.Size(65, 41);
            this.btn_Parsing.TabIndex = 5;
            this.btn_Parsing.Text = "解析";
            this.btn_Parsing.UseVisualStyleBackColor = true;
            // 
            // Link_Parsing
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(780, 592);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_Parsing);
            this.Name = "Link_Parsing";
            this.ShowIcon = false;
            this.Text = "Link_Parsing";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txt_LinkData;
        private System.Windows.Forms.RichTextBox txt_Parsing;
        private System.Windows.Forms.Button btn_Parsing;
    }
}