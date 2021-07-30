using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class DonoController : Controller
    {
        private readonly ILogger<DonoController> _logger;

        public DonoController(ILogger<DonoController> logger){

            _logger = logger;

        }

        public IActionResult Donos(){
            return View();
            
        }
    }
}