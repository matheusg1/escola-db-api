using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IMateriaRepository
    {
        Materia Create(Materia materia);
        Materia FindByID(int id);
        Task<List<Materia>> FindAllAsync();
        Materia Update(Materia materia);
        void Delete(int id);
    }
}
