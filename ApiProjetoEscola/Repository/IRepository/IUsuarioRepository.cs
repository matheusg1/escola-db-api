using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        Usuario ValidateCredentials(UsuarioDTO usuario);
        Usuario ValidateCredentials(string nomeUsuario);
        bool RevokeToken(string nomeUsuario);
        Usuario RefreshUsuarioInfo(Usuario usuario);
    }
}
