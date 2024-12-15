using MediatR;
using QueueGen.Common.Models;
using QueueGen.Core.Models.Auth;

namespace QueueGen.Core.Command.Auth.Refresh;

public record RefreshCommand(string RefreshToken) : IRequest<BaseResult<RefreshResult>>;
