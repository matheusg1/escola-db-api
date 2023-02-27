using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services.IServices
{
    public interface ITurmaService
    {
        Turma Create(Turma turma);
        Task<Turma> FindByIDAsync(int id);
        Task<List<Turma>> FindAllAsync();
        Turma Update(Turma turma);
        void Delete(int id);
    }
}