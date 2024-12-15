using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QueueGen.Common.Options;
using QueueGen.Common.Services.Abstractions;

namespace QueueGen.Common.Services;

public class TokenService(IOptions<JwtOptions> options) : ITokenService
{
    private const string SecurityAlgorithm = SecurityAlgorithms.HmacSha256;

    public string GenerateAccessToken(IEnumerable<Claim>? claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithm);
        var securityToken = new JwtSecurityToken(claims: claims,
            expires: DateTime.UtcNow.AddMinutes(options.Value.AccessTokenLifeTimeInMinutes),
            signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return token;
    }

    public string GenerateRefreshToken(IEnumerable<Claim>? claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithm);
        var securityToken = new JwtSecurityToken(claims: claims,
            expires: DateTime.UtcNow.AddDays(options.Value.RefreshTokenLifeTimeInDays),
            signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;
    }

    public bool IsTokenValid(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)),
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out _);
            return true;
        }
        catch (SecurityTokenException)
        {
            return false;
        }
    }

    public IEnumerable<Claim>? GetClaimsFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.ReadToken(token) is not JwtSecurityToken jwtToken
            ? null
            : jwtToken.Claims;
    }
}