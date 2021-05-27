using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConcessionariaMvc.Models;
using System.Net.Http;
using System.Net.Http.Json;
using ConcessionariaEntitiesLib;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Text.Json;
using ConcessionariaContextLib;

namespace ConcessionariaMvc.Controllers
{
    public class HomeController : Controller
    {

        private Concessionaria db;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory clientFactory;

        private readonly HttpClient _httpClient;

        private JsonSerializerOptions JsonConvert;


        public HomeController(ILogger<HomeController> logger, Concessionaria injectedContext, IHttpClientFactory httpClientFactory, HttpClient client)
        {
            _logger = logger;
            db = injectedContext;
            clientFactory = httpClientFactory;
            _httpClient = client;
        }

        public IActionResult Index(HomeViewModel home)
        {
            var data = home;
            return View(data);
        }

        public async Task<IActionResult> Carros(){

            string uri = "api/Carros";
            var client = clientFactory.CreateClient(
                name: "ConcessionariaService"
            );

            var request = new HttpRequestMessage(
                method: HttpMethod.Get, requestUri: uri
            );

            HttpResponseMessage response = await client.SendAsync(request);

            var model = await response.Content.ReadFromJsonAsync<IEnumerable<Carro>>();

            return View(model);

            
        }

        public IActionResult AddC(){
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddC(Carro carro){

         await _httpClient.PostAsJsonAsync<Carro>("https://localhost:5001/api/Carros", carro);

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
