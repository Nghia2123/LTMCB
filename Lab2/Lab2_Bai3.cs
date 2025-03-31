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

                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    countPhep++;
                    continue;
                }

                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || Char.IsPunctuation(c) || Char.IsSymbol(c))
                {
                    return false;
                }
                
            }

            if (countPhep == 0 || countPhep > 1)
            {
                return false;
            }

            return true;
        }

        private void calButton_Click(object sender, EventArgs e)
        {
            char[] phepTinh = { '+', '-', '*', '/' };
            ketQua = new string[bieuThucs.Length];
            bool[] bieuThucLoi = new bool[bieuThucs.Length];

            for (int i = 0; i < bieuThucs.Length; i++)
            {
                bieuThucs[i] = bieuThucs[i].Replace(" ", "").Replace("\n", "");

                if (bieuThucs[i] == "")
                {
                    continue;
                }

                if (!isBieuThuc(bieuThucs[i]))
                {
                    bieuThucLoi[i] = true;
                    continue;
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
                    catch (Exception err) 
                    {  
                        MessageBox.Show("Lỗi: " + err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Hien thi ket qua o outputRichText
            outputRichText.Text = "";
            string loi = "Biểu thức ";
            for (int i = 0; i < ketQua.Length; i++)
            {
                if (bieuThucLoi[i])
                {
                    loi += (i + 1) + ", ";
                    continue;
                }

                outputRichText.Text += bieuThucs[i] + " = " + ketQua[i] + "\n";
            }

            if (bieuThucLoi.Contains(true))
            {   
                loi = loi.Substring(0, loi.Length - 2);
                loi += " không hợp lệ";
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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
