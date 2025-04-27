using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Lab4_Bai2: Form
    {
        private void Lab4_Bai2_Resize(object sender, EventArgs e)
        {
            if (userAgentComboBox.SelectedItem != null && userAgentStrings.ContainsKey(userAgentComboBox.SelectedItem.ToString()))
            {
                SwitchUserAgent(userAgentStrings[userAgentComboBox.SelectedItem.ToString()]);
            }
        }

        private Dictionary<string, string> userAgentStrings = new Dictionary<string, string>
        {
            { "Windows Chrome", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36" },
            { "Windows Firefox", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:112.0) Gecko/20100101 Firefox/112.0" },
            { "iPhone Safari", "Mozilla/5.0 (iPhone; CPU iPhone OS 16_4_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.4 Mobile/15E148 Safari/604.1" },
            { "iPad Safari", "Mozilla/5.0 (iPad; CPU OS 16_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.4 Mobile/15E148 Safari/604.1" },
            { "macOS Safari", "Mozilla/5.0 (Macintosh; Intel Mac OS X 13_3_1) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.4 Safari/605.1.15" },
            { "Android Chrome", "Mozilla/5.0 (Linux; Android 9; SM-G960F) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Mobile Safari/537.36" },
            { "Android Samsung Browser", "Mozilla/5.0 (Linux; Android 11; SAMSUNG SM-G991B) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/19.0 Chrome/96.0.4664.45 Mobile Safari/537.36" },
            { "Pixel Android Chrome", "Mozilla/5.0 (Linux; Android 13; Pixel 7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Mobile Safari/537.36" }
        };

        private void SwitchUserAgent(string userAgent)
        {
            if (webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Settings.UserAgent = userAgent;
            }

            if (userAgent == userAgentStrings["iPhone Safari"])
            {
                webView21.Width = 400;
                webView21.Height = 800;
            }
            else if (userAgent == userAgentStrings["iPad Safari"])
            {
                webView21.Width = 768;
                webView21.Height = 1024;
            }
            else if (userAgent == userAgentStrings["Android Chrome"])
            {
                webView21.Width = 450;
                webView21.Height = 850;
            }
            else if (userAgent == userAgentStrings["Android Samsung Browser"])
            {
                webView21.Width = 412;
                webView21.Height = 915;
            }
            else if (userAgent == userAgentStrings["Pixel Android Chrome"])
            {
                webView21.Width = 412;
                webView21.Height = 870;
            }
            else
            {
                webView21.Width = this.ClientSize.Width - 20;
                webView21.Height = this.ClientSize.Height - userAgentComboBox.Height - 80;
            }

            webView21.Top = userAgentComboBox.Bottom + 10;
            webView21.Left = (this.ClientSize.Width - webView21.Width) / 2;
        }

        private void userAgentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userAgentComboBox.SelectedItem != null && userAgentStrings.ContainsKey(userAgentComboBox.SelectedItem.ToString()))
            {
                SwitchUserAgent(userAgentStrings[userAgentComboBox.SelectedItem.ToString()]);
            }

            if (webView21.Source != null)
            {
                webView21.Reload();
            }
        }

        public Lab4_Bai2()
        {
            InitializeComponent();
            foreach (var userAgent in userAgentStrings.Keys)
            {
                userAgentComboBox.Items.Add(userAgent);
            }
            userAgentComboBox.SelectedIndex = 0;
            this.WindowState = FormWindowState.Maximized;
            this.userAgentComboBox.SelectedIndexChanged += new EventHandler(userAgentComboBox_SelectedIndexChanged);
            this.Resize += new EventHandler(Lab4_Bai2_Resize);

            Rectangle screen = Screen.FromControl(this).WorkingArea;
            int minWidth = screen.Width - 20;
            int minHeight = screen.Height - 20;
            this.MinimumSize = new Size(minWidth, minHeight);
        }

        private async Task NavigateToURL()
        {
            string url = URLBox.Text.Trim();

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            try
            {
                if (webView21.CoreWebView2 == null)
                {
                    await webView21.EnsureCoreWebView2Async();
                }

                webView21.Source = new Uri(url);
            }
            catch (UriFormatException)
            {
                MessageBox.Show("Invalid URL format. Please enter a valid URL.");
            }
        }

        private async void browseButton_Click(object sender, EventArgs e)
        {
            await NavigateToURL();
        }

        private async void URLBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await NavigateToURL();
            }
        }

        private void URLBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
