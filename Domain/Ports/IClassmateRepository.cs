using Domain.Entities;
namespace Domain.Ports;

public interface IClassmateRepository
{
    Task<IEnumerable<Student>> GetStudentsByCourseAsync(int courseId, int excludeStudentId);
}