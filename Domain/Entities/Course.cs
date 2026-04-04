namespace Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public string CourseName { get; set; } = null!;
    public int Credits { get; set; }

    public Teacher Teacher { get; set; } = null!;
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}