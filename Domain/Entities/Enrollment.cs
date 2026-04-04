namespace Domain.Entities;

public class Enrollment
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;
}