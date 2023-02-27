using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Escolas")]
    public class Escola
    {
        public int EscolaId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public IEnumerable<Turma> Turmas { get; set; }
    }
}
