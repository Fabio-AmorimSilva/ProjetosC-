using System.Linq;
using ImobiliariaContext;
using ImobiliariaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class CorretorController : Controller
    {
        
        private Imobiliaria db;
        private readonly ILogger<CorretorController> _logger;

        public CorretorController(ILogger<CorretorController> logger, Imobiliaria injectedContext){

            _logger = logger;
            db = injectedContext;

        }

        [HttpGet]
        public IActionResult Corretores(){

            var model = new CorretorViewModel{
                Corretores = db.Corretores.ToList()

            };

            return View(model);
        }

        
    }
}