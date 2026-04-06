using Domain.Entities;
namespace Application.Interfaces.Repositories;

public interface IClassmateRepository
{
    Task<IEnumerable<Student>> GetStudentsByCourseAsync(int courseId, int excludeStudentId);
}