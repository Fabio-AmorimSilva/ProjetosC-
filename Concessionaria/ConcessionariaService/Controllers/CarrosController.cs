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
       

    }
}