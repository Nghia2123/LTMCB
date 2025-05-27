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

namespace _23521005_23521018_23521802_BAI2
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }
        void StartUnsafeThread()
        {
            Socket clientSocket=null;
            Socket listenerSocket = null;

            try
            {

                int bytesReceived = 0;
                // Khởi tạo mảng byte nhận dữ liệu
                byte[] recv = new byte[1024];
                // Tạo socket bên gửi
                // Tạo socket bên nhận, socket này là socket lắng nghe các kết nối tới nó tại địa chỉ IP của máy và port 8080.Đây là 1 TCP / IP socket.
                //AddressFamily: Với địa chỉ Ipv4 cần chọn AddressFamily.InterNetwork
                //SocketType: kiểu kết nối socket, ở đây dùng luồng Stream để nhận dữ liệu
                listenerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
                string strPort = "";
                TextBox_Port.Invoke(new Action(() => strPort = TextBox_Port.Text));
                string strIP = "";
                TextBoxIP.Invoke(new Action(() => strIP = TextBoxIP.Text));

                if (!IPAddress.TryParse(strIP, out IPAddress serverIP))
                {
                    MessageBox.Show("IP Address không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxIP.Clear();
                    return;
                }
                if (!int.TryParse(strPort, out int serverPort) || serverPort <= 0 || serverPort > 65535)
                {
                    MessageBox.Show("Port không hợp lệ! (Giá trị hợp lệ: 1 -> 65535)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBox_Port.Clear();
                    return;
                }
                IPEndPoint ipepServer = new IPEndPoint(serverIP, serverPort);
                // Gán socket lắng nghe tới địa chỉ IP của máy và port 8080
                listenerSocket.Bind(ipepServer);
                // bắt đầu lắng nghe. Socket.Listen(int backlog)
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listenerSocket.Listen(-1);
                //Đồng ý kết nối
                clientSocket = listenerSocket.Accept();
                //Nhận dữ liệu
                MessageBox.Show("Nhận dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //listView.Items.Add(new ListViewItem("New client"));
                RecMessBox.AppendText("Connected to new client:\n");
                while (clientSocket.Connected)
                {
                    //string text = "";
                    //do
                    //{
                    //    bytesReceived = clientSocket.Receive(recv);
                    //    text += Encoding.UTF8.GetString(recv);
                    //} while (text[text.Length - 1] != '\n');
                    //RecMessBox.AppendText(text);

                    bytesReceived = clientSocket.Receive(recv);
                    if (bytesReceived == 0) break;

                    string text = Encoding.UTF8.GetString(recv, 0, bytesReceived); // DÙng powershell UTF8

                    // Cập nhật giao diện trong luồng chính
                    RecMessBox.AppendText(text);
                }
                //listenerSocket.Close();
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionReset ||
                ex.SocketErrorCode == SocketError.Shutdown ||
                ex.SocketErrorCode == SocketError.Disconnecting)
                {
                    // Client đóng kết nối bất ngờ
                    RecMessBox.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Client đã ngắt kết nối đột ngột!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecMessBox.AppendText("Client đã ngắt kết nối.\n");
                    }));
                }
                else if (listenerSocket != null)
                {
                    MessageBox.Show("Trạng thái listen đang được bật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void StartListen(object sender, EventArgs e)
        {
            //Xử lý lỗi InvalidOperationException
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        private void buttonLis_Click(object sender, EventArgs e)
        {
            StartListen(sender, e);

        }
    }
}
