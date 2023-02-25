using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    //[Authorize("Bearer")]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        public IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Aluno>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_service.FindAll());
        }

        [HttpGet]
        [Route("FindByID")]
        [ProducesResponseType((200), Type = typeof(Aluno))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindByID([FromQuery] int id)
        {
            return Ok(_service.FindByID(id));
        }

        [HttpGet]
        [Route("FindByName")]
        [ProducesResponseType((200), Type = typeof(List<Aluno>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindByName([FromQuery] string nome, [FromQuery] string sobrenome)
        {
            var aluno = _service.FindByName(nome, sobrenome);
            if (aluno == null) return NotFound();

            return Ok(aluno);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((200), Type = typeof(Aluno))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] Aluno aluno)
        {
            if (aluno == null) return BadRequest();
            return Ok(_service.Create(aluno));
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType((200), Type = typeof(Aluno))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update([FromBody] Aluno aluno)
        {
            if (aluno == null) return BadRequest();
            return Ok(_service.Update(aluno));
        }

        [HttpDelete]
        [Route("Delete")]
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
