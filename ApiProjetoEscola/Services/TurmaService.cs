﻿using ApiProjetoEscola.Model;
using ApiProjetoEscola.Services.IServices;
using System.Collections.Generic;
using ApiProjetoEscola.Repository.IRepository;
using System.Threading.Tasks;

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

        public async Task<List<Turma>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
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
