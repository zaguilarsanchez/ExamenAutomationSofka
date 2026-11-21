using Microsoft.Extensions.Configuration;
using ExamenAutomationSofka.Core.Browser;
using ExamenAutomationSofka.Core.Driver;
using OpenQA.Selenium;
using System;
using System.IO;
using Xunit;
[assembly: CollectionBehavior(DisableTestParallelization = false, MaxParallelThreads = 4)]

namespace ExamenAutomationSofka.Tests.Tests
{
    public class TestBase : IDisposable
    {
       protected IBrowser _browser = null!;
        protected readonly IConfiguration Config;
        protected readonly string Url;
        protected readonly string TituloHome;
        protected readonly string MensajeConfirmacion;
        protected readonly string FormularioTitulo;
        protected readonly string MensajeConfirmacionCompra;

        public TestBase()
        {           
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Tests/Recursos/appsettings.json", optional: false)
                .Build();

            Url = Config["Ambiente:Url"]!;
            TituloHome = Config["Validaciones:TituloHome"]!;
            MensajeConfirmacion = Config["Validaciones:MensajeConfirmacion"]!;
            FormularioTitulo = Config["Validaciones:FormularioTitulo"]!;
            MensajeConfirmacionCompra= Config["Validaciones:MensajeConfirmacionCompra"]!;


        }
        public void InicializarPrueba(string browser)
        {
            DriverType tipo = Enum.Parse<DriverType>(browser, true);
            var manager = new DriverManager();
            IWebDriver driver = manager.GetDriver(tipo); 
           
            _browser = new BrowserImpl(20, driver);
            _browser.NavigateTo(Url);
        }

        public virtual void Dispose()
        {
            DriverManager.QuitDriver();
            GC.SuppressFinalize(this);
        }
    }

}