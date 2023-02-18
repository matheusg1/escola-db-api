using ApiProjetoEscola.Configurations;
using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.Services.IServices;
using ApiProjetoEscola.TokenServices.ITokenServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ApiProjetoEscola.Services
{
    public class LoginService : ILoginService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUsuarioRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginService(TokenConfiguration configuration, IUsuarioRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenDTO CreateUsuario(UsuarioDTO usuarioDto)
        {
            var usuario = _repository.CreateUsuario(usuarioDto);

            if (usuario == null)
            {
                return null;

            }

            try
            {
                _repository.Add(usuario);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return ValidateCredentials(usuarioDto);
        }

        public TokenDTO ValidateCredentials(UsuarioDTO usuarioCredentials)
        {
            var usuario = _repository.ValidateCredentials(usuarioCredentials);
            if (usuario == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.NomeUsuario)

            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            _repository.RefreshUsuarioInfo(usuario);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken
                );
        }

        public TokenDTO ValidateCredentials(TokenDTO token)
        {
            var accessToken = token.AccessToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var nomeUsuario = principal.Identity.Name;

            var usuario = _repository.ValidateCredentials(nomeUsuario);

            if (usuario == null)
            {
                return null;
            }

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);

            _repository.RefreshUsuarioInfo(usuario);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken
                );
        }
        /*
        public bool RevokeToken(string nomeUsuario)
        {
            return _repository.RevokeToken(nomeUsuario);
        }
        */
    }
}