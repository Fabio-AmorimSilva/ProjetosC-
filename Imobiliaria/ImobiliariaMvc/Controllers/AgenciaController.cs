using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class AgenciaController : Controller
    {
        
        private readonly ILogger<AgenciaController> _logger;

        public AgenciaController(ILogger<AgenciaController> logger){

            _logger = logger;

        }

        public IActionResult Agencias(){
            return View();

        }
    }
}