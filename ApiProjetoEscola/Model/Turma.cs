using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Turma")]
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        [Column("Codigo")]
        public string Codigo { get; set; }
        [ForeignKey("Id")]
        public IEnumerable<Materia> Materias { get; set; }
        [ForeignKey("Id")]
        public IEnumerable<Aluno> Alunos { get; set; }
    }
}