using ApiProjetoEscola.DTO;

namespace ApiProjetoEscola.Services.IServices
{
    public interface ILoginService
    {
        TokenDTO ValidateCredentials(UsuarioDTO usuario);
        TokenDTO ValidateCredentials(TokenDTO token);
        bool RevokeToken(string nomeUsuario);
    }
}
