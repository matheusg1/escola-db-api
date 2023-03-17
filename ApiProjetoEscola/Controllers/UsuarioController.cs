using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(UsuarioDTO usuario)
        {
            var result = _service.Create(usuario);
            result.Senha = "";
            return Ok(result);
        }
        /*
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromQuery] DeleteUsuarioDTO usuario)
        {
            Result result = _service.Delete(usuario);

            if (result.IsFailed)
            {
                var mensagemErro = result.Errors[0].Message;

                if (mensagemErro.Contains("Usuário")) return NotFound(mensagemErro);
                else if (mensagemErro.Contains("Senha")) return Unauthorized(mensagemErro);                
            }

            return Ok("Usuário deletado");
        }*/
    }
}
