using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;
using System.Collections.Generic;

namespace ApiProjetoEscola.Services.IServices
{
    public interface IEscolaService
    {
        EscolaDTO Create(EscolaDTO escola);
        EscolaDTO FindByID(int id);
        List<EscolaDTO> FindAll();
        EscolaDTO Update(EscolaDTO escola);
        void Delete(int id);
    }
}