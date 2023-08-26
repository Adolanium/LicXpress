using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Windows.Forms;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace LicXpress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            string text = serialTextBox.Text.Replace(" ", "").Replace("\r", "").Replace("\"", "");
            serialTextBox.Text = text;

            string _version = versionListBox.SelectedItem.ToString();
            string _product = productListBox.SelectedItem.ToString();

            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            IWebDriver driver = WebDriverHelper.CreateChromeDriver();

            NavigationManager.NavigateToBaseURL(driver);
            NavigationManager.Login(driver);
            SerialManager.ExtractSerial(driver, text, _version, _product);

            WebDriverWait waitActivationCode = WebDriverHelper.GetWebDriverWait(driver);
            string xpressCode = waitActivationCode.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"expressmail\"]/div[1]/table/tbody/tr/td[2]/span/b"))).Text;
            codeTextBox.Text = xpressCode;
            MessageBox.Show($"Done! The code for {_product} {_version} is: {xpressCode}");

            driver.Quit();
        }
    }
}