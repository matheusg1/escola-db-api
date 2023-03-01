using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface ITurmaRepository
    {
        Turma Create(Turma turma);
        Task<Turma> FindByIdAsync(int id);
        Task<List<Turma>> FindAllAsync();
        Turma Update(Turma turma);
        void Delete(int id);
        Task<int?> GetQuantidadeAlunosByTurmaAsync(int id);
    }
}
