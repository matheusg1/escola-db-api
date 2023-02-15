using ApiProjetoEscola.DTO;
using ApiProjetoEscola.DTO.Converter;
using ApiProjetoEscola.Model;
using ApiProjetoEscola.Repository;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.Services.IServices;
using System;
using System.Collections.Generic;

namespace ApiProjetoEscola.Services
{
    public class EscolaService : IEscolaService
    {
        private IEscolaRepository _repository;
        private EscolaConverter _converter;

        public EscolaService(IEscolaRepository repository)
        {
            _repository = repository;
            _converter = new EscolaConverter();
        }

        public EscolaDTO Create(EscolaDTO escola)
        {
            var escolaEntity = _converter.Parse(escola);
            escolaEntity = _repository.Create(escolaEntity);
            return _converter.Parse(escolaEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<EscolaDTO> FindAll()
        {
            var list = _repository.FindAll();
            return _converter.Parse(list);
        }

        public EscolaDTO FindByID(int id)
        {
            var result = _repository.FindByID(id);
            return _converter.Parse(result);
        }

        public EscolaDTO Update(EscolaDTO escola)
        {
            var escolaEntity = _converter.Parse(escola);
            escolaEntity = _repository.Update(escolaEntity);
            return _converter.Parse(escolaEntity);
        }
    }
}