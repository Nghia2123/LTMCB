namespace _23521005_23521018_23521802_BAI5
{
    partial class chatClient
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
            this.receiveTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sentButton = new System.Windows.Forms.Button();
            this.createRoomBtn = new System.Windows.Forms.Button();
            this.joinRoomBtn = new System.Windows.Forms.Button();
            this.roomIdTextBox = new System.Windows.Forms.TextBox();
            this.leaveRoomBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // receiveTextBox
            // 
            this.receiveTextBox.BackColor = System.Drawing.Color.White;
            this.receiveTextBox.Location = new System.Drawing.Point(37, 21);
            this.receiveTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.receiveTextBox.Name = "receiveTextBox";
            this.receiveTextBox.ReadOnly = true;
            this.receiveTextBox.Size = new System.Drawing.Size(824, 287);
            this.receiveTextBox.TabIndex = 0;
            this.receiveTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Message";
            // 
            // nameBox
            // 
            this.nameBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nameBox.Location = new System.Drawing.Point(37, 363);
            this.nameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(201, 22);
            this.nameBox.TabIndex = 3;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(37, 422);
            this.messageBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(716, 22);
            this.messageBox.TabIndex = 4;
            this.messageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageBox_KeyDown);
            // 
            // sentButton
            // 
            this.sentButton.BackColor = System.Drawing.Color.Maroon;
            this.sentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sentButton.ForeColor = System.Drawing.SystemColors.Control;
            this.sentButton.Location = new System.Drawing.Point(769, 416);
            this.sentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sentButton.Name = "sentButton";
            this.sentButton.Size = new System.Drawing.Size(115, 36);
            this.sentButton.TabIndex = 5;
            this.sentButton.Text = "Sent";
            this.sentButton.UseVisualStyleBackColor = false;
            this.sentButton.Click += new System.EventHandler(this.sentButton_Click);
            // 
            // createRoomBtn
            // 
            this.createRoomBtn.Location = new System.Drawing.Point(501, 384);
            this.createRoomBtn.Margin = new System.Windows.Forms.Padding(4);
            this.createRoomBtn.Name = "createRoomBtn";
            this.createRoomBtn.Size = new System.Drawing.Size(133, 28);
            this.createRoomBtn.TabIndex = 6;
            this.createRoomBtn.Text = "Create Room";
            this.createRoomBtn.UseVisualStyleBackColor = true;
            this.createRoomBtn.Click += new System.EventHandler(this.createRoomBtn_Click);
            // 
            // joinRoomBtn
            // 
            this.joinRoomBtn.Location = new System.Drawing.Point(501, 348);
            this.joinRoomBtn.Margin = new System.Windows.Forms.Padding(4);
            this.joinRoomBtn.Name = "joinRoomBtn";
            this.joinRoomBtn.Size = new System.Drawing.Size(100, 28);
            this.joinRoomBtn.TabIndex = 7;
            this.joinRoomBtn.Text = "Join Room";
            this.joinRoomBtn.UseVisualStyleBackColor = true;
            this.joinRoomBtn.Click += new System.EventHandler(this.joinRoomBtn_Click);
            // 
            // roomIdTextBox
            // 
            this.roomIdTextBox.Location = new System.Drawing.Point(629, 351);
            this.roomIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.roomIdTextBox.Name = "roomIdTextBox";
            this.roomIdTextBox.Size = new System.Drawing.Size(132, 22);
            this.roomIdTextBox.TabIndex = 8;
            // 
            // leaveRoomBtn
            // 
            this.leaveRoomBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveRoomBtn.Location = new System.Drawing.Point(769, 348);
            this.leaveRoomBtn.Margin = new System.Windows.Forms.Padding(4);
            this.leaveRoomBtn.Name = "leaveRoomBtn";
            this.leaveRoomBtn.Size = new System.Drawing.Size(115, 28);
            this.leaveRoomBtn.TabIndex = 9;
            this.leaveRoomBtn.Text = "Leave Room";
            this.leaveRoomBtn.UseVisualStyleBackColor = true;
            this.leaveRoomBtn.Click += new System.EventHandler(this.leaveRoomBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(501, 384);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Create Room";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createRoomBtn_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(501, 349);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "Join Room";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.joinRoomBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::_23521005_23521018_23521802_BAI5.Properties.Resources._3bears;
            this.pictureBox1.Image = global::_23521005_23521018_23521802_BAI5.Properties.Resources._3bears;
            this.pictureBox1.Location = new System.Drawing.Point(244, 318);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // chatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(900, 473);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.leaveRoomBtn);
            this.Controls.Add(this.roomIdTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.joinRoomBtn);
            this.Controls.Add(this.createRoomBtn);
            this.Controls.Add(this.sentButton);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.receiveTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "chatClient";
            this.Text = "chatClient";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox receiveTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button sentButton;
        private System.Windows.Forms.Button createRoomBtn;
        private System.Windows.Forms.Button joinRoomBtn;
        private System.Windows.Forms.TextBox roomIdTextBox;
        private System.Windows.Forms.Button leaveRoomBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}