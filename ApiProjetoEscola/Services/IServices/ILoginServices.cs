using ApiProjetoEscola.DTO;

namespace ApiProjetoEscola.Services.IServices
{
    public interface ILoginService
    {
        TokenDTO ValidateCredentials(UsuarioDTO usuario);
    }
}
