using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IEscolaService
    {
        Escola Create(Escola escola);
        Escola FindByID(int id);
        List<Escola> FindAll();
        Escola Update(Escola escola);
        void Delete(int id);
    }
}