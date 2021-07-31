using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class CorretorController : Controller
    {
        
        private readonly ILogger<CorretorController> _logger;

        public CorretorController(ILogger<CorretorController> logger){

            _logger = logger;

        }

        
    }
}