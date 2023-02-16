﻿using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Services.IServices;
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

        [HttpPost]
        [Route("Refresh")]
        public IActionResult Refresh([FromBody] TokenDTO tokenDTO)
        {
            if (tokenDTO == null) return BadRequest("Invalid client request");

            var token = _loginService.ValidateCredentials(tokenDTO);

            if (token == null) return BadRequest("Invalid client request");

            return Ok(token);
        }
    }
}
