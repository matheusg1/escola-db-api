using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IAlunoRepository
    {
        Aluno Create(Aluno aluno);
        Aluno FindByID(int id);
        List<Aluno> FindAll();
        Aluno Update(Aluno aluno);
        void Delete(int id);
    }
}
