using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Repository
{
    public class EscolaRepository : IEscolaRepository
    {
        private ProjetoDbContext _context;

        public EscolaRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public Escola Create(Escola escola)
        {
            try
            {
                _context.Add(escola);
                _context.SaveChanges();
                return escola;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            var result = _context.Escolas.FirstOrDefault(e => e.EscolaId == id);

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

        public async Task<List<Escola>> FindAllAsync()
        {
            return await _context.Escolas.OrderBy(e => e.Nome).ToListAsync();
        }

        public async Task<Escola> FindByIdAsync(int id)
        {
            return await _context.Escolas.Where(e => e.EscolaId == id).Include(e => e.Turmas).FirstOrDefaultAsync();
        }

        public Escola Update(Escola escola)
        {

            var result = _context.Escolas.Where(e => e.EscolaId == escola.EscolaId).Include(e => e.Turmas).FirstOrDefault();            

            if (result == null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(escola);
                _context.SaveChanges();
                return escola;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}