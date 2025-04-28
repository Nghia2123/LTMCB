namespace Lab4
{
    partial class Lab4_Bai3
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
            this.getCommentButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.getUserButton = new System.Windows.Forms.Button();
            this.getPhotoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getCommentButton
            // 
            this.getCommentButton.Location = new System.Drawing.Point(22, 4);
            this.getCommentButton.Margin = new System.Windows.Forms.Padding(4);
            this.getCommentButton.Name = "getCommentButton";
            this.getCommentButton.Size = new System.Drawing.Size(170, 75);
            this.getCommentButton.TabIndex = 0;
            this.getCommentButton.Text = "Get Comments";
            this.getCommentButton.UseVisualStyleBackColor = true;
            this.getCommentButton.Click += new System.EventHandler(this.getCommentButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(94, 206);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(772, 397);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.getUserButton);
            this.panel1.Controls.Add(this.getPhotoButton);
            this.panel1.Controls.Add(this.getCommentButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 98);
            this.panel1.TabIndex = 2;
            // 
            // getUserButton
            // 
            this.getUserButton.Location = new System.Drawing.Point(421, 4);
            this.getUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.getUserButton.Name = "getUserButton";
            this.getUserButton.Size = new System.Drawing.Size(170, 75);
            this.getUserButton.TabIndex = 2;
            this.getUserButton.Text = "Get Users";
            this.getUserButton.UseVisualStyleBackColor = true;
            this.getUserButton.Click += new System.EventHandler(this.getUserButton_Click);
            // 
            // getPhotoButton
            // 
            this.getPhotoButton.Location = new System.Drawing.Point(221, 4);
            this.getPhotoButton.Margin = new System.Windows.Forms.Padding(4);
            this.getPhotoButton.Name = "getPhotoButton";
            this.getPhotoButton.Size = new System.Drawing.Size(170, 75);
            this.getPhotoButton.TabIndex = 1;
            this.getPhotoButton.Text = "Get Photos";
            this.getPhotoButton.UseVisualStyleBackColor = true;
            this.getPhotoButton.Click += new System.EventHandler(this.getPhotoButton_Click);
            // 
            // Lab4_Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 642);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Lab4_Bai3";
            this.Text = "Lab4_Bai3";
            this.Load += new System.EventHandler(this.Lab4_Bai3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button getCommentButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button getUserButton;
        private System.Windows.Forms.Button getPhotoButton;
    }
}