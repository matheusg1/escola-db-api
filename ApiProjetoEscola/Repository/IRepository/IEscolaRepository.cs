using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Repository.IRepository
{
    public interface IEscolaRepository
    {
        Escola Create(Escola escola);
        Escola FindByID(int id);
        List<Escola> FindAll();
        Escola Update(Escola escola);
        void Delete(int id);
    }
}
