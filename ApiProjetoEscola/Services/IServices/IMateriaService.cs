using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IMateriaService
    {
        Materia Create(Materia materia);
        Materia FindByID(int id);
        List<Materia> FindAll();
        Materia Update(Materia materia);
        void Delete(int id);
    }
}