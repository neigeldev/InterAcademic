using Domain.Entities;
namespace Domain.Ports;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(int id);
    Task<IEnumerable<Student>> GetAllAsync();
    Task<bool> ExistsByEmailAsync(string email);
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(Student student);
}