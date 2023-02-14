using ApiProjetoEscola.Model;
using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository.IRepository;
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
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Aluno> FindAll()
        {
            return _context.Alunos.ToList();
        }

        public Aluno FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Aluno Update(Aluno escola)
        {
            throw new System.NotImplementedException();
        }
    }
}