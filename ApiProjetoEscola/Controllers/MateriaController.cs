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
    }
}
