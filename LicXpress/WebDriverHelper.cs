using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class WebDriverHelper
{
    private const int DEFAULT_WAIT_TIME = 10;

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
}