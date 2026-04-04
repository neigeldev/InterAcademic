namespace Application.DTOs.Enrollment;

public class EnrollmentResponse
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!;
    public int CourseId { get; set; }
    public string CourseName { get; set; } = null!;
    public string TeacherName { get; set; } = null!;
    public int Credits { get; set; }
    public DateTime EnrolledAt { get; set; }
}