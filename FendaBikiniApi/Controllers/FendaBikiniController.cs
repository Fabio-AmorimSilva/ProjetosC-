using FendaBikiniApi.Models;
using FendaBikiniApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FendaBikiniApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FendaBikiniController : ControllerBase
    {

        private readonly FendaBikiniService _fendaBikiniService;

        public FendaBikiniController(FendaBikiniService fendaBikiniService)
        {
            _fendaBikiniService = fendaBikiniService;
        }

        [HttpGet]
        public ActionResult<List<Personagens>> Get() =>
            _fendaBikiniService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPersonagem")]
        public ActionResult<Personagens> Get(string id)
        {
            var personagem = _fendaBikiniService.Get(id);

            if(personagem == null)
            {
                return NotFound();
            }

            return personagem;
        }

        [HttpPost]
        public ActionResult<Personagens> Create(Personagens personagem)
        {
            _fendaBikiniService.Create(personagem);

            return CreatedAtRoute("GetPersonagem", new { id = personagem.Id.ToString() }, personagem);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Personagens personagemIn)
        {
            var personagem = _fendaBikiniService.Get(id);

            if (personagem == null)
            {
                return NotFound();
            }

            _fendaBikiniService.Update(id, personagemIn);

            return NoContent();

        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var personagem = _fendaBikiniService.Get(id);

            if(personagem == null)
            {
                return NotFound();
            }

            _fendaBikiniService.Remove(personagem.Id);

            return NoContent();

        }


    }
}
