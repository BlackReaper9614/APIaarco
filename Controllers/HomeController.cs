using ConsumirAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;



namespace ConsumirAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static List<Marcas> _marcasList = new List<Marcas>();

        public async Task<IActionResult> Index()
        {
            //https://localhost:44369/api/Alumnoes

            string marcasString;

            var url = "https://apitestcotizamatico.azurewebsites.net/api/catalogos";

            Marcas primerElemento = new Marcas() { iIdMarca = "0", sMarca = "Seleccione una Marca" };

            _marcasList.Add(primerElemento);

            using (var httpClient = new HttpClient())
            {

                var parametros = new RequestAPI() { Filtro = "1", IdAplication = 2, NombreCatalogo = "Marca" };
                var respuesta = await httpClient.PostAsJsonAsync(url, parametros);

                if (respuesta.IsSuccessStatusCode)
                {

                    var cuerpo = await respuesta.Content.ReadAsStringAsync();

                    var results = JsonConvert.DeserializeObject<ResponseAPI>(cuerpo);

                    marcasString = results.CatalogoJsonString;

                    _marcasList = JsonConvert.DeserializeObject<List<Marcas>>(marcasString);
                }

            }

            _marcasList.Add(primerElemento);

            ViewBag.Marca = new SelectList(_marcasList, "iIdMarca", "sMarca", primerElemento.iIdMarca);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Microsoft.JSInterop.JSInvokable]
        public void SelectMarca() 
        {
            Marcas pierm = new Marcas() { iIdMarca = "40", sMarca = "Seleccione perro" };
            _marcasList.Add(pierm);
        }

    }
}
