namespace Domain.Entities;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}