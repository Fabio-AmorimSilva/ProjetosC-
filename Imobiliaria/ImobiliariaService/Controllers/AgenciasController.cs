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
                return BadRequest(400);

            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            repo.InsereAgencia(agencia);

            return StatusCode(200);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Agencia))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult AlteraAgencia(int id, Agencia agencia){

            if(id != agencia.id){
                return NotFound(404);

            }

            if(agencia == null){
                return BadRequest(400);

            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            repo.AlteraAgencia(id, agencia);
            return StatusCode(200);

            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeletaAgencia(int id){

            var status = repo.DeletaAgencia(id);
            if(status == false){
                return NotFound(404);

            }

            return StatusCode(200);

        }
        
    }
}