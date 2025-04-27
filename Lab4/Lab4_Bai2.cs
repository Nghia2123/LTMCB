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
            webView21.Top = URLBox.Bottom + 10;
            webView21.Left = 0;
            webView21.Width = this.ClientSize.Width;
            webView21.Height = this.Height - URLBox.Height - 50;
        }

        private Dictionary<string, string> userAgentStrings = new Dictionary<string, string>
        {
            { "Default", "" }, 
            { "Windows Chrome", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36" },
            { "iPhone Safari", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1" },
            { "Android Chrome", "Mozilla/5.0 (Linux; Android 9; SM-G960F) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Mobile Safari/537.36" }
        };

        private void SwitchUserAgent(string userAgent)
        {
            if (webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Settings.UserAgent = userAgent;
            }
        }

        public Lab4_Bai2()
        {
            InitializeComponent();
            userAgentComboBox.Items.Add("Default");
            userAgentComboBox.Items.Add("Windows Chrome");
            userAgentComboBox.Items.Add("iPhone Safari");
            userAgentComboBox.Items.Add("Android Chrome");
            userAgentComboBox.SelectedIndex = 0;
            this.WindowState = FormWindowState.Maximized;
            this.Resize += new EventHandler(Lab4_Bai2_Resize);
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

                if (userAgentComboBox.SelectedItem != null && userAgentStrings.ContainsKey(userAgentComboBox.SelectedItem.ToString()))
                {
                    SwitchUserAgent(userAgentStrings[userAgentComboBox.SelectedItem.ToString()]);
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
