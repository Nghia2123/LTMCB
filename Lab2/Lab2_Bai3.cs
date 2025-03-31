using OfficeOpenXml.ConditionalFormatting.Contracts;
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
    public partial class Lab2_Bai3 : Form
    {
        private string[] bieuThucs = null;
        private string[] ketQua = null;
        public Lab2_Bai3()
        {
            InitializeComponent();
        }

        public bool isBieuThuc(string bieuThuc)
        {
            int countPhep = 0;
            foreach (char c in bieuThuc)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    MessageBox.Show("Input chứa biểu thức không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    countPhep++;
                }
            }

            if (countPhep == 0 || countPhep > 1)
            {
                MessageBox.Show("Input chứa biểu thức không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void calButton_Click(object sender, EventArgs e)
        {
            char[] phepTinh = { '+', '-', '*', '/' };
            ketQua = new string[bieuThucs.Length];

            for (int i = 0; i < bieuThucs.Length; i++)
            {
                bieuThucs[i] = bieuThucs[i].Replace(" ", "").Replace("\n", "");

                if (bieuThucs[i] == "")
                {
                    continue;
                }

                if (!isBieuThuc(bieuThucs[i]))
                {
                    return;
                }

                foreach (char op in phepTinh)
                {
                    if (!bieuThucs[i].Contains(op))
                    {
                        continue;
                    }

                    string[] bieuThuc = bieuThucs[i].Split(op);
                    try {
                        if (Int32.TryParse(bieuThuc[0], out int num1) && Int32.TryParse(bieuThuc[1], out int num2))
                        {
                            if (op == '+')
                                ketQua[i] = (num1 + num2).ToString();
                            else if (op == '-')
                                ketQua[i] = (num1 - num2).ToString();
                            else if (op == '*')
                                ketQua[i] = (num1 * num2).ToString();
                            else if (op == '/')
                                ketQua[i] = ((float)num1 / num2).ToString();

                            bieuThucs[i] = bieuThucs[i].Replace(op.ToString(), " " + op.ToString() + " ");
                            break;
                        }
                    }
                    catch (Exception) 
                    {  
                        MessageBox.Show("Input chứa biểu thức không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Hien thi ket qua o outputRichText
            outputRichText.Text = "";
            for (int i = 0; i < ketQua.Length; i++)
            {
                outputRichText.Text += bieuThucs[i] + " = " + ketQua[i] + "\n";
            }

            MessageBox.Show("Tính toán thành công");
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            string fileName = "";

            bieuThucs = null;
            ketQua = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }

            try
            {
                if (fileName == "")
                {
                    return;
                }
                inputRichText.Text = File.ReadAllText(fileName).Replace("\r", "");
                bieuThucs = inputRichText.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                MessageBox.Show("Đọc file thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Đọc file không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
                string fileName = "";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                }
                if (fileName == "")
                {
                    return;
                }
                File.WriteAllText(fileName, outputRichText.Text);
                MessageBox.Show("Ghi file thành công");

            }
            catch (Exception)
            {
                MessageBox.Show("Ghi file không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
