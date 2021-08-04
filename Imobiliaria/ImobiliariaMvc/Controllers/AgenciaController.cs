using System.Linq;
using ImobiliariaContext;
using ImobiliariaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class AgenciaController : Controller
    {
        
        private Imobiliaria db;

        private readonly ILogger<AgenciaController> _logger;

        public AgenciaController(ILogger<AgenciaController> logger, Imobiliaria injectedContext){

            _logger = logger;
            db = injectedContext;

        }

        [HttpGet]
        public IActionResult Agencias(){

            var model = new AgenciaViewModel{
                Agencias = db.Agencias.ToList()

            };
           

            return View(model);

        }
    }
}