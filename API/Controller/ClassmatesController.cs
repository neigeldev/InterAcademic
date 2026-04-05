using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClassmatesController(IClassmateService service) : ControllerBase
{
    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetClassmates(int courseId)
    {
        var studentId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
        var result = await service.GetClassmatesAsync(courseId, studentId);
        return Ok(result);
    }
}