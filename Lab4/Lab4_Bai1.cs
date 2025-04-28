using CefSharp.DevTools.Fetch;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lab4
{
    public partial class Lab4_Bai1 : Form
    {
        private HttpClient _httpClient;
        public Lab4_Bai1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }
        private async void btnFetch_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if(string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a url");
                return;
            }
            try
            {
                await FetchWebsite(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching website: {ex.Message}");
            }
        }
        private async Task FetchWebsite(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Lấy html
            string htmlContent = await response.Content.ReadAsStringAsync();
            richTextBoxHtml.Text = htmlContent;

            dataGridViewHeaders.Rows.Clear();
            dataGridViewHeaders.Columns.Clear();
            dataGridViewHeaders.Columns.Add("Header","Header");
            dataGridViewHeaders.Columns.Add("Value", "Value");
            foreach (var header in response.Headers)
            {
                foreach(var value in header.Value)
                {
                    dataGridViewHeaders.Rows.Add(header.Key,value);
                }
            }
            foreach(var header in response.Content.Headers)
            {
                foreach (var value in header.Value)
                {
                    dataGridViewHeaders.Rows.Add(header.Key, value);
                }
            }
        }
    }
}
