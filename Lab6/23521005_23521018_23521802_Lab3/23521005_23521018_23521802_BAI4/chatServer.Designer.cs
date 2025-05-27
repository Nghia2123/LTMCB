namespace _23521005_23521018_23521802_BAI4
{
    partial class chatServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chatServer));
            this.listenButton = new System.Windows.Forms.Button();
            this.connectTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listenButton
            // 
            this.listenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listenButton.Location = new System.Drawing.Point(466, 22);
            this.listenButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(105, 35);
            this.listenButton.TabIndex = 0;
            this.listenButton.Text = "Listen";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
            // 
            // connectTextBox
            // 
            this.connectTextBox.Location = new System.Drawing.Point(38, 73);
            this.connectTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectTextBox.Name = "connectTextBox";
            this.connectTextBox.Size = new System.Drawing.Size(534, 298);
            this.connectTextBox.TabIndex = 1;
            this.connectTextBox.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // chatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(601, 390);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.connectTextBox);
            this.Controls.Add(this.listenButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "chatServer";
            this.Text = "Chat Server";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.RichTextBox connectTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}