using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23521005_23521018_23521802_BAI1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private Server serverrr = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (serverrr == null || serverrr.IsDisposed)
            {
                serverrr = new Server();
                serverrr.Show();
            }
            else
            {
                MessageBox.Show("Server đã được mở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                serverrr.BringToFront();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private Client clienttt = null;
        private void client_Click(object sender, EventArgs e)
        {
            if (clienttt == null || clienttt.IsDisposed)
            {
                clienttt = new Client();
                clienttt.Show();
            }
            else
            {
                MessageBox.Show("Client đã được mở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clienttt.BringToFront();
            }
        }
    }
}
