using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface ITurmaRepository
    {
        Turma Create(Turma turma);
        Turma FindByID(int id);
        List<Turma> FindAll();
        Turma Update(Turma turma);
        void Delete(int id);
    }
}
