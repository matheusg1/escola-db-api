using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IUsuarioService
    {
        Usuario Get(UsuarioDTO usuario);
        Usuario Create(UsuarioDTO usuario);
        Result Delete(DeleteUsuarioDTO usuario);
    }
}
