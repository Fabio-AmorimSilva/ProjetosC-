using System.Linq;
using System.Threading.Tasks;
using ConcessionariaContextLib;
using ConcessionariaEntitiesLib;
using ConcessionariaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConcessionariaMvc.Controllers
{
    public class CarroController : Controller
    {

        private readonly ILogger<CarroController> _logger;

        private Concessionaria db;

        public CarroController(ILogger<CarroController> logger, Concessionaria injectedContext){

            _logger = logger;
            db = injectedContext;

        }

        public async Task<IActionResult> Carros(){

            var model = new CarroViewModel{
                Carros = await db.Carros.ToListAsync()
            };

            return View(model);

        }

        public IActionResult AddCarro(Carro carro){

            if(ModelState.IsValid){
                db.Carros.Add(carro);
                db.SaveChangesAsync();
                return View("/Carros");
            }


            return View();

        }

        public IActionResult ConsultaCarro(int? id){

            Carro carroBusca = db.Carros.SingleOrDefault(carro => carro.CarroID == id); 
            if(carroBusca == null){
                return NotFound("Carro não encontrado na base de dados. Por favor inserir outro id");

            }

            return View();

        }

        public IActionResult DeletaCarro(int? id){

            Carro carroBusca = db.Carros.SingleOrDefault(carro => carro.CarroID == id);
            if(carroBusca == null){
                return NotFound("Carro não encontrado na base dados. Por favor, inserir outro id");

            }else{

                db.Carros.Remove(carroBusca);
                db.SaveChangesAsync();
                return View();

            }

        }
        
    }
}