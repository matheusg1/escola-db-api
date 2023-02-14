using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Turma")]
    public class Turma
    {
        [Key]
        public int id { get; set; }
        [Column("Codigo")]
        public string codigo { get; set; }
    }
}