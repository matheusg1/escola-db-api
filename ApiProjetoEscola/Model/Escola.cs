using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Escola")]
    public class Escola
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Endereco")]
        public string Endereco { get; set; }
        [ForeignKey("Id")]
        public List<Turma> Turmas { get; set; }
    }
}
