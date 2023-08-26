using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Windows.Forms;

public class SerialManager
{
    public static void ExtractSerial(IWebDriver driver, string _serial, string _version, string _product)
    {
        WebDriverWait waitSerial = WebDriverHelper.GetWebDriverWait(driver, 25);
        waitSerial.Until(ExpectedConditions.ElementIsVisible(By.Id("serial")));

        driver.FindElement(By.Id("serial")).SendKeys(_serial);

        SelectElement version = new SelectElement(driver.FindElement(By.Id("version")));
        version.SelectByText(_version);

        SelectElement product = new SelectElement(driver.FindElement(By.Id("product")));
        product.SelectByText(_product);

        driver.FindElement(By.Id("serialSubmit")).Click();
    }
}