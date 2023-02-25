using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ApiProjetoEscola.Model
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }        
        public Guid Matricula { get; set; }        
        public string Nome { get; set; }        
        public string Sobrenome { get; set; }        
        public string Cpf { get; set; }
        [Column("Data_Nascimento")]
        public DateTime DataNascimento { get; set; }        
        public int TurmaId{ get; set; }
    }
}
