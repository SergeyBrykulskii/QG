using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QueueGen.Common.Models;
using QueueGen.Common.Services.Abstractions;
using QueueGen.Core.Models.Auth;
using QueueGen.Infrastructure.Entities;
using QueueGen.Infrastructure.Repositories.Abstractions;

namespace QueueGen.Core.Command.Auth.Refresh;

public class RefreshCommandHandler(ITokenService tokenService, IBaseRepository<User> userRepository)
    : IRequestHandler<RefreshCommand, BaseResult<RefreshResult>>
{
    public async Task<BaseResult<RefreshResult>> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        var isTokenValid = tokenService.IsTokenValid(request.RefreshToken);

        if (!isTokenValid)
        {
            return BaseResult<RefreshResult>.Failed("Invalid refresh token");
        }
        
        var claimsFromToken = tokenService.GetClaimsFromToken(request.RefreshToken);
        var userIdString = claimsFromToken?.FirstOrDefault(c => c.Type == "Id")?.Value;

        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
        {
            return BaseResult<RefreshResult>.Failed("Invalid refresh token");
        }
        
        var user = await userRepository.GetAll().FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

        if (user == null)
        {
            return BaseResult<RefreshResult>.Failed("Invalid refresh token");
        }
        
        Claim[] claims = [new(ClaimTypes.Email, user.Email), new("Id", user.Id.ToString())];
        var accessToken = tokenService.GenerateAccessToken(claims);
        
        return BaseResult<RefreshResult>.Succeeded(new RefreshResult(accessToken));
    }
}