using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.Services;
using FluentResults;
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

        public Usuario Create(UsuarioDTO usuarioDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == usuarioDto.NomeUsuario);

            if (usuario != null)
            {
                return null;
            }

            var pass = IService.ComputeHash(usuarioDto.Senha, new SHA256CryptoServiceProvider()).ToString();

            var novoUsuario = new Usuario(usuarioDto.NomeUsuario, pass, usuarioDto.NomeCompleto);

            novoUsuario.RefreshToken = IService.GenerateRefreshToken();

            _context.Add(novoUsuario);
            _context.SaveChanges();

            return novoUsuario;
        }

        public Usuario Get(UsuarioDTO usuario)
        {
            var senhaHash = IService.ComputeHash(usuario.Senha, new SHA256CryptoServiceProvider()).ToString();

            return _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == usuario.NomeUsuario
                && u.Senha == senhaHash);
        }

        public Result Delete(DeleteUsuarioDTO usuario)
        {
            var pass = IService.ComputeHash(usuario.Senha, new SHA256CryptoServiceProvider()).ToString();

            var result = _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == usuario.NomeUsuario);            

            if(result == null)
            {
                return Result.Fail("Usuário não encontrado");
            }

            if (result.Senha != pass)
            {
                return Result.Fail("Senha inválida");
            }

            _context.Usuarios.Remove(result);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Usuario RefreshUsuarioInfo(Usuario usuario)
        {
            if (!_context.Usuarios.Any(u => u.Id == usuario.Id))
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
    }
}
