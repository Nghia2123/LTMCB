using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23521005_23521018_23521802_BAI5
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
            Login login = new Login();
            login.Show();
        }
    }
}
