using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ApiProjetoEscola.Model
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome_Usuario")]
        public string NomeUsuario { get; set; }
        [Column("Senha")]
        public string Senha { get; set; }
        [Column("Nome_Completo")]
        #nullable enable
        public string? NomeCompleto { get; set; }     
        [Column("refresh_token")]
        public string? RefreshToken { get; set; }

        public Usuario(string nomeUsuario, string senha, string nomeCompleto)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
            NomeCompleto = nomeCompleto;
        }
    }
}
