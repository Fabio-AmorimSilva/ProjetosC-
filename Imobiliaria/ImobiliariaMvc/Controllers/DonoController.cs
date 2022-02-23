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
    public class DonoController : Controller
    {

        private Imobiliaria ImobiliariaDb;
        private readonly ILogger<DonoController> _logger;
        private readonly IHttpClientFactory clientFactory;

        public DonoController(ILogger<DonoController> logger, 
        Imobiliaria injectedContext, 
        IHttpClientFactory httpClient)
        {

            _logger = logger;
            ImobiliariaDb = injectedContext;
            clientFactory = httpClient;

        }

        [HttpGet]
        public async Task<IActionResult> RetornaDonos(){

            string uri = "api/Donos";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            var request = new HttpRequestMessage(
                method: HttpMethod.Get, requestUri: uri
            );

            HttpResponseMessage response = await httpClient.SendAsync(request);

            var model = await response.Content.ReadFromJsonAsync<IEnumerable<Dono>>();

            return View(model);
            
        }

        public IActionResult AddDono(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddDono(Dono dono){

            string uri = $"api/Donos/{dono.id}";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"

            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await httpClient.PostAsJsonAsync<Dono>("Donos", dono);

            return View();
            
        }

        public IActionResult AlteraDono(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AlteraDono(int id, Dono dono){

            string uri = $"api/Donos/{id}";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await httpClient.PutAsJsonAsync<Dono>($"{dono.id}", dono);

            return View();

        }

        public IActionResult DeletaDono(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> DeletaDono(Dono dono){

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"

            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/api/");

            await httpClient.DeleteAsync($"Donos/{dono.id}");

            return View();

        }
    }
}