using Application.DTOs.Course;
using Domain.Ports;
namespace Application.Services;

public class CourseService(ICourseRepository repository) : ICourseService
{
    public async Task<IEnumerable<CourseResponse>> GetAllAsync()
    {
        var courses = await repository.GetAllAsync();
        return courses.Select(ToResponse);
    }

    public async Task<CourseResponse?> GetByIdAsync(int id)
    {
        var course = await repository.GetByIdAsync(id);
        return course is null ? null : ToResponse(course);
    }

    private static CourseResponse ToResponse(Domain.Entities.Course course) => new()
    {
        Id = course.pk_course_id,
        CourseName = course.course_name,
        Credits = course.credits,
        TeacherName = course.fk_teacher.name
    };
}