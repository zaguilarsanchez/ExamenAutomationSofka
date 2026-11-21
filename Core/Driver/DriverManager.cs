using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Threading;

namespace ExamenAutomationSofka.Core.Driver
{
    public enum DriverType { Chrome, Edge }

    public class DriverManager
    {
        private static ThreadLocal<IWebDriver?> _driver = new ThreadLocal<IWebDriver?>();
      
        public DriverManager() { }

        public IWebDriver GetDriver(DriverType type)
        {
            if (_driver.Value == null)
            {
                _driver.Value = CreateDriver(type);
            }
            return _driver.Value;
        }

        private static IWebDriver CreateDriver(DriverType type)
        {
            IWebDriver driver;

            switch (type)
            {
                case DriverType.Edge:
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("start-maximized");
                    edgeOptions.AddArgument("--ignore-certificate-errors");
                    driver = new EdgeDriver(edgeOptions);
                    break;

                case DriverType.Chrome:
                default:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("start-maximized");
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    driver = new ChromeDriver(chromeOptions);
                    break;
            }

            driver.Manage().Cookies.DeleteAllCookies();
            
            return driver;
        }

        public static void QuitDriver()
        {
            try
            {
                if (_driver.IsValueCreated && _driver.Value != null)
                {
                    _driver.Value.Quit();
                }
            }
            finally
            {
                _driver.Value = null;
            }
        }
    }
}