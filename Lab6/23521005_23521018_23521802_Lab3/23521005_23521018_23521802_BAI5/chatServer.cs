using System;
using System.IO;
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

namespace _23521005_23521018_23521802_BAI5
{
    public partial class chatServer : Form
    {
        private Thread serverThread;
        private bool isRunning = false;
        private List<TcpClient> clients = new List<TcpClient>();
        private IPEndPoint ipepServer;
        private TcpListener listenerSocket;
        private List<Thread> allThreads = new List<Thread>();

        private Dictionary<string, chatRoom> rooms = new Dictionary<string, chatRoom>(); // Danh sách các phòng chat
        private Dictionary<TcpClient, string> clientRooms = new Dictionary<TcpClient, string>(); // Danh sách các client và phòng chat của họ
        private Dictionary<TcpClient, string> clientNames = new Dictionary<TcpClient, string>(); // Danh sách các client và tên của họ


        private string GenerateUniqueRoomId()
        {
            string id;
            Random rnd = new Random();
            do
            {
                id = rnd.Next(1000, 9999).ToString(); // Ví dụ: "3025"
            } while (rooms.ContainsKey(id));
            return id;
        }

        public class chatRoom
        {
            public string roomId { get; set; }
            public List<TcpClient> Clients { get; set; } = new List<TcpClient>();
        }

        public chatServer()
        {
            InitializeComponent();
            StartConnectionChecker(); // Kiểm tra các kết nối tới client liên tục
        }

        // Ngắt kết nối client và xóa client khỏi phòng chat và server
        private void DisconnectClient(TcpClient client)
        {
            string currentRoom = null;
            string remoteEndPoint = "";

            try
            {
                // Lưu lại địa chỉ IP trước khi socket bị đóng
                if (client != null && client.Client != null && client.Client.Connected)
                {
                    remoteEndPoint = client.Client.RemoteEndPoint.ToString();
                }
            }
            catch { }

            lock (clientRooms)
            {
                clientRooms.TryGetValue(client, out currentRoom);
                clientRooms.Remove(client);
            }

            if (currentRoom != null)
            {
                lock (rooms)
                {
                    if (rooms.ContainsKey(currentRoom))
                    {
                        rooms[currentRoom].Clients.Remove(client);

                        foreach (TcpClient c in rooms[currentRoom].Clients)
                        {
                            SendMessageToClient(c, "Client disconnected");
                        }

                        if (rooms[currentRoom].Clients.Count == 0)
                        {
                            rooms.Remove(currentRoom);
                        }
                    }
                }
            }

            lock (clients)
            {
                clients.Remove(client);
            }

            lock (clientNames)
            {
                clientNames.Remove(client);
            }

            connectTextBox.Invoke(new Action(() =>
            {
                connectTextBox.AppendText(remoteEndPoint + " client disconnected\n");
            }));

            // Đóng sau cùng
            client.Close();
        }

