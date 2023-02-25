using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjetoEscola.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        private ProjetoDbContext _context;

        public MateriaRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public Materia Create(Materia materia)
        {
            try
            {
                _context.Add(materia);
                _context.SaveChanges();
                return materia;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            var result = _context.Materias.FirstOrDefault(m => m.MateriaId == id);

            if (result != null)
            {
                try
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public List<Materia> FindAll()
        {
            return _context.Materias.ToList();
        }

        public Materia FindByID(int id)
        {
            return _context.Materias.FirstOrDefault(m => m.MateriaId == id);
        }

        public Materia Update(Materia materia)
        {
            var result = FindByID(materia.MateriaId);

            if (result == null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(materia);
                _context.SaveChanges();
                return materia;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}