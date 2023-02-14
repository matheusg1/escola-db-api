﻿using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
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
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Escola> FindAll()
        {
            return _context.Escolas.Include(e => e.turmas).ToList();
        }

        public Escola FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Escola Update(Escola escola)
        {
            throw new System.NotImplementedException();
        }
    }
}