using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueueGen.Api.Dtos.Auth;
using QueueGen.Core.Command.Auth.Login;
using QueueGen.Core.Command.Auth.Refresh;
using QueueGen.Core.Command.Auth.Register;

namespace QueueGen.Api.Controllers;

[Route("api/auth")]
public class AuthController(IMediator mediator) : Controller
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Register.Request.Body request, CancellationToken cancellationToken)
    {
        var command = new RegisterCommand(request.Email, request.Password);
        var result = await mediator.Send(command, cancellationToken);
    
        return result.IsSuccess 
            ? Ok(result.Data) 
            : BadRequest(result.ErrorMessage);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login.Request.Body request, CancellationToken cancellationToken)
    {
        var command = new LoginCommand(request.Email, request.Password);
        var result = await mediator.Send(command, cancellationToken);

        return result.IsSuccess 
            ? Ok(result.Data) 
            : BadRequest(result.ErrorMessage);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] Refresh.Request.Body request, CancellationToken cancellationToken)
    {
        var command = new RefreshCommand(request.RefreshToken);
        var result = await mediator.Send(command, cancellationToken);
        
        return result.IsSuccess 
            ? Ok(result.Data) 
            : BadRequest(result.ErrorMessage);
    }
}