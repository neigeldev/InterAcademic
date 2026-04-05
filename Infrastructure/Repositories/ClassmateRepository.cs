using Domain.Entities;
using Domain.Ports;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class ClassmateRepository(AppDbContext context) : IClassmateRepository
{
    public async Task<IEnumerable<Student>> GetStudentsByCourseAsync(int courseId, int excludeStudentId) =>
        await context.Enrollments
            .Where(e => e.CourseId == courseId && e.StudentId != excludeStudentId)
            .Select(e => e.Student)
            .ToListAsync();
}