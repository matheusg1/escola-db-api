namespace ApiProjetoEscola.Repository.IRepository
{
    public interface ITokenRepository
    {
        void DeleteRefreshToken(string nomeUsuario, string refreshToken);
        string GetRefreshToken(string nomeUsuario);
        bool RevokeToken(string nomeUsuario);
        void SaveRefreshToken(string nomeUsuario, string refreshToken);
    }
}