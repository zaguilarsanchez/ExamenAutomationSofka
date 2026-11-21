using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ExamenAutomationSofka.Core.Utils
{
    public static class Waiters
    {
        // Espera a que un elemento sea visible antes de interactuar
        public static void WaitUntilVisible(IWebDriver driver, By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElement(locator).Displayed);
        }

        // Espera a que desaparezca un elemento (ideal para spinners)
        public static void WaitUntilInvisibe(IWebDriver driver, By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElements(locator).Count == 0);
        }
    }
}