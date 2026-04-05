using Application.DTOs.Enrollment;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController(IEnrollmentService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Enroll([FromBody] EnrollmentRequest request)
    {
        var result = await service.EnrollAsync(request);
        return Ok(result);
    }

    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetByStudent(int studentId)
    {
        var result = await service.GetByStudentAsync(studentId);
        return Ok(result);
    }

    [HttpDelete("student/{studentId}/course/{courseId}")]
    public async Task<IActionResult> Unenroll(int studentId, int courseId)
    {
        await service.UnenrollAsync(studentId, courseId);
        return NoContent();
    }
}