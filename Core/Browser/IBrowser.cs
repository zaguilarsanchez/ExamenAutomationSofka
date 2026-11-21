using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExamenAutomationSofka.Core.Browser
{
    public interface IBrowser
    {
        // --- Búsqueda de un solo elemento ---
        IWebElement FindId(string locator);
        IWebElement FindName(string locator);
        IWebElement FindXpath(string locator);
        IWebElement FindClassName(string locator);
        IWebElement FindLink(string locator);
        IWebElement FindLinkPartial(string locator);
        IWebElement FindTag(string locator);
        IWebElement FindCss(string cssSelector);
               
        // --- Búsqueda de múltiples elementos ---
        ReadOnlyCollection<IWebElement> FindsId(string locator);
        ReadOnlyCollection<IWebElement> FindsName(string locator);
        ReadOnlyCollection<IWebElement> FindsXpath(string locator);
        ReadOnlyCollection<IWebElement> FindsCss(string locator);
        ReadOnlyCollection<IWebElement> FindsClassName(string locator);
        ReadOnlyCollection<IWebElement> FindsLink(string locator);
        ReadOnlyCollection<IWebElement> FindsLinkPartial(string locator);
        ReadOnlyCollection<IWebElement> FindsTag(string locator);

        // --- Gestión del Navegador ---
        void Quit();
        void Close();
        void NavigateTo(string url);
        string GetTitle();
        string GetTitle(string header);
        string GetScreenshot();         
        string GetText(string cssSelector);

        // --- Alertas y Frames ---
        IAlert SwitchToAlert();
        void AcceptAlert(IAlert alert);
        void SwitchToFrame(int index);
        void SwitchToFrame(string nameOrId);
        void SwitchToFrame(IWebElement element);
        void SwitchToDefaultContent();
        string GetWindowHandle();
        ReadOnlyCollection<string> GetWindowHandles();
        void SwitchToWindow(int indexWindows);
        void JavaScriptExecutor(string script);
        void JavaScriptExecutor(string script, object element);

        // --- Tiempos y Esperas ---
        void Sleep();
        void Sleep(int seconds);
        void WaitId(string locator);
        void WaitName(string locator);
        void WaitCss(string locator);
        void WaitXpath(string locator);
        void WaitLink(string locator);
        void WaitPartialLink(string locator);
        void WaitClassName(string locator);
        void WaitTag(string locator);
        void ExecuteJavaScript(string v, IWebElement boton);
    }
}