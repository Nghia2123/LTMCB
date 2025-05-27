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

namespace _23521005_23521018_23521802_BAI4
{
    public partial class chatClient : Form
    {
        private TcpClient client;
        private NetworkStream ns;

        public chatClient()
        {
            InitializeComponent();
            connectToServer();
            this.FormClosed += ChatClient_FormClosed;
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
                if (client != null)
                {
                    receiveTextBox.Invoke(new Action(() =>
                    {
                        receiveTextBox.AppendText("Disconnected from server\n");
                    }));
                }
                return;
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
            catch (Exception)
            {
                MessageBox.Show("Server is not running");
                return;
            }
        }

        private void sentButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem client có kết nối chưa, nếu không, kết nối lại
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Disconnected from server. Reconnecting...");
                    connectToServer();
                }

                if (nameBox.Text == "")
                {
                    MessageBox.Show("Please enter your name!");
                    return;
                }

                string message = nameBox.Text + ": " + messageBox.Text;

                // Gửi dữ liệu tới server
                Byte[] data = Encoding.UTF8.GetBytes(message);
                ns.Write(data, 0, data.Length);
                ns.Flush();
                messageBox.Clear();

                // Kiểm tra nếu người dùng gửi tin nhắn "quit"
                if (receiveTextBox.Text.ToLower() == "quit")
                {
                    ns.Close();
                    client.Close();
                    client = null; // Đặt client = null sau khi đóng kết nối
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot send message: " + ex.Message);
            }
        }
    }
}