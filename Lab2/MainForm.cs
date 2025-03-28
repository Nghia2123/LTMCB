using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Lab2_Bai2 form2 = new Lab2_Bai2();
            form2.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Lab2_Bai3 form3 = new Lab2_Bai3();
            form3.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Lab2_Bai5 form5 = new Lab2_Bai5();
            form5.ShowDialog();
        }
    }
}
