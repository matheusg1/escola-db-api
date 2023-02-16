using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ApiProjetoEscola.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProjetoDbContext _context;

        public UsuarioRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public Usuario ValidateCredentials(UsuarioDTO usuario)
        {
            var pass = ComputeHash(usuario.Senha, new SHA256CryptoServiceProvider());
            return _context.Usuarios
                .FirstOrDefault(u => u.NomeUsuario == usuario.NomeUsuario && u.Senha == pass.ToString());            
        }

        public Usuario RefreshUsuarioInfo(Usuario usuario)
        {
            if(!_context.Usuarios.Any(u => u.Id == usuario.Id))
            {
                return null;
            }

            var result = _context.Usuarios.SingleOrDefault(u => u.Id == usuario.Id);

            try
            {
                _context.Entry(result).CurrentValues.SetValues(usuario);
                _context.SaveChanges();
                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private object ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);

            throw new NotImplementedException();
        }
    }
}
