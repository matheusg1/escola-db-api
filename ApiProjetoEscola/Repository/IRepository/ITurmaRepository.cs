using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface ITurmaRepository
    {
        Turma Create(Turma turma);
        Turma FindByID(int id);
        Task<List<Turma>> FindAllAsync();
        Turma Update(Turma turma);
        void Delete(int id);
    }
}
