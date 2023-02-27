using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [Route("findAll")]
        [ProducesResponseType((200), Type = typeof(List<Aluno>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> FindAllAsync()
        {
            return Ok(await _service.FindAllAsync());
        }

        [HttpGet]
        [Route("findByID")]
        [ProducesResponseType((200), Type = typeof(Aluno))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindByID([FromQuery] int id)
        {
            return Ok(_service.FindByID(id));
        }

        [HttpGet]
        [Route("findByName")]
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
        [Route("create")]
        [ProducesResponseType((200), Type = typeof(Aluno))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] Aluno aluno)
        {
            if (aluno == null) return BadRequest();
            return Ok(_service.Create(aluno));
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType((200), Type = typeof(Aluno))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update([FromBody] Aluno aluno)
        {
            if (aluno == null) return BadRequest();
            return Ok(_service.Update(aluno));
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
