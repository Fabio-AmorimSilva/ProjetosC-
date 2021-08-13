using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImobiliariaMvc.Models;
using System.Net.Http;
using ImobiliariaContext;
using ImobiliariaEntities;
using System.Net.Http.Json;

namespace ImobiliariaMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory clientFactory;

        private Imobiliaria db;

        public HomeController(
            ILogger<HomeController> logger, 
            Imobiliaria injectedContext,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            db = injectedContext;
            clientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Agencias(){

            string uri = "api/Agencias";

            var client = clientFactory.CreateClient(
              name: "ImobiliariaService"  
            );

            var request = new HttpRequestMessage(
                method: HttpMethod.Get, requestUri: uri
            );

            HttpResponseMessage response = await client.SendAsync(request);

            var model = await response.Content.ReadFromJsonAsync<IEnumerable<Agencia>>();

            return View(model);

        }

        public IActionResult AddAgencia(){

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAgencia(Agencia agencia){

            string uri = $"api/Agencias/{agencia.id}";

            var client = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            client.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await client.PostAsJsonAsync<Agencia>("Agencias", agencia);
            

            return View();

        }

        public IActionResult AlteraAgencia(){

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AlteraAgencia(Agencia agencia){

            string uri = $"api/Agencias/{agencia.id}";

            var client = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            client.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await client.PutAsJsonAsync<Agencia>($"{agencia.id}", agencia);

            return View();

        }

        public IActionResult DeletaAgencia(){

            return View();

        }

        [HttpPost]
        public IActionResult DeletaAltera(int id){

            var client = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            client.BaseAddress = new Uri("https://localhost:5001/api/");

            client.DeleteAsync($"Agencias/{id}");

            return View();

        }

        

        public IActionResult Index()
        {
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
    }
}
