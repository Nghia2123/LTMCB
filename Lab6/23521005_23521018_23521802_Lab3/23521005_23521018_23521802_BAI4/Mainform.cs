using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23521005_23521018_23521802_BAI4
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private chatServer server = null;
        private void serverButton_Click(object sender, EventArgs e)
        {
            if (server == null || server.IsDisposed)
            {
                server = new chatServer();
                server.Show();
            }
            else
            {
                server.BringToFront();
            }
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new System.Net.Sockets.TcpClient())
                {
                    var result = client.BeginConnect("127.0.0.1", 8080, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(500));

                    if (!success)
                    {
                        MessageBox.Show("Server is not running. Please start the server first.");
                        return;
                    }

                    client.EndConnect(result);
                }

                chatClient clientForm = new chatClient();
                clientForm.Show();
            }
            catch
            {
                MessageBox.Show("Cannot connect to server. Please start the server first.");
            }
        }
    }
}
