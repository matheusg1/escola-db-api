using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Escola> FindAll()
        {
            return _context.Escolas.ToList();
        }

        public Escola FindByID(int id)
        {
            return _context.Escolas.FirstOrDefault(e => e.EscolaId == id);                
        }

        public Escola Update(Escola escola)
        {
            var result = FindByID(escola.EscolaId);

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