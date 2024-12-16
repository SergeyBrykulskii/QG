using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueueGen.Common.Services.Abstractions;

namespace QueueGen.Api.Controllers;

[Route("api")]
public class GroupController(ITokenService tokenService) : Controller
{
    // GET
    [HttpGet("me/groups")]
    [Authorize]
    public async Task<IActionResult> GetUserGroups()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var userId = tokenService.GetUserIdFromToken(accessToken!);
        return Ok();
    }

    [HttpGet("groups/{groupId:guid}")]
    [Authorize]
    public async Task<IActionResult> GetGroupById([FromRoute] Guid groupId)
    {
        return Ok();
    }

    [HttpPost("groups")]
    [Authorize]
    public async Task<IActionResult> CreateGroup()
    {
        return Ok();
    }

    [HttpGet("groups/{groupId:guid}/disciplines")]
    [Authorize]
    public async Task<IActionResult> GetGroupDisciplines([FromRoute] Guid groupId)
    {
        return Ok();
    }
}