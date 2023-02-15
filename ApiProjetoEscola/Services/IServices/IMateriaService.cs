using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IMateriaService
    {
        MateriaDTO Create(MateriaDTO materia);
        MateriaDTO FindByID(int id);
        List<MateriaDTO> FindAll();
        MateriaDTO Update(MateriaDTO materia);
        void Delete(int id);
    }
}