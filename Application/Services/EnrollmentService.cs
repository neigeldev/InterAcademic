using Application.DTOs.Enrollment;
using Domain.Entities;
using Domain.Ports;
namespace Application.Services;

public class EnrollmentService(
    IEnrollmentRepository enrollmentRepository,
    IStudentRepository studentRepository,
    ICourseRepository courseRepository) : IEnrollmentService
{
    public async Task<EnrollmentResponse> EnrollAsync(EnrollmentRequest request)
    {
        // Verificar que el estudiante existe
        var student = await studentRepository.GetByIdAsync(request.StudentId)
            ?? throw new InvalidOperationException($"Student with id {request.StudentId} not found.");

        // Verificar que el curso existe
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new InvalidOperationException($"Course with id {request.CourseId} not found.");

        // Traer inscripciones actuales del estudiante
        var currentEnrollments = await enrollmentRepository.GetByStudentIdAsync(request.StudentId);
        var enrollmentList = currentEnrollments.ToList();

        // Regla 1: máximo 3 materias
        if (enrollmentList.Count >= 3)
            throw new InvalidOperationException("Student cannot enroll in more than 3 courses.");

        // Regla 2: no inscribirse dos veces al mismo curso
        var alreadyEnrolled = await enrollmentRepository.ExistsAsync(request.StudentId, request.CourseId);
        if (alreadyEnrolled)
            throw new InvalidOperationException("Student is already enrolled in this course.");

        // Regla 3: no puede tener dos materias con el mismo profesor
        var sameTeacher = enrollmentList.Any(e => e.Course.TeacherId == course.TeacherId);
        if (sameTeacher)
            throw new InvalidOperationException("Student already has a course with this teacher.");

        var enrollment = new Enrollment
        {
            StudentId = request.StudentId,
            CourseId = request.CourseId,
            EnrolledAt = DateTime.UtcNow
        };

        await enrollmentRepository.AddAsync(enrollment);

        return new EnrollmentResponse
        {
            StudentId = student.Id,
            StudentName = student.Name,
            CourseId = course.Id,
            CourseName = course.CourseName,
            TeacherName = course.Teacher.Name,
            Credits = course.Credits,
            EnrolledAt = enrollment.EnrolledAt
        };
    }

    public async Task<IEnumerable<EnrollmentResponse>> GetByStudentAsync(int studentId)
    {
        var student = await studentRepository.GetByIdAsync(studentId)
            ?? throw new InvalidOperationException($"Student with id {studentId} not found.");

        var enrollments = await enrollmentRepository.GetByStudentIdAsync(studentId);

        return enrollments.Select(e => new EnrollmentResponse
        {
            StudentId = student.Id,
            StudentName = student.Name,
            CourseId = e.Course.Id,
            CourseName = e.Course.CourseName,
            TeacherName = e.Course.Teacher.Name,
            Credits = e.Course.Credits,
            EnrolledAt = e.EnrolledAt
        });
    }

    public async Task UnenrollAsync(int studentId, int courseId)
    {
        var enrollment = await enrollmentRepository.GetAsync(studentId, courseId)
            ?? throw new InvalidOperationException("Enrollment not found.");

        await enrollmentRepository.DeleteAsync(enrollment);
    }
}