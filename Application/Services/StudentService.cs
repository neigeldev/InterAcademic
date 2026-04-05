using Application.DTOs.Student;
using Domain.Entities;
using Domain.Ports;
namespace Application.Services;

public class StudentService(IStudentRepository repository) : IStudentService
{
    public async Task<StudentResponse> CreateAsync(CreateStudentRequest request)
    {
        var exists = await repository.ExistsByEmailAsync(request.Email);
        if (exists)
            throw new InvalidOperationException($"A student with email '{request.Email}' already exists.");

        var student = new Student
        {
            name = request.Name.Trim(),
            email = request.Email.Trim().ToLower()
        };

        await repository.AddAsync(student);
        return ToResponse(student);
    }

    public async Task<StudentResponse?> GetByIdAsync(int id)
    {
        var student = await repository.GetByIdAsync(id);
        return student is null ? null : ToResponse(student);
    }

    public async Task<IEnumerable<StudentResponse>> GetAllAsync()
    {
        var students = await repository.GetAllAsync();
        return students.Select(ToResponse);
    }

    public async Task<StudentResponse> UpdateAsync(int id, UpdateStudentRequest request)
    {
        var student = await repository.GetByIdAsync(id)
            ?? throw new InvalidOperationException($"Student with id {id} not found.");

        student.name = request.Name.Trim();
        student.email = request.Email.Trim().ToLower();

        await repository.UpdateAsync(student);
        return ToResponse(student);
    }

    public async Task DeleteAsync(int id)
    {
        var student = await repository.GetByIdAsync(id)
            ?? throw new InvalidOperationException($"Student with id {id} not found.");

        await repository.DeleteAsync(student);
    }

    private static StudentResponse ToResponse(Student student) => new()
    {
        Id = student.pk_student_id,
        Name = student.name,
        Email = student.email
    };
}