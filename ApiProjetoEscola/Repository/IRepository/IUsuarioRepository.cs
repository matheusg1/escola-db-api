using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services;
using FluentResults;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IUsuarioRepository : IService
    {
        Usuario Get(UsuarioDTO usuario);
        public Usuario Create(UsuarioDTO usuarioDto);
        public Result Delete(DeleteUsuarioDTO usuario);
        Usuario RefreshUsuarioInfo(Usuario usuario);
    }
}
