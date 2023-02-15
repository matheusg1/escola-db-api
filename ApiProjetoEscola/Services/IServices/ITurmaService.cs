using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Services.IServices
{
    public interface ITurmaService
    {
        TurmaDTO Create(TurmaDTO turma);
        TurmaDTO FindByID(int id);
        List<TurmaDTO> FindAll();
        TurmaDTO Update(TurmaDTO turma);
        void Delete(int id);
    }
}