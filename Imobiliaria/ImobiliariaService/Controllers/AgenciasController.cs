using System.Collections.Generic;
using ImobiliariaEntities;
using ImobiliariaService.Agencias;
using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : Controller
    {
        private IAgencias repo;

        public AgenciasController(IAgencias repo){
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Agencia>))]
        public IEnumerable<Agencia> RetornaTodas(){
            return repo.RetornaTodas();

        }

        [HttpPost("{id}")]
        [ProducesResponseType(200, Type = typeof(Agencia))]
        [ProducesResponseType(400)]
        public IActionResult InsereAgencia([FromBody] Agencia agencia){

            if(agencia == null){
                return BadRequest();

            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            repo.InsereAgencia(agencia);

            return View();

        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult AlteraAgencia(int id, Agencia agencia){

            if(id != agencia.id){
                return NotFound();

            }

            if(agencia == null){
                return BadRequest();

            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            repo.AlteraAgencia(id, agencia);
            return View();

            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletaAgencia(int id){

            var state = repo.DeletaAgencia(id);
            if(state == true){
                return View();

            }

            return NotFound();

        }
        
    }
}