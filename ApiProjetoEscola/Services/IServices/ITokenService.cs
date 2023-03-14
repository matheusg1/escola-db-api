using ApiProjetoEscola.Model;
using System.Security.Cryptography;

namespace ApiProjetoEscola.Services.IServices
{
    public interface ITokenService
    {
        public string GenerateToken(Usuario usuario);
        object ComputeHash(string input, SHA256CryptoServiceProvider algorithm);
    }
}