using System.Linq;
using ImobiliariaContext;
using ImobiliariaEntities;
using ImobiliariaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImobiliariaMvc.Controllers
{
    public class AgenciaController : Controller
    {
        
        private Imobiliaria db;

        private readonly ILogger<AgenciaController> _logger;

        public AgenciaController(ILogger<AgenciaController> logger, Imobiliaria injectedContext){

            _logger = logger;
            db = injectedContext;

        }

        [HttpGet]
        public IActionResult Agencias(){

            var model = new AgenciaViewModel{
                Agencias = db.Agencias.ToList()

            };
           

            return View(model);

        }

        public IActionResult AddAgencia(){

            return View();
        }

        [HttpPost]
        public IActionResult AddAgencia(Agencia agencia){

            var agenciaAux = db.Agencias.SingleOrDefault(a => a.id == agencia.id);
            if(agenciaAux == null){
                db.Agencias.Add(agencia);
                db.SaveChanges();

            }

            return View();

        }

        public IActionResult AlteraAgencia(){

            return View();

        }

        [HttpPost]
        public IActionResult AlteraAgencia(Agencia agencia){

            var agenciaAux = db.Agencias.SingleOrDefault(a => a.id == agencia.id);
            if(agenciaAux != null){
                agenciaAux.nome = agencia.nome;
                agenciaAux.cidade = agencia.cidade;
                agenciaAux.idCorretores = agencia.idCorretores;
                agenciaAux.idImoveis = agencia.idImoveis;
                db.SaveChanges();

            }

            return View();

        }

        public IActionResult DeletaAgencia(){

            return View();

        }

        [HttpPost]
        public IActionResult DeletaAgencia(Agencia agencia){

            var agenciaAux = db.Agencias.SingleOrDefault(a => a.id == agencia.id);
            if(agenciaAux != null){
                db.Agencias.Remove(agenciaAux);
                db.SaveChanges();

            }

            return View();

        }
    }
}