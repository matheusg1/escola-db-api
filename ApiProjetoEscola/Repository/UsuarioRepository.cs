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

            var pass = ComputeHash(usuarioDto.Senha, new SHA256CryptoServiceProvider()).ToString();

            var novoUsuario = new Usuario(usuarioDto.NomeUsuario, pass, usuarioDto.NomeCompleto);

            novoUsuario.RefreshToken = GenerateRefreshToken();

            _context.Add(novoUsuario);
            _context.SaveChanges();

            return novoUsuario;
        }

        public Usuario Get(UsuarioDTO usuario)
        {
            var senhaHash = ComputeHash(usuario.Senha, new SHA256CryptoServiceProvider()).ToString();

            return _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == usuario.NomeUsuario
                && u.Senha == senhaHash);
        }

        public Result Delete(DeleteUsuarioDTO usuario)
        {
            var pass = ComputeHash(usuario.Senha, new SHA256CryptoServiceProvider()).ToString();

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

        private object ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
        public bool RevokeToken(string nomeUsuario)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.NomeUsuario == nomeUsuario);
            if (usuario == null) return false;

            usuario.RefreshToken = null;
            _context.SaveChanges();

            return true;
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

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
