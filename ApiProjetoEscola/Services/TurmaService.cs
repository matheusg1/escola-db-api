using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using ApiProjetoEscola.Repository.IGenericRepository;

namespace ApiProjetoEscola.Services
{
    public class TurmaService : ITurmaService
    {
        private IGenericRepository<Turma> _repository;

        public TurmaService(IGenericRepository<Turma> repository)
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
