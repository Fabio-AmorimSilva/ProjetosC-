using System.Collections.Generic;
using System.Threading.Tasks;
using ConcessionariaEntitiesLib;
using ConcessionariaService.Carros;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : Controller
    {
        private ICarros repoCarros;

        public CarrosController(ICarros repoCarros){
            this.repoCarros = repoCarros;

        }

        [HttpGet]
        [ProducesResponseType(200,
            Type = typeof(IEnumerable<Carro>))]
        public IEnumerable<Carro> RetornaTodos(){
            return repoCarros.RetornaTodos();

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Carro))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Cria([FromBody] Carro c){

            if(c == null){
                return BadRequest();

            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);

            }

            Carro add = await repoCarros.CriaAsync(c);
            
            return View();
            
        }

        [HttpPut("id")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Atualiza(int id, Carro c){

            if(c == null || c.CarroID != id){
                return BadRequest(); //400 Bad Request

            }

            if(!ModelState.IsValid){
                return BadRequest(); //400 Bad Request

            }

            var existe = repoCarros.Retorna(id);
            if(existe == null){
                return NotFound(); //404 Resource not found

            }

            repoCarros.Atualiza(id, c);
            return new ContentResult(); 

        }
    
       

    }
}