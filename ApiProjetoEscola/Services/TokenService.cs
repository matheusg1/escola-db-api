using ApiProjetoEscola.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System;
using ApiProjetoEscola.Services.IServices;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using ApiProjetoEscola.Repository.IRepository;

namespace ApiProjetoEscola.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;
        private IUsuarioRepository _repository;

        public TokenService(IConfiguration configuration, IUsuarioRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public string GenerateToken(Usuario usuario)
        {
            var config = _configuration.GetSection("TokenConfigurations");
            var hours = int.Parse(config["Hours"]);
            var minutes = int.Parse(config["Minutes"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.NomeUsuario)
                }),
                Expires = DateTime.UtcNow.AddHours(hours).AddMinutes(minutes),                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("TokenConfigurations")["Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("TokenConfigurations")["Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCulture))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }
        public string GetRefreshToken(string nomeUsuario)
        {
            return _repository.GetRefreshToken(nomeUsuario);
        }
        public void SaveRefreshToken(string nomeUsuario, string refreshToken)
        {
            _repository.SaveRefreshToken(nomeUsuario, refreshToken);
        }
        public void DeleteRefreshToken(string nomeUsuario, string refreshToken)
        {
            _repository.DeleteRefreshToken(nomeUsuario, refreshToken);
        }

        public object ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

    }
}
