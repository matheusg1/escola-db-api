using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ApiProjetoEscola.DTO
{
    public class CreateAlunoDto
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        [Column("Data_Nascimento")]
        public DateTime DataNascimento { get; set; }
        public int TurmaId { get; set; }
    }
}
