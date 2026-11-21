using ExamenAutomationSofka.Core.Browser;
using OpenQA.Selenium;

namespace ExamenAutomationSofka.Systems.POM.AgregarProductos
{
    public class AgregarProductosPO
    {
        private readonly IBrowser _browser;
        private readonly string _tituloTienda = "//div[@id='logo']//h1/a";
        private readonly string _clicItems = "cart";

        public AgregarProductosPO(IBrowser browser)
        {
            _browser = browser;
        }

        public string ObtenerTituloTienda()
        {
            _browser.WaitXpath(_tituloTienda);
            return _browser.FindXpath(_tituloTienda).Text.Trim();
        }

        private string AgregarProducto(string nombreProducto)
        {
            return $"//div[contains(@class,'product-thumb')][.//h4/a[normalize-space()='{nombreProducto}']]//button[contains(@onclick,'cart.add')]";
        }

        public void AgregarProductoAlCarrito(string nombreProducto)
        {
            string producto = AgregarProducto(nombreProducto);
            _browser.WaitXpath(producto);
           var boton = _browser.FindXpath(producto);
           _browser.JavaScriptExecutor("arguments[0].scrollIntoView({ block: 'center', inline: 'nearest' });", boton);
           _browser.Sleep(1);
           try
    {
        boton.Click();
    }
    catch (OpenQA.Selenium.ElementClickInterceptedException)
    {
        // Respaldo con JS si un elemento flotante/paginación intercepta el clic
        _browser.JavaScriptExecutor("arguments[0].click();", boton);
    }
        }
        
        public void clickBotonItems()
        {
            _browser.WaitId(_clicItems);
            _browser.FindId(_clicItems).Click();
        }



    }
}