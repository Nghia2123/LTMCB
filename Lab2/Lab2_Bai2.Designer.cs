namespace Lab2
{
    partial class Lab2_Bai2
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
            this.readButton = new System.Windows.Forms.Button();
            this.tenfile = new System.Windows.Forms.Label();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.fileUrlBox = new System.Windows.Forms.TextBox();
            this.url = new System.Windows.Forms.Label();
            this.fileLineBox = new System.Windows.Forms.TextBox();
            this.line = new System.Windows.Forms.Label();
            this.fileWordBox = new System.Windows.Forms.TextBox();
            this.word = new System.Windows.Forms.Label();
            this.fileCharBox = new System.Windows.Forms.TextBox();
            this.character = new System.Windows.Forms.Label();
            this.readFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contentTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // readButton
            // 
            this.readButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.readButton.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.readButton.FlatAppearance.BorderSize = 10;
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readButton.Location = new System.Drawing.Point(111, 36);
            this.readButton.Name = "readButton";
            this.readButton.Padding = new System.Windows.Forms.Padding(10);
            this.readButton.Size = new System.Drawing.Size(373, 125);
            this.readButton.TabIndex = 1;
            this.readButton.Text = "ĐỌC FILE";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // tenfile
            // 
            this.tenfile.AutoSize = true;
            this.tenfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenfile.Location = new System.Drawing.Point(24, 251);
            this.tenfile.Name = "tenfile";
            this.tenfile.Size = new System.Drawing.Size(103, 31);
            this.tenfile.TabIndex = 2;
            this.tenfile.Text = "Tên file";
            // 
            // fileNameBox
            // 
            this.fileNameBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileNameBox.Location = new System.Drawing.Point(172, 251);
            this.fileNameBox.Multiline = true;
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.ReadOnly = true;
            this.fileNameBox.Size = new System.Drawing.Size(378, 42);
            this.fileNameBox.TabIndex = 3;
            // 
            // fileUrlBox
            // 
            this.fileUrlBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileUrlBox.Location = new System.Drawing.Point(172, 327);
            this.fileUrlBox.Multiline = true;
            this.fileUrlBox.Name = "fileUrlBox";
            this.fileUrlBox.ReadOnly = true;
            this.fileUrlBox.Size = new System.Drawing.Size(378, 42);
            this.fileUrlBox.TabIndex = 5;
            // 
            // url
            // 
            this.url.AutoSize = true;
            this.url.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.url.Location = new System.Drawing.Point(24, 327);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(49, 31);
            this.url.TabIndex = 4;
            this.url.Text = "Url";
            // 
            // fileLineBox
            // 
            this.fileLineBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileLineBox.Location = new System.Drawing.Point(172, 409);
            this.fileLineBox.Multiline = true;
            this.fileLineBox.Name = "fileLineBox";
            this.fileLineBox.ReadOnly = true;
            this.fileLineBox.Size = new System.Drawing.Size(378, 42);
            this.fileLineBox.TabIndex = 7;
            // 
            // line
            // 
            this.line.AutoSize = true;
            this.line.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line.Location = new System.Drawing.Point(24, 409);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(114, 31);
            this.line.TabIndex = 6;
            this.line.Text = "Số dòng";
            // 
            // fileWordBox
            // 
            this.fileWordBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileWordBox.Location = new System.Drawing.Point(172, 495);
            this.fileWordBox.Multiline = true;
            this.fileWordBox.Name = "fileWordBox";
            this.fileWordBox.ReadOnly = true;
            this.fileWordBox.Size = new System.Drawing.Size(378, 42);
            this.fileWordBox.TabIndex = 9;
            // 
            // word
            // 
            this.word.AutoSize = true;
            this.word.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.word.Location = new System.Drawing.Point(24, 495);
            this.word.Name = "word";
            this.word.Size = new System.Drawing.Size(77, 31);
            this.word.TabIndex = 8;
            this.word.Text = "Số từ";
            // 
            // fileCharBox
            // 
            this.fileCharBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileCharBox.Location = new System.Drawing.Point(172, 581);
            this.fileCharBox.Multiline = true;
            this.fileCharBox.Name = "fileCharBox";
            this.fileCharBox.ReadOnly = true;
            this.fileCharBox.Size = new System.Drawing.Size(378, 42);
            this.fileCharBox.TabIndex = 11;
            // 
            // character
            // 
            this.character.AutoSize = true;
            this.character.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.character.Location = new System.Drawing.Point(24, 581);
            this.character.Name = "character";
            this.character.Size = new System.Drawing.Size(104, 31);
            this.character.TabIndex = 10;
            this.character.Text = "Số kí tự";
            // 
            // readFileDialog
            // 
            this.readFileDialog.FileName = "openFileDialog1";
            this.readFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // contentTextBox
            // 
            this.contentTextBox.Location = new System.Drawing.Point(609, 27);
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.Size = new System.Drawing.Size(882, 675);
            this.contentTextBox.TabIndex = 12;
            this.contentTextBox.Text = "";
            // 
            // Lab2_Bai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 740);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.fileCharBox);
            this.Controls.Add(this.character);
            this.Controls.Add(this.fileWordBox);
            this.Controls.Add(this.word);
            this.Controls.Add(this.fileLineBox);
            this.Controls.Add(this.line);
            this.Controls.Add(this.fileUrlBox);
            this.Controls.Add(this.url);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.tenfile);
            this.Controls.Add(this.readButton);
            this.Name = "Lab2_Bai2";
            this.Text = "Bai2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Label tenfile;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.TextBox fileUrlBox;
        private System.Windows.Forms.Label url;
        private System.Windows.Forms.TextBox fileLineBox;
        private System.Windows.Forms.Label line;
        private System.Windows.Forms.TextBox fileWordBox;
        private System.Windows.Forms.Label word;
        private System.Windows.Forms.TextBox fileCharBox;
        private System.Windows.Forms.Label character;
        private System.Windows.Forms.OpenFileDialog readFileDialog;
        private System.Windows.Forms.RichTextBox contentTextBox;
    }
}