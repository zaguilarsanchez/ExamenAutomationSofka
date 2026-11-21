using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace ExamenAutomationSofka.Core.Browser
{
    public class BrowserImpl : IBrowser
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BrowserImpl(int waitSeconds, IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitSeconds));
        }

        #region Find y FindBy
        private IWebElement Find(By by) => _wait.Until(d => d.FindElement(by));

        private ReadOnlyCollection<IWebElement> Finds(By by) => _driver.FindElements(by);

        public IWebElement FindId(string id) => Find(By.Id(id));
        public IWebElement FindName(string name) => Find(By.Name(name));
        public IWebElement FindClassName(string className) => Find(By.ClassName(className));
        public IWebElement FindCss(string cssSelector) => Find(By.CssSelector(cssSelector));
        public IWebElement FindLink(string linkText) => Find(By.LinkText(linkText));
        public IWebElement FindLinkPartial(string partialLinkText) => Find(By.PartialLinkText(partialLinkText));
        public IWebElement FindTag(string tagName) => Find(By.TagName(tagName));
        public IWebElement FindXpath(string xpath) => Find(By.XPath(xpath));
        public ReadOnlyCollection<IWebElement> FindsClassName(string className) => Finds(By.ClassName(className));
        public ReadOnlyCollection<IWebElement> FindsCss(string cssSelector) => Finds(By.CssSelector(cssSelector));
        public ReadOnlyCollection<IWebElement> FindsId(string id) => Finds(By.Id(id));
        public ReadOnlyCollection<IWebElement> FindsName(string name) => Finds(By.Name(name));
        public ReadOnlyCollection<IWebElement> FindsLink(string linkText) => Finds(By.LinkText(linkText));
        public ReadOnlyCollection<IWebElement> FindsLinkPartial(string partialLinkText) => Finds(By.PartialLinkText(partialLinkText));
        public ReadOnlyCollection<IWebElement> FindsTag(string tagName) => Finds(By.TagName(tagName));
        public ReadOnlyCollection<IWebElement> FindsXpath(string xpath) => Finds(By.XPath(xpath));
        #endregion

        #region Utilidades
        public void Close()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
        public string GetTitle() => _driver.Title;
        public string GetTitle(string header) => _driver.Title;

        public string GetScreenshot()
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)_driver;
            return screenshot.GetScreenshot().AsBase64EncodedString;
        }
        public string GetText(string cssSelector)
        {
            WaitCss(cssSelector); 
            return FindCss(cssSelector).Text; 
        }
        public void NavigateTo(string url) => _driver.Navigate().GoToUrl(url);

        public IAlert SwitchToAlert() => _driver.SwitchTo().Alert();
        public void AcceptAlert(IAlert alert) => alert.Accept();

        public void SwitchToFrame(int index) => _driver.SwitchTo().Frame(index);
        public void SwitchToFrame(string nameOrId) => _driver.SwitchTo().Frame(nameOrId);
        public void SwitchToFrame(IWebElement element) => _driver.SwitchTo().Frame(element);
        public void SwitchToDefaultContent() => _driver.SwitchTo().DefaultContent();

        public string GetWindowHandle() => _driver.CurrentWindowHandle;
        public ReadOnlyCollection<string> GetWindowHandles() => _driver.WindowHandles;

        public void SwitchToWindow(int indexWindows)
        {
            var handles = _driver.WindowHandles;
            _driver.SwitchTo().Window(handles[indexWindows]);
        }
        public void JavaScriptExecutor(string script) => ((IJavaScriptExecutor)_driver).ExecuteScript(script);
        public void JavaScriptExecutor(string script, object element) => ((IJavaScriptExecutor)_driver).ExecuteScript(script, element);
        #endregion

        #region Wait
        public void Sleep() => Sleep(1);
        public void Sleep(int seconds) => Thread.Sleep(seconds * 1000);

        public void WaitId(string locator) => Wait(By.Id(locator));
        public void WaitName(string locator) => Wait(By.Name(locator));
        public void WaitCss(string locator) => Wait(By.CssSelector(locator));
        public void WaitXpath(string locator) => Wait(By.XPath(locator));
        public void WaitLink(string locator) => Wait(By.LinkText(locator));
        public void WaitPartialLink(string locator) => Wait(By.PartialLinkText(locator));
        public void WaitClassName(string locator) => Wait(By.ClassName(locator));
        public void WaitTag(string locator) => Wait(By.TagName(locator));

        public void Wait(By locator)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public void ExecuteJavaScript(string script, IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(script, element);
        }

        public void Quit()
        {
            Close();
        }
        #endregion
    }
}