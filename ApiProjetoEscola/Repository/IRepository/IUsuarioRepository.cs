using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using FluentResults;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        Usuario Get(UsuarioDTO usuario);
        public Usuario Create(UsuarioDTO usuarioDto);
        public Result Delete(DeleteUsuarioDTO usuario);
        Usuario RefreshUsuarioInfo(Usuario usuario);
        bool RevokeToken(string nomeUsuario);
        public void SaveRefreshToken(string nomeUsuario, string refreshToken);
        public string GetRefreshToken(string nomeUsuario);
        public void DeleteRefreshToken(string nomeUsuario, string refreshToken);        
    }
}
