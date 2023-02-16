using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using ApiProjetoEscola.Repository.IRepository;


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

        public List<Aluno> FindAll()
        {
            return _repository.FindAll();
        }

        public Aluno FindByID(int id)
        {
            return _repository.FindByID(id);
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