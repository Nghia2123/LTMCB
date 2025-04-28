namespace Lab4
{
    partial class Lab4_Bai1
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBoxHtml = new System.Windows.Forms.RichTextBox();
            this.dataGridViewHeaders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHeaders)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(44, 24);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(860, 26);
            this.txtUrl.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(990, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Download";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // richTextBoxHtml
            // 
            this.richTextBoxHtml.Location = new System.Drawing.Point(56, 75);
            this.richTextBoxHtml.Name = "richTextBoxHtml";
            this.richTextBoxHtml.Size = new System.Drawing.Size(848, 735);
            this.richTextBoxHtml.TabIndex = 2;
            this.richTextBoxHtml.Text = "";
            // 
            // dataGridViewHeaders
            // 
            this.dataGridViewHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHeaders.Location = new System.Drawing.Point(990, 81);
            this.dataGridViewHeaders.Name = "dataGridViewHeaders";
            this.dataGridViewHeaders.RowHeadersWidth = 62;
            this.dataGridViewHeaders.RowTemplate.Height = 28;
            this.dataGridViewHeaders.Size = new System.Drawing.Size(593, 729);
            this.dataGridViewHeaders.TabIndex = 3;
            // 
            // Lab4_Bai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1609, 866);
            this.Controls.Add(this.dataGridViewHeaders);
            this.Controls.Add(this.richTextBoxHtml);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUrl);
            this.Name = "Lab4_Bai1";
            this.Text = "Lab4_Bai1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHeaders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBoxHtml;
        private System.Windows.Forms.DataGridView dataGridViewHeaders;
    }
}