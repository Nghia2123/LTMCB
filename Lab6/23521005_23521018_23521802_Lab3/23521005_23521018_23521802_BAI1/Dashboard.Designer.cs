namespace _23521005_23521018_23521802_BAI1
{
    partial class Dashboard
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
            this.server = new System.Windows.Forms.Button();
            this.client = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // server
            // 
            this.server.BackColor = System.Drawing.Color.DarkRed;
            this.server.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.server.Location = new System.Drawing.Point(50, 68);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(196, 46);
            this.server.TabIndex = 5;
            this.server.Text = "UDP Server";
            this.server.UseVisualStyleBackColor = false;
            this.server.Click += new System.EventHandler(this.button1_Click);
            // 
            // client
            // 
            this.client.BackColor = System.Drawing.Color.DarkRed;
            this.client.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.client.Location = new System.Drawing.Point(453, 68);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(193, 46);
            this.client.TabIndex = 6;
            this.client.Text = "UDP Client";
            this.client.UseVisualStyleBackColor = false;
            this.client.Click += new System.EventHandler(this.client_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(225, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "DASHBOARD";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(704, 137);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.client);
            this.Controls.Add(this.server);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button server;
        private System.Windows.Forms.Button client;
        private System.Windows.Forms.Label label1;
    }
}

