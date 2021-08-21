using System.Collections.Generic;
using System.Threading.Tasks;
using ImobiliariaEntities;
using ImobiliariaService.Corretores;
using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorretoresController : Controller
    {

        private ICorretores repo;

        public CorretoresController(ICorretores repo){
            this.repo = repo;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Corretor>))]
        public IEnumerable<Corretor> RetornaRodos(){
            return repo.RetornaTodos();
        }

        [HttpPost("{id}")]
        [ProducesResponseType(200, Type = typeof(Corretor))]
        [ProducesResponseType(400)]
        public IActionResult InsereCorretor([FromBody] Corretor corretor){
            
            if(corretor == null){
                return BadRequest(400);

            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            repo.InsereCorretor(corretor);

            return StatusCode(200);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Corretor))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult AlteraCorretor(int id, Corretor corretor){

             if(corretor == null){
                return BadRequest(400);

            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            if(id != corretor.id){
                return NotFound(404);

            }

            repo.AlteraCorretor(id, corretor);

            return StatusCode(200);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeletaCorretor(int id){

            bool status = repo.DeletaCorretor(id);

            if(status == false){
                return NotFound(404);

            }

            return StatusCode(200);
            
        }


    }
}