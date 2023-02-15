using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.DTO;
using ApiProjetoEscola.DTO.Converter;

namespace ApiProjetoEscola.Services
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _repository;
        private AlunoConverter _converter;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
            _converter = new AlunoConverter();
        }

        public AlunoDTO Create(AlunoDTO aluno)
        {
            var alunoEntity = _converter.Parse(aluno);
            alunoEntity = _repository.Create(alunoEntity);
            return _converter.Parse(alunoEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<AlunoDTO> FindAll()
        {
            var result = _repository.FindAll();
            return _converter.Parse(result);
        }

        public AlunoDTO FindByID(int id)
        {
            var result = _repository.FindByID(id);
            return _converter.Parse(result);
        }

        public AlunoDTO Update(AlunoDTO aluno)
        {
            var alunoEntity = _converter.Parse(aluno);
            alunoEntity = _repository.Update(alunoEntity);
            return _converter.Parse(alunoEntity);
        }
    }
}