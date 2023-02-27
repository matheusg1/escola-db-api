using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IEscolaRepository
    {
        Escola Create(Escola escola);
        Task<Escola> FindByIDAsync(int id);
        Task<List<Escola>> FindAllAsync();
        Escola Update(Escola escola);
        void Delete(int id);
    }
}
