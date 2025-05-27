using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace _23521005_23521018_23521802_BAI5
{
    public partial class chatClient : Form
    {
        private TcpClient client;
        private NetworkStream ns;

        public chatClient()
        {
            InitializeComponent();
            connectToServer();
            this.FormClosed += ChatClient_FormClosed; // Khi đóng form thì thực hiện ngắt kết nối
        }

        public chatClient(string username)
        {
            InitializeComponent();
            nameBox.Text = username;
            connectToServer();
            this.FormClosed += ChatClient_FormClosed; // Khi đóng form thì thực hiện ngắt kết nối
        }

        // Ngắt kết nối tới server khi đóng form
        private void ChatClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
            {
                client.Close();
                client = null;
            }
        }

        private void ReceiveMessage()
        {
            try
            {
                byte[] recv = new byte[1024];
                int bytesReceived = 0;
                while (true)
                {
                    bytesReceived = ns.Read(recv, 0, recv.Length);
                    string text = Encoding.UTF8.GetString(recv, 0, bytesReceived);
                    receiveTextBox.Invoke(new Action(() =>
                    {
                        receiveTextBox.AppendText(text + "\n");
                    }));
                }
            }
            catch (Exception)
            {
            }
        }

        private void connectToServer()
        {
            try
            {
                // Nếu client đã bị đóng, tạo lại đối tượng TcpClient
                if (client == null || !client.Connected)
                {
                    client = new TcpClient();
                    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
                    client.Connect(ipEndPoint);

                    // Tạo lại luồng sau khi kết nối thành công
                    ns = client.GetStream();
                }

                // Tạo luồng nhận dữ liệu từ server
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to server: " + ex.Message);
            }
        }

        private void sentButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem client có kết nối chưa, nếu không, kết nối lại
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Disconnected from server. Reconnecting...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connectToServer();
                }

                if (nameBox.Text == "")
                {
                    MessageBox.Show("Please enter your name!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string message = nameBox.Text + ": " + messageBox.Text;


                // Gửi dữ liệu tới server
                Byte[] data = Encoding.UTF8.GetBytes(message);
                ns.Write(data, 0, data.Length);
                ns.Flush();

                // Xóa nội dung của messageBox sau khi gửi
                messageBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot send message: " + ex.Message);
            }
        }

        private void createRoomBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem client có kết nối chưa, nếu không, kết nối lại
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Disconnected from server. Reconnecting...");
                    connectToServer();
                }

                string cmd = "/createroom";

                byte[] data = Encoding.UTF8.GetBytes(cmd);
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot send message: " + ex.Message);
            }
        }

        private void joinRoomBtn_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem client có kết nối chưa, nếu không, kết nối lại
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Disconnected from server. Reconnecting...");
                connectToServer();
            }

            if (roomIdTextBox.Text == "")
            {
                MessageBox.Show("Please enter room ID!");
                return;
            }

            string cmd = "/joinroom " + roomIdTextBox.Text + " " + nameBox.Text;

            byte[] data = Encoding.UTF8.GetBytes(cmd);
            ns.Write(data, 0, data.Length);
            ns.Flush();

            roomIdTextBox.Text = "";
        }

        private void leaveRoomBtn_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem client có kết nối chưa, nếu không, kết nối lại
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Disconnected from server. Reconnecting...");
                connectToServer();
            }

            string cmd = $"/leaveroom {nameBox.Text}";

            byte[] data = Encoding.UTF8.GetBytes(cmd);
            ns.Write(data, 0, data.Length);
            ns.Flush();
        }


        // Enter chat
        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true; 
                sentButton.PerformClick(); 
            }
        }
    }
}