using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Http;

namespace BAI3
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        IPEndPoint ep;

        void StartUnsafeThread()
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1024];
            Socket clientSocket;
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenerSocket.Bind(ep);
            listenerSocket.Listen(5);
            clientSocket = listenerSocket.Accept();
            while (clientSocket.Connected)
            {
                bytesReceived = clientSocket.Receive(recv);
                if (bytesReceived > 0)
                {
                    //string text = Encoding.UTF8.GetString(recv, 0, bytesReceived);
                    // Key và IV cho AES-128 (16 byte mỗi cái)
                    byte[] key = Encoding.UTF8.GetBytes("1a2b3c4d5e6f7g8h");
                    byte[] iv = Encoding.UTF8.GetBytes("a1b2c3d4e5f6g7h8");

                    // Use the static methods of AesEncryption directly
                    string decryptedText = AesEncryption.Decrypt(recv, key, iv);

                    Invoke((MethodInvoker)delegate
                    {
                        View.Text += "Client: " + decryptedText + '\n';
                    });
                }
            }

            listenerSocket.Close();
            clientSocket.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View.Text += "Waiting for a connection...\n";
            bool isValidIp = IPAddress.TryParse(IP.Text, out IPAddress ip);
            if (!isValidIp)
            {
                MessageBox.Show("IP không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int port = Convert.ToInt32(Port.Text);
            if (port < 0 || port > 65535)
            {
                MessageBox.Show("Port không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            View.Text += "Connected!\n";
            ep = new IPEndPoint(ip, port);
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }
    }
}
