using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab4_Bai1 form1 = new Lab4_Bai1();
            form1.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Lab4_Bai2 form2 = new Lab4_Bai2();
            form2.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Lab4_Bai3 form3 = new Lab4_Bai3();
            form3.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Lab4_Bai4 form4 = new Lab4_Bai4();
            form4.ShowDialog();
        }
    }
}
