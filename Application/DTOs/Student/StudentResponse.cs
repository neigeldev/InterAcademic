namespace Application.DTOs.Student;

public class StudentResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}