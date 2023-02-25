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

namespace ApiProjetoEscola.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private ProjetoDbContext _context;
        private IConfiguration _config;
        private string _connection;

        public TurmaRepository(ProjetoDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _connection = _config.GetConnectionString("EscolaDbCasa");
        }

        public Turma Create(Turma turma)
        {
            var escola = _context.Escolas.Where(e => e.EscolaId == turma.EscolaId).Include(e => e.Turmas).FirstOrDefault();
            if (escola == null) return null;

            escola.Turmas.Add(turma);
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

        public List<Turma> FindAll()
        {
            return _context.Turmas.ToList();
        }

        public Turma FindByID(int id)
        {
            return _context.Turmas.FirstOrDefault(t => t.TurmaId == id);
        }

        public Turma Update(Turma turma)
        {
            var result = FindByID(turma.TurmaId);

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