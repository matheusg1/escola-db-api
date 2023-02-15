using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Materia")]
    public class Materia
    {
        [Key]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Professor")]
        public string Professor { get; set; }
    }
}
