using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ImobiliariaContext;
using ImobiliariaEntities;
using ImobiliariaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class CorretorController : Controller
    {
        
        private Imobiliaria ImobiliariaDb;
        private readonly ILogger<CorretorController> _logger;
        private readonly IHttpClientFactory clientFactory;

        public CorretorController(
            ILogger<CorretorController> logger, 
            Imobiliaria injectedContext, 
            IHttpClientFactory httpClient)
        {

            _logger = logger;
            ImobiliariaDb; = injectedContext;
            clientFactory = httpClient;

        }

        public async Task<IActionResult> RetornaCorretores(){

            string uri = "api/Corretores";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService" 
            );

            var request = new HttpRequestMessage(
                method: HttpMethod.Get, requestUri: uri
            );

            HttpResponseMessage response = await httpClient.SendAsync(request);

            var model = await response.Content.ReadFromJsonAsync<IEnumerable<Corretor>>();

            return View(model);
            
        }

        public IActionResult AddCorretor(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddCorretor(Corretor corretor){

            string uri = $"api/Corretores/{corretor.id}";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"

            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await httpClient.PostAsJsonAsync<Corretor>("Corretores", corretor);

            return View();

        }

        public IActionResult AlteraCorretor(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AlteraCorretor(int id, Corretor corretor){

            string uri = $"api/Corretores/{id}";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await httpClient.PutAsJsonAsync<Corretor>($"{corretor.id}", corretor);

            return View();
        }

        public IActionResult DeletaCorretor(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> DeletaCorretor(Corretor corretor){

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"

            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/api/");

            await httpClient.DeleteAsync($"Corretores/{corretor.id}");

            return View();
            
        }

        
    }
}