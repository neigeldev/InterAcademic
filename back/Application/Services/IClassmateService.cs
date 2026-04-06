using Application.DTOs.Classmates;
namespace Application.Services;

public interface IClassmateService
{
    Task<IEnumerable<ClassmateResponse>> GetClassmatesAsync(int courseId, int studentId);
}