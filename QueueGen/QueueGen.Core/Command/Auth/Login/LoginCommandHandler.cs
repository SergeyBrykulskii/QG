using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QueueGen.Common.Models;
using QueueGen.Common.Services.Abstractions;
using QueueGen.Core.Models.Auth;
using QueueGen.Infrastructure.Entities;
using QueueGen.Infrastructure.Repositories.Abstractions;

namespace QueueGen.Core.Command.Auth.Login;

public class LoginCommandHandler(IBaseRepository<User> userRepository, ITokenService tokenService)
    : IRequestHandler<LoginCommand, BaseResult<AuthResult>>
{
    public async Task<BaseResult<AuthResult>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken);

        if (user == null)
        {
            return BaseResult<AuthResult>.Failed("Invalid email address");
        }

        if (user.Password != command.Password)
        {
            return BaseResult<AuthResult>.Failed("Invalid password");
        }

        Claim[] claims = [new(ClaimTypes.Email, user.Email), new("Id", user.Id.ToString())];

        var accessToken = tokenService.GenerateAccessToken(claims);
        var refreshToken = tokenService.GenerateRefreshToken([new Claim("Id", user.Id.ToString())]);

        return BaseResult<AuthResult>.Succeeded(new AuthResult(accessToken, refreshToken));
    }
}