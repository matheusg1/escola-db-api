using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        Usuario Get(UsuarioDTO usuario);
        public void Add(Usuario usuario);
        public Usuario Create(UsuarioDTO usuarioDto);
        Usuario ValidateCredentials(UsuarioDTO usuario);
        Usuario ValidateCredentials(string nomeUsuario);
        Usuario RefreshUsuarioInfo(Usuario usuario);
        bool RevokeToken(string nomeUsuario);
        public string GetRefreshToken(string nomeUsuario);
        public void DeleteRefreshToken(string nomeUsuario, string refreshToken);
        
    }
}
