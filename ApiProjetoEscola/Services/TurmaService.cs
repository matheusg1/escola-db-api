using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using System.Collections.Generic;
using ApiProjetoEscola.Repository.IRepository;

namespace ApiProjetoEscola.Services
{
    public class TurmaService : ITurmaService
    {
        private ITurmaRepository _repository;

        public TurmaService(ITurmaRepository repository)
        {
            _repository = repository;
        }

        public Turma Create(Turma turma)
        {
            return _repository.Create(turma);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Turma> FindAll()
        {
            return _repository.FindAll();
        }

        public Turma FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Turma Update(Turma turma)
        {
            return _repository.Update(turma);
        }
    }
}
