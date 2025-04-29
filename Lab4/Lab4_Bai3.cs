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

        private static HttpClient myAPIClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:39192"),
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
            //this.MaximizeBox = false;
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

        private void Lab4_Bai3_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ResetDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

        private async void getCommentButton_Click(object sender, EventArgs e)
        {
            string jsonResponse = await GetAsync(sharedClient, "/comments");
            var comments = JsonSerializer.Deserialize<List<Comment>>(jsonResponse);
            var first100Comments = comments.Take(100).ToList();

            ResetDataGridView();

            dataGridView1.DataSource = first100Comments;

            dataGridView1.Columns["postId"].HeaderText = "Post ID";
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["name"].HeaderText = "Name";
            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["body"].HeaderText = "Content";

            dataGridView1.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["postId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns["id"].Width = 100;
            dataGridView1.Columns["postId"].Width = 100;

            dataGridView1.Columns["body"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["body"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private async void getPhotoButton_Click(object sender, EventArgs e)
        {
            string jsonResponse = await GetAsync(sharedClient, "/photos");
            var photos = JsonSerializer.Deserialize<List<Photo>>(jsonResponse);
            var first100Photos = photos.Take(100).ToList();

            ResetDataGridView();

            dataGridView1.DataSource = first100Photos;

            dataGridView1.Columns["title"].HeaderText = "Title";
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["albumId"].HeaderText = "Album ID";
            dataGridView1.Columns["url"].HeaderText = "URL";
            dataGridView1.Columns["thumbnailUrl"].HeaderText = "Thumbnail URL";

            dataGridView1.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["albumId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns["id"].Width = 100;
            dataGridView1.Columns["albumId"].Width = 100;

            dataGridView1.Columns["title"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["url"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["url"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["thumbnailUrl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["thumbnailUrl"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private async void getUserButton_Click(object sender, EventArgs e)
        {
            string jsonResponse = await GetAsync(sharedClient, "/users");
            var users = JsonSerializer.Deserialize<List<User>>(jsonResponse);

            ResetDataGridView();

            var userList = users.Select(u => new
            {
                Id = u.id,
                Name = u.name,
                Username = u.username,
                Email = u.email,
                Address = $"{u.address.street}, {u.address.suite}, {u.address.city}, {u.address.zipcode}",
                Phone = u.phone,
                Website = u.website,
                Company = $"{u.company.name} - \"{u.company.catchPhrase}\" ({u.company.bs})"
            }).ToList();

            dataGridView1.DataSource = userList;

            dataGridView1.Columns["Id"].HeaderText = "ID";
            dataGridView1.Columns["Name"].HeaderText = "Name";
            dataGridView1.Columns["Username"].HeaderText = "Username";
            dataGridView1.Columns["Email"].HeaderText = "Email";
            dataGridView1.Columns["Address"].HeaderText = "Address";
            dataGridView1.Columns["Phone"].HeaderText = "Phone";
            dataGridView1.Columns["Website"].HeaderText = "Website";
            dataGridView1.Columns["Company"].HeaderText = "Company";

            dataGridView1.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Id"].Width = 30;
            dataGridView1.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Username"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Email"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Phone"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns["Website"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Website"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            dataGridView1.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Address"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns["Company"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Company"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private async void productAPIButton_Click(object sender, EventArgs e)
        {
            string jsonResponse = await GetAsync(myAPIClient, "/api/products");
            var products = JsonSerializer.Deserialize<List<Product>>(jsonResponse);

            ResetDataGridView();

            dataGridView1.DataSource = products;

            dataGridView1.Columns["Id"].HeaderText = "ID";
            dataGridView1.Columns["Name"].HeaderText = "Name";
            dataGridView1.Columns["Category"].HeaderText = "Category";
            dataGridView1.Columns["Price"].HeaderText = "Price";

            dataGridView1.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Id"].Width = 30;
            dataGridView1.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["Category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Category"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Price"].Width = 100;
            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "C2"; // Format as currency
            dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

    public class Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }

    public class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
