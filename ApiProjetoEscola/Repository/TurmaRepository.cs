using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _context.Turmas.Add(turma);
            _context.SaveChanges();
            return turma;
        }

        public void Delete(int id)
        {
            var result = _context.Turmas.FirstOrDefault(t => t.TurmaId == id);

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

        public async Task<List<Turma>> FindAllAsync()
        {
            return await _context.Turmas.ToListAsync();
        }

        public async Task<Turma> FindByIdAsync(int id)
        {
            return await _context.Turmas.Where(t => t.TurmaId == id).Include(t => t.Alunos).FirstOrDefaultAsync();
        }

        public Turma Update(Turma turma)
        {
            var result = _context.Turmas.Where(t => t.TurmaId == turma.TurmaId).Include(t => t.Alunos).FirstOrDefault();

            if (result == null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(turma);
                _context.SaveChanges();
                return turma;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}