using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace ExamenAutomationSofka.Core.Driver 
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateDriver(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException($"El navegador '{browser}' no está soportado.")
            };
        }
    }
}