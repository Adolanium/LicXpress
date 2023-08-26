using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Windows.Forms;

public class NavigationManager
{
    private const string BASE_URL = "https://my.solidworks.com/xpress";

    public static void NavigateToBaseURL(IWebDriver driver)
    {
        driver.Navigate().GoToUrl(BASE_URL);
    }

    public static void Login(IWebDriver driver)
    {
        var credentials = CredentialsManager.ReadCredentials();
        string username = credentials.Item1;
        string password = credentials.Item2;

        var wait = WebDriverHelper.GetWebDriverWait(driver);
        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("footer_tc_privacy_button_3"))).Click();
        wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log In"))).Click();
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"dsxLoginWrapper\"]/div[3]/div[2]/a[1]"))).Click();

        var emailField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));
        emailField.SendKeys(username);

        var passwordField = driver.FindElement(By.Name("password"));
        passwordField.SendKeys(password);
        passwordField.SendKeys(OpenQA.Selenium.Keys.Enter);
    }
}