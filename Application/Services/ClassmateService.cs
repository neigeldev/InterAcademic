using Application.DTOs.Classmates;
using Domain.Ports;
namespace Application.Services;

public class ClassmateService(
    IClassmateRepository repository,
    ICourseRepository courseRepository) : IClassmateService
{
    public async Task<IEnumerable<ClassmateResponse>> GetClassmatesAsync(int courseId, int studentId)
    {
        var course = await courseRepository.GetByIdAsync(courseId)
            ?? throw new InvalidOperationException($"Course with id {courseId} not found.");

        var students = await repository.GetStudentsByCourseAsync(courseId, studentId);

        return students.Select(s => new ClassmateResponse
        {
            Name = s.Name
        });
    }
}