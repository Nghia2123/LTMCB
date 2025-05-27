namespace _23521005_23521018_23521802_BAI4
{
    partial class Mainform
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
            this.serverButton = new System.Windows.Forms.Button();
            this.clientButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // serverButton
            // 
            this.serverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverButton.Location = new System.Drawing.Point(93, 31);
            this.serverButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.serverButton.Name = "serverButton";
            this.serverButton.Size = new System.Drawing.Size(137, 54);
            this.serverButton.TabIndex = 0;
            this.serverButton.Text = "Chat Server";
            this.serverButton.UseVisualStyleBackColor = true;
            this.serverButton.Click += new System.EventHandler(this.serverButton_Click);
            // 
            // clientButton
            // 
            this.clientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientButton.Location = new System.Drawing.Point(376, 31);
            this.clientButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(137, 54);
            this.clientButton.TabIndex = 1;
            this.clientButton.Text = "Chat Client";
            this.clientButton.UseVisualStyleBackColor = true;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_23521005_23521018_23521802_BAI4.Properties.Resources._3bears;
            this.pictureBox1.Location = new System.Drawing.Point(232, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(605, 124);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.clientButton);
            this.Controls.Add(this.serverButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Mainform";
            this.Text = "Lab03_Bai04";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button serverButton;
        private System.Windows.Forms.Button clientButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

