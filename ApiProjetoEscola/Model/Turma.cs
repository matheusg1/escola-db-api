using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Turmas")]
    public class Turma
    {
        [Key]
        public int TurmaId { get; set; }
        public string Codigo { get; set; }        
        public int EscolaId { get; set; }
        public IEnumerable<Materia> Materias { get; set; }
        public IEnumerable<Aluno> Alunos { get; set; }
    }
}