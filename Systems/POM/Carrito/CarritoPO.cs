using ExamenAutomationSofka.Core.Browser;
using OpenQA.Selenium;

namespace ExamenAutomationSofka.Systems.POM.Carrito
{
    public class CarritoPO
    {
        private readonly IBrowser _browser;
        private readonly string _clicCheckout = "//p[contains(@class,'text-right')]//a[contains(@href,'route=checkout/checkout') and .//strong[contains(normalize-space(),'Checkout')]]";

        public CarritoPO(IBrowser browser)
        {
            _browser = browser;
        }
        public void clickCheckout()
        {
            _browser.WaitXpath(_clicCheckout);
            _browser.FindXpath(_clicCheckout).Click();
        }



    }
}