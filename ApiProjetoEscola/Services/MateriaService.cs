using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Controllers;
using ApiProjetoEscola.DTO.Converter;

namespace ApiProjetoEscola.Services
{
    public class MateriaService : IMateriaService
    {
        private IMateriaRepository _repository;
        private MateriaConverter _converter;

        public MateriaService(IMateriaRepository repository)
        {
            _repository = repository;
            _converter = new MateriaConverter();
        }

        public MateriaDTO Create(MateriaDTO materia)
        {
            var materiaEntity = _converter.Parse(materia);
            materiaEntity = _repository.Create(materiaEntity);
            return _converter.Parse(materiaEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<MateriaDTO> FindAll()
        {
            var result = _repository.FindAll();
            return _converter.Parse(result);
        }

        public MateriaDTO FindByID(int id)
        {
            var result = _repository.FindByID(id);
            return _converter.Parse(result);
        }

        public MateriaDTO Update(MateriaDTO materia)
        {
            var materiaEntity = _converter.Parse(materia);
            materiaEntity = _repository.Update(materiaEntity);
            return _converter.Parse(materiaEntity);            
        }
    }
}