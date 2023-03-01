using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using ApiProjetoEscola.Repository.IRepository;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public Aluno Create(Aluno aluno)
        {
            return _repository.Create(aluno);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<List<Aluno>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Aluno> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public List<Aluno> FindByName(string nome, string sobrenome)
        {
            return _repository.FindByName(nome, sobrenome);
        }

        public Aluno Update(Aluno aluno)
        {
            return _repository.Update(aluno);
        }
    }
}