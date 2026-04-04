using Domain.Entities;
using Domain.Ports;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class CourseRepository(AppDbContext context) : ICourseRepository
{
    public async Task<IEnumerable<Course>> GetAllAsync() =>
        await context.Courses
            .Include(c => c.Teacher)
            .ToListAsync();

    public async Task<Course?> GetByIdAsync(int id) =>
        await context.Courses
            .Include(c => c.Teacher)
            .FirstOrDefaultAsync(c => c.Id == id);
}