using System.Collections.Generic;
using ImobiliariaEntities;
using ImobiliariaService.Imoveis;
using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ImoveisController : Controller
    {

        private IImoveis repo;

        public ImoveisController(IImoveis repo){
            this.repo = repo;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Imovel>))]
        public IEnumerable<Imovel> RetornaTodos(){
            return repo.RetornaTodos();

        }

        [HttpPost("{id}")]
        [ProducesResponseType(200, Type = typeof(Imovel))]
        [ProducesResponseType(400)]
        public IActionResult InsereImovel(Imovel imovel){

            if(imovel == null){
                return BadRequest(400);

            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            repo.InsereImovel(imovel);
            return StatusCode(200);


        } 

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Imovel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult AlteraImovel(int id, Imovel imovel){

            if(imovel == null){
                return BadRequest(400);

            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            if(id != imovel.id){
                return NotFound(404);

            }

            
            repo.AlteraImovel(id, imovel);
            return StatusCode(200);

        }       

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeletaImovel(int id){

            bool status = repo.DeletaImovel(id);

            if(status == false){
                return NotFound(404);

            }

            return StatusCode(200);

        }
        
        
    }
}