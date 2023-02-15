using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Services;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            return Ok(_service.FindAll());
        }


        [HttpGet]
        [Route("FindByID")]
        public IActionResult FindByID([FromQuery] int id)
        {
            return Ok(_service.FindByID(id));
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] TurmaDTO turma)
        {
            if (turma == null) return BadRequest();

            return Ok(_service.Create(turma));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] TurmaDTO turma)
        {
            if (turma == null) return BadRequest();
            return Ok(_service.Update(turma));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
