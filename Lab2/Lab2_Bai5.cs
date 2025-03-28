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
    public partial class Lab2_Bai5 : Form
    {
        private List<string> prePath = new List<string>();
        private ImageList imageList = new ImageList();

        public Lab2_Bai5()
        {
            InitializeComponent();
            setupListView();
        }

        // Khoi tao cac thuoc tinh cua list view
        private void setupListView()
        {
            fileListView.View = View.Details;
            fileListView.FullRowSelect = true;
            fileListView.SmallImageList = imageList;

            fileListView.Columns.Add("Name", 200);
            fileListView.Columns.Add("Creation Date", 150);
            fileListView.Columns.Add("Extension", 100);
            fileListView.Columns.Add("Size", 100);
        }

        private void loadFilesAndFolders(string path)
        {
            DirectoryInfo di = new DirectoryInfo(pathBox.Text);
            DirectoryInfo[] directories = di.GetDirectories();
            FileInfo[] files = di.GetFiles();

            // Xoa danh sach cac item trong list view va image list
            fileListView.Items.Clear();
            imageList.Images.Clear();

            // Liet ke cac folder trong folder hien tai
            foreach (DirectoryInfo directory in directories)
            {
                Icon iconForFile = SystemIcons.WinLogo;
                ListViewItem item = new ListViewItem(directory.Name);
                item.SubItems.Add(directory.CreationTime.ToString());
                item.SubItems.Add("Folder");
                item.SubItems.Add("");

                string folderKey = "folder";
                if (!imageList.Images.ContainsKey(folderKey))
                {
                    iconForFile = SystemIcons.WinLogo;
                    imageList.Images.Add(folderKey, iconForFile);
                }
                item.ImageKey = folderKey;

                fileListView.Items.Add(item);
            }


            // Liet ke cac file trong folder hien tai
            foreach (FileInfo file in files)
            {
                Icon iconForFile = SystemIcons.WinLogo;
                ListViewItem item = new ListViewItem(file.Name);
                item.SubItems.Add(file.CreationTime.ToString());
                item.SubItems.Add(file.Extension);
                item.SubItems.Add((file.Length / 1024).ToString() + " KB");

                if (!imageList.Images.ContainsKey(file.Extension))
                {
                    iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                    imageList.Images.Add(file.Extension, iconForFile.ToBitmap());
                }

                item.ImageKey = file.Extension;

                fileListView.Items.Add(item);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                prePath.Add(pathBox.Text);
                pathBox.Text = folderBrowserDialog.SelectedPath;
            }

            if (pathBox.Text == "")
            {
                return;
            }

            loadFilesAndFolders(pathBox.Text);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (prePath.Last() == "")
            {
                MessageBox.Show("No previous path");
                return;
            }
            pathBox.Text = prePath.Last();
            prePath.RemoveAt(prePath.Count - 1);

            loadFilesAndFolders(pathBox.Text);
        }
    }
}