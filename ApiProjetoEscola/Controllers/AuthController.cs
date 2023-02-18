using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoEscola.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn([FromBody] UsuarioDTO usuario)
        {
            if (User == null) return BadRequest("Invalid client request");

            var token = _loginService.ValidateCredentials(usuario);
            
            if (token == null) return Unauthorized();
            
            return Ok(token);
        }
        /*
        [HttpPost]
        [Route("Refresh")]
        public IActionResult Refresh([FromBody] RefreshTokenDTO RefreshTokenDTO)
        {
            var tokenDTO = new TokenDTO
            {
                AccessToken = RefreshTokenDTO.accessToken,
                RefreshToken = RefreshTokenDTO.refreshToken                
            };

            if (tokenDTO == null) return BadRequest("Invalid client request");

            var token = _loginService.ValidateCredentials(tokenDTO);

            if (token == null) return BadRequest("Invalid client request");

            return Ok(token);
        }

        [HttpGet]
        [Route("Revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var nomeUsuario = User.Identity.Name;
            var result = _loginService.RevokeToken(nomeUsuario);

            if (!result) return BadRequest("Invalid client request");        

            return NoContent();
        }
        */
        [HttpPost]
        [Route("CreateUsuario")]
        public IActionResult CreateUsuario([FromBody] UsuarioDTO usuario)
        {
            var result = _loginService.CreateUsuario(usuario);
            if(result == null)
            {
                return null;
            }
            return Ok(result);
        }
    }
}
