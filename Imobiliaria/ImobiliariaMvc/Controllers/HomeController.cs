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
        private Imobiliaria ImobiliariaDb;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory clientFactory;

        

        public HomeController(
            ILogger<HomeController> logger, 
            Imobiliaria injectedContext,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            ImobiliariaDb = injectedContext;
            clientFactory = httpClientFactory;
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
