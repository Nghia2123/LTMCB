using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace BAI3
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        byte[] key = Encoding.UTF8.GetBytes("1a2b3c4d5e6f7g8h");
        byte[] iv = Encoding.UTF8.GetBytes("a1b2c3d4e5f6g7h8");

        TcpClient tcpClient;
        IPEndPoint ep;
        private void button1_Click(object sender, EventArgs e)
        {
            bool isValidIp = IPAddress.TryParse(IP.Text, out IPAddress ip);
            if (!isValidIp) {
                MessageBox.Show("IP không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int port = Convert.ToInt32(Port.Text);
            if (port < 0 || port > 65535) {
                MessageBox.Show("Port không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ep = new IPEndPoint(ip, port);
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(ep);
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SocketException)
            {
                MessageBox.Show("Không thể kết nối tới server. Vui lòng iểm tra IP, Port hoặc đảm bảo rằng server đã nhấn Listen.",
                                "Lỗi kết nối",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tcpClient == null || ep == null) {
                MessageBox.Show("Kết nối trước khi gửi tin nhắn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NetworkStream ns = tcpClient.GetStream();

            Byte[] sendBytes = AesEncryption.Encrypt(Message.Text+'\n', key, iv);

            //Byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes(Message.Text + '\n');
            
            ns.Write(sendBytes, 0, sendBytes.Length);
            View.Text += Message.Text + '\n';
            
            Message.Text = "";
        }
    }
}
