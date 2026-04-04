// Application/Services/IStudentService.cs
using Application.DTOs.Student;
namespace Application.Services;

public interface IStudentService
{
    Task<StudentResponse> CreateAsync(CreateStudentRequest request);
    Task<StudentResponse?> GetByIdAsync(int id);
    Task<IEnumerable<StudentResponse>> GetAllAsync();
    Task<StudentResponse> UpdateAsync(int id, UpdateStudentRequest request);
    Task DeleteAsync(int id);
}