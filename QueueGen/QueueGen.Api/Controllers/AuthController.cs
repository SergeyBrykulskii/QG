using Microsoft.AspNetCore.Mvc;

namespace QueueGen.Api.Controllers;

[Route("api/[controller]")]
public class AuthController : Controller
{
    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }
    
    [HttpPost("refreshToken")]
    public async Task<IActionResult> RefreshToken()
    {
        return Ok();
    }
}