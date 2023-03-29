using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            var refreshToken = IService.GenerateRefreshToken();
            _tokenService.SaveRefreshToken(usuario.NomeUsuario, refreshToken);

            usuario.Senha = "";

            return Ok(new { usuario, token });
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] RefreshTokenDTO refreshToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(refreshToken.Token);
            var username = principal.Identity.Name;
            var savedRefreshToken = _tokenService.GetRefreshToken(username);

            if(savedRefreshToken != refreshToken.RefreshToken)
            
                throw new SecurityTokenException("Invalid refresh token");

            var newJwtToken = _tokenService.GenerateToken(principal.Claims);
            var newRefreshToken = IService.GenerateRefreshToken();

            _tokenService.DeleteRefreshToken(username, refreshToken.RefreshToken);
            _tokenService.SaveRefreshToken(username, newRefreshToken);

            return Ok(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }
    }
}
