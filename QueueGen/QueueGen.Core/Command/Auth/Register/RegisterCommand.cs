using MediatR;
using QueueGen.Common.Models;
using QueueGen.Core.Models.Auth;

namespace QueueGen.Core.Command.Auth.Register;

public record RegisterCommand(string Email, string Password) : IRequest<BaseResult<AuthResultModel>>;