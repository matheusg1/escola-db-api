using ApiProjetoEscola.Model;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.Services.IServices;
using System.Collections.Generic;

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

        public List<Escola> FindAll()
        {
            return _repository.FindAll();
        }

        public Escola FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Escola Update(Escola escola)
        {
            return _repository.Update(escola);
        }
    }
}