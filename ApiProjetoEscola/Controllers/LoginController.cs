using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public IUsuarioService _usuarioService;
        public ITokenService _tokenService;

        public LoginController(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioDTO usuarioDto)
        {
            var usuario = _usuarioService.Get(usuarioDto);

            if (usuario == null)
            {
                return NotFound();
            }

            var token = _tokenService.GenerateToken(usuario);
            usuario.Senha = "";

            return Ok(new { usuario, token });
        }
    }
}
