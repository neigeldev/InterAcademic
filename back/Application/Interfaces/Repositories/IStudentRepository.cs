using Domain.Entities;
namespace Application.Interfaces.Repositories;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(int id);
    Task<Student?> GetByEmailAsync(string email);
    Task<IEnumerable<Student>> GetAllAsync();
    Task<bool> ExistsByEmailAsync(string email);
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(Student student);
}