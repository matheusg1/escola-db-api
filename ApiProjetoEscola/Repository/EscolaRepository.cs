using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjetoEscola.Repository
{
    public class EscolaRepository
    {
        private EscolaDbContext _context;

        public EscolaRepository(EscolaDbContext context)
        {
            _context = context;
        }

        public List<Escola> FindAll()
        {
            return _context.Escolas.ToList();
        }
    }
}