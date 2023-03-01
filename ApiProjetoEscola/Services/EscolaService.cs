using ApiProjetoEscola.Model;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services
{
    public class EscolaService : IEscolaService
    {
        private IEscolaRepository _repository;

        public EscolaService(IEscolaRepository repository)
        {
            _repository = repository;
        }
        public Escola Create(Escola escola)
        {
            return _repository.Create(escola);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<List<Escola>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Escola> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public Escola Update(Escola escola)
        {
            return _repository.Update(escola);
        }
    }
}