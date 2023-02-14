using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
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
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Materia> FindAll()
        {
            return _context.Materias.ToList();
        }

        public Materia FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Materia Update(Materia materia)
        {
            throw new System.NotImplementedException();
        }
    }
}