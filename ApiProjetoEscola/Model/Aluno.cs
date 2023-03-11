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
        public Aluno(string nome, string sobrenome, string cpf, DateTime dataNascimento, int turmaId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            TurmaId = turmaId;
        }
    }
}
