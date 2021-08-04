using System.Linq;
using ImobiliariaContext;
using ImobiliariaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class DonoController : Controller
    {

        private Imobiliaria db;
        private readonly ILogger<DonoController> _logger;

        public DonoController(ILogger<DonoController> logger, Imobiliaria injectedContext){

            _logger = logger;
            db = injectedContext;

        }

        [HttpGet]
        public IActionResult Donos(){

            var model = new DonoViewModel{
                Donos = db.Donos.ToList()

            };

            return View(model);
            
        }
    }
}