using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ApiProjetoEscola.Model
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Column("Matricula")]
        public Guid Matricula { get; set; }
        [Column("Nome_Completo")]
        public string NomeCompleto { get; set; }
        [Column("CPF")]
        public string Cpf { get; set; }
        [Column("Data_Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
