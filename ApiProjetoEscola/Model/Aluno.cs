using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ApiProjetoEscola.Model
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int id { get; set; }
        [Column("Matricula")]
        public Guid matricula { get; set; }
        [Column("Nome_Completo")]
        public string nomeCompleto { get; set; }
        [Column("CPF")]
        public string cpf { get; set; }
        [Column("Data_Nascimento")]
        public DateTime dataNascimento { get; set; }
    }
}
