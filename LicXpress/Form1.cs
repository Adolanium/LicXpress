using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Playwright;

namespace LicXpress
{
    public partial class Form1 : Form
    {
        private const string BASE_URL = "https://my.solidworks.com/xpress";
        private readonly Configuration _config;

        public Form1()
        {
            InitializeComponent();
            _config = new Configuration("credentials.txt");
        }

        internal static async Task NavigateToBaseURLAsync(IPage page)
        {
            await page.GotoAsync(BASE_URL);
        }

        internal static async Task LoginAsync(IPage page, Configuration config)
        {
            try
            {
                string username = config.Username;
                string password = config.Password;

                await page.ClickAsync("#footer_tc_privacy_button_3");
                await page.ClickAsync("text=Log In");
                await page.ClickAsync("//*[@id=\"dsxLoginWrapper\"]/div[3]/div[2]/a[1]");

                await page.FillAsync("[name='username']", username);
                await page.FillAsync("[name='password']", password);
                await page.PressAsync("[name='password']", "Enter");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Login failed: {e.Message}");
            }
        }

        internal static async Task ExtractSerialAsync(IPage page, string _serial, string _version, string _product)
        {
            try
            {
                await page.FillAsync("#serial", _serial);
                await page.SelectOptionAsync("#version", _version);
                await page.SelectOptionAsync("#product", _product);
                await page.ClickAsync("#serialSubmit");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void generateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string text = CleanSerialNumber(serialTextBox.Text);
                serialTextBox.Text = text;

                string _version = versionListBox.SelectedItem.ToString();
                string _product = productListBox.SelectedItem.ToString();

                using var playwright = await Playwright.CreateAsync();
                await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });

                var context = await browser.NewContextAsync();
                var page = await context.NewPageAsync();

                await NavigateToBaseURLAsync(page);
                await LoginAsync(page, _config);
                await ExtractSerialAsync(page, text, _version, _product);

                string xpressCode = await page.InnerTextAsync("//*[@id=\"expressmail\"]/div[1]/table/tbody/tr/td[2]/span/b");
                codeTextBox.Text = xpressCode;
                MessageBox.Show("Done! The code for " + _product + " " + _version + " is: " + xpressCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private static string CleanSerialNumber(string input)
        {
            return input.Replace(" ", "").Replace("\r", "").Replace("\"", "");
        }
    }
}
