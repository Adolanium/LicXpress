using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Windows.Forms;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace LicXpress
{
    public partial class Form1 : Form
    {
        private const string BASE_URL = "https://my.solidworks.com/xpress";
        private const int DEFAULT_WAIT_TIME = 10;

        public Form1()
        {
            InitializeComponent();
        }

        public static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;
            return new ChromeDriver(service, options);
        }

        public static WebDriverWait GetWebDriverWait(IWebDriver driver, int seconds = DEFAULT_WAIT_TIME)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }

        static void NavigateToBaseURL(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        static Tuple<string, string> ReadCredentials()
        {
            try
            {
                string path = "credentials.txt";
                string[] lines = File.ReadAllLines(path);

                string username = lines[0].Split('=')[1].Trim();
                string password = lines[1].Split('=')[1].Trim();

                return new Tuple<string, string>(username, password);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to read credentials: {e.Message}");
                return new Tuple<string, string>(string.Empty, string.Empty);
            }
        }


        static void Login(IWebDriver driver)
        {
            try
            {
                var credentials = ReadCredentials();
                string username = credentials.Item1;
                string password = credentials.Item2;

                var wait = GetWebDriverWait(driver);
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("footer_tc_privacy_button_3"))).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log In"))).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"dsxLoginWrapper\"]/div[3]/div[2]/a[1]"))).Click();

                var emailField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));
                emailField.SendKeys(username);

                var passwordField = driver.FindElement(By.Name("password"));
                passwordField.SendKeys(password);
                passwordField.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Login failed: {e.Message}");
            }
        }

        static void ExtractSerial(IWebDriver driver, string _serial, string _version, string _product)
        {
            try
            {
                WebDriverWait waitSerial = GetWebDriverWait(driver, 25);
                waitSerial.Until(ExpectedConditions.ElementIsVisible(By.Id("serial")));

                driver.FindElement(By.Id("serial")).SendKeys(_serial);
                SelectElement version = new SelectElement(driver.FindElement(By.Id("version")));
                version.SelectByText(_version);

                SelectElement product = new SelectElement(driver.FindElement(By.Id("product")));
                product.SelectByText(_product);

                driver.FindElement(By.Id("serialSubmit")).Click();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            string text = serialTextBox.Text.Replace(" ", "").Replace("\r", "").Replace("\"", "");
            serialTextBox.Text = text;

            string _version = versionListBox.SelectedItem.ToString();
            string _product = productListBox.SelectedItem.ToString();

            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            IWebDriver driver = CreateChromeDriver();
            NavigateToBaseURL(driver);
            Login(driver);
            ExtractSerial(driver, text, _version, _product);

            WebDriverWait waitActivationCode = GetWebDriverWait(driver);
            string xpressCode = waitActivationCode.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"expressmail\"]/div[1]/table/tbody/tr/td[2]/span/b"))).Text;
            codeTextBox.Text = xpressCode;
            MessageBox.Show("Done! The code for " + _product + " " + _version + " is: " + xpressCode);
            driver.Quit();
        }
    }
}
