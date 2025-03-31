namespace Lab2
{
    partial class Lab2_Bai3
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
            this.writeButton = new System.Windows.Forms.Button();
            this.calButton = new System.Windows.Forms.Button();
            this.inputRichText = new System.Windows.Forms.RichTextBox();
            this.outputRichText = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.readButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // writeButton
            // 
            this.writeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.writeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.writeButton.Location = new System.Drawing.Point(761, 46);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(259, 59);
            this.writeButton.TabIndex = 1;
            this.writeButton.Text = "Ghi";
            this.writeButton.UseVisualStyleBackColor = false;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // calButton
            // 
            this.calButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.calButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calButton.Location = new System.Drawing.Point(397, 46);
            this.calButton.Name = "calButton";
            this.calButton.Size = new System.Drawing.Size(259, 59);
            this.calButton.TabIndex = 2;
            this.calButton.Text = "Tính";
            this.calButton.UseVisualStyleBackColor = false;
            this.calButton.Click += new System.EventHandler(this.calButton_Click);
            // 
            // inputRichText
            // 
            this.inputRichText.BackColor = System.Drawing.Color.White;
            this.inputRichText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.inputRichText.Location = new System.Drawing.Point(29, 149);
            this.inputRichText.Name = "inputRichText";
            this.inputRichText.ReadOnly = true;
            this.inputRichText.Size = new System.Drawing.Size(462, 554);
            this.inputRichText.TabIndex = 3;
            this.inputRichText.Text = "";
            // 
            // outputRichText
            // 
            this.outputRichText.BackColor = System.Drawing.Color.White;
            this.outputRichText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.outputRichText.Location = new System.Drawing.Point(558, 149);
            this.outputRichText.Name = "outputRichText";
            this.outputRichText.ReadOnly = true;
            this.outputRichText.Size = new System.Drawing.Size(462, 554);
            this.outputRichText.TabIndex = 4;
            this.outputRichText.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // readButton
            // 
            this.readButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.readButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readButton.Location = new System.Drawing.Point(29, 46);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(259, 59);
            this.readButton.TabIndex = 5;
            this.readButton.Text = "Đọc";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // Lab2_Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 750);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.outputRichText);
            this.Controls.Add(this.inputRichText);
            this.Controls.Add(this.calButton);
            this.Controls.Add(this.writeButton);
            this.Name = "Lab2_Bai3";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Bai3";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Button calButton;
        private System.Windows.Forms.RichTextBox inputRichText;
        private System.Windows.Forms.RichTextBox outputRichText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button readButton;
    }
}