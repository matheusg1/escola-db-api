using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace ApiProjetoEscola.TokenServices.ITokenServices
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string generateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
