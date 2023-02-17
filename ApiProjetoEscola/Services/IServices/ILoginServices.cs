using ApiProjetoEscola.DTO;
using ApiProjetoEscola.Model;

namespace ApiProjetoEscola.Services.IServices
{
    public interface ILoginService
    {
        TokenDTO CreateUsuario(UsuarioDTO usuarioDto);
        TokenDTO ValidateCredentials(UsuarioDTO usuario);
        TokenDTO ValidateCredentials(TokenDTO token);
        bool RevokeToken(string nomeUsuario);
    }
}
