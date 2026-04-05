using Application.DTOs.Auth;
namespace Application.Services;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}