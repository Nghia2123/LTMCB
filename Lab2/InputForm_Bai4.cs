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
    public partial class InputForm_Bai4 : Form
    {
        public InputForm_Bai4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\\Nam_2\\LTMCB\\test\\input.txt";
            string info = Hoten.Text + ";" + Hoten.Text + ";" + Sdt.Text + ";" + mathScore.Text + ";" + vanScore.Text + "\n";
            try
            {

                using (FileStream fs = new FileStream(filePath, FileMode.Append))
                {
                    byte[] ct = Encoding.UTF8.GetBytes(info);
                    Console.WriteLine(ct);
                    fs.Write(ct, 0, ct.Length);
                    MessageBox.Show("Nhập thành công");
                }
            }
            catch
            {
                MessageBox.Show("Nhập không thành công");
            }
        }
    }
}
