using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ApiProjetoEscola.DTO
{
    public class CreateUsuarioDTO
    {
        public string NomeUsuario { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
