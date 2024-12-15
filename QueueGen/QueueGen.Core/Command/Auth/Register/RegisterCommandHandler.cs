using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QueueGen.Common.Models;
using QueueGen.Common.Services.Abstractions;
using QueueGen.Core.Models.Auth;
using QueueGen.Infrastructure.Entities;
using QueueGen.Infrastructure.Repositories.Abstractions;

namespace QueueGen.Core.Command.Auth.Register;

public class RegisterCommandHandler(IBaseRepository<User> userRepository, ITokenService tokenService)
    : IRequestHandler<RegisterCommand, BaseResult<AuthResultModel>>
{
    public async Task<BaseResult<AuthResultModel>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken);
    
        if (existingUser != null)
        {
            return BaseResult<AuthResultModel>.Failed("Email already taken");
        }
    
        var newUser = await userRepository.CreateAsync(new User { Email = command.Email, Password = command.Password }, cancellationToken);
        await userRepository.SaveChangesAsync();
        
        Claim[] claims = [new(ClaimTypes.Email, newUser.Email), new("Id", newUser.Id.ToString())];

        var accessToken = tokenService.GenerateAccessToken(claims);
        var refreshToken = tokenService.GenerateRefreshToken([new Claim("Id", newUser.Id.ToString())]);
    
        return BaseResult<AuthResultModel>.Succeeded(new AuthResultModel(accessToken, refreshToken));
    }
}