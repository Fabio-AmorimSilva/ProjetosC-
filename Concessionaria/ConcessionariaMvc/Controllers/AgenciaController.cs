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
    public class AgenciaController : Controller
    {
        
        private readonly ILogger<AgenciaController> _logger;

        private Concessionaria db;

        public AgenciaController(ILogger<AgenciaController> logger, Concessionaria injectedContext){

            _logger = logger;
            db = injectedContext;

        }

        public async Task<IActionResult> Agencias(){

            //Listagem assíncrona para aumentar a eficiência e desempenho do sistema
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

            //Verificação se o modelo enviado é válido
            if(ModelState.IsValid){
                db.Agencias.Add(agencia);
                db.SaveChanges();

            }

            return View();

        }

        public IActionResult ConsultaAgencia(){
            return View();

        }

        [HttpPost]
        public IActionResult ConsultaAgencia(int? id){

            if(!id.HasValue){
                return NotFound("Digite um id válido.");

            }

            //Busca de agência na base de dados por id
            Agencia agencia = db.Agencias.SingleOrDefault(agencia => agencia.AgenciaID == id);
            if(agencia == null){
                return NotFound("Agência não encontrada. Digite um id presente na base de dados.");
            }

            return View(agencia);

        }

        public IActionResult DeletaAgencia(){
            return View();

        }

        [HttpPost]
        public IActionResult DeletaAgencia(int? id){

            if(!id.HasValue){
                return NotFound("Digite um valor válido.");

            }

            //Busca da agência na base de dados por id
            Agencia agencia = db.Agencias.SingleOrDefault(agencia => agencia.AgenciaID == id);
            if(agencia == null){
                return NotFound("Agência não encontrada. Digite um id presente na base de dados.");

            }else{

                //Remoção da agência da base de dados
                db.Agencias.Remove(agencia);
                db.SaveChanges();
            }

            return View();

        }

    }
}