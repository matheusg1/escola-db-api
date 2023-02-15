using System;

namespace ApiProjetoEscola.DTO
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public Guid Matricula { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
