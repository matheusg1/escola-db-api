using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        Usuario ValidateCredentials(UsuarioDTO usuario);
        Usuario RefreshUsuarioInfo(Usuario usuario);
    }
}
