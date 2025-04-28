using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
namespace Lab4
{
    public partial class Lab4_Bai4 : Form
    {
        private HttpClient _httpClient;
        public Lab4_Bai4()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }
        private async void btnGo(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (!url.StartsWith("http"))
            {
                url = "https://" + url;
            }
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.Navigate(url);
        }
        private async void btnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async void btnViewSource(object sender, EventArgs e)
        {
            if(webView.Source == null)
            {
                MessageBox.Show("No html source found");
                return;
            }
            string html = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");
            html = System.Text.Json.JsonSerializer.Deserialize<string>(html); // Remove JSON escaping
            Form sourceForm = new Form { Width = 800, Height = 600 };
            RichTextBox rtb = new RichTextBox { Dock = DockStyle.Fill, Text = html, Multiline = true, ScrollBars = RichTextBoxScrollBars.Both };
            sourceForm.Controls.Add(rtb);
            sourceForm.Show();
        }
        private async void btnSaveHtmlOnly_Click(object sender, EventArgs e)
        {
            if (webView.Source == null) return;

            string html = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");
            html = System.Text.Json.JsonSerializer.Deserialize<string>(html);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "HTML files (*.html)|*.html",
                DefaultExt = "html"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, html);
                MessageBox.Show("HTML saved successfully!");
            }
        }

        private async void btnSaveFullWebsite_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (!url.StartsWith("http"))
            {
                url = "https://" + url;
            }

            try
            {
                // Tải HTML và tài nguyên
                await DownloadWebsite(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading website: {ex.Message}");
            }
        }

        private async Task DownloadWebsite(string url)
        {
            try
            {
                // 1. Tải HTML của trang
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Đảm bảo rằng mã hóa được sử dụng là đúng
                var encoding = GetEncodingFromHeaders(response.Content.Headers.ContentType);
                byte[] data = await response.Content.ReadAsByteArrayAsync();
                string html = Encoding.UTF8.GetString(data);

                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html);

                // 2. Lưu HTML vào file
                SaveFileDialog saveHtmlDialog = new SaveFileDialog
                {
                    Filter = "HTML files (*.html)|*.html",
                    DefaultExt = "html"
                };

                if (saveHtmlDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveHtmlDialog.FileName, html);
                    MessageBox.Show("HTML saved successfully!");
                }

                // 3. Tải tất cả tài nguyên (img, css, js)
                string baseDirectory = Path.GetDirectoryName(saveHtmlDialog.FileName);
                await DownloadAssets(htmlDoc, baseDirectory, url);

                // 4. Cập nhật HTML để các tài nguyên liên kết đúng vào file local
                UpdateHtmlWithLocalLinks(htmlDoc, baseDirectory);

                // 5. Lưu HTML đã cập nhật với các đường dẫn tài nguyên local
                File.WriteAllText(saveHtmlDialog.FileName, htmlDoc.DocumentNode.OuterHtml);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading website: {ex.Message}");
            }
        }

        private Encoding GetEncodingFromHeaders(System.Net.Http.Headers.MediaTypeHeaderValue contentType)
        {
            if (contentType != null && !string.IsNullOrEmpty(contentType.CharSet))
            {
                try
                {
                    return Encoding.GetEncoding(contentType.CharSet);
                }
                catch (ArgumentException)
                {
                    // Nếu không thể xác định mã hóa, dùng mã hóa mặc định UTF-8
                    return Encoding.UTF8;
                }
            }
            // Mặc định sử dụng UTF-8 nếu không tìm thấy mã hóa
            return Encoding.UTF8;
        }


        private async Task DownloadAssets(HtmlAgilityPack.HtmlDocument htmlDoc, string baseDirectory, string baseUrl)
        {
            var assets = new List<string>();

            // Tìm tất cả tài nguyên hình ảnh, CSS, JS trong HTML
            var imgNodes = htmlDoc.DocumentNode.SelectNodes("//img");
            var cssNodes = htmlDoc.DocumentNode.SelectNodes("//link[@rel='stylesheet']");
            var jsNodes = htmlDoc.DocumentNode.SelectNodes("//script[@src]");

            assets.AddRange(ExtractUrls(imgNodes, "src"));
            assets.AddRange(ExtractUrls(cssNodes, "href"));
            assets.AddRange(ExtractUrls(jsNodes, "src"));

            // Tải từng tài nguyên
            foreach (var asset in assets)
            {
                Uri assetUri = new Uri(asset, UriKind.RelativeOrAbsolute);
                if (!assetUri.IsAbsoluteUri)
                {
                    assetUri = new Uri(new Uri(baseUrl), asset);  // Xử lý các link tương đối
                }

                string localPath = Path.Combine(baseDirectory, Path.GetFileName(assetUri.LocalPath));

                await DownloadFile(assetUri, localPath);
            }
            MessageBox.Show("Download tài nguyên thành công");
        }

        private List<string> ExtractUrls(HtmlNodeCollection nodes, string attribute)
        {
            var urls = new List<string>();
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var url = node.GetAttributeValue(attribute, string.Empty);
                    if (!string.IsNullOrEmpty(url))
                    {
                        urls.Add(url);
                    }
                }
            }
            return urls;
        }

        private async Task DownloadFile(Uri fileUrl, string localPath)
        {
            try
    {
                using (HttpClient client = new HttpClient())
                {
                    // Thêm header User-Agent
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                    // Thêm header Referer nếu cần
                    client.DefaultRequestHeaders.Add("Referer", localPath);

                    // Tải tệp và lưu vào đường dẫn cục bộ
                    var data = await client.GetByteArrayAsync(fileUrl);
                    using (FileStream fs = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous))
                    {
                        await fs.WriteAsync(data, 0, data.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải tài nguyên {fileUrl}: {ex.Message}");
            }
        }

        private void UpdateHtmlWithLocalLinks(HtmlAgilityPack.HtmlDocument htmlDoc, string baseDirectory)
        {
            // Cập nhật tất cả các liên kết trong HTML để trỏ đến tài nguyên local
            var imgNodes = htmlDoc.DocumentNode.SelectNodes("//img");
            var cssNodes = htmlDoc.DocumentNode.SelectNodes("//link[@rel='stylesheet']");
            var jsNodes = htmlDoc.DocumentNode.SelectNodes("//script[@src]");
            if(imgNodes!=null)
                foreach (var imgNode in imgNodes)
                {
                    string src = imgNode.GetAttributeValue("src", string.Empty);
                    string localPath = Path.Combine(baseDirectory, Path.GetFileName(src));
                    imgNode.SetAttributeValue("src", Path.GetFileName(localPath)); // Chỉnh sửa lại đường dẫn
                }
            if(cssNodes!=null)
                foreach (var cssNode in cssNodes)
                {
                    string href = cssNode.GetAttributeValue("href", string.Empty);
                    string localPath = Path.Combine(baseDirectory, Path.GetFileName(href));
                    cssNode.SetAttributeValue("href", Path.GetFileName(localPath));
                }
            if(jsNodes!=null)
                foreach (var jsNode in jsNodes)
                {
                    string src = jsNode.GetAttributeValue("src", string.Empty);
                    string localPath = Path.Combine(baseDirectory, Path.GetFileName(src));
                    jsNode.SetAttributeValue("src", Path.GetFileName(localPath));
                }
        }
    }
}
