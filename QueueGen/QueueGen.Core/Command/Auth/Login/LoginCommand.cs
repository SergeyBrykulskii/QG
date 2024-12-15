using MediatR;
using QueueGen.Common.Models;
using QueueGen.Core.Models.Auth;

namespace QueueGen.Core.Command.Auth.Login;

public record LoginCommand(string Email, string Password) : IRequest<BaseResult<AuthResult>>;