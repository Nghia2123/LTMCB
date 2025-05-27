namespace _23521005_23521018_23521802_BAI5
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
            this.SuspendLayout();
            // 
            // serverButton
            // 
            this.serverButton.BackColor = System.Drawing.Color.LightCyan;
            this.serverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverButton.Location = new System.Drawing.Point(93, 31);
            this.serverButton.Margin = new System.Windows.Forms.Padding(2);
            this.serverButton.Name = "serverButton";
            this.serverButton.Size = new System.Drawing.Size(137, 54);
            this.serverButton.TabIndex = 0;
            this.serverButton.Text = "Chat Server";
            this.serverButton.UseVisualStyleBackColor = false;
            this.serverButton.Click += new System.EventHandler(this.serverButton_Click);
            // 
            // clientButton
            // 
            this.clientButton.BackColor = System.Drawing.Color.LightCyan;
            this.clientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientButton.Location = new System.Drawing.Point(376, 31);
            this.clientButton.Margin = new System.Windows.Forms.Padding(2);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(137, 54);
            this.clientButton.TabIndex = 1;
            this.clientButton.Text = "Chat Client";
            this.clientButton.UseVisualStyleBackColor = false;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(605, 124);
            this.Controls.Add(this.clientButton);
            this.Controls.Add(this.serverButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Mainform";
            this.Text = "Lab03_Bai05";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button serverButton;
        private System.Windows.Forms.Button clientButton;
    }
}

