using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Turma")]
    public class Turma : BaseEntity
    {
        [Column("Codigo")]
        public string Codigo { get; set; }
        [Column("Escola")]
        public List<Escola> escolas{ get; set; }
    }
}
