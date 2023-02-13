using ApiProjetoEscola.Model;
using ApiProjetoEscola.Repository;
using System.Collections.Generic;

namespace ApiProjetoEscola.Services
{
    public class EscolaService
    {
        EscolaRepository _repository;

        public EscolaService(EscolaRepository repository)
        {
            _repository = repository;
        }

        public List<Escola> FindAll()
        {
            return _repository.FindAll();
        }
    }
}
