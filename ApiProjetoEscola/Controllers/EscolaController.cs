using ApiProjetoEscola.Model;
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
        [Route("findAll")]
        [ProducesResponseType((200), Type = typeof(List<Escola>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindAll()
        {
            return Ok(_service.FindAll());
        }

        [HttpGet]
        [Route("findByID")]
        [ProducesResponseType((200), Type = typeof(Escola))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindByID([FromQuery] int id)
        {
            return Ok(_service.FindByID(id));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType((200), Type = typeof(Escola))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] Escola escola)
        {
            if (escola == null) return BadRequest();

            return Ok(_service.Create(escola));
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType((200), Type = typeof(Escola))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update([FromBody] Escola escola)
        {
            if (escola == null) return BadRequest();
            return Ok(_service.Update(escola));
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete([FromQuery] int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}