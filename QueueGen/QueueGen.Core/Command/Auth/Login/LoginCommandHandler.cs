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
    : IRequestHandler<LoginCommand, BaseResult<AuthResultModel>>
{
    public async Task<BaseResult<AuthResultModel>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken);

        if (user == null)
        {
            return BaseResult<AuthResultModel>.Failed("Invalid email address");
        }

        if (user.Password != command.Password)
        {
            return BaseResult<AuthResultModel>.Failed("Invalid password");
        }

        Claim[] claims = [new(ClaimTypes.Email, user.Email), new("Id", user.Id.ToString())];

        var accessToken = tokenService.GenerateAccessToken(claims);
        var refreshToken = tokenService.GenerateRefreshToken([new Claim("Id", user.Id.ToString())]);

        return BaseResult<AuthResultModel>.Succeeded(new AuthResultModel(accessToken, refreshToken));
    }
}