        // Kiểm tra kết nối của client
        private bool IsClientConnected(TcpClient client)
        {
           
            Socket s = client.Client;
            if (s == null)
                return true;
            return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)));
        }

        // Hàm check các client đã ngắt kết nối hay chưa
        private void checkClientConnection()
        {
            List<TcpClient> disconnectedClients = new List<TcpClient>();

            foreach (TcpClient client in clients) 
            {
                try
                {
                    if (!IsClientConnected(client))
                    {
                        disconnectedClients.Add(client); 
                    }
                }
                catch
                {
                    disconnectedClients.Add(client);
                }
            }

            foreach (TcpClient client in disconnectedClients)
            {
                DisconnectClient(client); 
            }
        }

        // Tạo thread kiểm tra kết nối của các client mỗi 5 giây
        private void StartConnectionChecker()
        {
            Thread checker = new Thread(() =>
            {
                while (true)
                {
                    checkClientConnection();
                    Thread.Sleep(5000); 
                }
            });

            checker.IsBackground = true; 
            checker.Start();
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
                    string text = Encoding.UTF8.GetString(recv, 0, bytesReceived).Trim();
                    string[] parts = text.Split(' ');

                    if (text.StartsWith("[LOGIN]") || text.StartsWith("[REGISTER]"))
                    {
                        HandleLoginRegister(client, text);
                        break;
                    }

                    if (parts[0] == "/createroom" && parts.Length == 1)
                    {
                        if (clientRooms.ContainsKey(client))
                        {
                            return;
                        }

                        string roomId = GenerateUniqueRoomId();
                        lock (rooms)
                        {
                            if (!rooms.ContainsKey(roomId))
                            {
                                chatRoom newRoom = new chatRoom { roomId = roomId };
                                newRoom.Clients.Add(client);
                                rooms[roomId] = newRoom;
                                clientRooms[client] = roomId;

                                SendMessageToClient(client, "Room created: " + roomId);
                                connectTextBox.Invoke(new Action(() =>
                                {
                                    connectTextBox.AppendText(clientEndPoint + ": Room created: " + roomId + "\n");
                                }));
                            }
                            else
                            {
                                SendMessageToClient(client, "Room already exists: " + roomId);
                            }
                        }
                    }
                    else if (parts[0] == "/joinroom" && parts.Length > 1)
                    {
                        string roomId = parts[1];
                        string user = parts[2];
                        lock (rooms)
                        {
                            if (rooms.ContainsKey(roomId))
                            {
                                if (rooms[roomId].Clients.Contains(client))
                                {
                                    SendMessageToClient(client, "You are already in this room: " + roomId);
                                    continue;
                                }
                                else if (clientRooms.ContainsKey(client))
                                {
                                    string currentRoom = clientRooms[client];
                                    if (rooms.ContainsKey(currentRoom))
                                    {
                                        foreach (TcpClient c in rooms[currentRoom].Clients)
                                        {
                                            SendMessageToClient(c, user + " left the room");
                                        }
                                        rooms[currentRoom].Clients.Remove(client);
                                        if (rooms[currentRoom].Clients.Count == 0)
                                        {
                                            rooms.Remove(currentRoom);
                                        }      
                                    }
                                }
                                rooms[roomId].Clients.Add(client);
                                clientRooms[client] = roomId;
                                SendMessageToClient(client, "Joined room: " + roomId);
                                connectTextBox.Invoke(new Action(() =>
                                {
                                    connectTextBox.AppendText(clientEndPoint + ": Joined room: " + roomId + "\n");
                                }));

                                foreach (TcpClient c in rooms[roomId].Clients)
                                {
                                    if (c != client)
                                    {
                                        SendMessageToClient(c, user + " joined the room");
                                    }
                                }
                            }
                            else
                            {
                                SendMessageToClient(client, "Room does not exist: " + roomId);
                            }
                        }
                    }
                    else if (parts[0] == "/leaveroom" && parts.Length > 1)
                    {
                        string currentRoom = null;
                        string user = parts[1];

                        lock (clientRooms)
                        {
                            clientRooms.TryGetValue(client, out currentRoom);
                        }

                        if (currentRoom != null)
                        {
                            lock (rooms)
                            {
                                if (rooms.ContainsKey(currentRoom))
                                {
                                    rooms[currentRoom].Clients.Remove(client);

                                    if (rooms[currentRoom].Clients.Count > 0)
                                    {
                                        foreach (TcpClient c in rooms[currentRoom].Clients)
                                        {
                                            SendMessageToClient(c, user + " left the room");
                                        }
                                    }
                                    else
                                    {
                                        rooms.Remove(currentRoom); // Chỉ xóa sau khi thông báo xong
                                    }
                                }
                                else
                                {
                                    SendMessageToClient(client, "Room does not exist");
                                    return;
                                }
                            }

                            lock (clientRooms)
                            {
                                clientRooms.Remove(client);
                            }

                            SendMessageToClient(client, "Left room: " + currentRoom);
                            connectTextBox.Invoke(new Action(() =>
                            {
                                connectTextBox.AppendText(clientEndPoint + ": Left room: " + currentRoom + "\n");
                            }));
                        }
                        else
                        {
                            SendMessageToClient(client, "You are not in any room");
                        }
                    }
                    else
                    {
                        string currentRoom = null;
                        string user = parts[0].Replace(":", "");
                        lock (clientRooms)
                        {
                            clientRooms.TryGetValue(client, out currentRoom);
                        }

                        if (currentRoom != null && rooms.ContainsKey(currentRoom))
                        {
                            connectTextBox.Invoke(new Action(() =>
                            {
                                connectTextBox.AppendText(user + ": " + client.Client.RemoteEndPoint + " (" + currentRoom + "): Sent a message\n");
                            }));
                            lock (rooms) 
                            {
                                foreach (TcpClient c in rooms[currentRoom].Clients)
                                {
                                    try
                                    {
                                        SendMessageToClient(c, text);
                                        connectTextBox.Invoke(new Action(() =>
                                        {
                                            connectTextBox.AppendText(c.Client.RemoteEndPoint + ": received messsage in " + currentRoom + "\n");
                                        }));
                                    }
                                    catch
                                    {
                                        connectTextBox.Invoke(new Action(() =>
                                        {
                                            connectTextBox.AppendText($"Error sending message to client {c.Client.RemoteEndPoint}\n");
                                        }));
                                        continue;
                                    }
                                }
                            }
                           
                        }
                        else
                        {
                            SendMessageToClient(client, "You are not in any room");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Error Receive Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket = new TcpListener(ipepServer);

            if (serverThread == null || !serverThread.IsAlive) // Chỉ chạy nếu chưa có thread
            {
                //CheckForIllegalCrossThreadCalls = false; // (Không khuyến khích, nhưng tạm chấp nhận)
                isRunning = true; // Đánh dấu trạng thái chạy
                serverThread = new Thread(new ThreadStart(StartListen));
                serverThread.IsBackground = true; // Đảm bảo thread tự đóng khi app thoát
                serverThread.Start();
            }
        }

        private string accountsFile = "accounts.txt";

        private bool IsAccountExist(string username)
        {
            if (!File.Exists(accountsFile))
            {
                return false;
            }

            var lines = File.ReadAllLines(accountsFile);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 2 && parts[0] == username)
                    return true;
            }
            return false;
        }

        private bool IsValidAccount(string username, string password)
        {
            if (!File.Exists(accountsFile))
                return false;

            var lines = File.ReadAllLines(accountsFile);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 2 && parts[0] == username && parts[1] == password)
                    return true;
            }
            return false;
        }
        private void HandleLoginRegister(TcpClient client, string text)
        {
            var parts = text.Split('|');

            if (parts.Length >= 3)
            {
                var command = parts[0];
                var username = parts[1];
                var password = parts[2];

                if (command == "[LOGIN]")
                {
                    if (IsValidAccount(username, password))
                    {
                        SendMessageToClient(client, "[LOGIN_SUCCESS]|Login success!");
                        clientNames[client] = username; // Lưu tên người dùng vào danh sách
                    }
                    else
                        SendMessageToClient(client, "[LOGIN_FAIL]|Invalid username or password.");
                }
                else if (command == "[REGISTER]")
                {
                    if (IsAccountExist(username))
                        SendMessageToClient(client, "[REGISTER_FAIL]|Username already exists.");
                    else
                    {
                        File.AppendAllText(accountsFile, username + "|" + password + Environment.NewLine);
                        SendMessageToClient(client, "[REGISTER_SUCCESS]|Register success!");

                        connectTextBox.Invoke(new Action(() =>
                        {
                            connectTextBox.AppendText("New user was created\n");
                        }));
                    }
                }
            }
        }
    }
}
