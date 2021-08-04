using System.Linq;
using ImobiliariaContext;
using ImobiliariaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class ImovelController : Controller
    {

        private Imobiliaria db;
        private readonly ILogger<ImovelController> _logger;

        public ImovelController(ILogger<ImovelController> logger, Imobiliaria injectedContext){

            _logger = logger;
            db = injectedContext;
            
        }

        [HttpGet]
        public IActionResult Imoveis(){

            var model = new ImovelViewModel{
                Imoveis = db.Imoveis.ToList()
            };

            return View(model);
            
        }
        
    }
}