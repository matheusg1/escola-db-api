using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [Route("findAll")]
        [ProducesResponseType((200), Type = typeof(List<Turma>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> FindAllAsync()
        {
            return Ok(await _service.FindAllAsync());
        }


        [HttpGet]
        [Route("findByID")]
        [ProducesResponseType((200), Type = typeof(Turma))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> FindByIDAsync([FromQuery] int id)
        {
            return Ok(await _service.FindByIDAsync(id));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType((200), Type = typeof(Turma))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] Turma turma)
        {
            if (turma == null) return BadRequest();

            return Ok(_service.Create(turma));
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType((200), Type = typeof(Turma))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update([FromBody] Turma turma)
        {
            if (turma == null) return BadRequest();
            return Ok(_service.Update(turma));
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
