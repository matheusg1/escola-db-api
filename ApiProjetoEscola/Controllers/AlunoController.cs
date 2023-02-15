using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Services;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        public IAlunoService _service;

        public AlunoController(IAlunoService service)
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
        public IActionResult Create([FromBody] AlunoDTO aluno)
        {
            if (aluno == null) return BadRequest();
            return Ok(_service.Create(aluno));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] AlunoDTO aluno)
        {
            if (aluno == null) return BadRequest();
            return Ok(_service.Update(aluno));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
