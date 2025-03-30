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
    public partial class Lab2_Bai2 : Form
    {
        public Lab2_Bai2()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {

        }

        private void readButton_Click(object sender, EventArgs e) {
            readFileDialog.RestoreDirectory = true;
            readFileDialog.Filter = "txt files (*.txt)|*.txt";

            string path = "";
            string name = "";

            if (readFileDialog.ShowDialog() == DialogResult.OK) {
                path = readFileDialog.FileName;
                name = readFileDialog.SafeFileName;
            }
            fileNameBox.Text = name;
            fileUrlBox.Text = path;

            if (path == "") { return; }

            FileStream data = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(data);
            var content = reader.ReadToEnd();
            contentTextBox.Text = content;
            content = content.Replace("\r\n", "\n").Replace("  ", " ");

            var lines = content.Split('\n');
            fileLineBox.Text = lines.Length.ToString();
            fileCharBox.Text = content.Length.ToString();

            Int32 countWord = 0;
            foreach (var line in lines) {
                var words = line.Split(' ');
                foreach (var word in words)
                    if (word.Length > 0) {
                        if (word.Any(char.IsLetter) || word.Any(char.IsDigit)) {
                            countWord++;
                        }
                    }
            }

            fileWordBox.Text = countWord.ToString();

            reader.Close();
            data.Close();
        }
    }
}
