using System;
using OpenQA.Selenium;
using ExamenAutomationSofka.Core.Browser;

namespace ExamenAutomationSofka.Systems.POM.Accesos
{
    public class AlertasPO
    {
        private readonly IBrowser _browser;
        private readonly string _mensajeConfirmacionAdd = "//div[contains(@class,'alert-success')]";

        public AlertasPO(IBrowser browser)
        {
            _browser = browser;
        }

        public string GetMensajeConfimacionAñadido()
        {
            _browser.WaitXpath(_mensajeConfirmacionAdd);
            string texto = _browser.FindXpath(_mensajeConfirmacionAdd).Text;

            
            return texto.Replace("×", "")
                        .Replace("\r", " ")
                        .Replace("\n", " ")
                        .Trim();
        }
    }
}