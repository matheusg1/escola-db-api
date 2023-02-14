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
    }
}
