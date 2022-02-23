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
    public class ImovelController : Controller
    {

        private Imobiliaria ImobiliariaDb;
        private readonly ILogger<ImovelController> _logger;
        private readonly IHttpClientFactory clientFactory;

        public ImovelController(
            ILogger<ImovelController> logger, 
            Imobiliaria injectedContext, 
            IHttpClientFactory httpClient)
        {

            _logger = logger;
            ImobiliariaDb = injectedContext;
            clientFactory = httpClient;
            
        }

        [HttpGet]
        public async Task<IActionResult> RetornaImoveis(){

            string uri = "api/Imoveis";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"
            );

            var request = new HttpRequestMessage(
                method: HttpMethod.Get, requestUri: uri

            );

            HttpResponseMessage response = await httpClient.SendAsync(request);

            var model = await response.Content.ReadFromJsonAsync<IEnumerable<Imovel>>();

            return View(model);
            
        }
        
        public IActionResult AddImovel(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddImovel(Imovel imovel){

            string uri = $"api/Imoveis/{imovel.id}";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"

            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await httpClient.PostAsJsonAsync<Imovel>("Imoveis", imovel);

            return View();
            
        }

        public IActionResult AlteraImovel(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AlteraImovel(int id, Imovel imovel){

            string uri = $"api/Imoveis/{id}";

            var httpClient = clientFactory.CreateClient(
                name: "ImobiliariaService"

            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/" + uri);

            await httpClient.PutAsJsonAsync<Imovel>($"{imovel.id}", imovel);

            return View();

        }

        public IActionResult DeletaImovel(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> DeletaImovel(Imovel imovel){

            var httpClient = clientFactory.CreateClient(
                name: "Imobiliaria"
            );

            httpClient.BaseAddress = new Uri("https://localhost:5001/api/");

            await httpClient.DeleteAsync($"Imoveis/{imovel.id}");

            return View();

        }
    }
}