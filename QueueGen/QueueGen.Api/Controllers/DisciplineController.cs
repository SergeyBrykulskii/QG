using Microsoft.AspNetCore.Mvc;

namespace QueueGen.Api.Controllers;

[Route("api/[controller]")]
public class DisciplineController : Controller
{
    [HttpGet("{disciplineId:guid}/queue")]
    public async Task<IActionResult> GetQueueAsync(Guid disciplineId)
    {
        return Ok();
    }
}