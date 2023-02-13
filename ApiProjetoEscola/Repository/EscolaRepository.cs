using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjetoEscola.Repository
{
    public class EscolaRepository
    {
        private ProjetoDbContext _context;

        public EscolaRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public List<Escola> FindAll()
        {
            return _context.Escolas.ToList();
        }
    }
}