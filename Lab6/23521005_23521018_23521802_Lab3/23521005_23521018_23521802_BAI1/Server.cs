using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23521005_23521018_23521802_BAI1
{
    public partial class Server : Form
    {
        private bool isRunning = false;
        private Socket serverSocket;
        private IPEndPoint latestClientEP = null;
        public void connect()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                string strPort = "";
                richTextBox1.Invoke(new Action(() => strPort = richTextBox1.Text));

                if (!int.TryParse(strPort, out int serverPort) || serverPort <= 0 || serverPort > 65535)
                {
                    MessageBox.Show("Port không hợp lệ! (Giá trị hợp lệ: 1 -> 65535)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTextBox1.Clear();
                    return;
                }

                int port = Convert.ToInt32(Invoke(new Func<string>(() => richTextBox1.Text)));


                //serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint localEP = new IPEndPoint(IPAddress.Any, port);
                serverSocket.Bind(localEP);

                isRunning = true;
                MessageBox.Show($"Server đang lắng nghe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public Server()
        {
            InitializeComponent();
        }

        public void InfoMessage(List<string> mess)
        {
            if (richTextBox2.InvokeRequired)
            {
                richTextBox2.Invoke(new Action(() =>
                {
                    richTextBox2.Text = string.Join(Environment.NewLine, mess);
                    MessageBox.Show("Gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            else
            {
                richTextBox2.Text = string.Join(Environment.NewLine, mess);
                MessageBox.Show("Gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void serverThread()
        {
            if (!isRunning)
            {
                connect();
            }
            List<string> messages = new List<string>();

            //isRunning = true;
            while (isRunning)
            {
                byte[] buffer = new byte[1024];
                EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                try
                {

                    if (remoteEP == null)
                    {
                        MessageBox.Show("remoteEP nhận được giá trị null!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int received = serverSocket.ReceiveFrom(buffer, ref remoteEP);
                    string data = Encoding.UTF8.GetString(buffer, 0, received);
                    latestClientEP = (IPEndPoint)remoteEP;//cập nhật IP để lắng nghe thông điee[j từ server


                    string messIP = $"Connected from {((IPEndPoint)remoteEP).Address}";
                    string mess = $"{((IPEndPoint)remoteEP).Address}:{((IPEndPoint)remoteEP).Port}: {data}";
                    mess = messIP + Environment.NewLine + mess + Environment.NewLine;

                    messages.Add(mess);
                     InfoMessage(messages);

                }
                catch (SocketException)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show("Đã bị ngắt kết nối!", "Thông báo từ sever", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => serverThread());
        }



        
        
    }
}
