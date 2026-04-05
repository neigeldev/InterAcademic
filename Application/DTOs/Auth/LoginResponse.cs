namespace Application.DTOs.Auth;

public class LoginResponse
{
    public string Token { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int StudentId { get; set; }
}