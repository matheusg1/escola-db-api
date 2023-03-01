using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IAlunoRepository
    {
        Aluno Create(Aluno aluno);
        Task<Aluno> FindByIdAsync(int id);
        List<Aluno> FindByName(string nome, string sobrenome);
        Task<List<Aluno>> FindAllAsync();
        Aluno Update(Aluno aluno);
        void Delete(int id);
    }
}
