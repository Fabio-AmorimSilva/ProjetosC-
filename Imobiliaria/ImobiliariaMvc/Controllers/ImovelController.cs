using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class ImovelController : Controller
    {
        private readonly ILogger<ImovelController> _logger;

        public ImovelController(ILogger<ImovelController> logger){

            _logger = logger;
            
        }
        
    }
}