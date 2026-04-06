using Application.DTOs.Course;
namespace Application.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseResponse>> GetAllAsync();
    Task<CourseResponse?> GetByIdAsync(int id);
}