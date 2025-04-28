using CefSharp.DevTools.Network;
using CefSharp.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Lab4_Bai3 : Form
    {
        private static HttpClient sharedClient = new HttpClient
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
        };

        private static async Task<string> GetAsync(HttpClient httpClient, string url)
        {
            HttpResponseMessage response = null;

            using (response = await httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }

        }

        public Lab4_Bai3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Bounds = Screen.PrimaryScreen.WorkingArea;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            dataGridView1.Dock = DockStyle.Fill; 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            dataGridView1.ReadOnly = true; 
            dataGridView1.AllowUserToAddRows = false; 
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dataGridView1.MultiSelect = false; 
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string jsonResponse = await GetAsync(sharedClient, "/comments");
            var comments = JsonSerializer.Deserialize<List<Comment>>(jsonResponse);
            var first100Comments = comments.Take(100).ToList();

            dataGridView1.DataSource = first100Comments;

            dataGridView1.Columns["body"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["body"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void Lab4_Bai3_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Comment
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
}
