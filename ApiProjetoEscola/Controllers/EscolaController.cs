using ApiProjetoEscola.DTO;
using ApiProjetoEscola.DTO.Converter;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult FindAll()
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
        public IActionResult Create([FromBody] EscolaDTO escola)
        {
            if (escola == null) return BadRequest();

            return Ok(_service.Create(escola));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] EscolaDTO escola)
        {
            if (escola == null) return BadRequest();
            return Ok(_service.Update(escola));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}