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

namespace _23521005_23521018_23521802_BAI4
{
    public partial class chatServer : Form
    {
        private Thread serverThread;
        private bool isRunning = false;
        private List<TcpClient> clients = new List<TcpClient>();
        private IPEndPoint ipepServer;
        private TcpListener listenerSocket;

        public chatServer()
        {
            InitializeComponent();
            ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket = new TcpListener(ipepServer);
        }

        private void SendMessageToClient(TcpClient client, string message)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(message);
                ns.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Error Send Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendMessageToAllClients(string message)
        {
            lock(clients)
            {
                foreach (TcpClient client in clients)
                {
                    SendMessageToClient(client, message);
                }
            }
        }

        private void RecieveData(object clientSocket)
        {
            TcpClient client = (TcpClient)clientSocket; // Cast the object to Socket
            IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            try
            {
                byte[] recv = new byte[1024];
                int bytesReceived = 0;
                while (true)
                {
                    bytesReceived = client.Client.Receive(recv); // Use the casted socket
                    if (bytesReceived == 0)
                    {
                        break;
                    }
                    string text = Encoding.UTF8.GetString(recv, 0, bytesReceived);
                    connectTextBox.Invoke(new Action(() =>
                    {
                        connectTextBox.AppendText(clientEndPoint + ": " + text + "\n");
                        SendMessageToAllClients(text);
                    }));
                }
            }
            catch (Exception)
            {
                connectTextBox.Invoke(new Action(() =>
                {
                    connectTextBox.AppendText("Client disconnected\n");
                }));
            }
            finally
            {
                lock (clients)
                {
                    clients.Remove(client);
                }
                client.Close();
            }
        }

        private void AcceptClient()
        {
            while (true)
            {
                try
                {
                    TcpClient client = listenerSocket.AcceptTcpClient();
                    IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;

                    lock (clients)
                    {
                        clients.Add(client);
                    }

                    connectTextBox.Invoke(new Action(() =>
                    {
                        connectTextBox.AppendText($"New client connected from: {clientEndPoint}\n");
                    }));

                    Thread clientThread = new Thread(() => RecieveData(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Server Error Accept Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StartListen()
        {
            try
            {

                listenerSocket.Start();

                connectTextBox.Invoke(new Action(() =>
                {
                    connectTextBox.Text = "Server is listening...\n";
                }));

                Thread listenThread = new Thread(AcceptClient);
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Error Start Listening", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                connectTextBox.AppendText("Server is already running...\n");
                return;
            }
      
            if (serverThread == null || !serverThread.IsAlive) // Chỉ chạy nếu chưa có thread
            {
                //CheckForIllegalCrossThreadCalls = false; // (Không khuyến khích, nhưng tạm chấp nhận)
                isRunning = true; // Đánh dấu trạng thái chạy
                serverThread = new Thread(new ThreadStart(StartListen));
                serverThread.IsBackground = true; // Đảm bảo thread tự đóng khi app thoát
                serverThread.Start();
            }
        }
    }
}
