using System.Collections.Generic;
using System.Security.Claims;

namespace Store.Presentation.Providers.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
