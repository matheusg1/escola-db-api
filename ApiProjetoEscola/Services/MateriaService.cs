using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using ApiProjetoEscola.Repository.IRepository;

namespace ApiProjetoEscola.Services
{
    public class MateriaService : IMateriaService
    {
        private IMateriaRepository _repository;

        public MateriaService(IMateriaRepository repository)
        {
            _repository = repository;
        }

        public Materia Create(Materia materia)
        {
            return _repository.Create(materia);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Materia> FindAll()
        {
            return _repository.FindAll();
        }

        public Materia FindByID(int id)
        {
            return _repository.FindByID(id);            
        }

        public Materia Update(Materia materia)
        {
            return _repository.Update(materia);            
        }
    }
}