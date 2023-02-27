using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IEscolaService
    {
        Escola Create(Escola escola);
        Escola FindByID(int id);
        Task<List<Escola>> FindAllAsync();
        Escola Update(Escola escola);
        void Delete(int id);
    }
}