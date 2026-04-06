namespace Application.DTOs.Course;

public class CourseResponse
{
    public int Id { get; set; }
    public string CourseName { get; set; } = null!;
    public int Credits { get; set; }
    public string TeacherName { get; set; } = null!;
}