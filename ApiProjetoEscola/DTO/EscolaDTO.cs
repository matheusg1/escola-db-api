using ApiProjetoEscola.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.DTO
{
    public class EscolaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
    }
}
