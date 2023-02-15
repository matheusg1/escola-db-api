using ApiProjetoEscola.DTO;
using ApiProjetoEscola.DTO.Converter;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EscolaController : ControllerBase
    {
        public IEscolaService _service;

        public EscolaController(IEscolaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<EscolaDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindAll()
        {
            return Ok(_service.FindAll());
        }

        [HttpGet]
        [Route("FindByID")]
        [ProducesResponseType((200), Type = typeof(EscolaDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindByID([FromQuery] int id)
        {
            return Ok(_service.FindByID(id));
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((200), Type = typeof(EscolaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] EscolaDTO escola)
        {
            if (escola == null) return BadRequest();

            return Ok(_service.Create(escola));
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType((200), Type = typeof(EscolaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update([FromBody] EscolaDTO escola)
        {
            if (escola == null) return BadRequest();
            return Ok(_service.Update(escola));
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}