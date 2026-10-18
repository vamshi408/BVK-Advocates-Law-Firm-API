using System.Security.Claims;

namespace BVK_Advocates_Law_Firm.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username, IEnumerable<Claim>? additionalClaims = null);
    }
}