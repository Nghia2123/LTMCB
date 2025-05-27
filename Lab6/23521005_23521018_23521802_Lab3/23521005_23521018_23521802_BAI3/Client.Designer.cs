namespace BAI3
{
    partial class Client
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.RichTextBox();
            this.View = new System.Windows.Forms.RichTextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.IP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(694, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 73);
            this.button2.TabIndex = 11;
            this.button2.Text = "Gửi";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(694, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Kết nối";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(13, 365);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(675, 73);
            this.Message.TabIndex = 9;
            this.Message.Text = "";
            // 
            // View
            // 
            this.View.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.View.Location = new System.Drawing.Point(13, 50);
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.Size = new System.Drawing.Size(675, 308);
            this.View.TabIndex = 8;
            this.View.Text = "";
            // 
            // Port
            // 
            this.Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port.Location = new System.Drawing.Point(314, 13);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(140, 30);
            this.Port.TabIndex = 7;
            // 
            // IP
            // 
            this.IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP.Location = new System.Drawing.Point(13, 13);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(268, 30);
            this.IP.TabIndex = 6;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.View);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IP);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox Message;
        private System.Windows.Forms.RichTextBox View;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.TextBox IP;
    }
}