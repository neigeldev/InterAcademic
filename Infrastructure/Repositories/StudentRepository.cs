using Domain.Entities;
using Domain.Ports;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    public async Task<Student?> GetByIdAsync(int id) =>
        await context.Students.FindAsync(id);

    public async Task<IEnumerable<Student>> GetAllAsync() =>
        await context.Students.ToListAsync();

    public async Task<bool> ExistsByEmailAsync(string email) =>
        await context.Students.AnyAsync(s => s.Email == email.ToLower());

    public async Task<Student?> GetByEmailAsync(string email) =>
    await context.Students
        .FirstOrDefaultAsync(s => s.Email == email.ToLower());

    public async Task AddAsync(Student student)
    {
        await context.Students.AddAsync(student);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        context.Students.Update(student);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Student student)
    {
        context.Students.Remove(student);
        await context.SaveChangesAsync();
    }

}