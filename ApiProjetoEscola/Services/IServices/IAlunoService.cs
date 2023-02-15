using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IAlunoService
    {
        AlunoDTO Create(AlunoDTO aluno);
        AlunoDTO FindByID(int id);
        List<AlunoDTO> FindAll();
        AlunoDTO Update(AlunoDTO aluno);
        void Delete(int id);
    }
}