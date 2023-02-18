using ApiProjetoEscola.Configurations;
using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.TokenServices.ITokenServices;
using Microsoft.Extensions.Configuration;
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

        public Usuario CreateUsuario(UsuarioDTO usuarioDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == usuarioDto.NomeUsuario);
            
            if (usuario != null)
            {
                return null;
            }

            var pass = ComputeHash(usuarioDto.Senha, new SHA256CryptoServiceProvider()).ToString();

            var novoUsuario = new Usuario
            {
                NomeUsuario = usuarioDto.NomeUsuario,
                Senha = pass,
            };

            return novoUsuario;
        }
        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario ValidateCredentials(UsuarioDTO usuario)
        {
            var pass = ComputeHash(usuario.Senha, new SHA256CryptoServiceProvider());
            return _context.Usuarios
                .FirstOrDefault(u => u.NomeUsuario == usuario.NomeUsuario && u.Senha == pass.ToString());            
        }

        public Usuario ValidateCredentials(string nomeUsuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == nomeUsuario);
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
        }

        /*
        public bool RevokeToken(string nomeUsuario)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.NomeUsuario == nomeUsuario);
            if (usuario == null) return false;

            usuario.RefreshToken = null;
            _context.SaveChanges();
            
            return true;
        }
        */
    }
}
