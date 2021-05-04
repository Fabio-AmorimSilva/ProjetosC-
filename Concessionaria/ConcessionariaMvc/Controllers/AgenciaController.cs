using System.Threading.Tasks;
using ConcessionariaContextLib;
using ConcessionariaEntitiesLib;
using ConcessionariaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConcessionariaMvc.Controllers
{
    public class AgenciaController : Controller
    {
        
        private readonly ILogger<AgenciaController> _logger;

        private Concessionaria db;

        public AgenciaController(ILogger<AgenciaController> logger, Concessionaria injectedContext){

            _logger = logger;
            db = injectedContext;

        }

        public async Task<IActionResult> Agencias(){

            var model = new AgenciaViewModel{
                Agencias = await db.Agencias.ToListAsync()
            };
            
            return View(model);

        }

        public IActionResult AddAgencia(){
            return View();

        }

        [HttpPost]
        public IActionResult AddAgencia(Agencia agencia){

            if(ModelState.IsValid){
                db.Agencias.Add(agencia);
                db.SaveChanges();

            }

            return View();

        }

    }
}