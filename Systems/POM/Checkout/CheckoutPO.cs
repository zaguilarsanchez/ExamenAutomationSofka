using ExamenAutomationSofka.Core.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ExamenAutomationSofka.Systems.POM.Checkout
{
    public class CheckoutPO
    {
        private readonly IBrowser _browser;
        private readonly string _tituloCheckout = "//div[@id='content']/h1[normalize-space()='Checkout']";
        private readonly string _seleccionarRadio="input[type='radio'][name='account'][value='guest']";
        private readonly string _clicBotonContinuar="//input[@id='button-account']";
        private readonly string _nombre="input-payment-firstname";
        private readonly string _apellido = "input-payment-lastname";
        private readonly string _eMail ="input-payment-email";
        private readonly string _phone ="input-payment-telephone";
        private readonly string _direccion ="input-payment-address-1";
        private readonly string _ciudad ="input-payment-city";
        private readonly string _codigoPostal="input-payment-postcode";
        private readonly string _pais ="input-payment-country";
        private readonly string _region ="input-payment-zone";
        private readonly string _marcarCheckdireccion="input[type='checkbox'][name='shipping_address']";
        private readonly string _clicBotonContinuar1 ="button-guest";
        private readonly string _clicBotonContinuarMethod="button-shipping-method";
        private readonly string _acpetarTC="input[type='checkbox'][name='agree']";
        private readonly string _clicBotonContinuarTC="button-payment-method";
        private readonly string _clicBotonConfirmar="button-confirm";
        private readonly string _tituloConfirmacion="//div[@id='content']//h1";
        private readonly string _botonTerminar="#content .buttons a.btn-primary";

        public CheckoutPO(IBrowser browser)
        {
            _browser = browser;
        }
        public string ObtenerTituloCheckout()
        {
            _browser.WaitXpath(_tituloCheckout);
            return _browser.FindXpath(_tituloCheckout).Text.Trim();
        }

        public void SeleccionarCheckoutOptions()
        {
            _browser.WaitCss(_seleccionarRadio);
            _browser.FindCss(_seleccionarRadio).Click();
        }
        public void ClicBotonContinuar(){
            _browser.WaitXpath(_clicBotonContinuar);
            _browser.FindXpath(_clicBotonContinuar).Click();

        }
        public void IngresarNombre(string firstname)
        {
            _browser.WaitId(_nombre);
            var campoNombre = _browser.FindId(_nombre);
            campoNombre.Clear();
            campoNombre.SendKeys(firstname);
        }
        public void IngresarApellido (string lastname)
        {
            _browser.WaitId(_apellido);
            var campoApellido=_browser.FindId(_apellido);
            campoApellido.Clear();
            campoApellido.SendKeys(lastname);
        }

        public void IngresarMail(string correo)
        {
            _browser.WaitId(_eMail);
            var campoMail = _browser.FindId(_eMail);
            campoMail.Clear();
            campoMail.SendKeys(correo);
        }

        public void IngresarPhone(string celu)
        {
            _browser.WaitId(_phone);
            var campoTelef=_browser.FindId(_phone);
            campoTelef.Clear();
            campoTelef.SendKeys(celu);
        }

        public void IngresarDireccion(string address)
        {
            _browser.WaitId(_direccion);
            var campoAddress=_browser.FindId(_direccion);
            campoAddress.Clear();
            campoAddress.SendKeys(address);
        }

        public void IngresarCiudad(string city)
        {
            _browser.WaitId(_ciudad);
           var campoCiudad=_browser.FindId(_ciudad);
           campoCiudad.Clear();
           campoCiudad.SendKeys(city);

        }
        public void IngresarCodigoPostal (string postal)
        {
            _browser.WaitId(_codigoPostal);
            var campoCodigoPostal=_browser.FindId(_codigoPostal);
            campoCodigoPostal.Clear();
            campoCodigoPostal.SendKeys(postal);
        }

        public void SeleccionarPais(string country)
        {
            _browser.WaitId(_pais);
            var elementoSelect = _browser.FindId(_pais);
            var comboPais = new SelectElement(elementoSelect);

            comboPais.SelectByText(country);
        }

        public void SeleccionarRegion(string state)
        {
            _browser.WaitId(_region);
            _browser.Sleep(2); 

           var elementoSelect = _browser.FindId(_region);
           var comboRegion = new SelectElement(elementoSelect);

           comboRegion.SelectByText(state);
        }
        public void MarcarMismaDireccionEnvioYFacturacion()
        {
            _browser.WaitCss(_marcarCheckdireccion);
            var checkbox = _browser.FindCss(_marcarCheckdireccion);

            if (!checkbox.Selected)
            {
            checkbox.Click();
            }
         }
        public void ClickBotonContinuarFormularioUno()
        {
            _browser.WaitId(_clicBotonContinuar1);
            _browser.FindId(_clicBotonContinuar1).Click();
        }
        public void ClicBotonContinuarMethod()
        {
            _browser.WaitId(_clicBotonContinuarMethod);
            _browser.FindId(_clicBotonContinuarMethod).Click();
            _browser.Sleep(2); 
        }
       public void AceptarTerminosYCondiciones()
        {
            _browser.WaitCss(_acpetarTC);
             var checkbox = _browser.FindCss(_acpetarTC);

             if (!checkbox.Selected)
            {
           checkbox.Click();
           }
        }
        public void ClicBotonContinuarTerminosYCondiciones()
        {
           _browser.WaitId(_clicBotonContinuarTC);
            _browser.FindId(_clicBotonContinuarTC).Click();
            _browser.Sleep(2); 
        }
        public void ClicBotonConfirmarOrden()
        {
            _browser.WaitId(_clicBotonConfirmar);
            _browser.FindId(_clicBotonConfirmar).Click();
            _browser.Sleep(2); 
        }
        public string ValidarMensajeConfirmacion()
        {
           _browser.Sleep(2); 
           _browser.WaitXpath(_tituloConfirmacion);
           return _browser.FindXpath(_tituloConfirmacion).Text.Trim();
           
        }

        public void ClicBotonContinuarFinal()
        {
            _browser.WaitCss(_botonTerminar);
            _browser.FindCss(_botonTerminar).Click();
        }

    }
}