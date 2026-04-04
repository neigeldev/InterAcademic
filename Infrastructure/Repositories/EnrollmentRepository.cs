using Domain.Entities;
using Domain.Ports;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class EnrollmentRepository(AppDbContext context) : IEnrollmentRepository
{
    public async Task<IEnumerable<Enrollment>> GetByStudentIdAsync(int studentId) =>
        await context.Enrollments
            .Include(e => e.Course)
                .ThenInclude(c => c.Teacher)
            .Where(e => e.StudentId == studentId)
            .ToListAsync();

    public async Task<bool> ExistsAsync(int studentId, int courseId) =>
        await context.Enrollments
            .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);

    public async Task<Enrollment?> GetAsync(int studentId, int courseId) =>
        await context.Enrollments
            .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);

    public async Task AddAsync(Enrollment enrollment)
    {
        await context.Enrollments.AddAsync(enrollment);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Enrollment enrollment)
    {
        context.Enrollments.Remove(enrollment);
        await context.SaveChangesAsync();
    }
}