using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ApiProjetoEscola.Services.IServices
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
        string GenerateToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string GetRefreshToken(string nomeUsuario);
        void SaveRefreshToken(string nomeUsuario, string refreshToken);
        public void DeleteRefreshToken(string nomeUsuario, string refreshToken);
        object ComputeHash(string input, SHA256CryptoServiceProvider algorithm);
    }
}