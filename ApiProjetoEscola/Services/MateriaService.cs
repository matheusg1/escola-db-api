using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using System.Collections.Generic;
using ApiProjetoEscola.Repository.IRepository;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services
{
    public class MateriaService : IMateriaService
    {
        private IMateriaRepository _repository;

        public MateriaService(IMateriaRepository repository)
        {
            _repository = repository;
        }

        public Materia Create(Materia materia)
        {
            return _repository.Create(materia);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<List<Materia>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Materia> FindByIDAsync(int id)
        {
            return await _repository.FindByIDAsync(id);
        }

        public Materia Update(Materia materia)
        {
            return _repository.Update(materia);
        }
    }
}