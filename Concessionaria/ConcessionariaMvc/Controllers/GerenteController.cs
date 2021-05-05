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
    public class GerenteController : Controller
    {

        private readonly ILogger<GerenteController> _logger;

        private Concessionaria db;

        public GerenteController(ILogger<GerenteController> logger, Concessionaria injectedContext){

            _logger = logger;
            db = injectedContext;
            
        }

        //Chamada assíncrona para otimizar desempenho 
        public async Task<IActionResult> Gerentes(){

            var model = new GerenteViewModel{
                Gerentes = await db.Gerentes.ToListAsync()

            };

            return View(model);
            
        }


        public IActionResult AddGerente(){
            return View();

        }

        [HttpPost]
        public IActionResult AddGerente(Gerente gerente){

            //Verificação da validade do modelo para inserção no banco de dados
            if(ModelState.IsValid){
                db.Gerentes.Add(gerente);
                db.SaveChanges();
            }

            return View();

        }

        public IActionResult ConsultaGerente(){
            return View();

        }


        [HttpPost]
        public IActionResult ConsultaGerente(int? id){

            if(!id.HasValue){
                return NotFound("Digite um id válido.");

            }

            //Busca do gerente por id
            Gerente gerente = db.Gerentes.SingleOrDefault(gerente => gerente.GerenteID == id);
            if(gerente == null){
                return NotFound("Gerente não encontrado. Digite um id presente na base de dados.");

            }

            return View(gerente);
            
        }

        public IActionResult DeletaGerente(){
            return View();

        }

        [HttpPost]
        public IActionResult DeletaGerente(int? id){

            if(!id.HasValue){
                return NotFound("Digite um id válido.");

            }

            //Busca do gerente por id para remoção da base de dados
            Gerente gerente = db.Gerentes.SingleOrDefault(gerente => gerente.GerenteID == id);
            if(gerente == null){
                return NotFound("Gerente não encontrado. Digite um id presente na base de dados.");

            }else{
                db.Gerentes.Remove(gerente);
                db.SaveChanges();

            }

            return View();


        }

        
    }
}