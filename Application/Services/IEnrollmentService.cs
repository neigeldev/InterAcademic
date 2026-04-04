using Application.DTOs.Enrollment;
namespace Application.Services;

public interface IEnrollmentService
{
    Task<EnrollmentResponse> EnrollAsync(EnrollmentRequest request);
    Task<IEnumerable<EnrollmentResponse>> GetByStudentAsync(int studentId);
    Task UnenrollAsync(int studentId, int courseId);
}