using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QueueGen.Api.Controllers;

[Route("api/[controller]")]
public class GroupController : Controller
{
    // GET
    [HttpGet("user/{userId:guid}")]
    [Authorize]
    public async Task<IActionResult> GetUserGroups([FromRoute] Guid userId)
    {
        return Ok();
    }

    [HttpGet("{groupId:guid}")]
    [Authorize]
    public async Task<IActionResult> GetGroupById([FromRoute] Guid groupId)
    {
        return Ok();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateGroup()
    {
        return Ok();
    }

    [HttpGet("{groupId:guid}/disciplines")]
    [Authorize]
    public async Task<IActionResult> GetGroupDisciplines([FromRoute] Guid groupId)
    {
        return Ok();
    }
}