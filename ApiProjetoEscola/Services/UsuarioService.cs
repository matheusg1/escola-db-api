using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.Services.IServices;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario Get(UsuarioDTO usuarioDto)
        {
            return _repository.Get(usuarioDto);            
        }

        public Usuario Create(UsuarioDTO usuario)
        {
            return _repository.Create(usuario);
        }

        public Result Delete(DeleteUsuarioDTO usuario)
        {
            return _repository.Delete(usuario);
        }
    }
}
