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

namespace ConcessionariaMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            clientFactory = httpClientFactory;
        
        }

        public IActionResult Index(HomeViewModel home)
        {
            var data = home;
            return View(data);
        }

        public async Task<IActionResult> Carros(HttpContext context, RequestDelegate next){

            string uri = $"api/Carros";
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
