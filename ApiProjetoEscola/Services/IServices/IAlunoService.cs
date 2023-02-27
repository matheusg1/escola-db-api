using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IAlunoService
    {
        Aluno Create(Aluno aluno);
        Aluno FindByID(int id);
        List<Aluno> FindByName(string nome, string sobrenome);
        Task<List<Aluno>> FindAllAsync();
        Aluno Update(Aluno aluno);
        void Delete(int id);
    }
}