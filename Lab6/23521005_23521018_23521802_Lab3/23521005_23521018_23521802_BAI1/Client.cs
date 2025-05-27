using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23521005_23521018_23521802_BAI1
{
    public partial class Client : Form
    {
        private UdpClient udpClient;
        private bool isRunning = false;

        public Client()
        {
            InitializeComponent();

        }
        private async Task ReceiveMessagesAsync()
        {
            while (isRunning)
            {
                try
                {
                    UdpReceiveResult result = await udpClient.ReceiveAsync();
                    string receivedMessage = Encoding.UTF8.GetString(result.Buffer);

                    IPEndPoint senderEP = result.RemoteEndPoint;
                    string senderInfo = $"{senderEP.Address}:{senderEP.Port}";

                    richTextBox1.Invoke(new Action(() =>
                    {
                        richTextBox1.AppendText($"Received from {senderInfo}:  {Environment.NewLine}{receivedMessage} {Environment.NewLine}");
                    }));
                }
                catch (ObjectDisposedException)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show("Đã bị ngắt kết nối!", "Thông báo từ client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                string strPort = "";
                richTextBox3.Invoke(new Action(() => strPort = richTextBox3.Text));
                string strIP = "";
                richTextBox2.Invoke(new Action(() => strIP = richTextBox2.Text));

                if (!IPAddress.TryParse(strIP, out IPAddress serverIP))
                {
                    MessageBox.Show("IP Address không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTextBox2.Clear();
                    return;
                }
                if (!int.TryParse(strPort, out int serverPort) || serverPort <= 0 || serverPort > 65535)
                {
                    MessageBox.Show("Port không hợp lệ! (Giá trị hợp lệ: 1 -> 65535)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTextBox3.Clear();
                    return;
                }

                if (udpClient == null)
                {
                    udpClient = new UdpClient();
                    isRunning = true;
                    Task.Run(() => ReceiveMessagesAsync());
                }

                IPEndPoint ipend = new IPEndPoint(serverIP, serverPort);
                Byte[] sendBytes = Encoding.UTF8.GetBytes(richTextBox1.Text);
                udpClient.Send(sendBytes, sendBytes.Length, ipend);
                Console.WriteLine($"Sent to {ipend}: {sendBytes}");

                richTextBox1.Clear();
            }
            catch (ObjectDisposedException) //Hiển thị thông báo jkhi UDP client bị đóng 
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Đã bị ngắt kết nối!", "Thông báo từ client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
        }

        private void closeconnect_Click(object sender, EventArgs e)
        {
            if (udpClient != null)
            {
                udpClient.Close();
                udpClient.Dispose();
                udpClient = null;
                isRunning = false;
                richTextBox1.Clear();
                richTextBox2.Clear();
                richTextBox3.Clear();
                MessageBox.Show("Ngắt kết nối phía client!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }

}
