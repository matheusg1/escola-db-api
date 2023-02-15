using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Services;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriaController : ControllerBase
    {
        public IMateriaService _service;

        public MateriaController(IMateriaService service)
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
        public IActionResult Create([FromBody] MateriaDTO materia)
        {
            if (materia == null) return BadRequest();

            return Ok(_service.Create(materia));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] MateriaDTO materia)
        {
            if (materia == null) return BadRequest();
            return Ok(_service.Update(materia));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
