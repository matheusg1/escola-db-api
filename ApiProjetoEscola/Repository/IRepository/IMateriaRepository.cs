using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IMateriaRepository
    {
        Materia Create(Materia materia);
        Task<Materia> FindByIDAsync(int id);
        Task<List<Materia>> FindAllAsync();
        Materia Update(Materia materia);
        void Delete(int id);
    }
}
