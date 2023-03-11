using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        [NotMapped]
        public int? QuantidadeMaterias
        {
            get
            {
                if (Materias != null)
                {
                    return Materias.Count();
                }
                return null;
            }
        }
        [NotMapped]
        public int? QuantidadeAlunos
        {
            get
            {
                if (Alunos != null)
                {
                    return Alunos.Count();
                }
                return null;
            }
        }

        public Turma(string codigo, int escolaId)
        {
            Codigo = codigo;
            EscolaId = escolaId;
        }
    }
}