using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IUsuarioService
    {
        Usuario Get(UsuarioDTO usuario);
        Usuario Create(UsuarioDTO usuario);
        void Delete(int id);
    }
}
