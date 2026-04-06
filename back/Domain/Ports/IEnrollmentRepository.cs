using Domain.Entities;
namespace Domain.Ports;

public interface IEnrollmentRepository
{
    Task<IEnumerable<Enrollment>> GetByStudentIdAsync(int studentId);
    Task<bool> ExistsAsync(int studentId, int courseId);
    Task AddAsync(Enrollment enrollment);
    Task DeleteAsync(Enrollment enrollment);
    Task<Enrollment?> GetAsync(int studentId, int courseId);
}