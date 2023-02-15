using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Services;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {
        public ITurmaService _service;

        public TurmaController(ITurmaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<TurmaDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_service.FindAll());
        }


        [HttpGet]
        [Route("FindByID")]
        [ProducesResponseType((200), Type = typeof(TurmaDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindByID([FromQuery] int id)
        {
            return Ok(_service.FindByID(id));
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((200), Type = typeof(TurmaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] TurmaDTO turma)
        {
            if (turma == null) return BadRequest();

            return Ok(_service.Create(turma));
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType((200), Type = typeof(EscolaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update([FromBody] TurmaDTO turma)
        {
            if (turma == null) return BadRequest();
            return Ok(_service.Update(turma));
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
