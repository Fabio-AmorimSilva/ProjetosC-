using System.Collections.Generic;
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

       

    }
}