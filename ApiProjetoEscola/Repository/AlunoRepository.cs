using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjetoEscola.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private ProjetoDbContext _context;

        public AlunoRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public Aluno Create(Aluno aluno)
        {
            try
            {
                _context.Add(aluno);
                _context.SaveChanges();
                return aluno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            var result = _context.Alunos.FirstOrDefault(a => a.AlunoId == id);

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

        public List<Aluno> FindAll()
        {
            return _context.Alunos.ToList();
        }

        public Aluno FindByID(int id)
        {
            return _context.Alunos.FirstOrDefault(a => a.AlunoId == id);
        }

        public List<Aluno> FindByName(string nome, string sobrenome)
        {
            if (!string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(sobrenome))
            {
                return _context.Alunos.Where(a => a.Nome.Contains(nome) && a.Sobrenome == sobrenome).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(sobrenome))
            {
                return _context.Alunos.Where(a => a.Nome.Contains(nome)).ToList();
            }
            else if (string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(sobrenome))
            {
                return _context.Alunos.Where(a => a.Sobrenome.Contains(sobrenome)).ToList();
            }
            return null;
        }

        public Aluno Update(Aluno aluno)
        {
            var result = FindByID(aluno.AlunoId);

            if (result == null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(aluno);
                _context.SaveChanges();
                return aluno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}