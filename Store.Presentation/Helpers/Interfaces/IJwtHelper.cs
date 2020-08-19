using System.Collections.Generic;
using System.Security.Claims;

namespace Store.Presentation.Helpers.Interfaces
{
    public interface IJwtHelper
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
