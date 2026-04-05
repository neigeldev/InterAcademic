// Application/Services/AuthService.cs
using Application.DTOs.Auth;
using Domain.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Application.Services;

public class AuthService(
    IStudentRepository repository,
    IConfiguration configuration) : IAuthService
{
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var student = await repository.GetByEmailAsync(request.Email)
            ?? throw new InvalidOperationException("Student not found.");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(double.Parse(configuration["Jwt:ExpiresInMinutes"]!));

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
            new Claim(ClaimTypes.Email,          student.Email),
            new Claim(ClaimTypes.Name,           student.Name)
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new LoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Name = student.Name,
            StudentId = student.Id
        };
    }
}