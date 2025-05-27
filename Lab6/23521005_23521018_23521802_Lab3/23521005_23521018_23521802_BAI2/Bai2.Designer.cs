namespace _23521005_23521018_23521802_BAI2
{
    partial class Bai2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLis = new System.Windows.Forms.Button();
            this.RecMessBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxIP = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBox_Port = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_23521005_23521018_23521802_BAI2.Properties.Resources._3bears;
            this.pictureBox1.Location = new System.Drawing.Point(17, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLis
            // 
            this.buttonLis.BackColor = System.Drawing.Color.DarkRed;
            this.buttonLis.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLis.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLis.Location = new System.Drawing.Point(277, 20);
            this.buttonLis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLis.Name = "buttonLis";
            this.buttonLis.Size = new System.Drawing.Size(106, 37);
            this.buttonLis.TabIndex = 17;
            this.buttonLis.Text = "Listen";
            this.buttonLis.UseVisualStyleBackColor = false;
            this.buttonLis.Click += new System.EventHandler(this.buttonLis_Click);
            // 
            // RecMessBox
            // 
            this.RecMessBox.Location = new System.Drawing.Point(17, 182);
            this.RecMessBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RecMessBox.Name = "RecMessBox";
            this.RecMessBox.Size = new System.Drawing.Size(366, 247);
            this.RecMessBox.TabIndex = 18;
            this.RecMessBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "IP Address";
            // 
            // TextBoxIP
            // 
            this.TextBoxIP.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxIP.Location = new System.Drawing.Point(160, 88);
            this.TextBoxIP.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.Size = new System.Drawing.Size(223, 26);
            this.TextBoxIP.TabIndex = 19;
            this.TextBoxIP.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Port";
            // 
            // TextBox_Port
            // 
            this.TextBox_Port.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Port.Location = new System.Drawing.Point(160, 135);
            this.TextBox_Port.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_Port.Name = "TextBox_Port";
            this.TextBox_Port.Size = new System.Drawing.Size(223, 26);
            this.TextBox_Port.TabIndex = 21;
            this.TextBox_Port.Text = "";
            // 
            // Bai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(401, 455);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBox_Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxIP);
            this.Controls.Add(this.RecMessBox);
            this.Controls.Add(this.buttonLis);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Bai2";
            this.Text = "Bai 2 - Lab 3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonLis;
        private System.Windows.Forms.RichTextBox RecMessBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TextBoxIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox TextBox_Port;
    }
}

