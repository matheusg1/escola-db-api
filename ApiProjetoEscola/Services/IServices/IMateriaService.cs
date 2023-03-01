using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IMateriaService
    {
        Materia Create(Materia materia);
        Task<Materia> FindByIdAsync(int id);
        Task<List<Materia>> FindAllAsync();
        Materia Update(Materia materia);
        void Delete(int id);
    }
}