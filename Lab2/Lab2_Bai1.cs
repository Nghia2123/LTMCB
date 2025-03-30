using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Lab2_Bai1 : Form
    {
        public Lab2_Bai1()
        {
            InitializeComponent();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string filePath = ofd.FileName;

            StreamReader sr = new StreamReader(filePath); // Tự động đóng file sau khi đọc
            richTextBox1.Clear();
            richTextBox1.Text = sr.ReadToEnd();
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text (*.txt)|*.txt";
            sfd.ShowDialog();
            using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
            {
                byte[] ct = Encoding.UTF8.GetBytes(richTextBox1.Text.Trim());
                fs.Write(ct, 0, ct.Length);
            }                
           
        }
    }
}
