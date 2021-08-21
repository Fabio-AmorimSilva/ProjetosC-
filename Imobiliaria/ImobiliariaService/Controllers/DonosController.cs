using System.Collections.Generic;
using ImobiliariaEntities;
using ImobiliariaService.Donos;
using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DonosController : Controller
    {
        
        private IDonos repo;

        public DonosController(IDonos repo){
            this.repo = repo;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Dono>))]
        public IEnumerable<Dono> RetornaTodos(){
            return repo.RetornaTodos();

        }

        [HttpPost("{id}")]
        [ProducesResponseType(200, Type = typeof(Dono))]
        [ProducesResponseType(400)]
        public IActionResult InsereDono(Dono dono){

            if(dono == null){
                return BadRequest(400);

            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            repo.InsereDono(dono);
            return StatusCode(200);

        }


        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Dono))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult AlteraDono(int id, Dono dono){

            if(dono == null){
                return BadRequest(400);

            }

            if(id != dono.id){
                return NotFound(404);

            }

            repo.AlteraDono(id, dono);
            return StatusCode(200);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeletaDono(int id){

            bool status = repo.DeletaDono(id);
            if(status == false){
                return NotFound(404);

            }

            return StatusCode(200);

        }

        
    }
}