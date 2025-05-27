using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using _23521005_23521018_23521802_BAI5;
using System.Threading;

namespace _23521005_23521018_23521802_BAI5
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            passRe.UseSystemPasswordChar = true;
            cfrmRe.UseSystemPasswordChar = true;
            passLo.UseSystemPasswordChar = true;
        }

        private string SendToServer(string message)
        {
            TcpClient client = null; // Initialize the client variable to null
            try
            {
                client = new TcpClient("127.0.0.1", 8080);
            }
            catch
            {
                return "[ERROR]|Server is not working";
            }

            NetworkStream ns = client.GetStream();
            byte[] send = Encoding.UTF8.GetBytes(message);
            ns.Write(send, 0, send.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = ns.Read(buffer, 0, buffer.Length);
            client.Close();
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => HandleRegister());
            t.IsBackground = true; 
            t.Start();
        }

        private void HandleRegister()
        {
            string username = usrRe.Text.Trim();
            string password = passRe.Text.Trim();
            string confirmPass = cfrmRe.Text.Trim();

            if (username == "" || password == "" || confirmPass == "")
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show("Please enter complete information!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
                return;
            }

            if (password != confirmPass)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show("Confirm password does not match!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
                return;
            }

            string response = SendToServer($"[REGISTER]|{username}|{password}");

            this.Invoke(new Action(() =>
            {
                MessageBox.Show(response.Split('|')[1]);
                if (response.StartsWith("[REGISTER_SUCCESS]"))
                {
                    panel1.Visible = false;
                }
            }));
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => HandleLogin());
            t.Start();
        }

        private void HandleLogin()
        {
            string username = usrLo.Text.Trim();
            string password = passLo.Text.Trim();

            string response = SendToServer($"[LOGIN]|{username}|{password}");

            this.Invoke(new Action(() =>
            {
                if (response.StartsWith("[LOGIN_SUCCESS]"))
                {
                    MessageBox.Show("Log in successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Invoke(new Action(() =>
                    {
                        var client = new chatClient(username);
                        client.StartPosition = FormStartPosition.CenterScreen;
                        client.Show();
                        this.Close();
                    }));

                }
                else
                    MessageBox.Show(response.Split('|')[1]);
            }));
        }


        private void btnCrtAcc_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void haveAccRe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
