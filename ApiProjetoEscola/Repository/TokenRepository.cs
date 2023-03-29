using ApiProjetoEscola.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiProjetoEscola.Repository
{
    public class TokenRepository
    {
        private readonly ProjetoDbContext _context;

        public TokenRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public void SaveRefreshToken(string nomeUsuario, string refreshToken)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == nomeUsuario);
            usuario.RefreshToken = refreshToken;
            _context.SaveChanges();
        }

        public string GetRefreshToken(string nomeUsuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == nomeUsuario).RefreshToken;
        }

        public void DeleteRefreshToken(string nomeUsuario, string refreshToken)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == nomeUsuario
                && u.RefreshToken == refreshToken);

            usuario.RefreshToken = null;
            _context.SaveChanges();
        }

        public bool RevokeToken(string nomeUsuario)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.NomeUsuario == nomeUsuario);
            if (usuario == null) return false;

            usuario.RefreshToken = null;
            _context.SaveChanges();

            return true;
        }
    }
}
