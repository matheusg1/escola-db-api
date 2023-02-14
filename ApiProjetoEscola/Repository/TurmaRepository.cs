using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjetoEscola.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private ProjetoDbContext _context;

        public TurmaRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public Turma Create(Turma turma)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Turma> FindAll()
        {
            return _context.Turmas.ToList();
        }

        public Turma FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Turma Update(Turma turma)
        {
            throw new System.NotImplementedException();
        }
    }
}