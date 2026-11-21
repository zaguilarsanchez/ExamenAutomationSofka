using ExamenAutomationSofka.Core.Browser;
using ExamenAutomationSofka.Systems.POM.Accesos;
using ExamenAutomationSofka.Systems.POM.AgregarProductos;
using ExamenAutomationSofka.Systems.POM.Carrito;
using ExamenAutomationSofka.Systems.POM.Checkout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ExamenAutomationSofka.Tests.Tests
{
    public class CompraTest : TestBase
    {
        private AgregarProductosPO _agregarProductosPO = null!;
        private AlertasPO _alertasPO = null!;
        private CarritoPO _carritoPO=null!;
        private CheckoutPO _checkoutPO=null!;

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void FlujoCompraTest(string navegador, string producto1, string producto2, string firstname, string lastname,string correo, string celu, string address, string city, string postal, string country, string state)
        {
            InicializarPrueba(navegador);
            _agregarProductosPO = new AgregarProductosPO(_browser);
            _alertasPO = new AlertasPO(_browser);
            _carritoPO = new CarritoPO(_browser);
            _checkoutPO= new CheckoutPO(_browser);



            string tituloTienda = _agregarProductosPO.ObtenerTituloTienda();
            Assert.Equal(TituloHome, tituloTienda);

            // 1. Agregar primer producto y validar alerta
            _agregarProductosPO.AgregarProductoAlCarrito(producto1);
            string alerta1 = _alertasPO.GetMensajeConfimacionAñadido();
            Assert.Contains(string.Format(MensajeConfirmacion, producto1), alerta1);

            // 2. Agregar segundo producto y validar alerta
            _agregarProductosPO.AgregarProductoAlCarrito(producto2);
            string alerta2 = _alertasPO.GetMensajeConfimacionAñadido();
            Assert.Contains(string.Format(MensajeConfirmacion, producto2), alerta2);

            //3. Visualizar el carrito
            _browser.Sleep(1);
            _agregarProductosPO.clickBotonItems();
            _browser.Sleep(2);

            //4. Completar el “Checkout” como invitado: “Guest Checkout”
            _carritoPO.clickCheckout();
            string tituloCheckout = _checkoutPO.ObtenerTituloCheckout();
            Assert.Equal(FormularioTitulo, tituloCheckout);
            _checkoutPO.SeleccionarCheckoutOptions();
            _checkoutPO.ClicBotonContinuar();

            //5. Completar compra
            _checkoutPO.IngresarNombre(firstname);
            _checkoutPO.IngresarApellido(lastname);
            _checkoutPO.IngresarMail(correo);
            _checkoutPO.IngresarPhone(celu);
            _checkoutPO.IngresarDireccion(address);
            _checkoutPO.IngresarCiudad(city);
            _checkoutPO.IngresarCodigoPostal(postal);
            _checkoutPO.SeleccionarPais(country);
            _checkoutPO.SeleccionarRegion(state);
            _checkoutPO.MarcarMismaDireccionEnvioYFacturacion();
            _checkoutPO.ClickBotonContinuarFormularioUno();
            _checkoutPO.ClicBotonContinuarMethod();
           _checkoutPO.AceptarTerminosYCondiciones();
           _checkoutPO.ClicBotonContinuarTerminosYCondiciones();
           _checkoutPO.ClicBotonConfirmarOrden();
           string confirmacionCompra = _checkoutPO.ValidarMensajeConfirmacion();
           Assert.Equal(MensajeConfirmacionCompra, confirmacionCompra);
           _checkoutPO.ClicBotonContinuarFinal();       




        }

        public static IEnumerable<object[]> GetTestData()
        {
            var navegadores = new[] { "chrome" };
            var datosCsv = GetUsuariosDesdeCsv();

            foreach (var nav in navegadores)
            {
                foreach (var dato in datosCsv)
                {
                    var filaCompleta = new List<object> { nav };
                    filaCompleta.AddRange(dato);
                    yield return filaCompleta.ToArray();
                }
            }
        }

        public static IEnumerable<object[]> GetUsuariosDesdeCsv()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tests", "Recursos", "datosUsuarios.csv");
            return File.ReadAllLines(path)
                .Where(linea => !string.IsNullOrWhiteSpace(linea))
                .Select(linea => linea.Split(',').Select(dato => (object)dato.Trim()).ToArray());
        }
    }
}