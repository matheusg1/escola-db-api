using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoEscola.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome_Usuario")]
        public string NomeUsuario { get; set; }
        [Column("Senha")]
        public string Senha { get; set; }
        [Column("Nome_Completo")]
        public string NomeCompleto { get; set; }
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
