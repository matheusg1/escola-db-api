using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Materia")]
    public class Materia
    {
        [Key]
        public int id { get; set; }
        [Column("Nome")]
        public string nome { get; set; }
        [Column("Professor")]
        public string professor { get; set; }
    }
}
