using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Materias")]
    public class Materia
    {
        [Key]
        public int MateriaId { get; set; }       
        public string Nome { get; set; }        
        public string Professor { get; set; }        
        public int TurmaId { get; set; }
    }
}
