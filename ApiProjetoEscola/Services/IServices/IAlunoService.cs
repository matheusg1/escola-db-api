using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IAlunoService
    {
        Aluno Create(Aluno aluno);
        Aluno FindByID(int id);
        List<Aluno> FindByName(string nome, string sobrenome);
        List<Aluno> FindAll();
        Aluno Update(Aluno aluno);
        void Delete(int id);
    }
}