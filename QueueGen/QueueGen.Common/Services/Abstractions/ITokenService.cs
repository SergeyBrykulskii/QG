using System.Security.Claims;

namespace QueueGen.Common.Services.Abstractions;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken(IEnumerable<Claim> claims);
    bool IsTokenValid(string token);
    IEnumerable<Claim>? GetClaimsFromToken(string token);
}