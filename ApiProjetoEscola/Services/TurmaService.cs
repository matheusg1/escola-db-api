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
    public class TurmaService : ITurmaService
    {
        private ITurmaRepository _repository;
        private TurmaConverter _converter;

        public TurmaService(ITurmaRepository repository)
        {
            _repository = repository;
            _converter = new TurmaConverter();
        }

        public TurmaDTO Create(TurmaDTO turma)
        {
            var turmaEntity = _converter.Parse(turma);
            turmaEntity = _repository.Create(turmaEntity);
            return _converter.Parse(turmaEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<TurmaDTO> FindAll()
        {
            var result = _repository.FindAll();
            return _converter.Parse(result);
        }

        public TurmaDTO FindByID(int id)
        {
            var result = _repository.FindByID(id);
            return _converter.Parse(result);            
        }

        public TurmaDTO Update(TurmaDTO turma)
        {
            var turmaEntity = _converter.Parse(turma);
            turmaEntity = _repository.Update(turmaEntity);
            return _converter.Parse(turmaEntity);            
        }
    }
}
