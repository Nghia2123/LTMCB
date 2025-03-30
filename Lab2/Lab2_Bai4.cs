using OfficeOpenXml;
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
    public partial class Lab2_Bai4 : Form
    {
        public Lab2_Bai4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputForm_Lab2_Bai4 inputForm = new InputForm_Lab2_Bai4();
            inputForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string fileIn = @"../input.txt";
            string fileOut = @"../output.xlsx";
            string absolutePath = Path.GetFullPath(fileOut);


            FileStream fs;

            try
            {
                fs = new FileStream(fileIn, FileMode.Open);
            }
            catch
            {
                MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells[1, 1].Value = "MSSV";
                    worksheet.Cells[1, 2].Value = "Ho ten";
                    worksheet.Cells[1, 3].Value = "SDT";
                    worksheet.Cells[1, 4].Value = "Toan";
                    worksheet.Cells[1, 5].Value = "Van";
                    worksheet.Cells[1, 6].Value = "TB";



                    int i = 1;
                    while (!sr.EndOfStream)  // Kiểm tra còn dòng để đọc không
                    {
                        i++;
                        string context = sr.ReadLine();  // Đọc từng dòng
                        var data = context.Trim().Split(';');  // Tách dữ liệu theo dấu `;`
                        Console.WriteLine($"data: {data}");

                        if (data.Length >= 5)  // Đảm bảo dữ liệu đủ phần tử để tránh lỗi
                        {
                            int diemtoan, diemvan;
                            bool check1 = Int32.TryParse(data[3], out diemtoan);
                            Console.WriteLine($"data[4]: '{data[4]}' (Length: {data[4].Length})");
                            bool check2 = Int32.TryParse(data[4], out diemvan);

                            if (check1 && check2)
                            {
                                double tb = (diemtoan + diemvan) / 2.0;
                                worksheet.Cells[i, 1].Value = data[0];
                                worksheet.Cells[i, 2].Value = data[1];
                                worksheet.Cells[i, 3].Value = data[2];
                                worksheet.Cells[i, 4].Value = data[3];
                                worksheet.Cells[i, 5].Value = data[4];
                                worksheet.Cells[i, 6].Value = tb;
                                Console.WriteLine($"Toán: {diemtoan}, Văn: {diemvan}, Trung bình: {tb}");
                            }
                            else
                            {
                                Console.WriteLine("Lỗi chuyển đổi điểm số.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Dữ liệu không hợp lệ.");
                        }

                    }
                    worksheet.Cells.AutoFitColumns(); // Căn chỉnh cột tự động
                    package.SaveAs(new FileInfo(fileOut));
                }
            }

            MessageBox.Show("Ghi file Excel thành công! " +
                $"File được lưu tại {absolutePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddColumnIfNotExists(string columnName, string headerText)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name == columnName)
                {
                    return;
                }
            }
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = columnName, HeaderText = headerText });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddColumnIfNotExists("ID", "ID");
            AddColumnIfNotExists("name", "Họ Tên");
            AddColumnIfNotExists("class", "Lớp");
            AddColumnIfNotExists("math", "Toán");
            AddColumnIfNotExists("van", "Văn");
            AddColumnIfNotExists("tb", "Trung Bình");

            string fileIn = @"../input.txt";
            FileStream fs;
            try
            {
                fs = new FileStream(fileIn, FileMode.Open);
            }
            catch
            {
                MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                int i = 1;
                while (!sr.EndOfStream)  // Kiểm tra còn dòng để đọc không
                {
                    i++;
                    string context = sr.ReadLine();  // Đọc từng dòng
                    var data = context.Trim().Split(';');  // Tách dữ liệu theo dấu `;`
                    Console.WriteLine($"data: {data}");

                    if (data.Length >= 5)  // Đảm bảo dữ liệu đủ phần tử để tránh lỗi
                    {
                        int diemtoan, diemvan;
                        bool check1 = Int32.TryParse(data[3], out diemtoan);
                        bool check2 = Int32.TryParse(data[4], out diemvan);

                        if (check1 && check2)
                        {
                            double tb = (diemtoan + diemvan) / 2.0;
                            dataGridView1.Rows.Add(data[0], data[1], data[2], data[3], data[4], tb);
                            Console.WriteLine($"Toán: {diemtoan}, Văn: {diemvan}, Trung bình: {tb}");
                        }
                        else
                        {
                            Console.WriteLine("Lỗi chuyển đổi điểm số.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dữ liệu không hợp lệ.");
                    }

                }
            }
        }
    }



}
