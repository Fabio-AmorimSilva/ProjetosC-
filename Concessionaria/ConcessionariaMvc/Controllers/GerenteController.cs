using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConcessionariaMvc.Controllers
{
    public class GerenteController : Controller
    {

        private readonly ILogger<GerenteController> _logger;

        public GerenteController(ILogger<GerenteController> logger){

            _logger = logger;
            
        }

        public IActionResult Gerentes(){
            return View();
            
        }
        
    }
}